using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		WriteLine("For details about the examination project, see the ReadMe-file");

		// Test 1 - setting the data points
		double[] xs_1 = new double[] {-1.05, -0.75, -0.45, -0.15, 0.15, 0.45, 0.75, 1.05};
		double[] ys_1 = new double[] {0, 0, 0, 0, 1, 1, 1, 1};

		// Test 2 - setting the data points
		int n = 12;
		double[] xs_2 = berrut.linspace(-1, 1, n);
		double[] ys_2 = new double[xs_2.Length];
		Func<double,double> f2 = x => 1/(1 + 25*x*x);
		for(int i=0; i<xs_2.Length; i++){
			ys_2[i] = f2(xs_2[i]);
		}

		// Test 3 - setting the data points
		double[] xs_3 = berrut.linspace(-1, 1, n);
		double[] ys_3 = new double[xs_3.Length];
		Func<double,double> f3 = x => Abs(x) + x/2 - x*x;
		for(int i=0; i<xs_3.Length; i++){
			ys_3[i] = f3(xs_3[i]);
		}

		// Test 4 - setting the data points
		double[] xs_4 = berrut.linspace(-1, 1, n);
		double[] ys_4 = new double[xs_4.Length];
		Func<double,double> f4 = x => Cos(10*x)*Exp(-x);
		for(int i=0; i<xs_4.Length; i++){
			ys_4[i] = f4(xs_4[i]);
		}

		// Making Berrut and qspline interpolations for 4 different test

		// Test 1
		using(var outfile = new System.IO.StreamWriter("test1.txt")){

			for(int i=0; i<xs_1.Length; i++){
				outfile.WriteLine($"{xs_1[i]} {ys_1[i]}");
			}

			outfile.WriteLine("\n");

			var (xx, res) = berrut.B1_interp(xs_1, ys_1, -1.051, 1.051, 1000);
			for(int i=0; i<res.Length; i++){
				outfile.WriteLine($"{xx[i]} {res[i]}");
			}

			outfile.WriteLine("\n");

			qspline s = new qspline(xs_1, ys_1);
			for(double z=-1.051; z<=1.051; z+=1.0/64){
				double q = s.qspline_eval(z);
				outfile.WriteLine($"{z} {q}");
			}
		}

		// Test 2
		using(var outfile = new System.IO.StreamWriter("test2.txt")){

			for(int i=0; i<xs_3.Length; i++){
				outfile.WriteLine($"{xs_2[i]} {ys_2[i]}");
			}

			outfile.WriteLine("\n");

			var (xx, res) = berrut.B1_interp(xs_2, ys_2, -1.01, 1.01, 1000);
			for(int i=0; i<res.Length; i++){
				outfile.WriteLine($"{xx[i]} {res[i]}");
			}

			outfile.WriteLine("\n");

			qspline s = new qspline(xs_2, ys_2);
			for(double z=-1.01; z<=1.01; z+=1.0/64){
				double q = s.qspline_eval(z);
				outfile.WriteLine($"{z} {q}");
			}
		}

		// Test 3
		using(var outfile = new System.IO.StreamWriter("test3.txt")){

			for(int i=0; i<xs_3.Length; i++){
				outfile.WriteLine($"{xs_3[i]} {ys_3[i]}");
			}

			outfile.WriteLine("\n");

			var (xx, res) = berrut.B1_interp(xs_3, ys_3, -1.01, 1.01, 1000);
			for(int i=0; i<res.Length; i++){
				outfile.WriteLine($"{xx[i]} {res[i]}");
			}

			outfile.WriteLine("\n");

			qspline s = new qspline(xs_3, ys_3);
			for(double z=-1.01; z<=1.01; z+=1.0/64){
				double q = s.qspline_eval(z);
				outfile.WriteLine($"{z} {q}");
			}
		}

		// Test 4
		using(var outfile = new System.IO.StreamWriter("test4.txt")){

			for(int i=0; i<xs_4.Length; i++){
				outfile.WriteLine($"{xs_4[i]} {ys_4[i]}");
			}

			outfile.WriteLine("\n");

			var (xx, res) = berrut.B1_interp(xs_4, ys_4, -1.01, 1.01, 1000);
			for(int i=0; i<res.Length; i++){
				outfile.WriteLine($"{xx[i]} {res[i]}");
			}

			outfile.WriteLine("\n");

			qspline s = new qspline(xs_4, ys_4);
			for(double z=-1.01; z<=1.01; z+=1.0/64){
				double q = s.qspline_eval(z);
				outfile.WriteLine($"{z} {q}");
			}
		}
	}

}