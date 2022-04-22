using System;
using static System.Math;
public class roots{

	public static vector newton(Func<vector,vector> f, vector x0, double eps = 1e-2){
		for(int i=0; i<x0.size; i++){
			if(x0[i] == 0){x0[i] = 1e-5;}
		}

		vector x = x0.copy();
		int n = x.size;
		matrix J = new matrix(n,n);

		vector y = new vector(n), fy = new vector(n);
		double dx = 0;

		bool scan1 = true;
		while(scan1){
			vector fx = f(x);
			for(int j=0; j<n; j++){
				dx = Abs(x[j])*Pow(2,-26);
				x[j] += dx;
				vector df = f(x) - fx;

				for(int i=0; i<n; i++){
					J[i,j] = df[i]/dx;
				}
				x[j] -= dx;
			}
			matrix R = new matrix(n,n);
			matrix Q = J.copy();
			lineq.QRGSdecomp(Q,R);
			vector Dx = lineq.QRGSsolve(Q,R, -fx); // Newton's step

			double s = 2.0;
			bool scan2 = true;
			while(scan2){
				s /= 2;
				y = x + Dx*s;
				fy = f(y);

				if(fy.norm() < (1 - s/2)*fx.norm() || s < 1.0/64){scan2 = false;}
			}
			x = y;
			fx = fy;

			if(Dx.norm() < dx || fx.norm() < eps){scan1 = false;}
		}

		return x;	
	}
	
}