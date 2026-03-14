-- Удаление БД если существует
DROP DATABASE IF EXISTS university_db;

-- Создание БД
CREATE DATABASE university_db
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE university_db;

-- Таблица групп
CREATE TABLE student_group (
    group_id INT AUTO_INCREMENT PRIMARY KEY,
    group_name VARCHAR(20) NOT NULL UNIQUE,
    admission_year YEAR NOT NULL,
    CHECK (admission_year >= 2000)
);

-- Таблица студентов
CREATE TABLE student (
    student_id INT AUTO_INCREMENT PRIMARY KEY,
    last_name VARCHAR(50) NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    middle_name VARCHAR(50),
    birth_date DATE NOT NULL,
    group_id INT NOT NULL,
    email VARCHAR(100) UNIQUE,
    CHECK (birth_date <= CURDATE()),
    FOREIGN KEY (group_id)
        REFERENCES student_group(group_id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
);

-- Таблица преподавателей
CREATE TABLE teacher (
    teacher_id INT AUTO_INCREMENT PRIMARY KEY,
    last_name VARCHAR(50) NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    middle_name VARCHAR(50),
    position VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE
);

-- Таблица дисциплин
CREATE TABLE discipline (
    discipline_id INT AUTO_INCREMENT PRIMARY KEY,
    discipline_name VARCHAR(100) NOT NULL UNIQUE,
    hours INT NOT NULL,
    CHECK (hours > 0)
);

-- Таблица лабораторных работ
CREATE TABLE lab_work (
    lab_id INT AUTO_INCREMENT PRIMARY KEY,
    discipline_id INT NOT NULL,
    teacher_id INT NOT NULL,
    lab_title VARCHAR(150) NOT NULL,
    max_score INT NOT NULL DEFAULT 100,
    CHECK (max_score > 0),
    FOREIGN KEY (discipline_id)
        REFERENCES discipline(discipline_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (teacher_id)
        REFERENCES teacher(teacher_id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
);

-- Таблица рейтингов (оценок за лабораторные)
CREATE TABLE lab_rating (
    rating_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    lab_id INT NOT NULL,
    score INT NOT NULL,
    submission_date DATE NOT NULL,
    CHECK (score >= 0),
    CHECK (submission_date <= CURDATE()),
    UNIQUE (student_id, lab_id),
    FOREIGN KEY (student_id)
        REFERENCES student(student_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (lab_id)
        REFERENCES lab_work(lab_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
