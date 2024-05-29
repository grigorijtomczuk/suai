cmake_minimum_required(VERSION 3.13)
project(op)
set(CMAKE_CXX_STANDARD 14)

# Add main.cpp file of the project root directory as a source file
# set(SOURCE_FILES main.cpp)

# Add executable target with source files listed in SOURCE_FILES variable
# add_executable(simple_example ${SOURCE_FILES})

add_executable(pr1 pr1.cpp)
add_executable(test test.cpp)

add_executable(main1.1 lab1.1/main1.1.cpp)

add_executable(main_unoptimized1.2 lab1.2/main_unoptimized.cpp)
add_executable(main1.2 lab1.2/main1.2.cpp)

add_executable(test1.3 lab1.3/test.cpp)
add_executable(main1.3 lab1.3/main.cpp)

add_executable(test2.1 lab2.1/test2.1.cpp)
add_executable(main2.1 lab2.1/main2.1.cpp)

add_executable(main2.2 lab2.2/main2.2.cpp)

add_executable(main3.1 lab3.1/main3.1.cpp)

add_executable(main3.2 lab3.2/main3.2.cpp)

add_executable(test4.1 lab4.1/test4.1.cpp)
add_executable(main4.1 lab4.1/main4.1.cpp)

add_executable(test4.2 lab4.2/test4.2.cpp)
add_executable(main4.2 lab4.2/main4.2.cpp)

add_executable(main5.1 lab5.1/main5.1.cpp)

add_executable(main5.2 lab5.2/main5.2.cpp)

add_executable(main_extra1.1 extra1/main_extra1.1.cpp)
add_executable(main_extra1.2 extra1/main_extra1.2.cpp)

add_executable(main_extra2.1 extra2/main_extra2.1.cpp)
add_executable(main_extra2.2 extra2/main_extra2.2.cpp)
