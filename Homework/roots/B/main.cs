using System;
using static System.Console;
using static System.Math;
public class main{

	public static double Fe(double r, double e){
		double r_min = 1e-3;
		if(r < r_min){
			return r - r*r;
		}

		Func<double,vector,vector> schrodinger = (x,y) => {
			return new vector(new double[] {y[1], -2*(e + 1/x)*y[0]});
		};

		vector y_min = new vector(new double[] {r_min - r_min*r_min, 1 - 2*r_min}); // r_min^2 and its derivative
		vector y_max = rk.driver(schrodinger, r_min, y_min, r);
		return y_max[0];
	}

	public static void Main(){
		WriteLine("------------------------------------------------");
		WriteLine("HelloWorld");
		WriteLine("--------------------------------------");

		double r_max = 8;

		Func<vector,vector> master = (vector v) => {
			double e = v[0];
			double f_r_max = Fe(r_max, e);
			return new vector(f_r_max);
		};

		vector v_start = new vector(-0.5);
		vector root = roots.newton(master, v_start, eps:1e-5);
		double E = root[0];
		WriteLine($"r_max was {r_max}, and corresponding energy was {E}");

		using(var outfile = new System.IO.StreamWriter("solution.txt")){
			for(double r=0; r<r_max; r+=1.0/64){
				outfile.WriteLine($"{r} {Fe(r, E)} {r*Exp(-r)} {r*Exp(-r) - Fe(r, E)}");
			}
		}


		
		WriteLine("------------------------------------------------");
	}

}