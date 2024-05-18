#include <iostream>

bool contains_digit(const char *word) {
    while (*word) {
        if (std::isdigit(*word))
            return true;
        ++word;
    }
    return false;
}

void extract_words_with_digits(const char *input, char **&result, size_t &result_size) {
    size_t max_words = 8; // Начальный размер массива слов
    result = new char *[max_words];
    result_size = 0;

    const char *start = input;
    const char *end;

    while (*start) {
        // Пропуск пробелов в начале
        while (*start && std::isspace(*start))
            ++start;

        if (!*start) break;

        // Находим конец слова
        end = start;
        while (*end && !std::isspace(*end)) {
            ++end;
        }

        // Копирование слова в отдельный массив
        long length = end - start;
        char *word = new char[length + 1];
        for (size_t i = 0; i < length; ++i)
            word[i] = start[i];
        word[length] = '\0';

        // Проверка, содержит ли слово цифры
        if (contains_digit(word)) {
            if (result_size >= max_words) {
                // Увеличиваем размер массива
                max_words *= 2;
                char **new_result = new char *[max_words];
                for (size_t i = 0; i < result_size; ++i)
                    new_result[i] = result[i];
                delete[] result;
                result = new_result;
            }
            result[result_size++] = word;
        } else {
            delete[] word;
        }

        start = end;
    }
}

void free_words(char **words, size_t size) {
    for (size_t i = 0; i < size; ++i)
        delete[] words[i];
    delete[] words;
}

int main() {
    char input[256];
    std::cout << "Введите строку: ";
    std::cin.getline(input, 256);

    char **words_with_digits;
    size_t words_with_digits_size;

    extract_words_with_digits(input, words_with_digits, words_with_digits_size);

    for (size_t i = 0; i < words_with_digits_size; ++i)
        std::cout << "\"" << words_with_digits[i] << "\" ";

    // Освобождаем память
    free_words(words_with_digits, words_with_digits_size);

    return 0;
}
