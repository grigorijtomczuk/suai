#include <iostream>
#include <vector>
#include <set>
#include <string>
#include <sstream>

using namespace std;

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

int main() {
    int N;
    cout << "Введите количество претендентов: ";
    cin >> N;
    cin.ignore(); // Для игнорирования символа новой строки после ввода числа

    vector<set<string>> skills(N);
    set<string> allSkills;

    for (int i = 0; i < N; ++i) {
        cout << "Введите навыки претендента " << i + 1 << " через пробел: ";
        string line;
        getline(cin, line);
        stringstream ss(line);
        string skill;
        while (ss >> skill) {
            skills[i].insert(skill);
            allSkills.insert(skill);
        }
    }

    int M = allSkills.size(); // Количество уникальных навыков

    vector<int> result = findMinimumSetCover(skills, M);

    cout << "Минимальное количество претендентов для покрытия всех навыков: " << result.size() << endl;
    cout << "Претенденты: ";
    for (int index : result) {
        cout << index + 1 << " ";
    }
    cout << endl;

    return 0;
}
