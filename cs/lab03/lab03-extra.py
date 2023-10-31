# 20.	Ввести строку и букву, вывести только слова, заканчивающиеся на заданную букву.
# ДОП: Ввести строку и образец поиска, вывести только слова, заканчивающиеся на образец поиска

string = ""
sample = ""

# Проверка на ввод string
while True:
	string = input("Введите строку: ")
	# Valid, если строка непустая, не считая whitespace-симовлы
	if len(string.split()) == 0:
		print("Пожалуйста, введите непустую строку!")
	else:
		break

# Проверка на ввод sample
while True:
	sample = input("Введите образец: ")
	# Valid, если строку составляет одно слово, не считая whitespace-симовлы
	if len(sample.split()) != 1:
		print("Пожалуйста, введите одно слово!")
	else:
		break

string_list = string.split()
sample_length = len(sample)
res = []

for word in string_list:
	if word[-sample_length:] == sample:
		res.append(word)

print(*res)
