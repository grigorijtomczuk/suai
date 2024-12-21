class MaxStack:
    def __init__(self, max_size=None):
        self.stack = []
        self.max_stack = []
        self.min_stack = []
        self.sum = 0
        self.max_size = max_size

    def push(self, value):
        if self.max_size is not None and len(self.stack) >= self.max_size:
            print("Стек переполнен!")
            return

        self.stack.append(value)
        self.sum += value

        if not self.max_stack or value >= self.max_stack[-1]:
            self.max_stack.append(value)

        if not self.min_stack or value <= self.min_stack[-1]:
            self.min_stack.append(value)

    def pop(self):
        if not self.stack:
            print("Стек пуст!")
            return

        value = self.stack.pop()
        self.sum -= value

        if value == self.max_stack[-1]:
            self.max_stack.pop()

        if value == self.min_stack[-1]:
            self.min_stack.pop()

    def max(self):
        if not self.max_stack:
            print("Стек пуст!")
            return None
        return self.max_stack[-1]

    def min(self):
        if not self.min_stack:
            print("Стек пуст!")
            return None
        return self.min_stack[-1]

    def avg(self):
        if not self.stack:
            print("Стек пуст!")
            return None
        return self.sum / len(self.stack)


def process_requests(requests, max_stack):
    for request in requests:
        parts = request.split()
        command = parts[0]

        if command == "push":
            value = int(parts[1])
            max_stack.push(value)
        elif command == "pop":
            max_stack.pop()
        elif command == "max":
            result = max_stack.max()
            if result is not None:
                print(result)
        elif command == "min":
            result = max_stack.min()
            if result is not None:
                print(result)
        elif command == "avg":
            result = max_stack.avg()
            if result is not None:
                print(result)


if __name__ == "__main__":
    q = int(input(""))
    requests = []

    for _ in range(q):
        requests.append(input())

    max_stack = MaxStack(max_size=10)
    process_requests(requests, max_stack)
