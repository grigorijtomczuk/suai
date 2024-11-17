import numpy as np
import matplotlib.pyplot as plt
from matplotlib.widgets import Button
from scipy.special import comb
from numpy.polynomial.polynomial import Polynomial


# Исходная функция
def f(x):
    return (1 / np.sqrt(2 * np.pi)) * np.exp(-x**2 / 2)


# Функция для вычисления стандартной кривой Безье
def bezier_curve(control_points, num_points=200):
    length = len(control_points) - 1  # Порядок полинома
    t = np.linspace(0, 1, num_points)  # Параметризация
    curve = np.zeros((num_points, 2))  # Координаты кривой
    for i, (x, y) in enumerate(control_points):
        bernstein_poly = comb(length, i) * (t ** i) * ((1 - t) ** (length - i))
        curve[:, 0] += bernstein_poly * x
        curve[:, 1] += bernstein_poly * y
    return curve[:, 0], curve[:, 1]


# Функция для построения полиномиальной кривой Безье
def polynomial_bezier_curve(control_points, num_points=200):
    x_points, y_points = control_points[:, 0], control_points[:, 1]

    # Строим полиномы для x(t) и y(t) через индексацию
    poly_x = Polynomial.fit(np.linspace(0, 1, len(x_points)), x_points, len(x_points) - 1)
    poly_y = Polynomial.fit(np.linspace(0, 1, len(y_points)), y_points, len(y_points) - 1)

    # Вычисляем значения кривой
    t = np.linspace(0, 1, num_points)
    curve_x = poly_x(t)
    curve_y = poly_y(t)

    return curve_x, curve_y


# Функция для вычисления ошибки восстановления
def calculate_error(original_y, interpolated_y):
    return np.sqrt(np.mean((original_y - interpolated_y) ** 2))


# Основной класс приложения
class BezierLab:
    def __init__(self, ax):
        self.ax = ax
        self.ax.set_title("Сплайновая кривая Безье")
        self.ax.set_xlabel("X")
        self.ax.set_ylabel("Y")
        self.ax.grid(True)

        # Исходные данные
        self.x_range = np.linspace(-1, 3, 1000)
        self.y_original = f(self.x_range)
        self.control_points = None

        # Инициализация кнопок
        ax_button1 = plt.axes([0.1, 0.01, 0.2, 0.05])
        ax_button2 = plt.axes([0.4, 0.01, 0.2, 0.05])
        ax_button3 = plt.axes([0.7, 0.01, 0.2, 0.05])
        self.btn1 = Button(ax_button1, 'f(x)')
        self.btn2 = Button(ax_button2, 'Кривая Безье')
        self.btn3 = Button(ax_button3, 'Полином Безье')

        self.btn1.on_clicked(self.plot_func)
        self.btn2.on_clicked(self.plot_bezier)
        self.btn3.on_clicked(self.plot_bezier_polynomial)

        self.reset_plot()

    def reset_plot(self):
        self.ax.clear()
        self.ax.grid(True)
        self.ax.set_title("Сплайновая кривая Безье")
        self.ax.set_xlabel("X")
        self.ax.set_ylabel("Y")

    def plot_func(self, event=None):
        self.reset_plot()
        self.ax.plot(self.x_range, self.y_original, label='Функция $f(x)$')
        self.control_points = self.get_control_points(24)
        self.ax.scatter(self.control_points[:, 0], self.control_points[:, 1], color='red', label='Опорные точки')
        self.ax.legend()
        plt.draw()

    def plot_bezier(self, event=None):
        self.reset_plot()
        self.plot_func()

        bezier_x, bezier_y = bezier_curve(self.control_points)
        self.ax.plot(bezier_x, bezier_y, label='Кривая Безье', color='green')
        self.ax.legend()

        error = calculate_error(self.y_original, np.interp(self.x_range, bezier_x, bezier_y))
        print(f"Ошибка восстановления (24 точки): {error:.6f}")
        plt.draw()

    def plot_bezier_polynomial(self, event=None):
        self.reset_plot()
        self.plot_func()

        # Кривая Безье на основе полинома 24-го порядка
        bezier_x, bezier_y = polynomial_bezier_curve(self.control_points)
        self.ax.plot(bezier_x, bezier_y, label='Полиномиальная кривая Безье', color='orange')
        self.ax.legend()

        error = calculate_error(self.y_original, np.interp(self.x_range, bezier_x, bezier_y))
        print(f"Ошибка восстановления для полинома: {error:.6f}")
        plt.draw()

    def get_control_points(self, n_points):
        x_points = np.linspace(-1, 3, n_points)
        y_points = f(x_points)
        return np.column_stack((x_points, y_points))


# Основной блок запуска программы
fig, ax = plt.subplots()
plt.subplots_adjust(bottom=0.15)
app = BezierLab(ax)
plt.show()
