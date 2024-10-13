import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d.art3d import Poly3DCollection

# Вершины икосаэдра
phi = (1 + np.sqrt(5)) / 2  # ≈ 1.618 — золотая пропорция. Используется для описания правильных многогранников, таких как икосаэдр
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
    n = np.array([A, B, C])  # Нормальный вектор плоскости, относительно которой происходит отражение
    n = n / np.linalg.norm(n)  # Нормализуем нормальный вектор
    reflection_matrix = np.eye(3) - 2 * np.outer(n, n)

    # Преобразуем вершины
    transformed_vertices = np.dot(vertices, reflection_matrix.T)
    return transformed_vertices


# Пример: отражение фигуры относительно плоскости 4x + 2y + 3z - 7 = 0
# Применяем отражение
transformed_vertices_centered = reflection(vertices, 4, 2, 3, -7)

center = np.array([5, 5, 5])  # Центр икосаэдра (координаты, относительно которых будем его смещать)

# Смещаем фигуру от центра координат
transformed_vertices = transformed_vertices_centered + center

# Рисуем трансформированную фигуру
fig = plt.figure()  # Пространство, на котором будет рисоваться график
ax = fig.add_subplot(111, projection='3d')  # Объект осей, на которых рисуется график
ax.add_collection3d(Poly3DCollection([transformed_vertices[face] for face in faces], alpha=0.5, edgecolor='b'))

ax.set_xlabel('x')
ax.set_ylabel('y')
ax.set_zlabel('z')

plt.show()
