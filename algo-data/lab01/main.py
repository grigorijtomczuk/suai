import time
import re


def read_file(file_path):
    """Считывает текст из файла."""
    with open(file_path, 'r', encoding='utf-8') as file:
        return file.read()


def clean_and_split_text(text):
    """Очищает текст от пунктуации и разбивает на слова."""
    text = re.sub(r'[^\w\s]', '', text)  # Убираем знаки пунктуации
    words = text.lower().split()
    return words


def sort_key(word):
    """Задаёт ключ для сортировки: буквы идут перед цифрами."""
    if word[0].isalpha():
        # Если первый символ буква, возвращаем (0, буква)
        return (0, word)
    elif word[0].isdigit():
        # Если первый символ цифра, возвращаем (1, цифра)
        return (1, word)
    else:
        # На случай, если слово начинается с чего-то ещё
        return (2, word)


def comb_sort(words):
    """Реализация сортировки расчёской с учётом ключа."""
    gap = len(words)
    shrink = 1.3  # Коэффициент уменьшения
    sorted = False

    while not sorted:
        gap = int(gap / shrink)
        if gap <= 1:
            gap = 1
            sorted = True

        for i in range(len(words) - gap):
            if sort_key(words[i]) > sort_key(words[i + gap]):
                words[i], words[i + gap] = words[i + gap], words[i]
                sorted = False
    return words


def analyze_text(words):
    """Анализ текста, частота по буквам."""
    analysis = {
        "total_words": len(words),
        "alphabet_counts": {},
    }

    for word in words:
        first_letter = word[0]
        if first_letter not in analysis["alphabet_counts"]:
            analysis["alphabet_counts"][first_letter] = 0
        analysis["alphabet_counts"][first_letter] += 1

    return analysis


def write_to_file(file_path, data):
    """Записывает данные в файл."""
    with open(file_path, 'w', encoding='utf-8') as file:
        file.write(data)


def main():
    input_file = input("Введите путь к исходному файлу: ")

    # Считываем текст
    original_text = read_file(input_file)

    # Очищаем и разбиваем текст
    words = clean_and_split_text(original_text)

    # Начинаем замер времени
    start_time = time.time()

    # Сортируем слова
    sorted_words = comb_sort(words)

    # Останавливаем таймер
    sort_time = time.time() - start_time

    # Анализируем текст
    analysis = analyze_text(sorted_words)

    word_count = analysis['total_words']
    output_file = f"result/result_{word_count}.txt"
    analysis_file = f"analysis/analysis_{word_count}.txt"

    # Записываем результаты
    write_to_file(output_file, "\n".join(sorted_words))

    analysis_data = (
            f"Исходный текст:\n{original_text}\n\n"
            f"Вариант 20:\nкириллица, по алфавиту, по возрастанию, учитывать числа, сортировка Расческой\n\n"
            f"Количество слов: {word_count}\n"
            f"Время выполнения сортировки: {sort_time:.6f} секунд\n"
            f"Частота по буквам:\n" +
            "\n".join([f"{letter}: {count}" for letter, count in analysis["alphabet_counts"].items()])
    )
    write_to_file(analysis_file, analysis_data)

    print("Сортировка завершена. Результаты сохранены.\n")
    print(analysis_data)


if __name__ == "__main__":
    main()
