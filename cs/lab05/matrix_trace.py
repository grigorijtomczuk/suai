def findTrace(matrix: list[list[int]]):
	diag_sum = 0
	for i in range(len(matrix)):
		diag_sum += matrix[i][i]
	return diag_sum
