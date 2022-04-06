using System;
using static System.Double;
using static System.Math;
public class integrator{

	public static double quad(Func<double,double> f, double a, double b,
		double delta=1e-6, double eps=1e-6, double f2=NaN, double f3=NaN){

		double h = b-a;

		if(IsNaN(f2)){ // First call
			f2 = f(a + 2*h/6);
			f3 = f(a + 4*h/6);
		}

		double f1 = f(a + h/6);
		double f4 = f(a + 5*h/6);

		double Q = (2*f1 + f2 + f3 + 2*f4)/6*(b-a);
		double q = (f1 + f2 + f3 + f4)/4*(b-a);

		double err = Abs(Q-q);
		double tol = Max(delta, eps*Abs(Q));

		if(err <= tol) {return Q;}
		else{
			return quad(f, a, (a+b)/2, delta/Sqrt(2), eps, f1, f2) + quad(f, (a+b)/2, b, delta/Sqrt(2), eps, f3, f4);
		}
	}

}