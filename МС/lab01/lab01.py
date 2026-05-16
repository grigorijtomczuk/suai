import numpy as np
import matplotlib.pyplot as plt


def correlation(sequence, s, T):
    x = sequence[:T]
    y = sequence[s : s + T]
    return np.corrcoef(x, y)[0, 1]


r = 16  # число двоичных разрядов
MOD = 2**r  # модуль
M = 65539  # множитель (взаимно простой с 2^r)
m = 3  # длина прыжка
A0 = 1  # начальное значение
M_jump = pow(M, m, MOD)  # прыжковый множитель

T_theory = 2 ** (r - 2)  # теоретический период
N = 5000  # количество генерируемых чисел
K = 15  # количество интервалов для гистограммы

# генерация БСВ
A = np.zeros(N, dtype=np.uint64)
Z = np.zeros(N)
A[0] = A0

for i in range(1, N):
    A[i] = (A[i - 1] * M_jump) % MOD
    Z[i] = A[i] / MOD

# математическое ожидание и дисперсия
M_exp = np.mean(Z)
D_exp = np.var(Z)
M_theory = 0.5
D_theory = 1 / 12

print(f"Теоретический период T = {T_theory}")
print(f"Выборочное мат. ожидание = {M_exp} (теор. {M_theory})")
print(f"Выборочная дисперсия = {D_exp} (теор. {D_theory})")

fig, (ax1, ax2) = plt.subplots(2, 1, figsize=(10, 9))

# гистограмма распределения
ax1.hist(Z, bins=K, density=True)
ax1.set_title("Гистограмма распределения БСВ")
ax1.set_xlabel("Отрезки Z")
ax1.set_ylabel(r"Относительная частота $p_k$")
ax1.grid(True)

# коэффициент корреляции
T_values = np.arange(100, 3000, 100)
s_values = [2, 5, 10]
for s in s_values:
    R_values = []
    for T in T_values:
        R = correlation(Z, s, T)
        R_values.append(R)
    ax2.plot(T_values, R_values, label=f"s = {s}")

ax2.set_title("Зависимость коэффициента корреляции от длины выборки T")
ax2.set_xlabel("Длина выборки T")
ax2.set_ylabel("Корреляция R")
ax2.grid(True)
ax2.legend()

plt.tight_layout()
plt.show()
fig.savefig("plots.png")
