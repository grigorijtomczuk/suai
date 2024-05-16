#include <iostream>
#include <fstream>
#include <algorithm>

void read_array(const char *filename, long *&array, size_t &size) {
    std::ifstream input_file(filename);
    if (!input_file.is_open()) {
        std::cerr << "Ошибка открытия файла!" << std::endl;
        exit(1);
    }

    input_file >> size; // Читаем размерность массива

    array = new long[size];

    // Считываем элементы массива из файла
    for (size_t i = 0; i < size; i++)
        input_file >> array[i];

    input_file.close();
}

void write_array(const char *filename, long *array, size_t &size) {
    std::ofstream output_file(filename);
    if (!output_file.is_open()) {
        std::cerr << "Ошибка открытия файла!" << std::endl;
        exit(1);
    }

    // Записываем размерность и элементы выходного массива в файл
    output_file << size << std::endl;
    for (size_t i = 0; i < size; i++)
        output_file << array[i] << " ";

    output_file.close();
}

void exclude_max(const long *input_array, size_t input_array_size, long *&output_array, size_t &output_array_size) {
    // Находим максимальный элемент в массиве
    long max_element = *std::max_element(input_array, input_array + input_array_size);

    output_array = new long[input_array_size];
    output_array_size = 0;

    // Проходим по массиву и добавляем элементы в output_array, исключая максимальный элемент
    for (size_t i = 0; i < input_array_size; i++)
        if (input_array[i] != max_element)
            output_array[output_array_size++] = input_array[i];
}

int main() {
    char input_filename[100] = "/home/grigorijtomczuk/Desktop/suai/op/lab1.3/input.txt";
    char output_filename[100] = "/home/grigorijtomczuk/Desktop/suai/op/lab1.3/output.txt";

    long *input_array;
    size_t input_array_size;

    long *output_array;
    size_t output_array_size;

    read_array(input_filename, input_array, input_array_size);
    exclude_max(input_array, input_array_size, output_array, output_array_size);
    write_array(output_filename, output_array, output_array_size);

    delete[] input_array;
    delete[] output_array;

    return 0;
};
