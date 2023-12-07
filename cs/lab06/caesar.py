import string


def encode(text: str, shift: int) -> str:

	def shift_alphabet(alphabet):
		return alphabet[shift:] + alphabet[:shift]

	alphabets = (string.ascii_lowercase, string.ascii_uppercase, string.digits)

	shifted_alphabets = tuple(map(shift_alphabet, alphabets))
	joined_aphabets = ''.join(alphabets)
	joined_shifted_alphabets = ''.join(shifted_alphabets)
	table = str.maketrans(joined_aphabets, joined_shifted_alphabets)
	return text.translate(table)


def decode(text: str, shift: int) -> str:

	def shift_alphabet(alphabet):
		return alphabet[-shift:] + alphabet[:-shift]

	alphabets = (string.ascii_lowercase, string.ascii_uppercase, string.digits)

	shifted_alphabets = tuple(map(shift_alphabet, alphabets))
	joined_aphabets = ''.join(alphabets)
	joined_shifted_alphabets = ''.join(shifted_alphabets)
	table = str.maketrans(joined_aphabets, joined_shifted_alphabets)
	return text.translate(table)
