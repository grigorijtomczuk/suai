#include <iostream>
#include <vector>
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

void extractWordsWithDigits(const char *str, std::vector<std::string> &result) {
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
            result.push_back(word);
        }

        delete[] word;

        start = end;
    }
}

int main() {
    const char *input = "К2у7 Smt g6 PH 4a";
    std::vector<std::string> wordsWithDigits;

    extractWordsWithDigits(input, wordsWithDigits);

    std::cout << "Слова, содержащие цифры: ";
    for (const auto &word : wordsWithDigits) {
        std::cout << "\"" << word << "\" ";
    }
    std::cout << std::endl;

    return 0;
}
