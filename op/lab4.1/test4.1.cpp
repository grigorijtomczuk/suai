#include <iostream>
#include <string>
#include <vector>
#include <chrono>
#include <random>

std::vector<int> findOccurrences(const std::string &A, const std::string &B) {
    std::vector<int> occurrences;
    size_t pos = B.find(A); // находим первое вхождение

    while (pos != std::string::npos) {
        occurrences.push_back(pos); // добавляем индекс в вектор
        pos = B.find(A, pos + 1); // ищем следующее вхождение, начиная с позиции pos + 1
    }

    return occurrences;
}

std::string generateRandomString(size_t length) {
    const char charset[] = "abcdefghijklmnopqrstuvwxyz";
    std::default_random_engine generator;
    std::uniform_int_distribution<int> distribution(0, sizeof(charset) - 2);

    std::string randomString;
    for (size_t i = 0; i < length; ++i) {
        randomString += charset[distribution(generator)];
    }
    return randomString;
}

int main() {
    const int Test_Count = 1000;
    std::vector<int> sizes = {100, 1000, 10000, 100000}; // различные размерности входных данных

    for (int size : sizes) {
        std::string A = generateRandomString(5); // фиксированная длина подстроки A
        std::string B = generateRandomString(size); // изменяемая длина строки B

        auto total_duration = 0.0;

        for (int i = 0; i < Test_Count; ++i) {
            auto start = std::chrono::high_resolution_clock::now();
            findOccurrences(A, B);
            auto end = std::chrono::high_resolution_clock::now();
            std::chrono::duration<double> duration = end - start;
            total_duration += duration.count();
        }

        double average_duration = total_duration / Test_Count;
        std::cout << "Average time for B size " << size << " : " << average_duration << " seconds" << std::endl;
    }

    return 0;
}
