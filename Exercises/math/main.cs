using System;
using static System.Console;
using static System.Math;

public class math{

	public static void Main(){
		double sqrt2 = Sqrt(2.0);
		WriteLine($"sqrt(2) = {sqrt2}");
		WriteLine($"sqrt(2) * sqrt(2) = {sqrt2*sqrt2} (should be equal 2)\n");

		double e_pi = Exp(PI);
		WriteLine($"e^pi = {e_pi}");
		WriteLine($"ln(e^pi) = {Log(e_pi)} (should be pi = 3.14159)\n");

		double pi_e = Pow(PI, E);
		WriteLine($"pi^e = {pi_e}");
		WriteLine($"pi^e * pi^-e = {pi_e * Pow(PI, -E)} (should be 1)");
	}

}