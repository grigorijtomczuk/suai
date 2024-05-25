#include <iostream>
#include <vector>
#include <unordered_map>
#include <unordered_set>
#include <algorithm>

std::vector<std::string> splitWords(const std::string &s) {
    std::vector<std::string> words;
    std::string word;
    for (char ch : s) {
        if (ch == ' ' || ch == ',' || ch == '\n') {
            if (!word.empty()) {
                words.push_back(word);
                word.clear();
            }
        } else {
            word += ch;
        }
    }
    if (!word.empty()) {
        words.push_back(word);
    }
    return words;
}

std::vector<int> findIndices(const std::string &s, const std::string &word) {
    std::vector<int> indices;
    size_t pos = s.find(word, 0);
    while (pos != std::string::npos) {
        indices.push_back(static_cast<int>(pos));
        pos = s.find(word, pos + 1);
    }
    return indices;
}

std::string toLower(const std::string &s) {
    std::string lower = s;
    std::transform(lower.begin(), lower.end(), lower.begin(), ::tolower);
    return lower;
}

int main() {
    std::string S1 = "Get now to get first";
    std::string S2 = "I will get back to you";

    std::unordered_map<std::string, std::vector<int>> wordIndicesS1;
    std::unordered_map<std::string, std::vector<int>> wordIndicesS2;

    std::vector<std::string> wordsS1 = splitWords(S1);
    std::vector<std::string> wordsS2 = splitWords(S2);

    for (const std::string &word : wordsS1) {
        std::string lowerWord = toLower(word);
        wordIndicesS1[lowerWord] = findIndices(toLower(S1), lowerWord);
    }

    for (const std::string &word : wordsS2) {
        std::string lowerWord = toLower(word);
        wordIndicesS2[lowerWord] = findIndices(toLower(S2), lowerWord);
    }

    std::unordered_set<std::string> commonWords;
    for (const auto &pair : wordIndicesS1) {
        if (wordIndicesS2.find(pair.first) != wordIndicesS2.end()) {
            commonWords.insert(pair.first);
        }
    }

    for (const std::string &word : commonWords) {
        std::cout << "\"" << word << "\": ";
        std::cout << "[";
        for (int index : wordIndicesS1[word]) {
            std::cout << index;
            if (index < wordIndicesS1.size() - 1) std::cout << ", ";
        }
        std::cout << "], [";
        for (int index : wordIndicesS2[word]) {
            std::cout << index;
            if (index < wordIndicesS2.size() - 1) std::cout << ", ";
        }
        std::cout << "]" << std::endl;
    }

    return 0;
}
