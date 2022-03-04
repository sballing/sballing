using System;
using static System.Console;
using static System.Math;
public static class main{
	public static void Main(){
	double result = integrate.quad(x => Log(x)/Sqrt(x), a:0, b:1);
	WriteLine($"Numerical integration gives {result}. Exact result is -4 for comparison.");
	}
}