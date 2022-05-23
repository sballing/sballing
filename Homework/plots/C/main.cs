using System;
using static System.Console;
using static System.Math;
public class main {
	public static void Main(){
		WriteLine("-----------------------------------------------------------------");
		WriteLine("Computing and plotting the complex gamma function in a complex space");
		WriteLine("The plot is illustrated using PyxPlot's \'plot 3d\'");

		using(var outfile = new System.IO.StreamWriter("cgamma.txt")){
			for(double i=-5.1; i<=5.1; i+=1.0/8){
				for(double j=-5.1; j<=5.1; j+=1.0/8){
					complex z = new complex(i,j);
					complex gamma = G(z);
					double absgamma = cmath.abs(gamma);
					outfile.WriteLine($"{z.Re} {z.Im} {absgamma}");
				}
			}
		}
		WriteLine("The resulting plot can be seen in \'cgamma.png\'");
		WriteLine("-----------------------------------------------------------------");
	}

	public static complex G(complex z){
		if(cmath.abs(z)<0) return PI/cmath.sin(PI*z)/G(1-z);
		if(cmath.abs(z)<9) return G(z+1)/z;
		complex lngamma=z*cmath.log(z+1/(12*z-1/z/10))-z+cmath.log(2*PI/z)/2;
		return cmath.exp(lngamma);
	}
}