USE university_db;

-- изменение разделителя команд, чтобы знак ";" интерпретировался
-- как внутренняя часть процедуры
DELIMITER //

-- вставка студента с автодобавлением группы
CREATE PROCEDURE add_student(
  IN p_last VARCHAR(50),
  IN p_first VARCHAR(50),
  IN p_birth DATE,
  IN p_group_name VARCHAR(20),
  IN p_email VARCHAR(100)
)
BEGIN
  IF NOT EXISTS (SELECT 1 FROM student_group WHERE group_name = p_group_name) THEN
    INSERT INTO student_group(group_name, admission_year)
    VALUES (p_group_name, YEAR(CURDATE()));
  END IF;

  INSERT INTO student(last_name, first_name, birth_date, group_id, email)
  VALUES (
    p_last,
    p_first,
    p_birth,
    (SELECT group_id FROM student_group WHERE group_name = p_group_name LIMIT 1),
    p_email
  );
END //

DELIMITER ;

-- проверка вставки
CALL add_student('Давидов', 'Петр', '2002-05-10', '4111', 'davidov@mail.com');
SELECT s.last_name, sg.group_name FROM student s
JOIN student_group sg ON sg.group_id = s.group_id
WHERE s.last_name = 'Давидов';

DELIMITER //

-- удаление студента с очисткой справочника групп
CREATE PROCEDURE delete_student_cleanup(IN p_student_id INT)
BEGIN
  DECLARE g_id INT;

  SELECT group_id INTO g_id FROM student WHERE student_id = p_student_id;

  DELETE FROM student WHERE student_id = p_student_id;

  IF NOT EXISTS (SELECT 1 FROM student WHERE group_id = g_id) THEN
    DELETE FROM student_group WHERE group_id = g_id;
  END IF;
END //

DELIMITER ;

-- проверка удаления
CALL delete_student_cleanup((SELECT student_id FROM student s WHERE s.last_name = 'Давидов'));
SELECT * FROM student_group WHERE group_name = '4111';

DELIMITER //

-- каскадное удаление группы
CREATE PROCEDURE delete_group_cascade(IN p_group_id INT)
BEGIN
  DELETE FROM lab_rating
  WHERE student_id IN (SELECT student_id FROM student WHERE group_id = p_group_id);

  DELETE FROM student WHERE group_id = p_group_id;

  DELETE FROM student_group WHERE group_id = p_group_id;
END //

DELIMITER ;

-- проверка каскадного удаления
CALL add_student('Давидов', 'Петр', '2002-05-10', '4111', 'davidov@mail.com');
CALL delete_group_cascade((SELECT group_id FROM student_group sg
WHERE sg.group_name = '4111'));
SELECT * FROM student s
JOIN student_group sg ON sg.group_id = s.group_id
WHERE s.last_name = 'Давидов';

-- заполнение нулями отсутствующих оценок за работы (управляющие конструкции)
DROP PROCEDURE IF EXISTS recalc_student_status;
DELIMITER //
CREATE PROCEDURE recalc_student_status(IN p_student_id INT)
BEGIN
  DECLARE i INT DEFAULT 0;
  DECLARE lab_count INT;
  DECLARE v_lab_id INT;

  DROP TEMPORARY TABLE IF EXISTS tmp_labs;

  CREATE TEMPORARY TABLE tmp_labs AS
  SELECT lw.lab_id
  FROM lab_work lw
  JOIN discipline d ON lw.discipline_id = d.discipline_id
  WHERE d.discipline_name = 'Базы данных';

  SELECT COUNT(*) INTO lab_count FROM tmp_labs;

  WHILE i < lab_count DO

    SELECT tl.lab_id INTO v_lab_id
    FROM tmp_labs tl
    LIMIT 1 OFFSET i;

    IF v_lab_id IS NOT NULL THEN

      INSERT INTO lab_rating(student_id, lab_id, score, submission_date)
      SELECT p_student_id, v_lab_id, 0, CURDATE()
      WHERE NOT EXISTS (
        SELECT 1
        FROM lab_rating lr
        WHERE lr.student_id = p_student_id
          AND lr.lab_id = v_lab_id
      );

    END IF;

    SET i = i + 1;

  END WHILE;

END //

DELIMITER ;

-- проверка процедуры обхода лабораторных
CALL add_student('Давидов', 'Петр', '2002-05-10', '4111', 'davidov@mail.com');
CALL recalc_student_status((SELECT student_id FROM student s WHERE s.last_name = 'Давидов'));
SELECT * FROM lab_rating WHERE student_id = (
	SELECT student_id FROM student s WHERE s.last_name = 'Давидов'
	)

DELIMITER //

-- скалярная функция среднего балла
CREATE FUNCTION student_avg(p_student_id INT)
RETURNS DECIMAL(5,2)
DETERMINISTIC
BEGIN
  DECLARE res DECIMAL(5,2);

  SELECT AVG(score) INTO res
  FROM lab_rating
  WHERE student_id = p_student_id;

  RETURN res;
END //

DELIMITER ;

-- вызов скалярной функции
SELECT student_avg((SELECT student_id FROM student s WHERE s.last_name = 'Сыроежкин'));

-- табличное представление статистики студентов
CREATE VIEW student_stats AS
SELECT s.student_id, s.last_name, AVG(lr.score) AS avg_score
FROM student s
LEFT JOIN lab_rating lr ON s.student_id = lr.student_id
GROUP BY s.student_id, s.last_name;

-- проверка представления
SELECT * FROM student_stats;

DELIMITER //

-- формирование статистики по группам во временной таблице
CREATE PROCEDURE build_stats()
BEGIN
  DROP TEMPORARY TABLE IF EXISTS stats;

  CREATE TEMPORARY TABLE stats AS
  SELECT sg.group_name, COUNT(s.student_id) AS students_count
  FROM student_group sg
  LEFT JOIN student s ON sg.group_id = s.group_id
  GROUP BY sg.group_name;

  SELECT * FROM stats;
END //

DELIMITER ;

-- проверка статистики
CALL build_stats();
