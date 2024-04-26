#include <iostream>
#include <vector>

bool is_prime(int number) {
    for (int divisor = 2; divisor < number; divisor++)
        if (number % divisor == 0) {
            return false;
        }
    return true;
}

std::vector<int> find_prime_divisors(int A, int B) {
    std::vector<int> divisors;
    for (int divisor = 2; divisor < A; divisor++) {
        // if (A % divisor == 0 && divisor % 10 != B && is_prime(divisor))
        if (A % divisor == 0 && divisor % 10 != B) {
            divisors.push_back(divisor);
            A /= divisor;
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

    std::vector<int> result = find_prime_divisors(A, B);

    for (int i : result) {
        std::cout << i << std::endl;
    }

    return 0;
}
