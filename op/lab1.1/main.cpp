#include <iostream>
#include <string>
#include <bits/stdc++.h>


void tokenizer(std::string s, char del) {
    std::stringstream ss(s);
    std::string word;
    while (!ss.eof()) {
        getline(ss, word, del);
        std::cout << word << std::endl;
    }
}

int main() {
    std::string P;
    int a, b, R;

    std::cin >> P;
    std::cin >> a;
    std::cin >> b;
    std::cin >> R;

    tokenizer(P, ',');

    return 0;
}
