def findAbsoluteMax(arr: list[int]):
	max_num = 0
	max_num_i = 0

	for i, num in enumerate(arr):
		if abs(num) > abs(max_num):
			max_num = num
			max_num_i = i

	res = f"Максимальное по абсолютной величине число: {max_num}, индекс: {max_num_i}."

	return res
