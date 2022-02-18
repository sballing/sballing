using System;
using static System.Console;
using static System.Math;
public class passf{

	public static void Main() {
		for(int k = 1; k <= 3; k++){
			WriteLine("");
			WriteLine($"Making table for sin({k}x)");
			make_table(x => Sin(k*x), 0, 2*PI, 0.1);
		}
	}

	private static void make_table(Func<double,double> f, double a, double b, double dx) {
		double i = a;
		while (i < b) {
			WriteLine($"x = {i}, sin(x) = {f(i)}");
			i = i + dx;
		} 
	}

}