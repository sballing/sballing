import numpy as np
from scipy import integrate

def f1(x):
    global i
    i = i+1
    return 1/np.sqrt(x)

def f2(x):
    global j
    j = j+1
    return np.log(x)/np.sqrt(x)

i = 0
j = 0
res1 = integrate.quad(f1, 0, 1)
res2 = integrate.quad(f2, 0, 1)

print("1/sqrt(x) - Python implementation: " + str(res1[0]) + ". It took " + str(i) + " iterations.")
print("log(x)/sqrt(x) - Python implementation: " + str(res2[0]) + ". It took " + str(j) + " iterations.")