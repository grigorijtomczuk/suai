# 20.	Ввести строку и букву, вывести только слова, заканчивающиеся на заданную букву.

string = ""
letter = ""

# Проверка на ввод string
while True:
	string = input("Введите строку: ")
	# Valid, если строка непустая, не считая whitespace-симовлы
	if len(string.split()) == 0:
		print("Пожалуйста, введите непустую строку!")
	else:
		break

# Проверка на ввод letter
while True:
	letter = input("Введите букву: ")
	# Valid, если строка длиной в 1 символ, не считая whitespace-симовлы
	if len(letter) != 1 or len(letter.split()) == 0:
		print("Пожалуйста, введите один символ!")
	else:
		break

string_list = string.split()
res = []

for word in string_list:
	if word[-1] == letter:
		res.append(word)

print(*res)
