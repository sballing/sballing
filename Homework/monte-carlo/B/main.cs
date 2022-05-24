using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		WriteLine("-----------------------------------------------------------------------");
		WriteLine("Testing both integrator routines on some interesting integrals\n");


		WriteLine("Integrating x*y dx dy, x = 0..1, y = 0..1");
		Func<vector,double> f1 = x => x[0]*x[1];
		vector a1 = new double[2] {0,0};
		vector b1 = new double[2] {1,1};
		var res1_plain = mcint.plainmc(f1, a1, b1, 50000);
		var res1_halton = mcint.haltonmc(f1, a1, b1, 50000);
		WriteLine($"\tPlain routine gives: {res1_plain.Item1} with error {res1_plain.Item2}");
		WriteLine($"\tHalton routine gives: {res1_halton.Item1} with error {res1_halton.Item2}");
		WriteLine("\tResult should be 0.25");

		WriteLine("\nIntegrating (x + sin(y) + 1) dx dy, x = 0..2, y = -pi..pi");
		Func<vector,double> f2 = x => x[0] + Sin(x[1]) + 1;
		vector a2 = new double[2] {0,-PI};
		vector b2 = new double[2] {2,PI};
		var res2_plain = mcint.plainmc(f2, a2, b2, 50000);
		var res2_halton = mcint.haltonmc(f2, a2, b2, 50000);
		WriteLine($"\tPlain routine gives: {res2_plain.Item1} with error {res2_plain.Item2}");
		WriteLine($"\tHalton routine gives: {res2_halton.Item1} with error {res2_halton.Item2}");
		WriteLine("\tResult should be 8*pi = 25.133");

		WriteLine("\nIntegrating 1/([1 - cos(x)*cos(y)*cos(z)]*pi^3) dx dy dz, x = 0..pi, y = 0..pi, z = 0..pi");
		Func<vector,double> f3 = x => 1/((1 - Cos(x[0])*Cos(x[1])*Cos(x[2]))*Pow(PI,3));
		vector a3 = new double[3] {0,0,0};
		vector b3 = new double[3] {PI, PI, PI};
		var res3_plain = mcint.plainmc(f3, a3, b3, 10000000);
		var res3_halton = mcint.haltonmc(f3, a3, b3, 10000000);
		WriteLine($"\tPlain routine gives: {res3_plain.Item1} with error {res3_plain.Item2}");
		WriteLine($"\tHalton routine gives: {res3_halton.Item1} with error {res3_halton.Item2}");
		WriteLine("\tResult should be 1.393203");
		WriteLine("-----------------------------------------------------------------------");

	}

}