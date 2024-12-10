class MyDeque:
    def __init__(self):
        self.items = []

    def __bool__(self):
        return bool(self.items)

    def is_empty(self):
        return self.items == []

    def append(self, item):
        self.items.append(item)

    def appendleft(self, item):
        self.items.insert(0, item)

    def pop(self):
        return self.items.pop()

    def popleft(self):
        return self.items.pop(0)

    def getleft(self):
        if self.is_empty(): return
        return self.items[0]

    def getright(self):
        if self.is_empty(): return
        return self.items[-1]


# Находит максимум в каждом окне размера m массива array.
def find_max_sliding_window(n, array, m):
    # Дек для хранения индексов элементов текущего окна
    deque_indices = MyDeque()
    max_in_windows = []

    for i in range(n):
        # Удаляем элементы, которые выходят за пределы окна
        if deque_indices and deque_indices.getleft() < i - m + 1:
            deque_indices.popleft()

        # Удаляем из дека все элементы, которые меньше текущего
        # Так как они не могут быть максимумом в текущем или последующих окнах
        while deque_indices and array[deque_indices.getright()] < array[i]:
            deque_indices.pop()

        # Добавляем текущий индекс в дек
        deque_indices.append(i)

        # Максимум окна находится в начале дека
        # Начинаем добавлять максимумы в список только после того, как заполнили первое окно
        if i >= m - 1:
            max_in_windows.append(array[deque_indices.getleft()])

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
