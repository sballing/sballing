using System; 
using static System.Math;
using static System.Console;
public class rk{

	public static (vector, vector) rkstep45(Func<double, vector, vector> f,	double x, vector y, double h){
		// Table for rkf45
		vector k1 = h*f(x,y);
		vector k2 = h*f(x + 1.0/4*h, y + 1.0/4*k1);
		vector k3 = h*f(x + 3.0/8*h, y + 3.0/32*k1 + 9.0/32*k2);
		vector k4 = h*f(x + 12.0/13*h, y + 1932.0/2197*k1 + (-7200.0/2197)*k2 + 7296.0/2197*k3);
		vector k5 = h*f(x + h, y + 439.0/216*k1 + (-8.0)*k2 + 3680.0/513*k3 + (-845.0/4104)*k4);
		vector k6 = h*f(x + 1.0/2*h, y + (-8.0/27)*k1 + 2.0*k2 + (-3544.0/2565)*k3 + 1859.0/4104*k4 + (-11.0/40)*k5);


		vector yh = y + 16.0/135*k1 + 0.0*k2 + 6656.0/12825*k3 + 28561.0/56430*k4 + (-9.0/50)*k5 + 2.0/55*k6; // Eq. 18
		vector err = (16.0/135-25.0/216)*k1 + (0.0-0.0)*k2 + (6656.0/12825-1408.0/2565)*k3 + (28561.0/56430-2197.0/4104)*k4 + (-9.0/50+1.0/5)*k5 + (2.0/55-0)*k6; // Eq. 23
		return (yh, err);
	}

	public static vector driver(Func<double,vector,vector> f, 
					double a, vector ya, double b, 
					genlist<double> xlist=null, genlist<vector> ylist=null,
					double h=0.01, double acc=1e-8, double eps=1e-8){
		if(a>b) {throw new Exception("Cannot drive since a>b");}	
		double x = a;
		vector y = ya;
		if(xlist != null && ylist != null){
			xlist.push(x); // Remember to add initial points
			ylist.push(ya);
		}

		do{
			if(x>=b) {return y;}
			if(x+h>b) {h=b-x;}
			var (yh,err_vec) = rkstep45(f, x, y, h);
			vector tol = new vector(err_vec.size);
			bool ok = true;
			for(int i=0; i<tol.size; i++){
				tol[i] = Max(acc, Abs(yh[i])*eps)*Sqrt(h/(b-a));
				ok = ok && err_vec[i]<tol[i];
			}
			if(ok){
				x += h; 
				y=yh;
				if(xlist != null && ylist != null){
					xlist.push(x);
					ylist.push(y);
				}
			}
			double factor = tol[0]/Abs(err_vec[0]);
			for(int i=1; i<tol.size; i++){
				factor = Min(factor, tol[i]/Abs(err_vec[i]));
			}
			h = h*Min(Pow(factor, 0.25)*0.95, 2);
		} while(true);
	}
}