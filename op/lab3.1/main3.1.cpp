#include <iostream>

int64_t calculate_recursion_with_debug(int a, int b, int x, int &call_count, int k = 0) {
    // Увеличиваем номер вызова и сохраняем значение
    int current_call_count = ++call_count;

    // Вычисляем текущие значения (a - k) и (b - k)
    int a_minus_k = (a - k < 1) ? 1 : (a - k);
    int b_minus_k = (b - k < 1) ? 1 : (b - k);

    // Вывод отладочной информации
    std::cout << "Вызов #" << current_call_count << ": k=" << k << ", a-k=" << a_minus_k << ", b-k="
              << b_minus_k << std::endl;

    // Базовый случай: прекращаем рекурсию
    if (a_minus_k == 1 && b_minus_k == 1) {
        int64_t result = a_minus_k * x + b_minus_k;
        std::cout << "Возврат из вызова #" << current_call_count << ": " << result << std::endl;
        return result;
    }

    // Рекурсивный случай: продолжаем умножение
    int64_t result = (a_minus_k * x + b_minus_k) * calculate_recursion_with_debug(a, b, x, call_count, k + 1);
    std::cout << "Возврат из вызова #" << current_call_count << ": " << result << std::endl;

    return result;
}

int main() {
    int a, b, x;

    std::cout << "a: ";
    std::cin >> a;

    std::cout << "b: ";
    std::cin >> b;

    std::cout << "x: ";
    std::cin >> x;

    int call_count = 0;

    int64_t result = calculate_recursion_with_debug(a, b, x, call_count);
    std::cout << "Результат: " << result << ", глубина: " << call_count;

    return 0;
}
