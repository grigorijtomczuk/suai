USE university_db;

-- таблица истории изменений student
DROP TABLE IF EXISTS student_audit;
CREATE TABLE student_audit (
  audit_id INT AUTO_INCREMENT PRIMARY KEY,
  student_id INT,
  old_last VARCHAR(50),
  new_last VARCHAR(50),
  old_group_id INT,
  new_group_id INT,
  action_type VARCHAR(20),
  changed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- AFTER INSERT триггер
DELIMITER //
CREATE TRIGGER trg_student_after_insert
AFTER INSERT ON student
FOR EACH ROW
BEGIN
  INSERT INTO student_audit(student_id, new_last, new_group_id, action_type)
  VALUES (NEW.student_id, NEW.last_name, NEW.group_id, 'INSERT');
END //
DELIMITER ;

-- AFTER UPDATE триггер
DELIMITER //
CREATE TRIGGER trg_student_after_update
AFTER UPDATE ON student
FOR EACH ROW
BEGIN
  INSERT INTO student_audit(student_id, old_last, new_last, old_group_id, new_group_id, action_type)
  VALUES (OLD.student_id, OLD.last_name, NEW.last_name, OLD.group_id, NEW.group_id, 'UPDATE');
END //
DELIMITER ;

-- AFTER DELETE триггер
DELIMITER //
CREATE TRIGGER trg_student_after_delete
AFTER DELETE ON student
FOR EACH ROW
BEGIN
  INSERT INTO student_audit(student_id, old_last, old_group_id, action_type)
  VALUES (OLD.student_id, OLD.last_name, OLD.group_id, 'DELETE');
END //
DELIMITER ;

-- контроль целостности: запрет пустого email (INSERT)
DROP TRIGGER IF EXISTS trg_student_email_check_insert;
DELIMITER //
CREATE TRIGGER trg_student_email_check_insert
BEFORE INSERT ON student
FOR EACH ROW
BEGIN
  IF NEW.email IS NULL THEN
    SET NEW.email = CONCAT(NEW.last_name, NEW.first_name, '@mail.ru');
  END IF;
END //
DELIMITER ;

-- контроль целостности: запрет пустого email (UPDATE)
DELIMITER //
CREATE TRIGGER trg_student_email_check_update
BEFORE UPDATE ON student
FOR EACH ROW
BEGIN
  IF NEW.email IS NULL THEN
    SET NEW.email = OLD.email;
  END IF;
END //
DELIMITER ;

-- контроль удаления: нельзя удалить единственного студента группы
DROP TRIGGER IF EXISTS trg_student_delete_restrict;
DELIMITER //
CREATE TRIGGER trg_student_delete_restrict
BEFORE DELETE ON student
FOR EACH ROW
BEGIN
  DECLARE cnt INT;

  SELECT COUNT(*) INTO cnt
  FROM student
  WHERE group_id = OLD.group_id;

  IF cnt = 1 THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'Нельзя удалить единственного студента группы';
  END IF;
END //
DELIMITER ;

-- тестовые данные для вызова триггеров
INSERT INTO student_group(group_id, group_name, admission_year)
VALUES (999, 4999, 2024);

-- DELETE FROM student WHERE group_id = 999;
INSERT INTO student(last_name, first_name, birth_date, group_id, email)
VALUES ('Триггеров', 'Иван', '2002-01-01', 999, NULL);

SELECT * FROM student WHERE last_name = 'Триггеров';

UPDATE student
SET last_name = 'Обновленный', email = NULL
WHERE last_name = 'Триггеров';
SELECT * FROM student WHERE last_name = 'Обновленный';

DELETE FROM student
WHERE last_name = 'Обновленный';

-- просмотр истории
SELECT * FROM student_audit;