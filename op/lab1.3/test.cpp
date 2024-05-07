#include <iostream>
#include <fstream>
#include <algorithm>

int *excludeMax(const int *A, int size, int &newSize) {
    // Находим максимальный элемент в массиве A
    int maxElement = *std::max_element(A, A + size);

    // Создаем выходной массив B
    int *B = new int[size];
    newSize = 0;

    // Проходим по массиву A и добавляем элементы в B, исключая максимальный элемент
    for (int i = 0; i < size; ++i) {
        if (A[i] != maxElement) {
            B[newSize++] = A[i];
        }
    }

    return B;
}

int main() {
    std::ifstream inputFile("/home/grigorijtomczuk/Desktop/suai/op/lab1.3/input.txt");
    std::ofstream outputFile("/home/grigorijtomczuk/Desktop/suai/op/lab1.3/output.txt");

    if (!inputFile.is_open() || !outputFile.is_open()) {
        std::cerr << "Ошибка открытия файлов!" << std::endl;
        return 1;
    }

    int n;
    inputFile >> n; // Читаем размерность массива

    int *A = new int[n];

    // Считываем элементы массива A из файла
    for (int i = 0; i < n; ++i) {
        inputFile >> A[i];
    }

    int newSize;
    // Получаем выходной массив, исключая максимальный элемент
    int *B = excludeMax(A, n, newSize);

    // Записываем размерность и элементы выходного массива в файл
    outputFile << newSize << std::endl;
    for (int i = 0; i < newSize; ++i) {
        outputFile << B[i] << " ";
    }

    // Освобождаем память
    delete[] A;
    delete[] B;

    // Закрываем файлы
    inputFile.close();
    outputFile.close();

    return 0;
}
