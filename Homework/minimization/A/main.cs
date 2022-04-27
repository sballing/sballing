using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		WriteLine("---------------------------------------------------");
		WriteLine("Finding minimum of Rosenbrock's valley function:\n");

		Func<vector,double> f1 = x => (1 - x[0])*(1 - x[0]) + 100*(x[1] - x[0]*x[0])*(x[1] - x[0]*x[0]);
		double acc1 = 1e-5;
		vector x10 = new double[2] {0,0};

		WriteLine($"Start guess is ({x10[0]},{x10[1]})");
		var (x1,nsteps1) = mini.qnewton(f1, x10, acc: acc1);
		WriteLine("The minimum was determined to be\n");
		WriteLine($"\t({x1[0]},{x1[1]}) in {nsteps1} steps. \n\tHere f(x,y) = {f1(x1)}");
		WriteLine("\n\tOne minimum is at (1,1), where f(x,y) = 0");
		WriteLine("\n---------------------------------------------------");


		WriteLine("Finding a minimum of Himmelblau's function:\n");
		Func<vector,double> f2 = x => (x[0]*x[0] + x[1] - 11)*(x[0]*x[0] + x[1] - 11) + (x[0] + x[1]*x[1] - 7)*(x[0] + x[1]*x[1] - 7);
		double acc2 = 1e-5;
		vector x20 = new double[2] {1,1};

		WriteLine($"Start guess is ({x20[0]},{x20[1]})");
		var (x2,nsteps2) = mini.qnewton(f2, x20, acc: acc2);
		WriteLine("The minimum was determined to be\n");
		WriteLine($"\t({x2[0]},{x2[1]}) in {nsteps2} steps. \n\tHere f(x,y) = {f2(x2)}");
		WriteLine("\n\tOne minimum is at (3,2), where f(x,y) = 0");
		WriteLine("\n---------------------------------------------------");
	}

}