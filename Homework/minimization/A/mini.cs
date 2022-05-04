using System;
using static System.Math;
using static System.Console;
public class mini{

	public static vector gradient(Func<vector,double>f, vector x){
		int n = x.size;
		vector g = new vector(n);
		double fx = f(x);

		double eps = Pow(2,-26);

		for(int i = 0; i < n; i++){
			double dx = Abs(x[i])*eps;
			if(Abs(x[i]) < Sqrt(eps)){
				dx = eps;
			}
			x[i] += dx;
			g[i] = (f(x)-fx)/dx;
			x[i] -= dx;
		}
		return g;
	}

	public static (vector, int) qnewton(Func<vector,double> f, vector xstart, double acc=1e-3){
		double eps = Pow(2,-26);
		int steps = 0;

		vector x = xstart.copy();
		int n = x.size;
		double fx = f(x);
		vector gx = gradient(f,x);

		matrix B = new matrix(n,n);
		B.set_unity();

		while(acc < gx.norm() && steps < 10000){ // We allow no more than 10000 steps
			steps++;
			vector dx = -B*gx; // Eq. 6 of notes

			if(dx.norm() < eps*x.norm()){ // Unsuccesful step
				Error.WriteLine("uups...");
				break;
			}
			if(dx.norm() < acc){ 		  // Unsuccesful step
				Error.WriteLine("uups...");
				break;
			}

			vector z;

			double fz, lambda = 1;
			
				while(true){
				z = x + dx*lambda;
				fz = f(z);
				if(fz < fx){
					break; // Accept step
				}
				if(lambda < eps){
					B.set_unity(); // Set B back to identity
					break;
				}
				lambda /= 2;
			}

			vector s = z - x;
			vector gz = gradient(f, z);
			vector y = gz - gx; // Below eq. 12
			vector u = s - B*y; // Below eq. 12

			double u_Trans_y = u.dot(y); // u^T * y for scaling, eq. 18

			if(Abs(u_Trans_y) > 1e-6){
				B.update(u,u, 1/u_Trans_y); // Rank-1 update according to eq. 18
			}
			else{B.set_unity();}

			x = z;
			gx = gz;
			fx = fz;
		}

		return (x, steps);
	}

}