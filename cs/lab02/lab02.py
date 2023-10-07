num = None

while not num:
	try:
		num = int(input("Введите число N: "))
		if num == 0:
			break
	except ValueError:
		print("Пожалуйста, введите целое число.")

power2 = 0

while 2**power2 < num:
	power2 += 1

if 2**power2 - num <= num - 2**power2 // 2:
	print(f"Степень: {power2}, два в степени: {2**power2}")
else:
	print(f"Степень: {power2 // 2}, два в степени: {2**(power2 // 2)}")
