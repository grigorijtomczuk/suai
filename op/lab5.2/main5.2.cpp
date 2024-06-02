#include <iostream>
#include <vector>
#include <bitset>
#include <sstream>

struct CodeWord {
    uint32_t word; // Кодовое слово, хранится в 32 битах
    int length; // Длина кодового слова в битах
};

std::vector<uint8_t> pack_code_words(const std::vector<CodeWord> &code_table, const std::vector<int> &sequence) {
    std::vector<uint8_t> result;
    uint32_t buffer = 0; // Буфер для накопления бит
    int bit_count = 0; // Количество бит в буфере

    for (int index : sequence) {
        // Проверка индекса
        if (index < 0 || index >= code_table.size()) {
            std::cerr << "Ошибка: в таблице отсутствует слово с индексом " << index;
            return {};
        }

        const CodeWord &code = code_table[index];

        // Добавляем кодовое слово в буфер
        buffer = (buffer << code.length) | code.word;
        bit_count += code.length;

        // Пока в буфере есть полный байт, выгружаем его в результат
        while (bit_count >= 8) {
            bit_count -= 8;
            result.push_back(buffer >> bit_count);
        }
    }

    // Если остались неиспользованные биты, добавляем их в результат
    if (bit_count > 0)
        result.push_back(buffer << (8 - bit_count));

    return result;
}

int main() {
    // Таблица кодовых слов
    std::vector<CodeWord> code_table = {
            {0b1110001000,      10},
            {0b11111110101,     11},
            {0b0000101,         7},
            {0b10101010,        8},
            {0b00110101,        8},
            {0b1011011,         7},
            {0b111100000011111, 15},
            {0b1,               1}
    };

    // Последовательность индексов кодовых слов
    std::vector<int> sequence;
    std::string input;
    std::cout << "M: ";
    std::getline(std::cin >> std::ws, input);
    std::stringstream ss(input);
    std::string index;
    while (ss >> index) sequence.push_back(std::stoi(index));

    // Получаем упакованную битовую последовательность
    std::vector<uint8_t> packed_bits = pack_code_words(code_table, sequence);
    if (packed_bits.empty()) return 1;

    // Выводим результат в виде битовых последовательностей по байтам
    for (uint8_t byte : packed_bits) {
        std::bitset<8> bits(byte);
        std::cout << bits << std::endl;
    }

    return 0;
}
