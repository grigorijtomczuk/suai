# 20. Написать программу для кодирования исходного текстового файла и его раскодированной записи в новый текстовый файл.

import os

import caesar


def encode_file(file_name: str, shift: int):
	try:
		with open(f"{file_name}.txt", "r") as file:
			lines = [line for line in file.readlines()]
			with open(f"{file_name}_encoded.txt", "w") as file_encoded:
				file_encoded.writelines((caesar.encode(line, shift) for line in lines))
	except:
		print("Что-то пошло не так...")
		return
	print("Файл успешно закодирован.")


def decode_file(file_name: str, shift: int):
	try:
		with open(f"{file_name}.txt", "r") as file:
			lines = [line for line in file.readlines()]
			with open(f"{file_name}_decoded.txt", "w") as file_decoded:
				file_decoded.writelines((caesar.decode(line, shift) for line in lines))
	except:
		print("Что-то пошло не так...")
		return
	print("Файл успешно декодирован.")


operation_map = {"1": "encode", "2": "decode"}
operation = None

while not operation:
	try:
		operation = operation_map[input("Введите тип операции (1 - закодировать, 2 - раскодировать): ")]
	except KeyError:
		print("Введите существующий номер опции!")

while True:
	file_name = input("Введите название текстового файла: ")
	if not os.path.isfile(f"{file_name}.txt"):
		print("Введите имя существующего файла!")
	else:
		break

shift = None

while not shift:
	try:
		shift = int(input("Введите число - сдвиг алфавита: "))
	except ValueError:
		print("Введите целое число!")

match operation:
	case "encode":
		encode_file(file_name, shift)
	case "decode":
		decode_file(file_name, shift)
	case _:
		raise Exception("Что-то пошло не так...")
