#include <iostream>
#include <fstream>
#include <vector>
#include <sstream>

void get_partial_permutations_with_debug(const std::vector<int> &A, std::vector<int> &current,
                                         std::vector<bool> &used, int depth, int K,
                                         std::vector<std::vector<int>> &result, int &call_count) {
    if (K > A.size()) {
        std::cout << "Ошибка: элементов меньше, чем K";
        exit(1);
    }

    int current_call_count = ++call_count;
    std::cout << "Вызов #" << current_call_count << ": depth=" << depth << ", current={ ";
    for (int i : current) std::cout << i << " ";
    std::cout << "}" << std::endl;

    // Базовый случай: прекращаем рекурсию
    if (depth == K + 1) {
        result.push_back(current);
        std::cout << "- Возврат из вызова #" << current_call_count << std::endl;
        return;
    }

    // Рекурсивный случай: продолжаем составление
    for (size_t i = 0; i < A.size(); ++i)
        if (!used[i]) {
            used[i] = true;
            current.push_back(A[i]);
            get_partial_permutations_with_debug(A, current, used, depth + 1, K, result, call_count);
            current.pop_back();
            used[i] = false;
        }

    std::cout << "- Возврат из вызова #" << current_call_count << std::endl;
    return;
}

void write_to_file(const std::string &filename, const std::vector<std::vector<int>> &permutations) {
    std::ofstream file(filename, std::ios::binary);
    if (!file) {
        std::cout << std::endl << "Ошибка открытия файла для записи";
        exit(1);
    }
    for (const auto &permutation : permutations)
        file.write(reinterpret_cast<const char *>(permutation.data()), permutation.size() * sizeof(int));
    file.close();
}

std::vector<std::vector<int>> read_from_file(const std::string &filename, int K) {
    std::ifstream file(filename, std::ios::binary);
    if (!file) {
        std::cout << std::endl << "Ошибка открытия файла для чтения";
        exit(1);
    }
    std::vector<std::vector<int>> permutations;
    std::vector<int> permutation(K);
    while (file.read(reinterpret_cast<char *>(permutation.data()), K * sizeof(int)))
        permutations.push_back(permutation);
    file.close();
    return permutations;
}

void print_permutations(const std::vector<std::vector<int>> &permutations) {
    for (const auto &permutation : permutations) {
        std::cout << "{ ";
        for (int item : permutation) std::cout << item << " ";
        std::cout << "}" << std::endl;
    }
}

int main() {
    // Ввод массива
    std::string input;
    std::vector<int> A;
    std::cout << "Массив: ";
    std::getline(std::cin >> std::ws, input);
    std::stringstream ss(input);
    std::string word;
    while (ss >> word) A.push_back(std::stoi(word));

    int K;
    std::cout << "K: ";
    std::cin >> K;

    std::vector<std::vector<int>> permutations;
    std::vector<int> current;
    std::vector<bool> used(A.size(), false);
    int call_count = 0;

    get_partial_permutations_with_debug(A, current, used, 1, K, permutations, call_count);

    // Запись размещений в файл
    std::cout << "Запись в файл permutations.bin...";
    std::string filename = "/home/grigorijtomczuk/Desktop/suai/op/lab3.2/permutations.bin";
    write_to_file(filename, permutations);
    std::cout << " ✔" << std::endl;

    // Чтение и вывод размещений из файла
    std::cout << "Чтение из файла permutations.bin...";
    std::vector<std::vector<int>> readPermutations = read_from_file(filename, K);
    std::cout << " ✔" << std::endl;
    print_permutations(readPermutations);

    // Глубина рекурсии для данной задачи всегда равна K+1
    std::cout << "Глубина: " << K + 1;

    return 0;
}
