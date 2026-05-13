USE university_db;

-- добавление недостающих данных

/*INSERT INTO
  lab_rating (student_id, lab_id, score, submission_date)
VALUES
  (5, 1, 3, '2024-01-20');

INSERT INTO
  lab_rating (student_id, lab_id, score, submission_date)
VALUES
  (5, 3, 2, '2024-01-25');*/

/*INSERT INTO
  lab_rating (student_id, lab_id, score, submission_date)
VALUES
  (1, 4, 4, '2024-01-30');*/

/*
INSERT INTO student
  (last_name, first_name, middle_name, birth_date, group_id, email, phone)
VALUES
  ('Петров', 'Петр', 'Петрович-Младший', '2004-07-02', 1, 'petrovpetr@yandex.ru', NULL);
*/

-- ж) лабораторные по БД для досдачи студентом Тестовым из группы 4000
SELECT lw.lab_title
FROM lab_work lw
JOIN discipline d ON lw.discipline_id = d.discipline_id
WHERE d.discipline_name = 'Базы данных'
AND EXISTS (
  SELECT *
  FROM student s
  JOIN student_group sg ON s.group_id = sg.group_id
  WHERE s.last_name = 'Тестов'
    AND sg.group_name = '4000'
)
AND NOT EXISTS (
  SELECT *
  FROM lab_rating lr
  JOIN student s ON lr.student_id = s.student_id
  JOIN student_group sg ON s.group_id = sg.group_id
  WHERE s.last_name = 'Тестов'
    AND sg.group_name = '4000'
    AND lr.lab_id = lw.lab_id
);

-- з) студенты с одинаковыми оценками за все работы
SELECT
  s.student_id,
  s.last_name
FROM student s
WHERE
  EXISTS (
    SELECT *
    FROM lab_rating lr
    WHERE
      lr.student_id = s.student_id
  )
  AND NOT EXISTS (
    SELECT *
    FROM
      lab_rating lr1
      JOIN lab_rating lr2 ON lr1.student_id = lr2.student_id
    WHERE
      lr1.student_id = s.student_id
      AND lr1.score <> lr2.score
  );

-- и) студенты, сдавшие все работы по БД
SELECT
  s.student_id,
  s.last_name
FROM student s
WHERE
  NOT EXISTS (
    SELECT *
    FROM
      lab_work lw
      JOIN discipline d ON lw.discipline_id = d.discipline_id
    WHERE
      d.discipline_name = 'Базы данных'
      AND NOT EXISTS (
        SELECT *
        FROM lab_rating lr
        WHERE
          lr.student_id = s.student_id
          AND lr.lab_id = lw.lab_id
      )
  );

-- подзапрос в INSERT
INSERT INTO
  student (last_name, first_name, birth_date, group_id, email)
SELECT
  'Новиков', 'Андрей', '2002-05-10', group_id, 'novikov@mail.com'
FROM student_group
WHERE group_name = '4000';

-- подзапрос в UPDATE
UPDATE lab_rating
SET score = 5
WHERE
  student_id = (
    SELECT student_id
    FROM student
    WHERE last_name = 'Тестов'
    LIMIT 1
  );

-- подзапрос в DELETE
DELETE FROM lab_rating
WHERE
  student_id = (
    SELECT student_id
    FROM student
    WHERE last_name = 'Тестов'
  )
  AND score = 5
LIMIT 1;

-- INTERSECT, одинаковые почты у студентов и преподавателей (вернет строки с NULL значениями)
SELECT email
FROM student
INTERSECT
SELECT email
FROM teacher;

-- INTERSECT через EXISTS (не вернет строки с NULL значениями)
-- т. к. NULL = NULL => UNKNOWN
SELECT s.email
FROM student s
WHERE EXISTS (
    SELECT *
    FROM teacher t
    WHERE s.email = t.email
);

-- EXCEPT, почты студентов с исключением пересекающихся почт преподавателей (не вернет строки с NULL значениями)
SELECT email
FROM student
EXCEPT
SELECT email
FROM teacher;

-- EXCEPT через NOT EXISTS (вернет строки с NULL значениями)
SELECT s.email
FROM student s
WHERE NOT EXISTS (
    SELECT *
    FROM teacher t
    WHERE s.email = t.email
);
