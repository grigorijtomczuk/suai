import numpy as np
import matplotlib.pyplot as plt


# Заданная функция: f(z) = z^5 - 1
def f(z): return z ** 5 - 1


# Производная заданной функции: f'(z) = 5z^4
def f_derivative(z): return 5 * z ** 4


# Метод Ньютона
def newton_fractal(x_min, x_max, y_min, y_max, width, height, iteration_max=100, tolerance=1e-6):
    # Задаём сетку значений на комплексной плоскости
    real = np.linspace(x_min, x_max, width)
    imaginary = np.linspace(y_min, y_max, height)
    X, Y = np.meshgrid(real, imaginary)
    Z = X + 1j * Y

    # Корни и цвета
    roots = np.array([1, np.exp(2j * np.pi / 5), np.exp(4j * np.pi / 5), np.exp(6j * np.pi / 5), np.exp(8j * np.pi / 5)])
    colors = np.array([[0, 0, 255], [0, 255, 0], [0, 255, 255], [255, 0, 0], [255, 0, 255]])

    # Инициализируем массив для хранения цветов
    image = np.zeros((height, width, 3), dtype=np.uint8)

    for i in range(iteration_max):
        # Вычисляем новое приближение
        Z -= f(Z) / f_derivative(Z)

        # Для каждого корня проверяем, близко ли текущее значение к нему
        for k, root in enumerate(roots):
            mask = np.abs(Z - root) < tolerance
            image[mask] = colors[k]

    return image


# Параметры фрактала
x_min, x_max, y_min, y_max = -3.5, 3.5, -3.5, 3.5
width, height = 800, 800
iteration_max = 50

# Генерация фрактала
fractal = newton_fractal(x_min, x_max, y_min, y_max, width, height, iteration_max)

# Отображаем фрактал
plt.imshow(fractal)
plt.axis('off')
plt.show()
