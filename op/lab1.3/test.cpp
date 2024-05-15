#include <iostream>
#include <fstream>
#include <algorithm>

int *exclude_max(const int *A, int size, int &new_size) {
    // Находим максимальный элемент в массиве A
    int max_element = *std::max_element(A, A + size);

    // Создаем выходной массив B
    int *B = new int[size];
    new_size = 0;

    // Проходим по массиву A и добавляем элементы в B, исключая максимальный элемент
    for (int i = 0; i < size; ++i) {
        if (A[i] != max_element)
            B[new_size++] = A[i];
    }

    return B;
}

int main() {
    std::ifstream input_file("/home/grigorijtomczuk/Desktop/suai/op/lab1.3/input.txt");
    std::ofstream output_file("/home/grigorijtomczuk/Desktop/suai/op/lab1.3/output.txt");

    if (!input_file.is_open() || !output_file.is_open()) {
        std::cerr << "Ошибка открытия файлов!" << std::endl;
        return 1;
    }

    int n;
    input_file >> n; // Читаем размерность массива

    int *A = new int[n];

    // Считываем элементы массива A из файла
    for (int i = 0; i < n; ++i) {
        input_file >> A[i];
    }

    int new_size;
    // Получаем выходной массив, исключая максимальный элемент
    int *B = exclude_max(A, n, new_size);

    // Записываем размерность и элементы выходного массива в файл
    output_file << new_size << std::endl;
    for (int i = 0; i < new_size; ++i) {
        output_file << B[i] << " ";
    }

    // Освобождаем память
    delete[] A;
    delete[] B;

    // Закрываем файлы
    input_file.close();
    output_file.close();

    return 0;
}
