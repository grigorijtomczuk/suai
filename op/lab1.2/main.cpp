// Реализовать функцию нахождения всех простых множителей числа A на экран таких,
// что в них нет цифры B в младшем разряде десятичной записи.

#include <iostream>

bool is_whole(size_t number) {
    return floor(number) == number;
};

int *find_dividers(int A, int B) {
    static int dividers[100] = {};
    int i = 0;

    for (int divider = 0; divider < A; divider++) {
        size_t quotient = A % divider;
        if (is_whole(quotient)) {
            dividers[i] = quotient;
            i++;
        }
    }

    return dividers;
}

int main() {
    int A, B;

    std::cout << "A: ";
    std::cin >> A;

    std::cout << "B: ";
    std::cin >> B;

    int *result = find_dividers(A, B);

    for (int i = 0;; i++) {
        if (result[i] == 0) {
            break;
        }
        std::cout << result[i] << std::endl;
    }

    return 0;
}
