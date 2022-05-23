using System;
using static System.Console;

public class passf{
	public static void make_table(Func<double,double> f, double a, double b, double dx) {
		for(double x=a; x<=b; x+=dx){
			WriteLine($"{x} {f(x)}");
		}
	}
}