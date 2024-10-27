import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation

# Вершины куба
cube_vertices = np.array([
    [-1, -1, -1], [1, -1, -1],
    [1, 1, -1], [-1, 1, -1],
    [-1, -1, 1], [1, -1, 1],
    [1, 1, 1], [-1, 1, 1]
])

# Грани куба
cube_edges = [
    [cube_vertices[0], cube_vertices[1], cube_vertices[2], cube_vertices[3]],
    [cube_vertices[4], cube_vertices[5], cube_vertices[6], cube_vertices[7]],
    [cube_vertices[0], cube_vertices[1], cube_vertices[5], cube_vertices[4]],
    [cube_vertices[2], cube_vertices[3], cube_vertices[7], cube_vertices[6]],
    [cube_vertices[1], cube_vertices[2], cube_vertices[6], cube_vertices[5]],
    [cube_vertices[4], cube_vertices[7], cube_vertices[3], cube_vertices[0]],
    [cube_vertices[0], cube_vertices[4]]
]

# Ось вращения
rotation_axis_start = np.array([2, 2, 2])  # Начало оси вращения
rotation_axis_direction = np.array([1, 0, -1])  # Направление оси

# Матрица проекции для двухточечной перспективы
def perspective_projection_matrix(d=10):
    return np.array([
        [1, 0, 0, 0],
        [0, 1, 0, 0],
        [0, 0, 1, -1/d],
        [0, 0, 0.5/d, 1]
    ])

# Матрица вращения вокруг произвольной оси
def rotation_matrix(axis, theta):
    axis = axis / np.linalg.norm(axis)
    a = np.cos(theta / 2.0)
    b, c, d = -axis * np.sin(theta / 2.0)
    return np.array([
        [a*a + b*b - c*c - d*d, 2*(b*c + a*d), 2*(b*d - a*c), 0],
        [2*(b*c - a*d), a*a + c*c - b*b - d*d, 2*(c*d + a*b), 0],
        [2*(b*d + a*c), 2*(c*d - a*b), a*a + d*d - b*b - c*c, 0],
        [0, 0, 0, 1]
    ])

# Применение вращения и проекции
def transform(vertices, rotation, projection):
    rotated = np.dot(vertices, rotation[:3, :3].T)
    projected = np.dot(np.c_[rotated, np.ones(len(rotated))], projection.T)
    projected = projected / projected[:, -1:]  # Нормализация
    return projected[:, :2]

# Настройка графика
fig, ax = plt.subplots()
ax.set_aspect('equal')
ax.set_xlim(-9, 6)
ax.set_ylim(-9, 6)

# Функция для обновления анимации
def update(frame):
    ax.cla()  # Очистка текущего кадра
    ax.set_aspect('equal')
    ax.set_xlim(-9, 6)
    ax.set_ylim(-9, 6)

    # Вращение куба вокруг оси
    rotation = rotation_matrix(rotation_axis_direction, frame)
    shifted_vertices = cube_vertices + rotation_axis_start  # Смещение перед вращением
    rotated_vertices = np.dot(shifted_vertices, rotation[:3, :3].T)
    restored_vertices = rotated_vertices - rotation_axis_start  # Обратное смещение

    # Применение проекции
    projected_vertices = transform(restored_vertices, np.eye(4), perspective_projection_matrix())

    # Отрисовка куба
    for edge in cube_edges:
        edge_proj = [projected_vertices[cube_vertices.tolist().index(list(vertex))] for vertex in edge]
        ax.plot(*zip(*edge_proj), color='black')

# Создание анимации
ani = FuncAnimation(fig, update, frames=np.linspace(0, 2 * np.pi, 120), interval=50, repeat=True)
plt.show()
