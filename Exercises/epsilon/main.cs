using System;
using static System.Console;
using static System.Math;
public class epsilon{
	public static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9) {
		bool res = false;
		if(Abs(a-b) < tau) {res = true;}
		if(Abs(a-b)/(Abs(a)+Abs(b)) < epsilon) {res = true;}
		return res;
	}

	static void Main() {
		int i = 0;
		while(i+1>i) {i++;}
		WriteLine("------------------------------------------------------");
		WriteLine($"My max int (from while loop) is {i}");
		WriteLine($"My max int (from int.MaxValue) is {int.MaxValue}");

		int j = 0;
		while(j-1<j) {j--;}
		WriteLine("------------------------------------------------------");
		WriteLine($"My min int (from while loop) is {j}");
		WriteLine($"My min int (from int.MinValue) is {int.MinValue}");

		double x = 1;
		while(1+x!=1) {x/=2;} x*=2;

		float y=1F; 
		while((float)(1F+y) != 1F){y/=2F;} y*=2F;

		WriteLine("------------------------------------------------------");
		WriteLine($"Epsilon for double is {x}");
		WriteLine($"Epsilon for float is {y}");

		int n=(int)1e6;
		double epsilon=Pow(2,-52);
		double tiny=epsilon/2;
		double sumA=0,sumB=0;

		WriteLine("------------------------------------------------------");
		sumA+=1; for(int k=0;k<n;k++){sumA+=tiny;}
		WriteLine($"sumA-1 = {sumA-1:e}, should be {n*tiny:e}");

		for(int k=0;k<n;k++){sumB+=tiny;} sumB+=1;
		WriteLine($"sumB-1 = {sumB-1:e}, should be {n*tiny:e}");

		WriteLine("------------------------------------------------------");
		WriteLine("Testing the implemented approx method with a few examples");
		WriteLine($"1,2: {approx(1,2)}");
		WriteLine($"0,0: {approx(0,0)}");
		WriteLine($"0,1e-10: {approx(0,1e-10)}");
		WriteLine("------------------------------------------------------");
	}
}