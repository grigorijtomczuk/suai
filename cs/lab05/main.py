# 20. Задав две матрицы A[M, N] и B[N, M], реализуйте функцию, выполняющую умножение матриц для получения результирующей матрицы C[M, M]. Вывести результат на экран. Вычислить след полученной матрицы C и вывести его на экран.

from matrix_mult import mult
from matrix_trace import findTrace

while True:
	matrices = []

	for letter in ["A", "B"]:
		matrix = []
		row_num = None

		while True:
			try:
				row_num = int(input(f"Введите количество строк матрицы {letter}: "))
			except ValueError:
				print("Введите натуральное число!")
				continue
			if row_num <= 0:
				print("Введите натуральное число!")
			else:
				break

		while True:
			try:
				column_num = int(input(f"Введите количество столбцов матрицы {letter}: "))
			except ValueError:
				print("Введите натуральное число!")
				continue
			if column_num <= 0:
				print("Введите натуральное число!")
			else:
				break

		print(f"Введите построчно матрицу {letter}:")

		for _ in range(row_num):
			while True:
				try:
					row = list(map(int, input().split()))
				except ValueError:
					print("Введите полную строку!")
					continue
				if not row or (column_num and len(row) != column_num):
					print("Введите полную строку!")
				else:
					matrix.append(row)
					break

		matrices.append(matrix)

	matrix_a, matrix_b = matrices[0], matrices[1]
	matrix_c = mult(matrix_a, matrix_b)

	if matrix_c:
		print("Результат умножения матриц A и B:")
		for row in matrix_c:
			for num in row:
				print(num, end=" ")
			print()

		matrix_trace = findTrace(matrix_c)
		print(f"След полученной матрицы: {matrix_trace}")
