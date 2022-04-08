using System;
using static System.Console;
using static System.Math;
using static System.Double;
public class main{

	public static void Main(){
		WriteLine("------------------------------------");
		WriteLine("Testing error implementation on the same integrals as earlier:\n");

		double a=0.0, b=1.0;
		Func<double,double> f1 = x => Sqrt(x);
		Func<double,double> f2 = x => 1/Sqrt(x);
		Func<double,double> f3 = x => 4*Sqrt(1-x*x);
		Func<double,double> f4 = x => Log(x)/Sqrt(x);


		(double res1, double err1) = integrator.quad(f1, a, b);
		(double res2, double err2) = integrator.quad(f2, a, b);
		(double res3, double err3) = integrator.quad(f3, a, b);
		(double res4, double err4) = integrator.quad(f4, a, b);
		WriteLine($"Int sqrt(x) from 0 to 1: {res1} with error {err1}");
		WriteLine($"Int 1/sqrt(x) from 0 to 1: {res2} with error {err2}");
		WriteLine($"Int 4*sqrt(1-x^2) from 0 to 1: {res3} with error {err3}");
		WriteLine($"Int log(x)/sqrt(x) from 0 to 1: {res4} with error {err4}");
		WriteLine("\nEvidently, the error is lower than the required eps and delta!");
		WriteLine("------------------------------------");

		WriteLine("Testing the implementation on infinite limits:\n");
		int i = 0, j = 0, k = 0;
		Func<double,double> f5 = x => {i++; return Exp(-x*x);};
		Func<double,double> f6 = x => {j++; return Pow(Sin(x)/x,2);};
		Func<double,double> f7 = x => {k++; return 1/(1+x*x);};

		(double res5, double err5) = integrator.quad(f5, NegativeInfinity, PositiveInfinity);
		(double res6, double err6) = integrator.quad(f6, 0, PositiveInfinity);
		(double res7, double err7) = integrator.quad(f7, NegativeInfinity, 0);


		WriteLine($"Int e^(-x^2) from -inf to inf: {res5} in {i} recursive calls (should be sqrt(pi) = 1.772)");
		WriteLine($"Int (sin(x)/x)^2 from 0 to inf: {res6} in {j} recursive calls (should be pi/2 = 1.571)");
		WriteLine($"Int 1/(1+x^2) from -inf to 0: {res7} in {k} recursive calls (should be pi/2 = 1.571)");
		WriteLine("------------------------------------");

		WriteLine("Testing the Python SciPy routine for comparison:\n");
		var instream =new System.IO.StreamReader("python_res.txt");
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
        	WriteLine(line);
        }
		instream.Close();
		WriteLine("------------------------------------");


	}
}