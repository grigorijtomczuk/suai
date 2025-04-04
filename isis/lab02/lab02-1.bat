@echo off
REM Создание дерева с возможностью задания параметров

mkdir "%~1"
cd "%~1"
mkdir "%~2" "%~3" "%~4" "%~5"
cd "%~2"
mkdir "%~6" "%~7"
cd "%~6"
mkdir "%~8"
cd ..
cd "%~7"
mkdir "%~9" B3
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
