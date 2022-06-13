using System;
using static System.Math;
public class berrut{

	/*public static double B1_interp(double x, double[] xs, double[] ys){ // x: point to evaluate, xs, ys: data data points to interpolate
		int n = xs.Length;

		double numer = 0;
		double denom = 0;

		for(int i=0; i<n; i++){
			double xdiff = x - xs[i];
			double temp = Pow(-1,i)/xdiff;
			numer += temp*ys[i];
			denom += temp;
		}

		return numer/denom;
	}*/

	public static double[] linspace(double x0, double x1, int N){
		double step = (x1 - x0)/(N - 1);
		double[] y = new double[N];
		for(int i=0; i<N; i++){
			y[i] = x0 + step*i;
		}
		return y;
	}

	public static (double[],double[]) B1_interp(double[] xs, double[] ys, double x0, double x1, int N){
		int n = xs.Length;

		double[] c = new double[n+1];
		c[0] = 1.0/2;
		c[n] = 1.0/2*Pow(-1,n);

		for(int i=1; i<n; i++){
			c[i] = Pow(-1,i);
		}

		double[] xx = linspace(x0, x1, N);

		double[] numer = new double[xx.Length];
		double[] denom = new double[xx.Length];
		double[] res = new double[xx.Length];

		for(int i=0; i<xx.Length; i++){
			for(int j=0; j<n; j++){
				double xdiff = xx[i] - xs[j];
				double temp = c[j]/xdiff;
				numer[i] += temp*ys[j];
				denom[i] += temp;
			}
			res[i] = numer[i]/denom[i];
		}

		/*for(int j=0; j<n; j++){
			for(int i=0; i<xx.Length; i++){
				double xdiff = xx[i]-xs[j];
				double temp = c[j]/xdiff;
				numer[i] = numer[i] + temp*ys[j];
				denom[i] = denom[i] + temp;
				res[i] = numer[i]/denom[i];
			}
		}*/

		return (xx, res);
	}

	/*public static (double[],double[]) B1_interp(double[] xs, double[] ys, double x0, double x1, int N){
		int n = xs.Length;

		double[] c = new double[n+1];
		for(int i=0; i<=n; i++){
			if(i==0 || i==n+1){
				c[i] = 1.0/2*Pow(-1,i);
			}
			else{
				c[i] = Pow(-1,i);
			}
		}

		double[] xx = linspace(x0, x1, N);

		double[] numer = new double[xx.Length];
		double[] denom = new double[xx.Length];

		for(int j=0; j<n; j++){
			for(int i=0; i<xx.Length; i++){
				double xdiff = xx[i]-xs[j];
				double temp = c[j]/xdiff;
				numer[i] += temp*ys[j];
				denom[i] += temp;
			}
		}

		double[] res = new double[numer.Length];
		for(int i=0; i<res.Length; i++){
			res[i] = numer[i]/denom[i];
		}

		return (xx, res);
	}*/

}