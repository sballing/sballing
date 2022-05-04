using System;
using static System.Math;
public class ann{

	public int n; // Number of hidden neurons
	public Func<double,double> f; // Activation function
	public vector p; // Parameters 

	public ann(int n, Func<double,double> f){
		this.n = n;
		this.f = f;
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