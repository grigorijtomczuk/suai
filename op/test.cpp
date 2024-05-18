#include <iostream>

using namespace std;

// void test(int **&ptr) {
//     ptr = new int *[3];
//     ptr[0] = new int(10);
//     ptr[1] = new int(20);
//     ptr[2] = new int(30);
// };
//
// int main() {
//     int **array = nullptr;
//
//     test(array);
//
//     for (int i = 0; i < 3; i++)
//         cout << *array[i] << " ";
//
//     // Освобождение памяти
//     if (array != nullptr) {
//         for (int i = 0; i < 3; ++i) {
//             delete array[i];
//         }
//         delete[] array;
//     }
//
//     return 0;
// }

int main() {
    // new int[3] returns a pointer to the 1st element
    int *array = new int[3];
    array[0] = 1;
    array[1] = 2;
    array[2] = 3;

    cout << *(array + 1) << endl;

    for (size_t i = 0; i < 3; i++) {
        cout << array[i] << " ";
    }

    return 0;
}
