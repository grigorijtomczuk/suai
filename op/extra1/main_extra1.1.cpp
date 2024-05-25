#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>
#include <climits>
#include <queue>

using namespace std;

const int N = 100; // Рекомендовано для отладки
const int D = 7;
const int T = 14;
const int K1 = 1; // Примерное значение
const int K2 = 3; // Примерное значение
const double P_PLUS = 0.05;
const double P_MINUS = 0.02;

struct Bacteria {
    int dayBorn;
    bool alive;
};

vector<vector<Bacteria>> field(N, vector<Bacteria>(N, {0, false}));

bool isFilled() {
    for (int i = 0; i < N; ++i)
        for (int j = 0; j < N; ++j)
            if (!field[i][j].alive) return false;
    return true;
}

void addBacteria(int day) {
    int numBacteria = K1 + rand() % (K2 - K1 + 1);
    for (int i = 0; i < numBacteria; ++i) {
        int x = rand() % N;
        int y = rand() % N;
        if (!field[x][y].alive) {
            field[x][y] = {day, true};
        }
    }
    cout << "Day " << day << ": Added " << numBacteria << " bacteria." << endl;
}

void spreadBacteria(int day) {
    vector<pair<int, int>> newBacteria;
    for (int i = 0; i < N; ++i) {
        for (int j = 0; j < N; ++j) {
            if (field[i][j].alive && day - field[i][j].dayBorn < T) {
                for (int dx = -1; dx <= 1; ++dx) {
                    for (int dy = -1; dy <= 1; ++dy) {
                        if (dx == 0 && dy == 0) continue;
                        int nx = i + dx, ny = j + dy;
                        if (nx >= 0 && nx < N && ny >= 0 && ny < N && !field[nx][ny].alive) {
                            if ((rand() % 100) < (P_PLUS * 100)) {
                                newBacteria.push_back({nx, ny});
                            }
                        }
                    }
                }
            }
        }
    }
    for (auto &pos : newBacteria) {
        field[pos.first][pos.second] = {day, true};
    }
    cout << "Day " << day << ": Spread " << newBacteria.size() << " bacteria." << endl;
}

void killBacteria(int day) {
    int killed = 0;
    for (int i = 0; i < N; ++i) {
        for (int j = 0; j < N; ++j) {
            if (field[i][j].alive && day - field[i][j].dayBorn > T / 2) {
                if ((rand() % 100) < (P_MINUS * 100)) {
                    field[i][j].alive = false;
                    ++killed;
                }
            }
        }
    }
    cout << "Day " << day << ": Killed " << killed << " bacteria." << endl;
}

int simulate() {
    for (int i = 0; i < D; ++i) {
        addBacteria(i);
    }
    int day = D;
    while (!isFilled()) {
        spreadBacteria(day);
        killBacteria(day);
        ++day;
        if (day > 1000) { // Ограничение по числу дней для отладки
            cerr << "Превышено число дней. Возможна ошибка." << endl;
            return day;
        }
    }
    return day;
}

int main() {
    srand(time(0));

    int simulations = 1; // Количество симуляций для статистики
    int totalDays = 0, maxDays = 0, minDays = INT_MAX;

    for (int i = 0; i < simulations; ++i) {
        for (int x = 0; x < N; ++x) {
            for (int y = 0; y < N; ++y) {
                field[x][y] = {0, false};
            }
        }
        int days = simulate();
        if (days < 1000) {
            totalDays += days;
            maxDays = max(maxDays, days);
            minDays = min(minDays, days);
        } else {
            cout << "Симуляция " << i << " не завершена корректно." << endl;
        }
    }

    cout << "Среднее количество дней: " << totalDays / simulations << endl;
    cout << "Максимальное количество дней: " << maxDays << endl;
    cout << "Минимальное количество дней: " << minDays << endl;

    return 0;
}
