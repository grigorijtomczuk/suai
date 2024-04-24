// Реализовать функцию нахождения всех простых множителей числа A на экран таких,
// что в них нет цифры B в младшем разряде десятичной записи.

#include <iostream>
#include <vector>

std::vector<int> find_divisors(int A, int B) {
    std::vector<int> divisors;
    for (int i = 2; i < A; ++i) {
        bool is_prime = true;
        for (int j = 2; j < i; ++j)
            if (i % j == 0 && i != j) {
                is_prime = false;
                break;
            }
        if (is_prime && A % i == 0 && i % 10 != B) {
            divisors.push_back(i);
            A /= i;
        }
    }
    return divisors;
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
