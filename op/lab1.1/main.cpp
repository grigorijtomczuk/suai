#include <iostream>
#include <cmath>
#include <windows.h>

struct Point2D {
    short x;
    short y;
};

int func(Point2D point, short a, short b, unsigned short R);

int main() {
    SetConsoleOutputCP(CP_UTF8);

    short x, y, a, b;
    unsigned short R;

    std::cout << "x: ";
    std::cin >> x;

    std::cout << "y: ";
    std::cin >> y;

    std::cout << "a: ";
    std::cin >> a;

    std::cout << "b: ";
    std::cin >> b;

    std::cout << "R: ";
    std::cin >> R;

    if (std::cin.fail()) {
        std::cerr << "Введите целое число" << std::endl;
        return 1;
    }

    if (a < b) {
        std::cerr << "Должно выполнятся условие: a > b" << std::endl;
        return 1;
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
