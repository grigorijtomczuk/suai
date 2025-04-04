@echo off
REM Проверяем, передан ли параметр
if "%~1"=="" (
    echo Ошибка: Необходимо передать полное имя файла.
    exit /b
)

REM Получаем расширение файла
set "fileExt=%~x1"
set "fileExt=%fileExt:~1%"  REM Убираем точку из расширения

mkdir "%fileExt%"

REM Копируем все файлы, начинающиеся с "A", из каталога "Variant 19"
for /r "Variant 19" %%G in (A*) do copy "%%G" "%fileExt%" >nul

echo Файлы, начинающиеся на "A", скопированы в папку "%fileExt%".
