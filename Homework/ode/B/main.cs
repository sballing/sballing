using System;
using static System.Console;
using static System.Math;
public class main{
	public static void Main(){
		WriteLine("--------------------------------------");
		WriteLine("Solving the ODE from SciPy");
		WriteLine("The path is stored in the genlists given as parameters");
		WriteLine("The result is plotted in figure ode_test.png");
		WriteLine("--------------------------------------");
		double b=0.25, c=5.0;
		Func<double,vector,vector> f = delegate(double t, vector y){
			double theta=y[0], omega=y[1];
			return new vector(omega, -b*omega-c*Sin(theta));
		};

		var xlist = new genlist<double>();
		var ylist = new genlist<vector>();

		double start=0, stop=10;
		vector y0 = new vector(PI-0.1, 0.0);

		rk.driver(f, start, y0, stop, xlist, ylist);

		using(var outfile = new System.IO.StreamWriter("sol.txt")){
			for(int i=0; i<xlist.size; i++){
				outfile.WriteLine($"{xlist.data[i]} {ylist.data[i][0]} {ylist.data[i][1]}");
			}
		}

	}
}