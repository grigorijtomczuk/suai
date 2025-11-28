import collections
from math import log2

text = "В чужом глазу соринку видим а в своем бревна не видим Что хорошо для вторника не всегда подходит для среды Повадился кувшин по воду ходить не там ему голову сложить а там ему полным быть"

char_counts = collections.Counter(text.lower())
total_char = len(text)
entropy = -sum(
    (char_counts[ch] / total_char) * log2(char_counts[ch] / total_char)
    for ch in char_counts
)
m = 32
H0 = log2(m)
total_info_hartley = total_char * H0
total_info = entropy * total_char
redundancy = 1 - (entropy / H0)

char_counts = sorted(char_counts.items(), key=lambda x: (-x[1], x[0]))
char_stats = list(
    map(lambda x: (x[0], x[1], x[1] / total_char, x[1] / total_char * 100), char_counts)
)

for char, n, p, percent in char_stats:
    print(f"{char} {n} {p:.4f} {percent:.2f}%")

for x in [total_char, entropy, H0, total_info_hartley, total_info, redundancy]:
    print(x)
