using System;
using static System.Console;
using static System.Random;
public class main{
	public static void Main(){
		double[] xs = new double[] {1,2,3,4,6,9,10,13,15};
		double[] ys = new double[] {117,100,88,72,53,29.5,25.2,15.2,11.1};
		double[] dys = new double[] {5,5,5,5,5,1,1,1,1};
		var funcs = new Func<double,double>[] { z => 1.0, z => z };
		
		using(var outfile = new System.IO.StreamWriter("data_points.txt")){
			for(int i = 0; i<xs.Length; i++){
				outfile.WriteLine($"{xs[i]} {ys[i]} {dys[i]}");
			}
		}

		for(int i=0; i<ys.Length; i++){
			dys[i] = dys[i]/ys[i];
			ys[i] = Math.Log(ys[i]);
		}
		
		double[] cs = lsfit.fit(xs, ys, dys, funcs);

		using(var outfile = new System.IO.StreamWriter("best_fit.txt")){
			for(double t=0; t<=16; t+=1.0/32){
				double res = 0;
				for(int j=0; j<funcs.Length; j++){
					res += cs[j]*funcs[j](t);
				}
				outfile.WriteLine($"{t} {Math.Exp(res)}");
			}
		}

		WriteLine("----------------------------------------------");
		WriteLine($"The fit parameters are {cs[0]} and {cs[1]}");
		WriteLine($"This corresponds to a fitted lambda value of {-cs[1]}");
		WriteLine($"Hence, the half-life is Ln(2)/lambda = {Math.Log(2)/(-cs[1])} days");
		WriteLine("This does not agree very well with the modern table value of 3.6319 days (Wikipedia)");
		WriteLine("----------------------------------------------");
		WriteLine("A plot of the experimental data alongside a fit is made");
		WriteLine("This can also be seen in this directory as \'best_fit.png\'");
		WriteLine("----------------------------------------------");
	}
}