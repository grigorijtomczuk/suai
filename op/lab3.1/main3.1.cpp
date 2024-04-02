#include <cstdio>
#include <iostream>

int recursive_sum(long *array, size_t start, size_t end, int &call_count, int *memory, int depth_level,
                  int *levels) {
    int _call_count = call_count;
    memory[_call_count] = end;
    levels[_call_count] = depth_level;
    call_count++;

    if (end == start) {
        return array[end];
    }

    size_t mid = (start + end) / 2;

    long result = recursive_sum(array, start, mid, call_count, memory, depth_level + 1, levels) + array[end] +
                  recursive_sum(array, mid + 1, end, call_count, memory, depth_level + 1, levels) + array[end];
    memory[_call_count] = result;

    return result;
}

int main() {
    size_t array_size = 10;
    long *array = new long(array_size);

    for (size_t i = 1; i <= array_size; i++) {
        array[i] = i;
    }

    int call_count = 0;
    int *memory = new int(array_size * 2);
    int depth_level = 0;
    int *levels = new int(array_size * 2);

    int result = recursive_sum(array, 0, array_size - 1, call_count, memory, depth_level, levels);

    for (size_t i; i < call_count; i++) {
        printf("[%d], [%d]\n", levels[i], memory[i]);
    }

    delete memory;
    delete levels;

    std::cout << result;
    return 0;
}
