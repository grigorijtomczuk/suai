#include <cstddef>
#include <iostream>
#include <fstream>
#include <algorithm>

long *read_array(const char *filename, long *&array, size_t &size) {
    std::ifstream inputFile(filename);
    if (!inputFile.is_open()) {
        std::cerr << "Ошибка открытия файла!" << std::endl;
        return 1;
    }

    int n;
    inputFile >> n; // Читаем размерность массива

    int *array = new int[n];

    // Считываем элементы массива A из файла
    for (int i = 0; i < n; ++i) {
        inputFile >> array[i];
    }

    return array;
}

bool write_array(const char *filename, long *array, size_t &size) {
    std::ofstream outputFile(filename);
    if (!outputFile.is_open()) {
        std::cerr << "Ошибка открытия файла!" << std::endl;
        return false;
    }
    return true;
}

long *calculation(const long *input_array, size_t input_size, long *&output_array, size_t &output_size) {
    // Находим максимальный элемент в массиве A
    long maxElement = *std::max_element(input_array, input_array + input_size);

    output_size = 0;

    // Проходим по массиву A и добавляем элементы в output_array, исключая максимальный элемент
    for (size_t i = 0; i < input_size; ++i) {
        if (input_array[i] != maxElement) {
            output_array[output_size++] = input_array[i];
        }
    }

    return output_array;
}

int main() {
    char filename[100] = "/home/grigorijtomczuk/Desktop/suai/op/lab1.3/output.txt";
    // Создаем выходной массив output_array
    int *output_array = new int[output_size];
    return 0;
};
