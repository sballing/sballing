using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		WriteLine("-----------------------------------------------------------------------");
		WriteLine("Testing the implemented Monte-Carlo integrator on some interesting integrals\n");


		WriteLine("Integrating x*y dx dy, x = 0..1, y = 0..1");
		Func<vector,double> f1 = x => x[0]*x[1];
		vector a1 = new double[2] {0,0};
		vector b1 = new double[2] {1,1};
		var res1 = mcint.plainmc(f1, a1, b1, 50000);
		WriteLine($"\tResult is {res1.Item1} and error is {res1.Item2}");
		WriteLine("\tResult should be 0.25");

		WriteLine("\nIntegrating (x + sin(y) + 1) dx dy, x = 0..2, y = -pi..pi");
		Func<vector,double> f2 = x => x[0] + Sin(x[1]) + 1;
		vector a2 = new double[2] {0,-PI};
		vector b2 = new double[2] {2,PI};
		var res2 = mcint.plainmc(f2, a2, b2, 50000);
		WriteLine($"\tResult is {res2.Item1} and error is {res2.Item2}");
		WriteLine("\tResult should be 8*pi = 25.133");

		WriteLine("\nIntegrating 1/([1 - cos(x)*cos(y)*cos(z)]*pi^3) dx dy dz, x = 0..pi, y = 0..pi, z = 0..pi");
		Func<vector,double> f3 = x => 1/((1 - Cos(x[0])*Cos(x[1])*Cos(x[2]))*Pow(PI,3));
		vector a3 = new double[3] {0,0,0};
		vector b3 = new double[3] {PI, PI, PI};
		var res3 = mcint.plainmc(f3, a3, b3, 50000);
		WriteLine($"\tResult is {res3.Item1} and error is {res3.Item2}");
		WriteLine("\tResult should be 1.393203");
		WriteLine("-----------------------------------------------------------------------");

	}

}