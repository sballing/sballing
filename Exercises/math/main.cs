using System;
using static System.Console;
using static System.Math;
public class math{
	static void Main() {
		double sqrt2 = Sqrt(2.0);
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be equal 2)\n");

		double e_pi = Exp(PI); 
		Write($"e^pi = {e_pi}\n");

		double pi_e = Pow(PI, E);
		Write($"pi^e = {pi_e}\n");

	}

}