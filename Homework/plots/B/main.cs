using System;
using static System.Console;
using static System.Math;
public class main{

	static double gamma(double x){
		if(x<0)return PI/Sin(PI*x)/gamma(1-x);
		if(x<9)return gamma(x+1)/x;
		double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return Exp(lngamma);
	}

	static double lngamma(double x){
		if(x<0){
			return Double.NaN;
		}
		if(x<9){
			return lngamma(x+1) - Log(x); // Similar to the gamma-implementation
		}
		double loggamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2; // Taken from other implementation
		return loggamma;
	}

	public static void Main(){
		WriteLine("---------------------------------------------------------");
		WriteLine("Computing and plotting the gamma function");

		using(var outfile = new System.IO.StreamWriter("gamma.txt")){
			for(double x=-5.1; x<=5.1; x+=1.0/32) {
				outfile.WriteLine($"{x} {gamma(x)}");
			}
		}

		WriteLine("The result can be seen in \'gamma.png\'");
		WriteLine("It is compared to table values (factorial)");
		WriteLine("---------------------------------------------------------");
		
		WriteLine("Computing and plotting the ln(gamma) function");

		using(var outfile = new System.IO.StreamWriter("lngamma.txt")){
			for(double x=0.001; x<=6; x+=1.0/32) {
				outfile.WriteLine($"{x} {lngamma(x)}");
			}
		}

		WriteLine("The result can be seen in \'lngamma.png\'");
		WriteLine("It is compared to table values");
		WriteLine("---------------------------------------------------------");

	}

}