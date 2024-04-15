// найти все точки где z(x,y) равны
// вход - двумерный массив, выход - список

#include <iostream>
#include <vector>

int main() {
    const int arraySize = 3;
    int
            array[arraySize][3] = {{0, 0, 6},
                                   {2, 3, 6},
                                   {4, 2, 4}};

    // int groups[arraySize][arraySize][3];
    std::vector<std::vector<std::array<int, 3>>> groups;

    for (int i = 0; i < arraySize; i++) {
        if (array[i][2] == 6) {
            groups.push_back(std::vector<std::array<int, 3>>());
            // std::cout << groups[0][0][0];
            groups.back().push_back({array[i][0], array[i][1], array[i][2]});
            printf(groups[0][0][0])
        }
    };

    for (int i = 0; i < groups.size(); i++) {
        for (int j = 0; j < groups[i].size(); j++) {
            for (int k = 0; k < 3; k++) {
                // std::cout << groups[i][j][k] << ",";
            }
            std::cout << std::endl;
        }
        std::cout << std::endl;
    }

    return 0;
}
