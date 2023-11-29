def mult(matrix_a: list[list[int]], matrix_b: list[list[int]]) -> list[list[int]] | None:
	columns_a = len(matrix_a[0])
	rows_b = len(matrix_b)

	if columns_a != rows_b:
		print("Невозможно умножить матрицы (кол-во столбцов матрицы A не соответствует кол-ву строк матрицы B).")
		return
	else:
		matrix_c = [[0] * columns_a for _ in range(columns_a)]
		for row in range(rows_b):
			for column in range(columns_a):
				for element in range(len(matrix_b)):
					matrix_c[row][column] += matrix_a[row][element] * matrix_b[element][column]

		return matrix_c
