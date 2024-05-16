#include <iostream>
#include <cctype>
#include <cstring>

bool containsDigit(const char *word) {
    while (*word) {
        if (std::isdigit(*word)) {
            return true;
        }
        ++word;
    }
    return false;
}

void extractWordsWithDigits(const char *str, char **&result, int &resultCount) {
    resultCount = 0;
    int maxWords = 10; // Начальный размер массива слов
    result = new char *[maxWords];

    const char *start = str;
    const char *end;
    while (*start) {
        // Пропуск пробелов в начале
        while (*start && std::isspace(*start)) {
            ++start;
        }

        if (!*start) break;

        // Найти конец слова
        end = start;
        while (*end && !std::isspace(*end)) {
            ++end;
        }

        // Копирование слова в отдельный массив
        int length = end - start;
        char *word = new char[length + 1];
        std::strncpy(word, start, length);
        word[length] = '\0';

        // Проверка, содержит ли слово цифры
        if (containsDigit(word)) {
            if (resultCount >= maxWords) {
                // Увеличиваем размер массива
                maxWords *= 2;
                char **newResult = new char *[maxWords];
                for (int i = 0; i < resultCount; ++i) {
                    newResult[i] = result[i];
                }
                delete[] result;
                result = newResult;
            }
            result[resultCount++] = word;
        } else {
            delete[] word;
        }

        start = end;
    }
}

void freeWords(char **words, int count) {
    for (int i = 0; i < count; ++i) {
        delete[] words[i];
    }
    delete[] words;
}

int main() {
    const char *input = "К2у7 Smt g6 PH 4a";
    char **wordsWithDigits;
    int wordCount;

    extractWordsWithDigits(input, wordsWithDigits, wordCount);

    std::cout << "Слова, содержащие цифры: ";
    for (int i = 0; i < wordCount; ++i) {
        std::cout << "\"" << wordsWithDigits[i] << "\" ";
    }
    std::cout << std::endl;

    // Освобождаем память
    freeWords(wordsWithDigits, wordCount);

    return 0;
}
