import numpy as np
from scipy import integrate

def f1(x):
    return np.exp(-x**2)

def f2(x):
    return 1/(x**2)

def f3(x):
    return 1/(1+x**2)


res1, err1, infodict1 = integrate.quad(f1, -np.inf, np.inf, epsabs=0.001, epsrel=0.001, full_output=True)
res2, err2, infodict2 = integrate.quad(f2, 1, np.inf, epsabs=0.001, epsrel=0.001, full_output=True)
res3, err3, infodict3 = integrate.quad(f3, -np.inf, 0, epsabs=0.001, epsrel=0.001, full_output=True)


print("exp(-x^2) - Python implementation: " + str(res1) + ". It took " + str(infodict1['neval']) + " iterations.")
print("1/x^2 - Python implementation: " + str(res2) + ". It took " + str(infodict2['neval']) + " iterations.")
print("1/(1+x^2) - Python implementation: " + str(res3) + ". It took " + str(infodict3['neval']) + " iterations.")