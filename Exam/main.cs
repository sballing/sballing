using System;
using static System.Console;
using static System.Math;
public class main{

	public static double[] linspace(double x0, double x1, int N){
		double step = (x1 - x0)/(N - 1);
		double[] y = new double[N];
		for(int i=0; i<N; i++){
			y[i] = x0 + step*i;
		}
		return y;
	}


	public static void Main(){
		WriteLine("For details about the examination project, see the ReadMe-file");

		// Test 1 - setting data points
		double[] xs_1 = new double[] {-1.05, -0.75, -0.45, -0.15, 0.15, 0.45, 0.75, 1.05};
		double[] ys_1 = new double[] {0, 0, 0, 0, 1, 1, 1, 1};

		// Test 2 - setting data points
		int n = 12;
		/*double[] xs_2 = new double[n];
		for(int i=0; i<xs_2.Length; i++){
			xs_2[i] = Cos(PI*(i-1)/n);
		}*/
		double[] xs_2 = linspace(-1, 1, n);
		//double[] xs_2 = new double[] {-1, -0.75, -0.50, -0.25, 0, 0.25, 0.50, 0.75, 1};
		double[] ys_2 = new double[xs_2.Length];
		Func<double,double> f2 = x => 1/(1 + 25*x*x);
		for(int i=0; i<xs_2.Length; i++){
			ys_2[i] = f2(xs_2[i]);
		}

		// Test 3 - setting data points
		/*double[] xs_3 = new double[n];
		for(int i=0; i<xs_3.Length; i++){
			xs_3[i] = Cos(PI*(i-1)/n);
		}*/
		double[] xs_3 = linspace(-1, 1, n);
		//double[] xs_3 = new double[] {-1, -0.75, -0.50, -0.25, 0, 0.25, 0.50, 0.75, 1};
		double[] ys_3 = new double[xs_3.Length];
		Func<double,double> f3 = x => Abs(x) + x/2 - x*x;
		for(int i=0; i<xs_3.Length; i++){
			ys_3[i] = f3(xs_3[i]);
		}

		// Test 4 - setting data points
		/*double[] xs_4 = new double[n];
		for(int i=0; i<xs_4.Length; i++){
			xs_4[i] = Cos(PI*i/n);
		}*/
		double[] xs_4 = linspace(-1, 1, n);
		//double[] xs_4 = new double[] {-1, -0.75, -0.50, -0.25, 0, 0.25, 0.50, 0.75, 1};
		double[] ys_4 = new double[xs_4.Length];
		Func<double,double> f4 = x => Cos(10*x)*Exp(-x);
		for(int i=0; i<xs_4.Length; i++){
			ys_4[i] = f4(xs_4[i]);
		}

		// Testing the Berrut interpolation algorithm
		using(var outfile = new System.IO.StreamWriter("berrut_interpolation.txt")){

			//2nd approach
			// Test 1 - interpolating the function
			for(int i=0; i<xs_1.Length; i++){
				outfile.WriteLine($"{xs_1[i]} {ys_1[i]}");
			}

			outfile.WriteLine("\n");

			var (xx1, res1) = berrut.B1_interp(xs_1, ys_1, -1.051, 1.051, 1000);
			for(int i=0; i<res1.Length; i++){
				outfile.WriteLine($"{xx1[i]} {res1[i]}");
			}

			// Test 2 - interpolating the function
			outfile.WriteLine("\n");
			for(int i=0; i<xs_2.Length; i++){
				outfile.WriteLine($"{xs_2[i]} {ys_2[i]}");
			}

			outfile.WriteLine("\n");

			var (xx2, res2) = berrut.B1_interp(xs_2, ys_2, -1.01, 1.01, 1000);
			for(int i=0; i<res2.Length; i++){
				outfile.WriteLine($"{xx2[i]} {res2[i]}");
			}


			// Test 3 - interpolating the function
			outfile.WriteLine("\n");
			for(int i=0; i<xs_3.Length; i++){
				outfile.WriteLine($"{xs_3[i]} {ys_3[i]}");
			}

			outfile.WriteLine("\n");

			var (xx3, res3) = berrut.B1_interp(xs_3, ys_3, -1.01, 1.01, 1000);
			for(int i=0; i<res1.Length; i++){
				outfile.WriteLine($"{xx3[i]} {res3[i]}");
			}

			// Test 4 - interpolating the function
			outfile.WriteLine("\n");
			for(int i=0; i<xs_4.Length; i++){
				outfile.WriteLine($"{xs_4[i]} {ys_4[i]}");
			}

			outfile.WriteLine("\n");

			var (xx4, res4) = berrut.B1_interp(xs_4, ys_4, -1.01, 1.01, 1000);
			for(int i=0; i<res4.Length; i++){
				outfile.WriteLine($"{xx4[i]} {res4[i]}");
			}
			
			/* 1st approach
			// Test 1 - interpolating the function
			for(int i=0; i<xs_1.Length; i++){
				outfile.WriteLine($"{xs_1[i]} {ys_1[i]}");
			}

			outfile.WriteLine("\n");

			for(double z=-1.051; z<=1.051; z+=1.0/64){
				double q = berrut.B1_interp(z, xs_1, ys_1);
				outfile.WriteLine($"{z} {q}");
			}

			// Test 2 - interpolating the function
			outfile.WriteLine("\n");
			for(int i=0; i<xs_2.Length; i++){
				outfile.WriteLine($"{xs_2[i]} {ys_2[i]}");
			}

			outfile.WriteLine("\n");

			for(double z=-1.01; z<=1.01; z+=1.0/64){
				double q = berrut.B1_interp(z, xs_2, ys_2);
				outfile.WriteLine($"{z} {q}");
			}

			// Test 3 - interpolating the function
			outfile.WriteLine("\n");
			for(int i=0; i<xs_3.Length; i++){
				outfile.WriteLine($"{xs_3[i]} {ys_3[i]}");
			}

			outfile.WriteLine("\n");

			for(double z=-1.01; z<=1.01; z+=1.0/64){
				double q = berrut.B1_interp(z, xs_3, ys_3);
				outfile.WriteLine($"{z} {q}");
			}

			// Test 4 - interpolating the function
			outfile.WriteLine("\n");
			for(int i=0; i<xs_4.Length; i++){
				outfile.WriteLine($"{xs_4[i]} {ys_4[i]}");
			}

			outfile.WriteLine("\n");

			for(double z=-1.01; z<=1.01; z+=1.0/64){
				double q = berrut.B1_interp(z, xs_4, ys_4);
				outfile.WriteLine($"{z} {q}");
			}*/
		}

		// Compare to the cspline interpolation algorithm
		using(var outfile = new System.IO.StreamWriter("qspline_interpolation.txt")){
			// Test 1 - interpolating the function
			for(int i=0; i<xs_1.Length; i++){
				outfile.WriteLine($"{xs_1[i]} {ys_1[i]}");
			}

			outfile.WriteLine("\n");

			qspline s1 = new qspline(xs_1, ys_1);
			for(double z=-1.051; z<=1.051; z+=1.0/64){
				double q = s1.qspline_eval(z);
				outfile.WriteLine($"{z} {q}");
			}

			// Test 2 - interpolating the function
			outfile.WriteLine("\n");
			for(int i=0; i<xs_2.Length; i++){
				outfile.WriteLine($"{xs_2[i]} {ys_2[i]}");
			}

			outfile.WriteLine("\n");

			qspline s2 = new qspline(xs_2, ys_2);
			for(double z=-1.01; z<=1.01; z+=1.0/64){
				double q = s2.qspline_eval(z);
				outfile.WriteLine($"{z} {q}");
			}

			// Test 3 - interpolating the function
			outfile.WriteLine("\n");
			for(int i=0; i<xs_3.Length; i++){
				outfile.WriteLine($"{xs_3[i]} {ys_3[i]}");
			}

			outfile.WriteLine("\n");

			qspline s3 = new qspline(xs_3, ys_3);
			for(double z=-1.01; z<=1.01; z+=1.0/64){
				double q = s3.qspline_eval(z);
				outfile.WriteLine($"{z} {q}");
			}

			// Test 4 - interpolating the function
			outfile.WriteLine("\n");
			for(int i=0; i<xs_4.Length; i++){
				outfile.WriteLine($"{xs_4[i]} {ys_4[i]}");
			}

			outfile.WriteLine("\n");

			qspline s4 = new qspline(xs_4, ys_4);
			for(double z=-1.01; z<=1.01; z+=1.0/64){
				double q = s4.qspline_eval(z);
				outfile.WriteLine($"{z} {q}");
			}
		}
	}

}