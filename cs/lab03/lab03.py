# Запрещено использовать словари и множества
# Разрешается использовать только функции split, join, len, clear, copy и функции явного приведения типов
# Собственные функции использовать запрещено

# 20.	Ввести строку и букву, вывести только слова, заканчивающиеся на заданную букву.

# Hello black dog! It's been a while... How have you been?
# dog. fog? log! smog... rog wog

string = input("Введите строку: ")
letter = input("Введите букву: ")

string_list = list(string.split())
res = []

for word in string_list:
	if word[-1] == letter:
		res.append(word)

print(*res)
