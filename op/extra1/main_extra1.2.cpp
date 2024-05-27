#include <iostream>
#include <vector>
#include <climits>

struct Bacteria {
    bool alive;
};

const int N = 50;
const int K1 = 2;
const double p_plus = 1.0;
const double p_minus = 0.0;

std::vector<std::vector<Bacteria>> field(N, std::vector<Bacteria>(N, {false}));

bool is_filled() {
    for (int i = 0; i < N; ++i)
        for (int j = 0; j < N; ++j)
            if (!field[i][j].alive) return false;
    return true;
}

void spread() {
    std::vector<std::pair<int, int>> new_bacteria;
    for (int i = 0; i < N; ++i) {
        for (int j = 0; j < N; ++j) {
            if (field[i][j].alive) {
                for (int delta_x = -1; delta_x <= 1; ++delta_x) {
                    for (int delta_y = -1; delta_y <= 1; ++delta_y) {
                        if (delta_x == 0 && delta_y == 0) continue;
                        int new_x = i + delta_x, new_y = j + delta_y;
                        if (new_x >= 0 && new_x < N && new_y >= 0 && new_y < N && !field[new_x][new_y].alive) {
                            if ((rand() % 100) < (p_plus * 100)) {
                                new_bacteria.push_back({new_x, new_y});
                            }
                        }
                    }
                }
            }
        }
    }
    // Заполнение поля новыми бактериями
    for (auto &position : new_bacteria)
        field[position.first][position.second].alive = true;
}

int simulate(std::vector<std::pair<int, int>> initial_positions) {
    for (auto &position : initial_positions)
        field[position.first][position.second].alive = true;
    int days_passed = 0;
    while (!is_filled()) {
        spread();
        days_passed++;
    }
    return days_passed;
}

std::vector<std::pair<int, int>> find_best_positions() {
    std::vector<std::pair<int, int>> best_positions;
    int min_days_passed = INT_MAX;

    // Генерация случайных начальных позиций
    for (int _ = 0; _ < 1000; _++) {
        std::vector<std::pair<int, int>> initial_positions;
        while (initial_positions.size() < K1) {
            int x = rand() % N;
            int y = rand() % N;
            initial_positions.push_back({x, y});
        }

        for (int x = 0; x < N; ++x)
            for (int y = 0; y < N; ++y)
                field[x][y].alive = false;

        int days_passed = simulate(initial_positions);
        if (days_passed < min_days_passed) {
            min_days_passed = days_passed;
            best_positions = initial_positions;
        }
    }

    return best_positions;
}

int main() {
    srand(time(nullptr));
    std::vector<std::pair<int, int>> best_positions = find_best_positions();
    std::cout
            << "Позиции поля изначальных бактерий, при которых поле будет заполнено максимально быстро:"
            << std::endl;
    for (auto &positions : best_positions)
        std::cout << "(" << positions.first << ", " << positions.second << ")" << std::endl;
    return 0;
}
