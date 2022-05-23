using static System.Console;
using static System.Math;
using static lspline;
public class main{
	public static void Main(){
		WriteLine("-----------------------------------------------------------");
		WriteLine("A linear interpolator has been implemented");
		WriteLine("It supports integration of the interpolant");
		WriteLine("The implementation is tested on sin(x) data points");
		double[] xs = new double[] {0, 0.4, 0.8, 1.2, 1.6, 2.0, 2.4, 2.8, 3.2, 3.6, 4.0, 4.4, 4.8, 5.2, 5.6, 6.0, 6.4};
		double[] ys = new double[17];
		for(int i=0; i<ys.Length; i++){ys[i]=Sin(xs[i]);}

		using(var outfile = new System.IO.StreamWriter("linterp.txt")){
		for(int i=0; i<xs.Length; i++){
			outfile.WriteLine($"{xs[i]} {ys[i]}");
		}
		outfile.WriteLine("\n");
		lspline s = new lspline(xs,ys);
			for(double z=0; z<=6.4; z+=1.0/64){
				double interp = s.lspline_eval(z);
				double integ = s.integ(z, -1);
				outfile.WriteLine($"{z} {interp} {integ}");
			}
		}

		WriteLine("The resulting interpolant and its integral can be seen in \'linterp.png\'");
		WriteLine("-----------------------------------------------------------");

	}
}