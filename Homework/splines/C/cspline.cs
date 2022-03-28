using System;
using static System.Console;
using System.Diagnostics;
public class cspline{

	double[] x,y,b,c,d;

	private static int binsearch(double[] x, double z){
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public cspline(double[] xs, double[] ys){
		int n = xs.Length; Trace.Assert(ys.Length>=n);
		// Arrays to hold data points and polynomial coefficients
		x=new double[n];
		y=new double[n];
		b=new double[n];
		c=new double[n-1];
		d=new double[n-1];

		// Filling in the data points
		for(int i=0; i<n; i++){ 
			x[i] = xs[i];
			y[i] = ys[i];
		}
		// Arrays to hold matrix elements from the system of equations, see eq. 22
		var D = new double[n];
		var Q = new double[n-1];
		var B = new double[n];
		var h = new double[n-1];
		var p = new double[n-1];

		for(int i=0; i<n-1; i++){
			h[i] = x[i+1]-x[i];  // dx
			Trace.Assert(h[i]>0);
		}

		for(int i=0; i<n-1; i++){
			p[i] = (y[i+1]-y[i])/h[i]; // dy/dx
		}

		D[0]=2; Q[0]=1; B[0]=3*p[0]; D[n-1]=2; B[n-1]=3*p[n-2]; // Boundaries, eq. 23, 24, 25

		for(int i=0; i<n-2; i++){
			D[i+1] = 2*h[i]/h[i+1]+2; // eq. 23
			Q[i+1] = h[i]/h[i+1]; // eq. 24
			B[i+1] = 3*(p[i]+p[i+1]*h[i]/h[i+1]); // eq. 25
		}
		for(int i=1; i<n; i++){
			D[i] -= Q[i-1]/D[i-1];
			B[i] -= B[i-1]/D[i-1];
		}

		b[n-1] = B[n-1]/D[n-1];

		for(int i=n-2; i>=0; i--){
			b[i] = (B[i]-Q[i]*b[i+1])/D[i];
		}

		for(int i=0; i<n-1; i++){
			c[i] = (-2*b[i]-b[i+1]+3*p[i])/h[i];
			d[i] = (b[i]+b[i+1]-2*p[i])/(h[i]*h[i]);
		}

	}

	public double cspline_eval(double z){ //Evaluating the spline at point z
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		int idx=binsearch(x,z);
		double dx=z-x[idx];
		return y[idx]+dx*(b[idx]+dx*(c[idx]+dx*d[idx]));
	}

	public double deriv(double z){ // Calculating derivative of spline at point z
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		int idx=binsearch(x,z);
		double dx=z-x[idx];
		return b[idx]+dx*(2*c[idx]+dx*3*d[idx]);
	}

	public double integ(double z, double cst){ // Calculating integral of spline at point z
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		int idx=binsearch(x,z);
		double sum=0,dx;
		for(int i=0;i<idx;i++){
			dx=x[i+1]-x[i];
			sum+=dx*(y[i]+dx*(b[i]/2+dx*(c[i]/3+dx*d[i]/4)));
			}
		dx=z-x[idx];
		sum+=dx*(y[idx]+dx*(b[idx]/2+dx*(c[idx]/3+dx*d[idx]/4)));
		return sum+cst;
	}

}