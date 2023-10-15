input_number = None

while not input_number:
	try:
		input_number = int(input("Введите число N: "))
		if input_number == 0: break
	except ValueError:
		print("Пожалуйста, введите целое число.")

exponent = 1

# Увеличиваем показатель степени на 1, пока число 2 в степени не превысит число N
while 2**exponent < input_number:
	exponent += 1

# Проверяем, не ближе ли к числу N число 2 в степени, меньшей на единицу (меньше N)
if input_number - 2**(exponent - 1) < 2**exponent - input_number:
	exponent -= 1

print(f"Cтепень: {exponent}, два в степени: {2**exponent}")
