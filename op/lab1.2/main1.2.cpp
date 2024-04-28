#include <iostream>
#include <cmath>
#include <set>

std::set<int> find_prime_factors(int A, int B) {
    std::set<int> factors;
    int mutated_A = A;
    int factor = 2;
    int sqrt_A = (int) sqrt(A);

    // Раскладываем число А на простые множители путем деления на простые числа, начиная с наименьших (2)
    while (factor <= sqrt_A) {
        if (mutated_A % factor == 0) {
            if (factor % 10 != B)
                factors.insert(factor);
            mutated_A /= factor;
        } else
            factor++;
    }

    // Если mutated_A больше 1, значит mutated_A - последний простой множитель А (больше корня из А, а больше одного множителя больше корня не может быть)
    if (mutated_A > 1 && mutated_A % 10 != B)
        factors.insert(mutated_A);

    return factors;
}

int main() {
    int A, B;

    std::cout << "A: ";
    std::cin >> A;

    std::cout << "B: ";
    std::cin >> B;

    std::set<int> result = find_prime_factors(A, B);

    for (int i : result) {
        std::cout << i << " ";
    }

    return 0;
}
