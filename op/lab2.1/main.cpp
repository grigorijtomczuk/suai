// 2.2 - с любой библиотекой, но эту только через обработку массивов

#include <cstddef>
#include <cstdio>

bool read_array(const char *filename, char *&array, size_t &size) {
    return true;
}

bool write_array(const char *filename, char *array, size_t &size) {
    return true;
}

void calculation(long *input_array, size_t input_size, char *&output_array, size_t &output_size) {
    return;
}

int main() {
    size_t max_string_length = 100;

    char *input_string = new char[100];
    char *output_string = new char[100];

    char *current_string = input_string + 14;

    // input_string[12] = 'A';
    // input_string[13] = '\a';

    // printf("%s\n", input_string);

    for (int i = 0; i < 100; ++i) {
        input_string[i] = (char) i;
        printf("%d = ", i);
        printf("%c\n", input_string[i]);
    }

    return 0;
};
