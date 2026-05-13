USE university_db;

-- тестовые данные
INSERT INTO lab_rating(student_id, lab_id, score, submission_date)
SELECT 18, 1, 2, CURDATE()
WHERE NOT EXISTS (
  SELECT 1
  FROM lab_rating
  WHERE student_id = 18
    AND lab_id = 1
);

INSERT INTO lab_rating(student_id, lab_id, score, submission_date)
SELECT 18, 2, 0, CURDATE()
WHERE NOT EXISTS (
  SELECT 1
  FROM lab_rating
  WHERE student_id = 18
    AND lab_id = 2
);

UPDATE lab_rating
SET score = 2
WHERE score = 3;

DELIMITER //

-- курсор для обновления оценок
CREATE PROCEDURE fix_low_scores()
BEGIN
  DECLARE done INT DEFAULT 0;
  DECLARE v_rating_id INT;
  DECLARE v_score INT;

  DECLARE cur CURSOR FOR
  SELECT rating_id, score
  FROM lab_rating;

  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

  OPEN cur;

  read_loop: LOOP

    FETCH cur INTO v_rating_id, v_score;

    IF done THEN
      LEAVE read_loop;
    END IF;

    IF v_score < 3 THEN
      UPDATE lab_rating
      SET score = 3
      WHERE rating_id = v_rating_id;
    END IF;

  END LOOP;

  CLOSE cur;
END //

DELIMITER ;

-- запуск обновления
CALL fix_low_scores();

-- просмотр результата
SELECT * FROM lab_rating;

DELIMITER //

-- курсор для удаления нулевых оценок
CREATE PROCEDURE delete_zero_scores()
BEGIN
  DECLARE done INT DEFAULT 0;
  DECLARE v_rating_id INT;
  DECLARE v_score INT;

  DECLARE cur CURSOR FOR
  SELECT rating_id, score
  FROM lab_rating;

  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

  OPEN cur;

  delete_loop: LOOP

    FETCH cur INTO v_rating_id, v_score;

    IF done THEN
      LEAVE delete_loop;
    END IF;

    IF v_score = 0 THEN
      DELETE FROM lab_rating
      WHERE rating_id = v_rating_id;
    END IF;

  END LOOP;

  CLOSE cur;
END //

DELIMITER ;

INSERT INTO lab_rating
(student_id, lab_id, score, submission_date)
VALUES (22, 1, 0, '2026-01-10'),
	(22, 2, 0, '2026-01-10'),
	(22, 3, 0, '2026-01-10');

-- запуск удаления
CALL delete_zero_scores();

-- просмотр результата
SELECT * FROM lab_rating;
