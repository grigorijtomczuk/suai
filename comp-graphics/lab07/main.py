import tkinter as tk
from tkinter import filedialog
from PIL import Image, ImageTk
import numpy as np
import math


def load_image():
    file_path = filedialog.askopenfilename(filetypes=[("BMP files", "*.bmp")])
    if not file_path:
        return
    image = Image.open(file_path)
    image = image.resize((200, 200))  # Приводим все изображения к единому размеру
    display_image(image, original_canvas)

    # Углы для поворота
    angles = [2, 6, 10]

    # Преобразования
    affine_images = [rotate_affine(image, angle) for angle in angles]
    owen_makedon_images = [rotate_owen_makedon(image, angle) for angle in angles]

    # Отображение изображений
    display_images(affine_images, affine_canvases, affine_images_storage)
    display_images(owen_makedon_images, owen_canvases, owen_images_storage)


def display_image(image, canvas):
    canvas.image = ImageTk.PhotoImage(image)
    canvas.create_image(0, 0, anchor="nw", image=canvas.image)


def display_images(images, canvases, storage):
    for i, (img, canvas) in enumerate(zip(images, canvases)):
        img_tk = ImageTk.PhotoImage(img)
        storage[i] = img_tk  # Сохраняем ссылку на изображение
        canvas.create_image(0, 0, anchor="nw", image=img_tk)


def rotate_affine(image, angle):
    radians = math.radians(angle)
    cos_a, sin_a = math.cos(radians), math.sin(radians)
    affine_matrix = np.array([
        [cos_a, -sin_a, 0],
        [sin_a, cos_a, 0],
        [0, 0, 1]
    ])
    return apply_transformation(image, affine_matrix)


def rotate_owen_makedon(image, angle):
    radians = math.radians(angle)
    cos_a, sin_a = math.cos(radians), math.sin(radians)
    owen_matrix = np.array([
        [1, -sin_a, 0],
        [0, cos_a, 0],
        [0, 0, 1]
    ])
    makedon_matrix = np.array([
        [cos_a, 0, 0],
        [sin_a, 1, 0],
        [0, 0, 1]
    ])
    combined_matrix = np.dot(makedon_matrix, owen_matrix)
    return apply_transformation(image, combined_matrix)


def apply_transformation(image, matrix):
    width, height = image.size
    src_coords = np.array([[x, y, 1] for y in range(height) for x in range(width)])
    transformed_coords = np.dot(src_coords, matrix.T).astype(int)
    transformed_image = Image.new("RGB", (width, height))
    transformed_image_pixels = transformed_image.load()
    for (x, y, _), (tx, ty, _) in zip(src_coords, transformed_coords):
        if 0 <= tx < width and 0 <= ty < height:
            transformed_image_pixels[tx, ty] = image.getpixel((x, y))
    return transformed_image


# Интерфейс
root = tk.Tk()

original_label = tk.Label(root, text="Оригинальное изображение")
original_label.grid(row=0, column=0, pady=10)
original_canvas = tk.Canvas(root, width=200, height=200, bg="white")
original_canvas.grid(row=1, column=0, padx=10, pady=10)

affine_label = tk.Label(root, text="Аффинное преобразование")
affine_label.grid(row=0, column=1, pady=10)
affine_canvases = [tk.Canvas(root, width=200, height=200, bg="white") for _ in range(3)]
for i, canvas in enumerate(affine_canvases):
    canvas.grid(row=1, column=i + 1, padx=10, pady=10)

owen_label = tk.Label(root, text="Преобразование с матрицами Оуэна и Македона")
owen_label.grid(row=2, column=0, pady=10)
owen_canvases = [tk.Canvas(root, width=200, height=200, bg="white") for _ in range(3)]
for i, canvas in enumerate(owen_canvases):
    canvas.grid(row=3, column=i, padx=10, pady=10)

# Хранилище для изображений
affine_images_storage = [None] * 3
owen_images_storage = [None] * 3

load_button = tk.Button(root, text="Load Image", command=load_image)
load_button.grid(row=4, column=1, columnspan=2, pady=20)

root.mainloop()
