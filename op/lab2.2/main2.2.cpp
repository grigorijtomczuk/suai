#include <iostream>
#include <vector>
#include <unordered_map>
#include <unordered_set>
#include <algorithm>

std::vector<std::string> split_words(const std::string &string) {
    std::vector<std::string> words;
    std::string word;
    for (char character : string) {
        if (character == ' ' || character == ',' || character == '\n') {
            if (!word.empty()) {
                words.push_back(word);
                word.clear();
            }
        } else {
            word += character;
        }
    }
    if (!word.empty()) { // Добавляем последнее слово
        words.push_back(word);
    }
    return words;
}

std::vector<int> find_indices(const std::string &string, const std::string &word) {
    std::vector<int> indices;
    size_t position = string.find(word); // Находим первое вхождение
    while (position != std::string::npos) {
        char character = string[position + word.size()];
        // Проверяем окончание слова
        if (character == ' ' || character == ',' || character == '\n' || character == '\0')
            indices.push_back((int) position); // Добавляем индекс в вектор
        position = string.find(word, position + 1); // Ищем следующее вхождение, начиная с позиции position + 1
    }
    return indices;
}

std::string transform_to_lower(const std::string &string) {
    std::string lower = string;
    std::transform(lower.begin(), lower.end(), lower.begin(), ::tolower);
    return lower;
}

int main() {
    std::string S1;
    std::string S2;

    std::cout << "S1: ";
    std::getline(std::cin >> std::ws, S1);

    std::cout << "S2: ";
    std::getline(std::cin >> std::ws, S2);

    std::string lower_s1 = transform_to_lower(S1);
    std::string lower_s2 = transform_to_lower(S2);

    std::unordered_map<std::string, std::vector<int>> word_indices_s1;
    std::unordered_map<std::string, std::vector<int>> word_indices_s2;

    std::vector<std::string> words_s1 = split_words(S1);
    std::vector<std::string> words_s2 = split_words(S2);

    // Находим индексы
    for (const std::string &word : words_s1) {
        std::string lower_word = transform_to_lower(word);
        word_indices_s1[lower_word] = find_indices(lower_s1, lower_word);
    }
    for (const std::string &word : words_s2) {
        std::string lower_word = transform_to_lower(word);
        word_indices_s2[lower_word] = find_indices(lower_s2, lower_word);
    }

    // Находим общие слова
    std::unordered_set<std::string> common_words;
    for (const auto &pair : word_indices_s1) {
        if (word_indices_s2.find(pair.first) != word_indices_s2.end()) {
            common_words.insert(pair.first);
        }
    }

    // Выводим индексы вхождений
    for (const std::string &word : common_words) {
        std::vector<int> current_indices_s1 = word_indices_s1[word];
        std::vector<int> current_indices_s2 = word_indices_s2[word];

        std::cout << "\"" << word << "\": ";
        std::cout << "[";
        for (size_t i = 0; i < current_indices_s1.size(); i++) {
            std::cout << current_indices_s1[i];
            if (i < current_indices_s1.size() - 1) std::cout << ", ";
        }
        std::cout << "], [";
        for (size_t i = 0; i < current_indices_s2.size(); i++) {
            std::cout << current_indices_s2[i];
            if (i < current_indices_s2.size() - 1) std::cout << ", ";
        }
        std::cout << "]" << std::endl;
    }

    return 0;
}
