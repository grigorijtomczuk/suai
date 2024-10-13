import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d.art3d import Poly3DCollection

# Вершины икосаэдра
phi = (1 + np.sqrt(5)) / 2
vertices = np.array([
    [-1, phi, 0], [1, phi, 0], [-1, -phi, 0], [1, -phi, 0],
    [0, -1, phi], [0, 1, phi], [0, -1, -phi], [0, 1, -phi],
    [phi, 0, -1], [phi, 0, 1], [-phi, 0, -1], [-phi, 0, 1]
])

# Грани икосаэдра (связи между вершинами)
faces = [
    [0, 11, 5], [0, 5, 1], [0, 1, 7], [0, 7, 10], [0, 10, 11],
    [1, 5, 9], [5, 11, 4], [11, 10, 2], [10, 7, 6], [7, 1, 8],
    [3, 9, 4], [3, 4, 2], [3, 2, 6], [3, 6, 8], [3, 8, 9],
    [4, 9, 5], [2, 4, 11], [6, 2, 10], [8, 6, 7], [9, 8, 1]
]


# Функция отражения относительно произвольной плоскости
def reflection(vertices, A, B, C, D):
    # Матрица отражения относительно плоскости Ax + By + Cz + D = 0
    n = np.array([A, B, C])
    n = n / np.linalg.norm(n)  # Нормализуем нормальный вектор
    reflection_matrix = np.eye(3) - 2 * np.outer(n, n)

    # Преобразуем вершины
    transformed_vertices = np.dot(vertices, reflection_matrix.T)
    return transformed_vertices


# Пример: отражение относительно плоскости 2x + 3y + 4z - 10 = 0
transformed_vertices = reflection(vertices, 2, 3, 4, -10)

# Рисуем оригинальную и трансформированную фигуру
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')

# Оригинальный икосаэдр
ax.add_collection3d(Poly3DCollection([vertices[face] for face in faces], alpha=.25, edgecolor='r'))

# Трансформированный икосаэдр
ax.add_collection3d(Poly3DCollection([transformed_vertices[face] for face in faces], alpha=.25, edgecolor='b'))

ax.set_xlabel('X')
ax.set_ylabel('Y')
ax.set_zlabel('Z')

plt.show()
