using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
public static class odeint{
	public static void Main(){
		double b=0.25, c=5.0;
		Func<double,vector,vector> f = delegate(double t, vector y){
			double theta=y[0], omega=y[1];
			return new vector(omega, -b*omega-c*Sin(theta));
		};
		double start=0, stop=10;
		vector y0 = new vector(PI-0.1, 0.0);
		var xlist = new List<double>();
		var ylist = new List<vector>();

		vector ystop = ode.ivp(f, start, y0, stop, xlist, ylist);

		for (int i=0; i<xlist.Count;i++){
			WriteLine($"{xlist[i]} {ylist[i][0]} {ylist[i][1]}");
		}
	}
}