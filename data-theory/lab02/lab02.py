from collections import Counter

text = "Si mangia per vivere, non si vive per mangiare"
text = text.lower()

# 1. частоты
freq = Counter(text)
total = sum(freq.values())

# 2. сортируем по убыванию вероятности
items = sorted([(ch, freq[ch] / total) for ch in freq], key=lambda x: (-x[1], x[0]))


def shannon_fano(sorted_items):
    codes = {sym: "" for sym, _ in sorted_items}
    splits = []

    def split_group(items):
        if len(items) <= 1:
            return
        probs = [p for _, p in items]
        total_p = sum(probs)
        best_idx = 1
        best_diff = abs(sum(probs[:1]) - (total_p - sum(probs[:1])))
        for i in range(2, len(items)):
            left_sum = sum(probs[:i])
            diff = abs(left_sum - (total_p - left_sum))
            if diff < best_diff:
                best_diff = diff
                best_idx = i
        left = items[:best_idx]
        right = items[best_idx:]
        for sym, _ in left:
            codes[sym] += "0"
        for sym, _ in right:
            codes[sym] += "1"
        splits.append((items, left, right))
        split_group(left)
        split_group(right)

    split_group(sorted_items)
    return codes, splits


codes, splits = shannon_fano(items)

# вывод
print("Символ  Кол-во  p       Код       Длина")
for ch, p in items:
    print(f"{repr(ch):6}  {freq[ch]:6d}  {p:.4f}  {codes[ch]:8}  {len(codes[ch]):d}")

avg_len = sum(p * len(codes[ch]) for ch, p in items)
print("L =", avg_len)
print("Всего бит:", round(total * avg_len))
