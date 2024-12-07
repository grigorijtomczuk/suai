from collections import deque


# Находит максимум в каждом окне размера m массива array.
def find_max_sliding_window(n, array, m):
    # Дек для хранения индексов элементов текущего окна
    deque_indices = deque()
    max_in_windows = []

    for i in range(n):
        # Удаляем элементы, которые выходят за пределы окна
        if deque_indices and deque_indices[0] < i - m + 1:
            deque_indices.popleft()

        # Удаляем из дека все элементы, которые меньше текущего
        # Так как они не могут быть максимумом в текущем или последующих окнах
        while deque_indices and array[deque_indices[-1]] < array[i]:
            deque_indices.pop()

        # Добавляем текущий индекс в дек
        deque_indices.append(i)

        # Максимум окна находится в начале дека
        # Начинаем добавлять максимумы в список только после того, как заполнили первое окно
        if i >= m - 1:
            max_in_windows.append(array[deque_indices[0]])

    return max_in_windows


def main():
    # Чтение входных данных
    n = int(input("Введите n: ").strip())
    array = list(map(int, input("Введите массив: ").strip().split()))
    m = int(input("Введите m: ").strip())

    # Вычисление максимумов в каждом окне
    results = find_max_sliding_window(n, array, m)

    # Вывод результата
    print(" ".join(map(str, results)))


if __name__ == "__main__":
    main()
