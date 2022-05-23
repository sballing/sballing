using System;
using static System.Console;
using static cmath;
using static complex;
public class main {
	static void Main(){
		complex minusOne = new complex(-1,0);
		WriteLine("-------------------------------------------------");
		WriteLine("Testing the cmath class on some examples:");
		WriteLine($"sqrt(-1) = {cmath.sqrt(minusOne)} (should be 0 + 1i)");
		WriteLine($"sqrt(i) = {cmath.sqrt(cmath.I)} (should be 0.7071 + 0i)");
		WriteLine($"e^i = {cmath.exp(cmath.I)} (should be 0.5403 + 0.8415i)");
		WriteLine($"e^i*pi = {cmath.exp(cmath.I*System.Math.PI)} (should be -1 + 0i)");
		WriteLine($"i^i = {cmath.pow(cmath.I, cmath.I)} (should be 0.2079 + 0i)");
		WriteLine($"ln(i) = {cmath.log(cmath.I)} (should be 0 + 1.5708i)");
		WriteLine($"sin(i*pi) = {cmath.sin(cmath.I*System.Math.PI)} (should be 0 + 11.55i)");
		WriteLine("-------------------------------------------------");
	}
}