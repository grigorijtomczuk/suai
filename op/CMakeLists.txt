cmake_minimum_required(VERSION 3.13)
project(op)
set(CMAKE_CXX_STANDARD 14)

# Add main.cpp file of the project root directory as a source file
# set(SOURCE_FILES main.cpp)

# Add executable target with source files listed in SOURCE_FILES variable
# add_executable(simple_example ${SOURCE_FILES})

add_executable(pr1 pr1.cpp)
add_executable(test test.cpp)

add_executable(main_unoptimized lab1.2/main_unoptimized.cpp)
add_executable(main1.2 lab1.2/main1.2.cpp)

add_executable(test1.3 lab1.3/test.cpp)
add_executable(main1.3 lab1.3/main.cpp)

add_executable(test2.1 lab2.1/test2.1.cpp)
add_executable(main2.1 lab2.1/main.cpp)

add_executable(main3.1 lab3.1/main3.1.cpp)


add_executable(test2.1-2 lab2.1/test2.1-2.cpp)
