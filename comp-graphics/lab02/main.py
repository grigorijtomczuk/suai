import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation

# Задание фигуры бумеранга
boomerang = np.array([
    [0, 0],  # Вершина 1
    [1, 0],  # Вершина 2
    [0.5, 1]  # Вершина 3
])


# Функция для создания матрицы поворота
def rotation_matrix(angle):
    return np.array([
        [np.cos(angle), -np.sin(angle)],
        [np.sin(angle), np.cos(angle)]
    ])


# Функция для вращения и перемещения бумеранга
def transform_boomerang(boomerang, angle, radius):
    # Вращение (умножение матрицы)
    rotated_boomerang = boomerang @ rotation_matrix(angle)

    # Перемещение по окружности
    cx = radius * np.cos(angle) # координаты центра окружности по оси X
    cy = radius * np.sin(angle) # # координаты центра окружности по оси Y

    # Сдвиг фигуры (сложение матриц)
    return rotated_boomerang + np.array([cx, cy])


# Настройки анимации
# figure - объект фигуры, представляет собой окно для графического отображения. В нем размещаются оси и другие элементы визуализации
# axes - объект осей внутри фигуры. Это область, где происходит построение графиков и анимаций, включая рисование объектов и управление их свойствами
figure, axes = plt.subplots()
axes.set_xlim(-2, 2)
axes.set_ylim(-2, 2)
line, = axes.plot([], [], lw=2) # объект линии контура бумеранга


# Функция обновления для анимации
def update(frame):
    angle = np.radians(frame)
    transformed_boomerang = transform_boomerang(boomerang, angle, radius=1)

    line.set_data(transformed_boomerang[:, 0], transformed_boomerang[:, 1])
    return line,


# Создание анимации
# anim - объект анимации, отвечает за обновление отображения на каждом кадре анимации и управляет ее динамическим поведением
anim = animation.FuncAnimation(figure, update, frames=range(0, 360), interval=50, blit=True)
plt.show()
