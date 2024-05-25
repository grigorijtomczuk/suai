#include <iostream>
#include <vector>
#include <algorithm>

int reset_random_bits(int number, int k, std::vector<int> &positions) {
    // Считаем количество единичных битов в числе
    int one_bits_count = 0;
    for (int i = 0; i < 32; ++i)
        if (number & (1 << i))
            one_bits_count++;
    if (one_bits_count < k) {
        return 0; // Единичных битов недостаточно для обнуления
    }

    srand(time(nullptr)); // Установка начала последовательности чисел, генерируемой rand()

    // Обнуляем случайные биты
    while (k > 0) {
        int random_position = rand() % 32; // Генерация случайной позиции от 0 до 31
        if (number & (1 << random_position)) { // Проверка, является ли текущий бит единицей
            number &= ~(1 << random_position); // Обнуление текущего бита
            positions.push_back(random_position); // Сохранение позиции обнуленного бита
            k--;
        }
    }

    std::sort(positions.begin(), positions.end());

    return number;
}

int main() {
    int number;
    int k;

    std::cout << "Число: ";
    std::cin >> number;

    if (std::cin.fail()) {
        std::cerr << "Число слишком большое";
        return 1;
    }

    std::cout << "K: ";
    std::cin >> k;

    std::vector<int> positions;

    int result = reset_random_bits(number, k, positions);

    // Выводим отладочную информацию
    if (result == 0) {
        std::cout << 0;
    } else {
        std::cout << result << " = ";
        int bit_counter = 0;
        for (int i = 31; i >= 0; --i) {
            if (bit_counter == 4) {
                std::cout << " ";
                bit_counter = 0;
            }
            std::cout << ((result >> i) & 1);
            bit_counter++;
        }

        std::cout << std::endl;

        for (size_t i = 0; i < positions.size(); ++i) {
            std::cout << positions[i];
            if (i < positions.size() - 1) std::cout << ", ";
        }
    }

    return 0;
}
