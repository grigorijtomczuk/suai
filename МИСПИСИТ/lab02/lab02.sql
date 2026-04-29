USE university_db;

-- Восстановление базы в первоначальный вид
SET
  FOREIGN_KEY_CHECKS = 0;

TRUNCATE TABLE lab_rating;

TRUNCATE TABLE lab_work;

TRUNCATE TABLE student;

TRUNCATE TABLE teacher;

TRUNCATE TABLE discipline;

TRUNCATE TABLE student_group;

SET
  FOREIGN_KEY_CHECKS = 1;

ALTER TABLE student
DROP COLUMN phone;

-- Добавление групп
INSERT INTO
  student_group (group_name, admission_year)
VALUES
  ('4000', 2022),
  ('4001', 2023);

-- Добавление преподавателей
INSERT INTO
  teacher (
    last_name,
    first_name,
    middle_name,
    position,
    email
  )
VALUES
  ('Иванов', 'Иван', 'Иванович', 'Доцент', NULL),
  (
    'Петров',
    'Петр',
    NULL,
    'Профессор',
    'petrovpetr@yandex.ru'
  );

-- Добавление дисциплин
INSERT INTO
  discipline (discipline_name, hours)
VALUES
  ('Базы данных', 120),
  ('Программирование', 100);

-- Добавление студентов
INSERT INTO
  student (
    last_name,
    first_name,
    middle_name,
    birth_date,
    group_id,
    email
  )
VALUES
  (
    'Сыроежкин',
    'Сергей',
    'Иванович',
    '2003-05-10',
    1,
    'syroezhkin@mail.com'
  ),
  (
    'Иванов',
    'Алексей',
    NULL,
    '2002-03-15',
    1,
    'ivanov@mail.com'
  ),
  ('Петров', 'Дмитрий', NULL, '2001-09-20', 2, NULL);

-- Добавление работ
INSERT INTO
  lab_work (discipline_id, teacher_id, lab_title, max_score)
VALUES
  (1, 1, 'ЛР1', 5),
  (1, 1, 'ЛР8', 5),
  (2, 2, 'ЛР1', 5);

-- Добавление оценок
INSERT INTO
  lab_rating (student_id, lab_id, score, submission_date)
VALUES
  (1, 1, 2, '2024-01-10'),
  (1, 2, 4, '2024-01-15'),
  (2, 1, 3, '2024-01-11');

-- Пример некорректной вставки (ошибка FK)
INSERT INTO
  student (last_name, first_name, birth_date, group_id)
VALUES
  ('Test', 'Test', '2002-03-15', 999);

-- Пример некорректной вставки (ошибка CHECK)
INSERT INTO
  student (last_name, first_name, birth_date, group_id)
VALUES
  ('Test', 'Test', '1800-03-15', 1);

-- Исправление оценки за работу
UPDATE lab_rating
SET
  score = 5
WHERE
  student_id = 1
  AND lab_id = 1;

-- Каскадное удаление студента
DELETE FROM student
WHERE
  student_id = 2;

-- Добавление в student поля для номера телефона
ALTER TABLE student
ADD phone VARCHAR(20);

UPDATE student
SET
  phone = '+7-999-111-22-33'
WHERE
  student_id = 1;

UPDATE student
SET
  phone = '+7-999-222-33-44'
WHERE
  email = 'ivanov@mail.com';
