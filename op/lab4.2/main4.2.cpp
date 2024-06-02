#include <iostream>
#include <vector>
#include <set>
#include <string>
#include <sstream>

// Функция для объединения навыков нескольких претендентов
std::set<std::string> unite_skills(const std::vector<std::set<std::string>> &skills, const std::vector<int> &indices) {
    std::set<std::string> result;
    for (int index : indices)
        result.insert(skills[index].begin(), skills[index].end());
    return result;
}

// Основная функция для решения задачи полного перебора
std::vector<int> find_min_set_cover(const std::vector<std::set<std::string>> &skills, int M) {
    int N = skills.size();
    std::vector<int> best_subset;
    int best_size = N + 1;

    // Перебираем все возможные подмножества претендентов
    for (int i = 1; i < (1 << N); ++i) {
        std::vector<int> subset;
        for (int j = 0; j < N; ++j)
            if (i & (1 << j)) subset.push_back(j);

        // Проверяем, покрывают ли выбранные претенденты все навыки
        std::set<std::string> covered_skills = unite_skills(skills, subset);
        if (covered_skills.size() == M && subset.size() < best_size) {
            best_size = subset.size();
            best_subset = subset;
        }
    }

    return best_subset;
}

int main() {
    int N;
    std::cout << "Введите количество претендентов: ";
    std::cin >> N;
    std::cin.ignore(); // Для игнорирования символа новой строки после ввода числа

    std::vector<std::set<std::string>> skills(N);
    std::set<std::string> all_skills;

    for (int i = 0; i < N; ++i) {
        std::cout << "Введите навыки претендента " << i + 1 << " через пробел: ";
        std::string line;
        getline(std::cin, line);
        std::stringstream ss(line);
        std::string skill;
        while (ss >> skill) {
            skills[i].insert(skill);
            all_skills.insert(skill);
        }
    }

    int M = all_skills.size(); // Количество уникальных навыков

    std::vector<int> result = find_min_set_cover(skills, M);

    std::cout << "Минимальное количество претендентов для покрытия всех навыков: " << result.size() << std::endl;
    std::cout << "Претенденты: ";
    for (int index : result) {
        std::cout << index + 1 << " ";
    }

    return 0;
}
