using System;
using static System.Console;

public class passf{
	public static void make_table(Func<double,double> f, double a, double b, double dx) {
		while (a <= b) {
			WriteLine($"{a}, {f(a)}");
			a += dx;
		} 
	}

}