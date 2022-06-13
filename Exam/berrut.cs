using System;
using static System.Math;
public class berrut{

	public static double B1_interp(double x, double[] xs, double[] ys){ // x: point to evaluate, xs, ys: data data points to interpolate
		int n = xs.Length;

		double numer = 0;
		double denom = 0;

		/*for(int i=0; i<n; i++){
			numer += Pow(-1,i)/(x - xs[i])*ys[i];
			denom += Pow(-1,i)/(x - xs[i]);
		}*/

		for(int i=0; i<n; i++){
			double xdiff = x - xs[i];
			double temp = Pow(-1,i)/xdiff;
			numer += temp*ys[i];
			denom += temp;
		}

		return numer/denom;
	}

	public static void test(){
		System.Console.WriteLine("HelloWorld2");
	}

}