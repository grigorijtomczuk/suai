import numpy as np
import matplotlib.pyplot as plt

# исходные данные
x = np.array([-50.7, -21.8, -14.4, 23.5, 34.7, 55.0, 85.3])
p = np.array([0.159, 0.157, 0.166, 0.089, 0.136, 0.137, 0.156])

N = 500  # размер выборки

# генерация дискретной СВ
sample = np.random.choice(x, size=N, p=p)

print("Первые 30 значений выборки:")
for i in range(30):
    print(f"x[{i+1}] = {sample[i]}")

M_theory = np.sum(p * x)
D_theory = np.sum(p * x**2) - M_theory**2

M_emp = np.mean(sample)
D_emp = np.var(sample)

# вывод результатов
print(f"\nТеоретическое M = {M_theory}")
print(f"Эмпирическое M = {M_emp}")
print(f"\nТеоретическая D = {D_theory}")
print(f"Эмпирическая D = {D_emp}")

# эмпирические вероятности
unique, counts = np.unique(sample, return_counts=True)
p_emp = counts / N

# график
width = 5
plt.figure(figsize=(12, 6))
plt.bar(unique - width / 2, p_emp, width=width, label="Эмпирические вероятности")
plt.bar(x + width / 2, p, width=width, label="Теоретические вероятности")
plt.xlabel("Значения x")
plt.ylabel("Вероятность")
plt.title("Сравнение эмпирических и теоретических вероятностей")
plt.legend()
plt.grid(True)
plt.savefig("discrete_distribution.png")
plt.show()
