using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		WriteLine("---------------------------------------------------------------------------------------");
		WriteLine("Testing the implemented artificial neural network");
		WriteLine("Specifically, the routine is tested with regards to interpolation");
		WriteLine("\nThe function\n\tg(x) = Cos(5*x-1)*Exp(-x^2)\nis interpolated");
		WriteLine("\nThis is done using a gaussian wavelet as the activation function.");
		WriteLine("---------------------------------------------------------------------------------------");

		Func<double,double> act = x => x*Exp(-x*x);
		Func<double,double> g = x => Cos(5*x - 1)*Exp(-x*x);

		int n = 5; // Number of hidden neurons
		ann network = new ann(n, act); // Constructing the network

		double a = -1, b = 1; // Interval to consider
		int nx = 20; // Number of points given to supervise

		vector xs = new vector(nx);
		vector ys = new vector(nx);

		using(var outfile = new System.IO.StreamWriter("toPlot.txt")){

			for(int i=0; i<xs.size; i++){
				xs[i] = a + (b-a)*i/(nx-1); // Making the x-points
				ys[i] = g(xs[i]); // Making the corresponding y-points
				outfile.WriteLine($"{xs[i]} {ys[i]}");
			}
			outfile.WriteLine("\n");

			for(int i=0; i<network.n; i++){ // Filling the initial p-vector
				network.p[3*i + 0] = a + (b-a)*i/(network.n-1); // Same as the filling x above
				network.p[3*i + 1] = 1; // b_i is set to 1 initially
				network.p[3*i + 2] = 1; // w_i is set to 1 initially
			}

			network.train(xs, ys); // Train the network using the given supervisor (table points)

			for(double z=a; z<b; z+=1.0/64){
				outfile.WriteLine($"{z} {network.response(z)}"); // Printing the interpolant
			}
		}
		WriteLine("The artificial neural network succesfully interpolated the given function g(x)");
		WriteLine("The resulting plot can be seen in \'interpolation.png\'");
		WriteLine("---------------------------------------------------------------------------------------");

	}

}