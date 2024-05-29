#include <iostream>
#include <vector>
#include <set>
#include <string>
#include <sstream>
#include <chrono>
#include <random>
#include <iomanip>

using namespace std;
using namespace std::chrono;

// Функция для объединения навыков нескольких претендентов
set<string> unionSkills(const vector<set<string>> &skills, const vector<int> &indices) {
    set<string> result;
    for (int index : indices) {
        result.insert(skills[index].begin(), skills[index].end());
    }
    return result;
}

// Основная функция для решения задачи полного перебора
vector<int> findMinimumSetCover(const vector<set<string>> &skills, int M) {
    int N = skills.size();
    vector<int> bestSubset;
    int bestSize = N + 1;

    // Перебираем все возможные подмножества претендентов
    for (int i = 1; i < (1 << N); ++i) {
        vector<int> subset;
        for (int j = 0; j < N; ++j) {
            if (i & (1 << j)) {
                subset.push_back(j);
            }
        }

        // Проверяем, покрывают ли выбранные претенденты все навыки
        set<string> coveredSkills = unionSkills(skills, subset);
        if (coveredSkills.size() == M && subset.size() < bestSize) {
            bestSize = subset.size();
            bestSubset = subset;
        }
    }

    return bestSubset;
}

// Функция для генерации случайных данных
vector<set<string>> generateRandomSkills(int N, int M) {
    vector<set<string>> skills(N);
    vector<string> allSkills(M);

    for (int i = 0; i < M; ++i) {
        allSkills[i] = "skill" + to_string(i);
    }

    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<> dis(1, M);

    for (int i = 0; i < N; ++i) {
        int numSkills = dis(gen);
        for (int j = 0; j < numSkills; ++j) {
            skills[i].insert(allSkills[dis(gen) - 1]);
        }
    }

    return skills;
}

int main() {
    int Test_Count = 10; // Количество повторений для каждого теста
    vector<int> sizes = {5, 6, 7, 8, 16, 32}; // Размерности входных данных (количество претендентов)

    for (int size : sizes) {
        int N = size;
        int M = 10; // Количество уникальных навыков

        vector<duration<double>> durations;

        for (int i = 0; i < Test_Count; ++i) {
            vector<set<string>> skills = generateRandomSkills(N, M);

            auto start = high_resolution_clock::now();
            vector<int> result = findMinimumSetCover(skills, M);
            auto end = high_resolution_clock::now();

            durations.push_back(duration_cast<duration<double>>(end - start));
        }

        double totalDuration = 0;
        for (const auto &d : durations) {
            totalDuration += d.count();
        }

        double averageDuration = totalDuration / Test_Count;

        cout << "Среднее время для N = " << N << ": " << std::fixed << setprecision(10) << averageDuration
             << " секунд." << endl;
    }

    return 0;
}
