# 20. Написать программу для кодирования исходного текстового файла и его раскодированной записи в новый текстовый файл.

import os
import shutil

import caesar


def encode_file():
	with open("example.txt", "r") as file:
		lines = [line for line in file.readlines()]
		with open("example_encoded.txt", "w") as file_encoded:
			file_encoded.writelines((caesar.encode(line, 3) for line in lines))


def decode_file():
	with open("example_encoded.txt", "r") as file:
		lines = [line for line in file.readlines()]
		with open("example_decoded.txt", "w") as file_encoded:
			file_encoded.writelines((caesar.decode(line, 3) for line in lines))


encode_file()
decode_file()
