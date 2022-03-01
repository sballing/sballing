using System;
using static System.Console;
using static System.Math;
public class main{

	public static void Main(){
		for(double x=-5.1; x<=5.1; x+=1.0/32) {
			WriteLine($"{x} {gamma(x)}");
		}
	}

	static double gamma(double x){
		if(x<0)return PI/Sin(PI*x)/gamma(1-x);
		if(x<9)return gamma(x+1)/x;
		double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return Exp(lngamma);
	}
}