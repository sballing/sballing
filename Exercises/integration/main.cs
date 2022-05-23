using System;
using static System.Console;
using static System.Math;
public class main{

	public static double erf(double z){
		double integral = integrate.quad(x => Exp(-x*x), a:0, b:z);
		return 2/Sqrt(PI)*integral;
	}

	public static void Main(){
		WriteLine("----------------------------------------------------------");
		WriteLine("Testing the numerical integrator on a well-studied example");
		WriteLine("We consider the integral of ln(x)/sqrt(x) from 0 to 1\n");

		double result = integrate.quad(x => Log(x)/Sqrt(x), a:0, b:1);
		WriteLine($"Numerical integration gives \n\n\t{result}. \n\nExact result is -4 for comparison.");
		WriteLine("----------------------------------------------------------");

		WriteLine("Using the numerical integrator to implement the error function");
		using(var outfile = new System.IO.StreamWriter("gamma.txt")){
			for(double x=-3; x<=3; x+=1.0/16){
				outfile.WriteLine($"{x} {erf(x)}");
			}
		}
		WriteLine("The resulting error function is plotted in \'gamma.png\'");
		WriteLine("The result is compared to table values");
		WriteLine("----------------------------------------------------------");

	}

}