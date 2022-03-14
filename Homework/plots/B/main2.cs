using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		for(double x=0.001; x<=6; x+=1.0/32) {
			WriteLine($"{x} {lngamma(x)}");
		}
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
}