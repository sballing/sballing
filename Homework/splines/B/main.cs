using static System.Console;
public class main{
	public static void Main(){
		WriteLine("-----------------------------------------------------------");
		WriteLine("A quadratic interpolator has been implemented");
		WriteLine("It supports both integration and derivative of the interpolant");
		WriteLine("The implementation is tested on four different examples");
		double[] xs = new double[] {-5,-4,-3,-2,-1,0,1,2,3,4,5};
		double[] y1 = new double[xs.Length];
		double[] y2 = new double[xs.Length];
		double[] y3 = new double[xs.Length];
		for(int i=0; i<xs.Length; i++){
			y1[i] = 1;
			y2[i] = xs[i];
			y3[i] = xs[i]*xs[i];
		}

		using(var outfile = new System.IO.StreamWriter("qinterp.txt")){
			qspline s1 = new qspline(xs, y1);
			for(int i=0;i<xs.Length; i++){
				outfile.WriteLine($"{xs[i]} {y1[i]}");
			}
			outfile.WriteLine("\n");
			for(double z=-5; z<=5; z+=1.0/32){
				double interp = s1.qspline_eval(z);
				double integ = s1.integ(z,-4);
				double deriv = s1.deriv(z);
				outfile.WriteLine($"{z} {interp} {integ} {deriv}");
			}

			outfile.WriteLine("\n");
			qspline s2 = new qspline(xs, y2);
			for(int i=0;i<xs.Length; i++){
				outfile.WriteLine($"{xs[i]} {y2[i]}");
			}
			outfile.WriteLine("\n");
			for(double z=-5; z<=5; z+=1.0/32){
				double interp = s2.qspline_eval(z);
				double integ = s2.integ(z,6.5);
				double deriv = s2.deriv(z);
				outfile.WriteLine($"{z} {interp} {integ} {deriv}");
			}

			outfile.WriteLine("\n");
			qspline s3 = new qspline(xs, y3);
			for(int i=0;i<xs.Length; i++){
				outfile.WriteLine($"{xs[i]} {y3[i]}");
			}
			outfile.WriteLine("\n");
			for(double z=-5; z<=5; z+=1.0/32){
				double interp = s3.qspline_eval(z);
				double integ = s3.integ(z,-30);
				double deriv = s3.deriv(z);
				outfile.WriteLine($"{z} {interp} {integ} {deriv}");
			}

			double[] x0 = new double[] {-3.5, -2.5, -1.5, -0.5, 0.5, 1.5, 2.5, 3.5};
			double[] y0 = new double[] {0, 0, 0, 0, 1, 1, 1, 1};		 
			outfile.WriteLine("\n");
			qspline s4 = new qspline(x0, y0);
			for(int i=0;i<x0.Length; i++){
				outfile.WriteLine($"{x0[i]} {y0[i]}");
			}
			outfile.WriteLine("\n");
			for(double z=-3.5; z<=3.5; z+=1.0/32){
				double interp = s4.qspline_eval(z);
				double integ = s4.integ(z,0);
				double deriv = s4.deriv(z);
				outfile.WriteLine($"{z} {interp} {integ} {deriv}");
			}
		}

		WriteLine("\nThe four different examples can");
		WriteLine("be seen as subplots in \'qspline.png\'");
		WriteLine("-----------------------------------------------------------");

	}
}	