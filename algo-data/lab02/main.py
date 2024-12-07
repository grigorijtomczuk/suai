# Вычисляет высоту дерева на основе массива parent.
def calculate_tree_height(n, parent):
    # Кэш для хранения высоты поддеревьев, чтобы избежать повторных вычислений
    heights = [-1] * n

    # Рекурсивно вычисляет высоту поддерева с корнем в node.
    def compute_height(node):
        if heights[node] != -1:
            return heights[node]  # Если высота уже вычислена, вернуть её

        if parent[node] == -1:
            heights[node] = 1  # Корень дерева имеет высоту 1
        else:
            heights[node] = 1 + compute_height(parent[node])  # Высота = 1 + высота родителя
        return heights[node]

    # Вычисляем высоту для всех узлов
    return max(compute_height(i) for i in range(n))


def main():
    # Считываем количество вершин
    n = int(input("Введите количество вершин: "))

    # Считываем массив parent
    parent = list(map(int, input("Введите массив родительских связей: ").split()))

    # Проверяем корректность ввода
    if len(parent) != n:
        print("Длина массива parent должна совпадать с n.")
        return

    # Вычисляем высоту дерева
    tree_height = calculate_tree_height(n, parent)

    # Выводим результат
    print("Высота дерева:", tree_height)


if __name__ == "__main__":
    main()
