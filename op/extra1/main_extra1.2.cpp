#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>
#include <climits>

using namespace std;

const int N = 100; // Рекомендовано для отладки
const int K1 = 5; // Примерное значение
const double P_PLUS = 1.0;
const double P_MINUS = 0.0;

struct Bacteria {
    bool alive;
};

vector<vector<Bacteria>> field(N, vector<Bacteria>(N, {false}));

bool isFilled() {
    for (int i = 0; i < N; ++i)
        for (int j = 0; j < N; ++j)
            if (!field[i][j].alive) return false;
    return true;
}

void spreadBacteria(int day) {
    vector<pair<int, int>> newBacteria;
    for (int i = 0; i < N; ++i) {
        for (int j = 0; j < N; ++j) {
            if (field[i][j].alive) {
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
        field[pos.first][pos.second].alive = true;
    }
}

int simulate(vector<pair<int, int>> initialBacteria) {
    for (auto &pos : initialBacteria) {
        field[pos.first][pos.second].alive = true;
    }
    int day = 0;
    while (!isFilled()) {
        spreadBacteria(day);
        ++day;
    }
    return day;
}

vector<pair<int, int>> findOptimalPositions() {
    vector<pair<int, int>> bestPositions;
    int minDays = INT_MAX;

    // Генерация случайных начальных позиций
    for (int attempt = 0; attempt < 1000; ++attempt) { // Ограниченное количество попыток
        vector<pair<int, int>> initialBacteria;
        while (initialBacteria.size() < K1) {
            int x = rand() % N;
            int y = rand() % N;
            initialBacteria.push_back({x, y});
        }

        for (int x = 0; x < N; ++x) {
            for (int y = 0; y < N; ++y) {
                field[x][y].alive = false;
            }
        }

        int days = simulate(initialBacteria);
        if (days < minDays) {
            minDays = days;
            bestPositions = initialBacteria;
        }
    }

    return bestPositions;
}

int main() {
    srand(time(0));

    vector<pair<int, int>> bestPositions = findOptimalPositions();

    cout << "Optimal initial positions:" << endl;
    for (auto &pos : bestPositions) {
        cout << "(" << pos.first << ", " << pos.second << ")" << endl;
    }

    return 0;
}
