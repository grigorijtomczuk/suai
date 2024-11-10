import numpy as np
import tkinter as tk
from tkinter import ttk
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
import matplotlib.pyplot as plt
from scipy.interpolate import lagrange


# Исходная функция
def func(x):
    return (1 / np.sqrt(2 * np.pi)) * np.exp(-x ** 2 / 2)


# Опорные точки
x_values = np.linspace(-1, 3, 24)
y_values = func(x_values)


# Функция Catmull-Rom для генерации точек интерполяции между двумя заданными точками
def catmull_rom_segment(p0, p1, p2, p3, num_points=50):
    t = np.linspace(0, 1, num_points)
    segment = []
    for tj in t:
        # Catmull-Rom формула для интерполяции
        x = 0.5 * (
                (2 * p1[0]) +
                (-p0[0] + p2[0]) * tj +
                (2 * p0[0] - 5 * p1[0] + 4 * p2[0] - p3[0]) * tj ** 2 +
                (-p0[0] + 3 * p1[0] - 3 * p2[0] + p3[0]) * tj ** 3
        )
        y = 0.5 * (
                (2 * p1[1]) +
                (-p0[1] + p2[1]) * tj +
                (2 * p0[1] - 5 * p1[1] + 4 * p2[1] - p3[1]) * tj ** 2 +
                (-p0[1] + 3 * p1[1] - 3 * p2[1] + p3[1]) * tj ** 3
        )
        segment.append([x, y])
    return np.array(segment)


# Основная функция для построения Catmull-Rom сплайна
def catmull_rom_spline(x_vals, y_vals, num_points=200):
    points = np.column_stack((x_vals, y_vals))
    spline_points = []

    # Генерация сегментов сплайна между всеми точками
    for i in range(1, len(points) - 2):
        p0, p1, p2, p3 = points[i - 1], points[i], points[i + 1], points[i + 2]
        segment = catmull_rom_segment(p0, p1, p2, p3, num_points // (len(points) - 3))
        spline_points.extend(segment)

    spline_points = np.array(spline_points)
    return spline_points[:, 0], spline_points[:, 1]


# Полиномиальная интерполяция Лагранжа
def lagrange_interpolation(x_vals, y_vals, x_dense):
    poly = lagrange(x_vals, y_vals)
    y_dense = poly(x_dense)
    return y_dense


# Функция для вычисления среднеквадратичной ошибки
def calculate_error(original_func, x_dense, y_dense):
    y_original = original_func(x_dense)
    return np.sqrt(np.mean((y_original - y_dense) ** 2))


# Создание интерфейса
class InterpolationApp:
    def __init__(self, root):
        self.root = root
        self.root.title("ЛР № 5")

        # Настройка matplotlib Figure
        self.figure, self.ax = plt.subplots(figsize=(8, 6))
        self.canvas = FigureCanvasTkAgg(self.figure, master=root)
        self.canvas.get_tk_widget().pack()

        # Таблица для координат
        self.table = ttk.Treeview(root, columns=("X", "Y"), show="headings")
        self.table.heading("X", text="X")
        self.table.heading("Y", text="Y")
        self.table.pack()

        # Кнопки
        button1 = tk.Button(root, text="Построить гармоническое колебание", command=self.plot_harmonic)
        button2 = tk.Button(root, text="Построить Catmull-Rom сплайн", command=self.plot_catmull_rom)
        button3 = tk.Button(root, text="Построить полиномиальную интерполяцию", command=self.plot_lagrange)
        button1.pack()
        button2.pack()
        button3.pack()

    # Функция для построения исходной функции
    def plot_harmonic(self):
        self.ax.clear()
        x_dense = np.linspace(-1, 3, 200)
        y_dense = func(x_dense)
        self.ax.plot(x_dense, y_dense, label="Гармоническое колебание")
        self.ax.plot(x_values, y_values, 'o', color="orange", label="Опорные точки")
        self.update_table(x_values, y_values)
        self.ax.legend()
        self.canvas.draw()

    # Функция для построения Catmull-Rom сплайна
    def plot_catmull_rom(self):
        self.ax.clear()
        x_dense = np.linspace(-1, 3, 200)
        y_dense = func(x_dense)
        self.ax.plot(x_dense, y_dense, label="Гармоническое колебание")
        self.ax.plot(x_values, y_values, 'o', color="orange", label="Опорные точки")

        x_spline, y_spline = catmull_rom_spline(x_values, y_values)
        error = calculate_error(func, x_spline, y_spline)
        self.ax.plot(x_spline, y_spline, 'r-', label=f"Catmull-Rom сплайн (E={error:.5f})")
        self.ax.legend()
        self.canvas.draw()

    # Функция для построения полиномиальной интерполяции Лагранжа
    def plot_lagrange(self):
        self.ax.clear()
        x_dense = np.linspace(-1, 3, 200)
        y_dense = func(x_dense)
        self.ax.plot(x_dense, y_dense, label="Гармоническое колебание")
        self.ax.plot(x_values, y_values, 'o', color="orange", label="Опорные точки")

        y_lagrange_dense = lagrange_interpolation(x_values, y_values, x_dense)
        error = calculate_error(func, x_dense, y_lagrange_dense)
        self.ax.plot(x_dense, y_lagrange_dense, 'g-', label=f"Полиномиальная интерполяция (E={error:.5f})")
        self.ax.legend()
        self.canvas.draw()

    # Обновление таблицы
    def update_table(self, x_vals, y_vals):
        for i in self.table.get_children():
            self.table.delete(i)
        for x, y in zip(x_vals, y_vals):
            self.table.insert("", "end", values=(f"{x:.2f}", f"{y:.5f}"))


# Запуск приложения
root = tk.Tk()
app = InterpolationApp(root)
root.mainloop()
