# 0.526688

from math import cos, pi, sin, sqrt, tan

A = -10**4
B = 0.2
C = -0.5
D = 3

res = (sqrt(A * (3 * sin(D) - 9 * cos(abs(B)) + 10 * tan(C)))) / (25 * pi * D**2)

print(res)
