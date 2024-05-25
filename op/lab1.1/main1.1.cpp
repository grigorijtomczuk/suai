#include <iostream>
#include <cmath>
#include <windows.h>
#include <cstring>

struct Point2D {
    int x;
    int y;
};

int func(Point2D point, short a, short b, unsigned short R);

int invalid_input();

int main() {
    SetConsoleOutputCP(CP_UTF8);

    char point_str[32];
    short a, b;
    unsigned short R;

    std::cout << "x,y: ";
    std::cin >> point_str;

    char *ptr = strtok(point_str, ",");
    int x = strtol(ptr, nullptr, 10);
    ptr = strtok(nullptr, ",");
    int y = strtol(ptr, nullptr, 10);

    std::cout << "a: ";
    std::cin >> a;
    if (std::cin.fail()) {
        invalid_input();
    }

    std::cout << "b: ";
    std::cin >> b;
    if (std::cin.fail()) {
        invalid_input();
    }

    if (a <= b) {
        std::cerr << "Должно выполнятся условие: a > b" << std::endl;
        return 1;
    }

    std::cout << "R: ";
    std::cin >> R;
    if (std::cin.fail()) {
        invalid_input();
    }

    int result = func({x, y}, a, b, R);

    std::cout << "Область: " << result << std::endl;

    return 0;
}

int func(Point2D point, short a, short b, unsigned short R) {
    if (pow(point.x, 2) + pow(point.y, 2) > pow(R, 2)) {
        return 0;
    } else if (pow(point.x, 2) + pow(point.y, 2) < pow(R, 2)) {
        if (point.y > a) {
            return 1;
        }
        if (point.y < a && point.y > b) {
            return 2;
        }
        if (point.y < b) {
            return 3;
        }
    }
    std::cout << "Точка находится на одной из линий" << std::endl;
    exit(0);
}

int invalid_input() {
    std::cerr << "Введите целое число" << std::endl;
    exit(1);
}
