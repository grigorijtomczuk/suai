while True:
	input_number = None

	while not input_number:
		try:
			input_number = int(input("Введите число N: "))
			if input_number == 0: break
		except ValueError:
			print("Пожалуйста, введите целое число.")

	for base in range(10):
		exponent = 1

		# Исключение для 0 и 1
		if base == 0:
			if input_number >= 1: exponent = 0
			else: exponent = 1
			print(f"Число {str(base)} - ", end="")
			print(f"степень: {exponent}, число в степени: {base**exponent}")
			continue
		elif base == 1: pass
		else:
			# Увеличиваем показатель степени на 1, пока число base в степени не превысит число N
			while base**exponent < input_number:
				exponent += 1

		print(f"Число {str(base)} - ", end="")

		# Проверяем, не ближе ли к числу N число base в степени, меньшей на единицу (меньше N)
		if input_number - base**(exponent - 1) <= base**exponent - input_number:
			exponent -= 1

		print(f"степень: {exponent}, число в степени: {base**exponent}")
