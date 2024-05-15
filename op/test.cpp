#include <iostream>

using namespace std;

int main() {
    int num = 5;
    int *num_ptr = &num;
    cout << &num << endl;
    cout << num_ptr << endl;
    cout << num << endl;
    cout << sizeof(num) << endl;

    char str[5] = "abcd";
    short s_value = 0;

    return 0;
}
