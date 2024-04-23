// Реализовать функцию нахождения всех простых множителей числа A на экран таких,
// что в них нет цифры B в младшем разряде десятичной записи.

#include <iostream>
#include <cmath>
#include <vector>

// bool is_prime(int number) {
//     static int divisors[100] = {};
//     int i = 0;
//
//     for (int divisor = 2; divisor <= sqrt(number); divisor++) {
//         int remainder = number % divisor;
//         if (remainder == 0) {
//             divisors[i] = divisor;
//             i++;
//         }
//     }
//
//     return divisors[0] == 0;
// };
//
// int *find_divisors(int A, int B) {
//     static int divisors[100] = {};
//     int i = 0;
//
//     for (int divisor = 2; divisor <= A; divisor++) {
//         int remainder = A % divisor;
//         if (remainder == 0 && is_prime(divisor)) {
//             divisors[i] = divisor;
//             i++;
//         }
//     }
//
//     return divisors;
// }

std::vector<int> find_divisors(int A, int B) {
    for (int i = 2; i < A; ++i) {
        int flag = 1;
        for (int j = 2; j < i; ++j)
            if (i % j == 0 && i != j) {
                flag = 0;
                break;
            }
        if (flag == 1 && A % i == 0) {
            std::cout << i << std::endl;
            A /= i;
        }
    }
}

int main() {
    int A, B;

    std::cout << "A: ";
    std::cin >> A;

    std::cout << "B: ";
    std::cin >> B;

    std::vector<int> result = find_divisors(A, B);

    for (int i = 0; i < result.size(); i++) {
        std::cout << result[i] << std::endl;
    }

    return 0;
}
