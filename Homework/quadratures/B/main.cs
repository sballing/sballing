using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		WriteLine("Note that Python packages NumPy and SciPy are required to run this program!");
		WriteLine("----------------------------------------------------------");
		WriteLine("Testing the new implementation:");
		WriteLine("The number of function calls is investigated (ideally minimized)\n");

		int i=0, j=0, k=0, l=0;
		double a=0.0, b=1.0;
		Func<double,double> f11 = x => {i++; return 1/Sqrt(x);};
		Func<double,double> f12 = x => {j++; return 1/Sqrt(x);};
		Func<double,double> f21 = x => {k++; return Log(x)/Sqrt(x);};
		Func<double,double> f22 = x => {l++; return Log(x)/Sqrt(x);};


		double res11 = integrator.quad(f11, a, b);
		double res12 = integrator.vt_quad(f12, a, b);

		double res21 = integrator.quad(f21, a, b);
		double res22 = integrator.vt_quad(f22, a, b);

		WriteLine($"1/sqrt(x) - old implementation: {res11}. It took {i} iterations.");
		WriteLine($"1/sqrt(x) - new implementation: {res12}. It took {j} iterations.\n");

		WriteLine($"log(x)/sqrt(x) - old implementation: {res21}. It took {k} iterations.");
		WriteLine($"log(x)/sqrt(x) - new implementation: {res22}. It took {l} iterations.\n");

		WriteLine("Hence, the variable transformation results in significantly fewer calls to the function");
		WriteLine("----------------------------------------------------------");
		WriteLine("Testing the Python SciPy routine for comparison:\n");
		var instream =new System.IO.StreamReader("python_res.txt");
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
        	WriteLine(line);
        }
		instream.Close();
		WriteLine();
		WriteLine("Evidently, the Python routine is somewhere between the original and optimized implementation");
		WriteLine("----------------------------------------------------------");


	}
}