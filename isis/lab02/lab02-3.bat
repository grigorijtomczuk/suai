@echo off
tree "Variant 19" /F

set /p sourceDir="Укажите имя каталога-источника копирования: "
set /p targetDir="Укажите имя каталога-назначения копирования: "
set /p fileName="Укажите имя файла для копирования: "

copy "%sourceDir%\%fileName%" "Variant 19\%targetDir%\%fileName%"

tree "Variant 19" /F
echo Копирование завершено.
