def findAbsoluteMinMax(arr: list[int]):
	min_num = float("inf")
	min_num_i = 0

	max_num = 0
	max_num_i = 0

	for i, num in enumerate(arr):
		if abs(num) < abs(min_num):
			min_num = num
			min_num_i = i

		if abs(num) > abs(max_num):
			max_num = num
			max_num_i = i

	res = f"Максимальное по абсолютной величине число: {max_num}, индекс: {max_num_i}.\nМинимальное по абсолютной величине число: {min_num}, индекс: {min_num_i}."

	return res
