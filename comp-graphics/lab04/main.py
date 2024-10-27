import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation

# Вершины куба
cube_vertices = np.array([
    [-1, -1, -1], [1, -1, -1],  # Нижняя грань
    [1, 1, -1], [-1, 1, -1],    # Верхняя грань
    [-1, -1, 1], [1, -1, 1],     # Нижняя грань
    [1, 1, 1], [-1, 1, 1]       # Верхняя грань
])

# Грани куба определяются с помощью рёбер
cube_edges = [
    [cube_vertices[0], cube_vertices[1], cube_vertices[2], cube_vertices[3]],  # Нижняя грань
    [cube_vertices[4], cube_vertices[5], cube_vertices[6], cube_vertices[7]],  # Верхняя грань
    [cube_vertices[0], cube_vertices[1], cube_vertices[5], cube_vertices[4]],  # Боковая грань
    [cube_vertices[2], cube_vertices[3], cube_vertices[7], cube_vertices[6]],  # Боковая грань
    [cube_vertices[1], cube_vertices[2], cube_vertices[6], cube_vertices[5]],  # Боковая грань
    [cube_vertices[4], cube_vertices[7], cube_vertices[3], cube_vertices[0]],  # Боковая грань
    [cube_vertices[0], cube_vertices[4]]  # Дополнительное ребро
]

# Параметры оси вращения
rotation_axis_start = np.array([2, 2, 2])  # Начальная точка оси вращения
rotation_axis_direction = np.array([1, 0, -1])  # Направление оси вращения

# Матрица проекции для двухточечной перспективы
def perspective_projection_matrix(d=10):
    # Возвращает матрицу проекции для двухточечной перспективы
    return np.array([
        [1, 0, 0, 0],
        [0, 1, 0, 0],
        [0, 0, 1, -1/d],  # Удаление глубины
        [0, 0, 0.5/d, 1]  # Применение коэффициента перспективы
    ])

# Функция создания матрицы вращения вокруг произвольной оси
def rotation_matrix(axis, theta):
    # Нормализация оси вращения
    axis = axis / np.linalg.norm(axis)
    a = np.cos(theta / 2.0)
    b, c, d = -axis * np.sin(theta / 2.0)
    # Возвращает матрицу вращения
    return np.array([
        [a*a + b*b - c*c - d*d, 2*(b*c + a*d), 2*(b*d - a*c), 0],
        [2*(b*c - a*d), a*a + c*c - b*b - d*d, 2*(c*d + a*b), 0],
        [2*(b*d + a*c), 2*(c*d - a*b), a*a + d*d - b*b - c*c, 0],
        [0, 0, 0, 1]  # Четвертая строка и столбец для однородных координат
    ])

# Применение вращения и проекции
def transform(vertices, rotation, projection):
    # Вращение вершин куба
    rotated = np.dot(vertices, rotation[:3, :3].T)
    # Проекция на двумерную плоскость
    projected = np.dot(np.c_[rotated, np.ones(len(rotated))], projection.T)
    # Нормализация координат
    projected = projected / projected[:, -1:]
    return projected[:, :2]  # Возвращаем только x и y

# Настройка графика
fig, ax = plt.subplots()
ax.set_aspect('equal')  # Сохраняем пропорции
ax.set_xlim(-9, 6)  # Установка пределов по оси x
ax.set_ylim(-9, 6)  # Установка пределов по оси y

# Функция для обновления анимации
def update(frame):
    ax.cla()  # Очистка текущего кадра
    ax.set_aspect('equal')  # Сохранение пропорций
    ax.set_xlim(-9, 6)  # Пределы по оси x
    ax.set_ylim(-9, 6)  # Пределы по оси y

    # Создание матрицы вращения на основе текущего кадра
    rotation = rotation_matrix(rotation_axis_direction, frame)
    # Смещение вершин перед вращением
    shifted_vertices = cube_vertices + rotation_axis_start
    # Вращение смещенных вершин
    rotated_vertices = np.dot(shifted_vertices, rotation[:3, :3].T)
    # Обратное смещение для восстановления положения
    restored_vertices = rotated_vertices - rotation_axis_start

    # Применение проекции к восстановленным вершинам
    projected_vertices = transform(restored_vertices, np.eye(4), perspective_projection_matrix())

    # Отрисовка куба
    for edge in cube_edges:
        # Проекция и отрисовка каждого ребра куба
        edge_proj = [projected_vertices[cube_vertices.tolist().index(list(vertex))] for vertex in edge]
        ax.plot(*zip(*edge_proj), color='black')  # Рисование ребер в черном цвете

# Создание анимации
ani = FuncAnimation(fig, update, frames=np.linspace(0, 2 * np.pi, 120), interval=50, repeat=True)
plt.show()  # Отображение графика
