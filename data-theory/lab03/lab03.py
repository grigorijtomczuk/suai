def lz78_encode(text):
    dictionary = {"": 0}
    dict_size = 1
    w = ""
    result = []

    for c in text:
        if w + c in dictionary:
            w = w + c
        else:
            result.append((dictionary[w], c))
            dictionary[w + c] = dict_size
            dict_size += 1
            w = ""

    if w != "":
        result.append((dictionary[w], None))

    return result


text = "Деидеологизировали-деидеологизировали, и додеидеологизировались"
encoded = lz78_encode(text)

for pair in encoded:
    print(pair)
