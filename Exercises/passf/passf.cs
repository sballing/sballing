using System;
using static System.Console;
using static System.Math;
public class passf{

	public static void Main() {
		int k = 1;
		WriteLine($"Making table for sin({k}x)");
		make_table(x => Sin(x), 0, 2*PI, 0.1);
	}

	private static void make_table(Func<double,double> f, double a, double b, double dx) {
		double i = a;
		while (i < b) {
			WriteLine($"{f(i)}");
			i = i + dx;
		} 
	}

}