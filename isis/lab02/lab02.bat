@echo off
REM Создание дерева каталогов

mkdir "Variant 19"
cd "Variant 19"
mkdir GUAP A1 A2 A3
cd GUAP
mkdir Person Performance
cd Person
mkdir Ability
cd ..
cd Performance
mkdir B2 B3
cd ..
cd ..
mkdir C1 C2 C3
cd C1
mkdir B1
cd ..
cd C2
mkdir Qualitie
cd ..\

echo Дерево каталогов создано.
tree .