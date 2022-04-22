using System;
using static System.Console;
using static System.Math;
public class main{

	public static double Fe(double r, double e, double r_min){
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

	public static double solver(double r_min, double r_max){
		Func<vector,vector> master = (vector v) => {
			double e = v[0];
			double f_r_max = Fe(r_max, e, r_min);
			return new vector(f_r_max);
		};

		vector v_start = new vector(-1.0);
		vector root = roots.newton(master, v_start, eps:1e-5);
		double E = root[0];

		return E;
	}

	public static void Main(){
		WriteLine("------------------------------------------------");
		WriteLine("Investigating the lowest energy solution for r_min = 1e-3, r_max = 8\n");	
		double r_min = 1e-3;
		double r_max = 8;

		double energy = solver(r_min, r_max);
		WriteLine($"\tThe energy is estimated to be {energy} Hartree");
		WriteLine("\tIt should be 0.5 Hartree");

		using(var outfile = new System.IO.StreamWriter("solution.txt")){
			for(double r=0; r<r_max; r+=1.0/64){
				outfile.WriteLine($"{r} {Fe(r, energy, r_min)} {r*Exp(-r)} {r*Exp(-r) - Fe(r, energy, r_min)}");
			}
		}

		WriteLine("\nThe corresponding radial wavefunction is plotted alongside the analytical solution");
		WriteLine("These can be seen in file \'hydrogen.png\'");	
		WriteLine("------------------------------------------------");

		WriteLine("Investigating the convergence of solution with respect to varying r_min and r_max");
		using(var outfile = new System.IO.StreamWriter("convergence.txt")){
			double r_min2 = 1e-3;

			for(double r_max2 = 0.5; r_max2 <= 15; r_max2 += 0.2){
				double energy2 = solver(r_min2, r_max2);
				outfile.WriteLine($"{r_max2} {energy2} {-0.5}");
			}
			outfile.WriteLine("\n");

			double r_max3 = 8;
			for(double r_min3 = 0.5; r_min3 >= 1e-3; r_min3 -= 0.01){
				double energy3 = solver(r_min3, r_max3);
				outfile.WriteLine($"{r_min3} {energy3} {-0.5}");
			}
		}
	}

}