#include <iostream>
#include <string>
#include <vector>
#include <chrono>
#include <random>
#include <iomanip>

std::vector<int> find_occurrences(const std::string &A, const std::string &B) {
    std::vector<int> occurrences;
    size_t pos = B.find(A); // находим первое вхождение

    while (pos != std::string::npos) {
        occurrences.push_back(pos); // добавляем индекс в вектор
        pos = B.find(A, pos + 1); // ищем следующее вхождение, начиная с позиции pos + 1
    }

    return occurrences;
}

std::string generate_random_string(size_t length) {
    const char charset[] = "abcdefghijklmnopqrstuvwxyz";
    std::default_random_engine generator;
    std::uniform_int_distribution<int> distribution(0, sizeof(charset) - 2);

    std::string random_string;
    for (size_t i = 0; i < length; ++i) {
        random_string += charset[distribution(generator)];
    }
    return random_string;
}

void test_find_occurrences() {
    const int test_count = 1000;
    std::vector<int> sizes = {10000, 100000, 1000000, 10000000};

    for (int size : sizes) {
        std::string A = generate_random_string(5);
        std::string B = generate_random_string(size);

        auto total_duration = 0.0;

        for (int i = 0; i < test_count; ++i) {
            auto start = std::chrono::high_resolution_clock::now();
            find_occurrences(A, B);
            auto end = std::chrono::high_resolution_clock::now();
            std::chrono::duration<double> duration = end - start;
            total_duration += duration.count();
        }

        double average_duration = total_duration / test_count;
        std::cout << "Среднее время выполнения при B=" << size << ": " << std::fixed << std::setprecision(12)
                  << average_duration << " с" << std::endl;
    }
}

int main() {
    test_find_occurrences();
    return 0;
}
