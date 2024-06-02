#include <iostream>
#include <vector>
#include <set>
#include <string>
#include <chrono>
#include <random>
#include <iomanip>

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

// Функция для генерации случайных данных
std::vector<std::set<std::string>> generate_random_skills(int N, int M) {
    std::vector<std::string> all_skills(M);
    std::vector<std::set<std::string>> skills(N);

    for (int i = 0; i < M; ++i)
        all_skills[i] = "skill" + std::to_string(i);

    std::random_device rd;
    std::mt19937 gen(rd());
    std::uniform_int_distribution<> skill_quantity_dist(1, M);
    std::uniform_int_distribution<> skill_index_dist(0, M - 1);

    for (int i = 0; i < N; ++i) {
        int skills_quantity = skill_quantity_dist(gen);
        for (int j = 0; j < skills_quantity; ++j)
            skills[i].insert(all_skills[skill_index_dist(gen)]);
    }

    return skills;
}

void test_find_min_set_cover() {
    const int test_count = 5;
    std::vector<int> sizes = {5, 6, 7, 8, 9, 10, 15,
                              20, 21, 22, 23, 24}; // Размерности входных данных (количество претендентов)

    for (int size : sizes) {
        int N = size;
        int M = 10; // Количество уникальных навыков

        double total_duration = 0.0;

        for (int i = 0; i < test_count; ++i) {
            std::vector<std::set<std::string>> skills = generate_random_skills(N, M);

            auto start = std::chrono::high_resolution_clock::now();
            std::vector<int> result = find_min_set_cover(skills, M);
            auto end = std::chrono::high_resolution_clock::now();

            std::chrono::duration<double> duration = end - start;
            total_duration += duration.count();
        }

        double average_duration = total_duration / test_count;
        std::cout << "Среднее время для N = " << N << ": " << std::fixed << std::setprecision(10) << average_duration
                  << " секунд." << std::endl;
    }
}

int main() {
    test_find_min_set_cover();
    return 0;
}
