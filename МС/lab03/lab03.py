import numpy as np
import matplotlib.pyplot as plt
from math import gamma

N = 10000
z = np.random.rand(N)

# 1. экспоненциальное распределение
lam = 2
exp_x = -np.log(z) / lam

M_exp_theory = 1 / lam
D_exp_theory = 1 / (lam**2)

M_exp_emp = np.mean(exp_x)
D_exp_emp = np.var(exp_x)

# 2. равномерное распределение
a = 2
b = 10
uni_x = a + (b - a) * z

M_uni_theory = (a + b) / 2
D_uni_theory = ((b - a) ** 2) / 12

M_uni_emp = np.mean(uni_x)
D_uni_emp = np.var(uni_x)

# 3. распределение эрланга
k_erlang = 3
lam_erlang = 2
erlang_x = np.zeros(N)

for i in range(N):
    product = 1
    for j in range(k_erlang):
        product *= np.random.rand()
    erlang_x[i] = -np.log(product) / lam_erlang

M_erlang_theory = k_erlang / lam_erlang
D_erlang_theory = k_erlang / (lam_erlang**2)

M_erlang_emp = np.mean(erlang_x)
D_erlang_emp = np.var(erlang_x)

# 4. нормальное распределение
m = 5
sigma = 2
z1 = np.random.rand(N // 2)
z2 = np.random.rand(N // 2)
x1 = np.sqrt(-2 * np.log(z1)) * np.sin(2 * np.pi * z2)
x2 = np.sqrt(-2 * np.log(z1)) * np.cos(2 * np.pi * z2)
normal_standard = np.concatenate([x1, x2])
normal_x = m + sigma * normal_standard

M_normal_theory = m
D_normal_theory = sigma**2

M_normal_emp = np.mean(normal_x)
D_normal_emp = np.var(normal_x)

# 5. распределение вейбулла
alpha = 2
beta = 3
weibull_x = beta * (-np.log(z)) ** (1 / alpha)

M_weibull_theory = beta * gamma(1 + 1 / alpha)
D_weibull_theory = beta**2 * (gamma(1 + 2 / alpha) - gamma(1 + 1 / alpha) ** 2)

M_weibull_emp = np.mean(weibull_x)
D_weibull_emp = np.var(weibull_x)

# вывод результатов
print("Экспоненциальное")
print(f"M = {M_exp_emp:.3f} (теор. = {M_exp_theory:.3f})")
print(f"D = {D_exp_emp:.3f} (теор. = {D_exp_theory:.3f})")

print("Равномерное")
print(f"M = {M_uni_emp:.3f} (теор. = {M_uni_theory:.3f})")
print(f"D = {D_uni_emp:.3f} (теор. = {D_uni_theory:.3f})")

print("Эрланга")
print(f"M = {M_erlang_emp:.3f} (теор. = {M_erlang_theory:.3f})")
print(f"D = {D_erlang_emp:.3f} (теор. = {D_erlang_theory:.3f})")

print("Нормальное")
print(f"M = {M_normal_emp:.3f} (теор. = {M_normal_theory:.3f})")
print(f"D = {D_normal_emp:.3f} (теор. = {D_normal_theory:.3f})")

print("Вейбулла")
print(f"M = {M_weibull_emp:.3f} (теор. = {M_weibull_theory:.3f})")
print(f"D = {D_weibull_emp:.3f} (теор. = {D_weibull_theory:.3f})")

# гистограммы
distributions = [
    ("Экспоненциальное", exp_x),
    ("Равномерное", uni_x),
    ("Эрланга", erlang_x),
    ("Нормальное", normal_x),
    ("Вейбулла", weibull_x),
]

for name, data in distributions:
    plt.figure(figsize=(10, 6))
    plt.hist(data, bins=30, density=True)
    plt.title(f"Гистограмма распределения: {name}")
    plt.xlabel("x")
    plt.ylabel("Плотность вероятности")
    plt.grid(True)
    filename = f"{name}.png"
    plt.savefig(filename)
    plt.show()
