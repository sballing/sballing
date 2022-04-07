import numpy as np
from scipy import integrate

def f1(x):
    return 1/np.sqrt(x)

def f2(x):
    return np.log(x)/np.sqrt(x)


res1, err1, infodict1 = integrate.quad(f1, 0, 1, epsabs=0.001, epsrel=0.001, full_output=True)
res2, err2, infodict2 = integrate.quad(f2, 0, 1, epsabs=0.001, epsrel=0.001, full_output=True)

print("1/sqrt(x) - Python implementation: " + str(res1) + ". It took " + str(infodict1['neval']) + " iterations.")
print("log(x)/sqrt(x) - Python implementation: " + str(res2) + ". It took " + str(infodict2['neval']) + " iterations.")