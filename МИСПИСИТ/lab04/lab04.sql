USE university_db;

-- добавление данных для корректных выборок
/*INSERT INTO
student (
last_name,
first_name,
birth_date,
group_id,
email
)
VALUES
(
'Тестов',
'Иван',
'2000-01-01',
1,
'test@mail.com'
);

INSERT INTO
lab_rating (student_id, lab_id, score, submission_date)
VALUES
(1, 1, 5, '2024-01-01');*/
-- г) количество работ по Базам данных для каждого студента
SELECT
  s.student_id,
  COUNT(*) AS work_count
FROM
  student s
  JOIN lab_rating lr ON s.student_id = lr.student_id
  JOIN lab_work lw ON lr.lab_id = lw.lab_id
  JOIN discipline d ON lw.discipline_id = d.discipline_id
WHERE
  d.discipline_name = 'Базы данных'
GROUP BY
  s.student_id;

-- д) студенты со средним рейтингом > 4
SELECT
  s.student_id,
  AVG(lr.score) AS avg_score
FROM
  student s
  JOIN lab_rating lr ON s.student_id = lr.student_id
  JOIN lab_work lw ON lr.lab_id = lw.lab_id
  JOIN discipline d ON lw.discipline_id = d.discipline_id
WHERE
  d.discipline_name = 'Базы данных'
GROUP BY
  s.student_id
HAVING
  AVG(lr.score) > 4;

-- е) студенты без работ по Базам данных
SELECT
  s.student_id
FROM
  student s
  LEFT JOIN lab_rating lr ON s.student_id = lr.student_id
  LEFT JOIN lab_work lw ON lr.lab_id = lw.lab_id
  LEFT JOIN discipline d ON lw.discipline_id = d.discipline_id
  AND d.discipline_name = 'Базы данных'
WHERE
  d.discipline_id IS NULL;

-- дополнительные агрегаты
SELECT
  MIN(score),
  MAX(score)
FROM
  lab_rating;

SELECT
  AVG(score)
FROM
  lab_rating;

-- UNION (без дублей)
SELECT
  student_id
FROM
  lab_rating
UNION
SELECT
  student_id
FROM
  student;

-- UNION ALL (с дублями)
SELECT
  student_id
FROM
  lab_rating
UNION ALL
SELECT
  student_id
FROM
  student;

-- INTERSECT
SELECT
  student_id
FROM
  student INTERSECT
SELECT
  student_id
FROM
  lab_rating;

-- EXCEPT
SELECT
  student_id
FROM
  student EXCEPT
SELECT
  student_id
FROM
  lab_rating;
