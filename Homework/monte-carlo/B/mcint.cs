using System;
using static System.Math;
public class mcint{

	public static (double, double) plainmc(Func<vector,double> f, vector a, vector b, int N){
		var rand = new Random();

		int dim = a.size;
		double V = 1.0; 
		for(int i=0; i<dim; i++){
			V *= b[i] - a[i];
		}
		double sum = 0, sum2 = 0;

		var x = new vector(dim);
		for(int i=0; i<N; i++){
			for(int k=0; k<dim; k++){
				x[k] = a[k] + rand.NextDouble()*(b[k] - a[k]);
			}
			double fx = f(x);
			sum += fx;
			sum2 += fx*fx;
		}

		double mean = sum/N;
		double sigma = Sqrt(sum2/N - mean*mean);
		var res = (mean*V, sigma*V/Sqrt(N));
		return res;
	}

	public static (double, double) haltonmc(Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;
		double V = 1.0;
		for(int i=0; i<dim; i++){
			V *= b[i] - a[i];
		}
		double sum = 0, sum2 = 0; // Two sequences are used in order to estimate the error

		double[] x = new double[dim];
		double[] x2 = new double[dim];

        int offset=0; // We can skip diverging points


		for(int i=0; i<N; i++){
			double[] quas = halton(i+offset, dim);
			double[] quas2 = halton(i+offset, dim, 4); //Base shifted to 2nd sequence
			
			for(int k=0; k<dim; k++){
				x[k] = a[k] + quas[k]*(b[k] - a[k]);
				x2[k] = a[k] + quas2[k]*(b[k] - a[k]);
			}

			double fx = f(x);
			double fx2 = f(x2);

			if (double.IsNaN(fx) || double.IsInfinity(fx) || double.IsNaN(fx2) || double.IsInfinity(fx2)){
				--i; ++offset;
			}

			else{
				sum += fx;
				sum2 += fx2;
			}
		}

		double mean = sum/N;
		double mean2 = sum2/N;
		var res = (mean*V, Abs(mean*V - mean2*V));

		return res;

	}

	public static double corput(int n, int Base){
		double q = 0, bk = 1.0/Base;
		while(n>0){
			q += (n % Base)*bk;
			n /= Base;
			bk /= Base;
		}

		return q;
	}


	public static double[] halton(int n, int d, int sec=0){
		int[] Base = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67};
		if(d>Base.Length){
			throw new System.Exception("Dimension is too large for the Halton approach");
		}
		
		double[] x = new double[d];

		for(int i=0; i<d; i++){
			x[i] = corput(n, Base[(i+sec)%Base.Length]);
		}
		return x;
	} 

}