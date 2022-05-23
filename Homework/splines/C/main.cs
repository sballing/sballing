using static System.Console;
public class main{
	public static void Main(){
		WriteLine("-----------------------------------------------------------");
		WriteLine("A cubic interpolator has been implemented");
		WriteLine("It supports both integration and derivative of the interpolant");
		WriteLine("The implementation is tested on two different examples");
		WriteLine("Furthermore, the interpolant is compared to PyxPlot's interpolator");
		double[] x0 = new double[] {-3.5, -2.5, -1.5, -0.5, 0.5, 1.5, 2.5, 3.5};
		double[] y0 = new double[] {0, 0, 0, 0, 1, 1, 1, 1};		 

		using(var outfile = new System.IO.StreamWriter("cinterp.txt")){
			cspline s1 = new cspline(x0, y0);
			for(int i=0;i<x0.Length; i++){
				outfile.WriteLine($"{x0[i]} {y0[i]}");
			}
			outfile.WriteLine("\n");
			for(double z=-3.5; z<=3.5; z+=1.0/32){
				double interp = s1.cspline_eval(z);
				outfile.WriteLine($"{z} {interp}");
			}

			double[] xs = new double[] {-5,-4,-3,-2,-1,0,1,2,3,4,5};
			double[] ys = new double[xs.Length];
			for(int i=0; i<xs.Length; i++){
				ys[i] = xs[i]*xs[i];
			}
			outfile.WriteLine("\n");
			cspline s2 = new cspline(xs, ys);
			for(int i=0;i<xs.Length; i++){
				outfile.WriteLine($"{xs[i]} {ys[i]}");
			}
			outfile.WriteLine("\n");
			for(double z=-5; z<=5; z+=1.0/32){
				double interp = s2.cspline_eval(z);
				double integ = s2.integ(z, -30);
				double deriv = s2.deriv(z);
				outfile.WriteLine($"{z} {interp} {integ} {deriv}");
			}
		}
		WriteLine("The agreement is very satisfactory");
		WriteLine("-----------------------------------------------------------");
	}
}	