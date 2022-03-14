using static System.Console;
public class main{
	public static void Main(){
		WriteLine("\n");
		double[] x0 = new double[] {-3.5, -2.5, -1.5, -0.5, 0.5, 1.5, 2.5, 3.5};
		double[] y0 = new double[] {0, 0, 0, 0, 1, 1, 1, 1};		 
		cspline s1 = new cspline(x0, y0);
		for(int i=0;i<x0.Length; i++){
			WriteLine($"{x0[i]} {y0[i]}");
		}
		WriteLine("\n");
		for(double z=-3.5; z<=3.5; z+=1.0/32){
			double interp = s1.cspline_eval(z);
			WriteLine($"{z} {interp}");
		}

		double[] xs = new double[] {-5,-4,-3,-2,-1,0,1,2,3,4,5};
		double[] ys = new double[xs.Length];
		for(int i=0; i<xs.Length; i++){
			ys[i] = xs[i]*xs[i];
		}
		WriteLine("\n");
		cspline s2 = new cspline(xs, ys);
		for(int i=0;i<xs.Length; i++){
			WriteLine($"{xs[i]} {ys[i]}");
		}
		WriteLine("\n");
		for(double z=-5; z<=5; z+=1.0/32){
			double interp = s2.cspline_eval(z);
			double integ = s2.integ(z, -30);
			double deriv = s2.deriv(z);
			WriteLine($"{z} {interp} {integ} {deriv}");
		}
	}
}	