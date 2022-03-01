using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		for(double x=0.1; x<=77; x+=1.0/8) {
			WriteLine($"{x} {lngamma(x)}");
		}
	}

	static double lngamma(double x){
		return x*Log(x) - x - 1/2*Log(x) + 1/2*Log(2*PI) + 1/(12*x) - 1/(360*x*x*x) + 1/(1260*x*x*x*x*x);
	}
}