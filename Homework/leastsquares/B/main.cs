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
		
		(double[] cs, matrix S) = lsfit.fit(xs, ys, dys, funcs);

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
		WriteLine("Now the fit is carried out with the addition of the covariance-matrix");
		WriteLine($"The fit parameters remain {cs[0]} and {cs[1]}");
		WriteLine("The covariance-matrix is:");
		S.print();
		WriteLine($"\nHence, lambda is fitted to a value of {-cs[1]} +/- {Math.Sqrt(S[1,1])}");
		WriteLine($"This corresponds to a half-life of {Math.Log(2)/(-cs[1])} +/- {Math.Sqrt(S[1,1])*Math.Log(2)/(-cs[1])} days"); // Error propagation!
		WriteLine("And in conclusion, the modern table value of 3.6319 days (Wikipedia) is not within the uncertainties of the fit!");
		WriteLine("----------------------------------------------");
		WriteLine("A plot of the experimental data alongside a fit is made");
		WriteLine("This can also be seen in this directory as \'best_fit.png\'");
		WriteLine("----------------------------------------------");
	}
}