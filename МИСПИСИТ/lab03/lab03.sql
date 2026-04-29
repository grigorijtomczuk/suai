USE university_db;

-- Дополнительные записи
/*INSERT INTO
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
'Иванов',
'Алексей',
NULL,
'2002-04-11',
1,
'ivanov@mail.com'
);
INSERT INTO
lab_rating (student_id, lab_id, score, submission_date)
VALUES
(3, 2, 3, '2024-01-16');*/
-- 1. Максимальный рейтинг за ЛР8 по дисциплине "Базы данных"
SELECT
  lw.max_score
FROM
  lab_work lw
  JOIN discipline d ON lw.discipline_id = d.discipline_id
WHERE
  lw.lab_title = 'ЛР8'
  AND d.discipline_name = 'Базы данных';

-- 2. Работы и рейтинги конкретного студента id = 1 (Сыроежкин)
SELECT
  d.discipline_name AS subject,
  lw.lab_title AS lab,
  lr.score AS rating
FROM
  lab_rating lr
  JOIN lab_work lw ON lr.lab_id = lw.lab_id
  JOIN discipline d ON lw.discipline_id = d.discipline_id
WHERE
  lr.student_id = 1;

-- 3. Дисциплины, у которых есть ЛР с одинаковыми названиями
SELECT DISTINCT
  lw1.lab_title,
  d1.discipline_name
FROM
  lab_work lw1
  JOIN discipline d1 ON lw1.discipline_id = d1.discipline_id
  JOIN lab_work lw2 ON lw1.lab_title = lw2.lab_title
  AND lw1.discipline_id <> lw2.discipline_id;

-- DISTINCT
-- Выбор уникальных фамилий студентов
SELECT DISTINCT
  last_name
FROM
  student;

-- ORDER BY
-- Список студентов, отсортированный по фамилии
SELECT
  student_id,
  last_name,
  first_name
FROM
  student
ORDER BY
  last_name ASC;

-- AS
-- Переименование столбца результата
SELECT
  last_name AS surname,
  first_name AS name
FROM
  student;

-- IN
-- Студенты, принадлежащие к указанным группам
SELECT
  *
FROM
  student
WHERE
  group_id IN (1, 2);

-- NOT IN
-- Студенты, не имеющие оценок
SELECT
  student_id,
  last_name
FROM
  student
WHERE
  student_id NOT IN (
    SELECT
      student_id
    FROM
      lab_rating
  );

-- BETWEEN
-- Оценки в диапазоне
SELECT
  *
FROM
  lab_rating
WHERE
  score BETWEEN 3 AND 5;

-- NOT BETWEEN
-- Оценки вне диапазона
SELECT
  *
FROM
  lab_rating
WHERE
  score NOT BETWEEN 4 AND 5;

-- IS NULL
-- Студенты без отчества
SELECT
  *
FROM
  student
WHERE
  middle_name IS NULL;

-- IS NOT NULL
-- Студенты с email
SELECT
  *
FROM
  student
WHERE
  email IS NOT NULL;

-- LIKE
-- Фамилии, начинающиеся на "С"
SELECT
  *
FROM
  student
WHERE
  last_name LIKE 'С%';

-- NOT LIKE
-- Исключение фамилий на "С"
SELECT
  *
FROM
  student
WHERE
  last_name NOT LIKE 'С%';
