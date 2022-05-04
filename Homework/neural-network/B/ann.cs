using System;
using static System.Math;
public class ann{

	public int n; // Number of hidden neurons
	public Func<double,double> f; // Activation function
	public Func<double,double> f_diff; // Derivative of activation function
	public Func<double,double> f_int; // Anti-derivative of activation function
	public vector p; // Parameters 

	public ann(int n, Func<double,double> f, Func<double,double> f_diff, Func<double,double> f_int){
		this.n = n;
		this.f = f;
		this.f_diff = f_diff;
		this.f_int = f_int;
		this.p = new vector(3*n);
	}

	public double response(double x){
		double Fp = 0;

		for(int i=0; i<n; i++){		// First access the a,b,c values from vector p, then evaluate Fp
			double a = p[3*i + 0];
			double b = p[3*i + 1];
			double w = p[3*i + 2];
			Fp += f((x - a)/b)*w;
		}

		return Fp;
	}

	public double response_diff(double x){
		double Fp_diff = 0;

		for(int i=0; i<n; i++){		// First access the a,b,c values from vector p, then evaluate Fp
			double a = p[3*i + 0];
			double b = p[3*i + 1];
			double w = p[3*i + 2];
			Fp_diff += f_diff((x - a)/b)*w/b;
		}

		return Fp_diff;
	}

	public double response_int(double x){
		double Fp_int = 0;

		for(int i=0; i<n; i++){		// First access the a,b,c values from vector p, then evaluate Fp
			double a = p[3*i + 0];
			double b = p[3*i + 1];
			double w = p[3*i + 2];
			Fp_int += f_int((x - a)/b)*w/b;
		}

		return Fp_int;
	}

	public void train(vector x, vector y){
		Func<vector,double> costfunction = C => {
			p = C;
			double sum = 0;

			for(int i=0; i<x.size; i++){
				sum += Pow(response(x[i]) - y[i], 2);
			}

			return sum/x.size;
		};

		vector v = p;
		var (res,nsteps) = mini.qnewton(costfunction, v);

		p = res;
	}

}