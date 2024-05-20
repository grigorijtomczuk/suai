#include <iostream>
#include <string>
#include <vector>

std::vector<int> find_occurrences(const std::string &A, const std::string &B) {
    std::vector<int> occurrences;
    size_t pos = B.find(A); // находим первое вхождение

    while (pos != std::string::npos) {
        occurrences.push_back(pos); // добавляем индекс в вектор
        pos = B.find(A, pos + 1); // ищем следующее вхождение, начиная с позиции pos + 1
    }

    return occurrences;
}

int main() {
    std::string A;
    std::string B;

    std::cout << "A: ";
    std::cin >> A;

    std::cout << "B: ";
    std::cin >> B;

    std::vector<int> occurrences = find_occurrences(A, B);

    for (int index : occurrences) {
        std::cout << index << " ";
    }

    return 0;
}
