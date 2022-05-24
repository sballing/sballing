using System;
using static System.Console;
using static System.Math;
public class main{

	public static double erf(double z){
		double integral = integrator.quad(x => Exp(-x*x), a:0, b:z);
		return 2/Sqrt(PI)*integral;
	}

	public static void Main(){
		WriteLine("-------------------------------------------------------");
		WriteLine("Testing implementation on some interesting integrals:\n");

		double a=0.0, b=1.0;
		Func<double,double> f1 = x => Sqrt(x);
		Func<double,double> f2 = x => 1/Sqrt(x);
		Func<double,double> f3 = x => 4*Sqrt(1-x*x);
		Func<double,double> f4 = x => Log(x)/Sqrt(x);


		double res1 = integrator.quad(f1, a, b);
		double res2 = integrator.quad(f2, a, b);
		double res3 = integrator.quad(f3, a, b);
		double res4 = integrator.quad(f4, a, b);
		WriteLine($"Int sqrt(x) from 0 to 1: {res1} (should be 2/3 = 0.666...)");
		WriteLine($"Int 1/sqrt(x) from 0 to 1: {res2} (should be 2)");
		WriteLine($"Int 4*sqrt(1-x^2) from 0 to 1: {res3} (should be pi = 3.14159...)");
		WriteLine($"Int log(x)/sqrt(x) from 0 to 1: {res4} (should be -4)");
		WriteLine("\n-------------------------------------------------------");

		WriteLine("Using the implemented integrator to estimate the error function");
		WriteLine("The result is plotted in \'gamma.png\' along some table values");
		WriteLine("-------------------------------------------------------");

		using(var outfile = new System.IO.StreamWriter("gamma.txt")){
			for(double x=-3; x<=3; x+=1.0/16){
				outfile.WriteLine($"{x} {erf(x)}");	
			}
		}
	}
}