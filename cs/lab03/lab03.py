# 20.	Ввести строку и букву, вывести только слова, заканчивающиеся на заданную букву.

string = ""
letter = ""

# Проверка на ввод string
while True:
	string = input("Введите строку: ")
	if len(string.split()) == 0:  # Если строка непустая, кроме whitespace-симовлов
		print("Пожалуйста, введите непустую строку!")
	else:
		break

# Проверка на ввод letter
while True:
	letter = input("Введите букву: ")
	if len(letter) != 1 or letter in [" ", "\t"]:
		print("Пожалуйста, введите один символ!")
	else:
		break

string_list = string.split()
res = []

for word in string_list:
	if word[-1] == letter:
		res.append(word)

print(*res)
