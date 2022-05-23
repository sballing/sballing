using System;
using static System.Console;
using static System.Math;
public class main{
	public static void Main(){
		WriteLine("--------------------------------------");
		WriteLine("Solving the 3-body gravitational problem using the implemented ODE-solver");
		WriteLine("Initial values for the stable figure 8 solution was found at:");
		WriteLine("http://www.artcompsci.org/msa/web/vol_1/v1_web/node45.html");
		WriteLine("The result is plotted in figure \'figure8.png\'");
		WriteLine("--------------------------------------");

		Func<double,vector,vector> f = delegate(double t, vector y){
			double pos1x = y[0], pos1y = y[1];
			vector pos1 = new vector(pos1x, pos1y);
			double vel1x = y[2], vel1y = y[3];
			vector vel1 = new vector(vel1x, vel1y);

			double pos2x = y[4], pos2y = y[5];
			vector pos2 = new vector(pos2x, pos2y);
			double vel2x = y[6], vel2y = y[7];
			vector vel2 = new vector(vel2x, vel2y);

			double pos3x = y[8], pos3y = y[9];
			vector pos3 = new vector(pos3x, pos3y);
			double vel3x = y[10], vel3y = y[11];
			vector vel3 = new vector(vel3x, vel3y);

			// All constants set to 1
			vector dv1dt = -(pos1 - pos2)/Pow((pos1 - pos2).norm(), 3) - (pos1 - pos3)/Pow((pos1 - pos3).norm(), 3);
			vector dv2dt = -(pos2 - pos1)/Pow((pos2 - pos1).norm(), 3) - (pos2 - pos3)/Pow((pos2 - pos3).norm(), 3);
			vector dv3dt = -(pos3 - pos1)/Pow((pos3 - pos1).norm(), 3) - (pos3 - pos2)/Pow((pos3 - pos2).norm(), 3);

			double[] ode = new double[12] {vel1[0], vel1[1], dv1dt[0], dv1dt[1],
										vel2[0], vel2[1], dv2dt[0], dv2dt[1],
										vel3[0], vel3[1], dv3dt[0], dv3dt[1]};

			return new vector(ode);
		};

		double start=0, stop=10;

		// Initial values found at http://www.artcompsci.org/msa/web/vol_1/v1_web/node45.html
		double pos1x0 = 0.9700436, pos1y0 = -0.24308753, vel1x0 = 0.466203685, vel1y0 = 0.432366573;
		double pos2x0 = -pos1x0, pos2y0 = -pos1y0, vel2x0 = vel1x0, vel2y0 = vel1y0;
		double pos3x0 = 0.0, pos3y0 = 0.0, vel3x0 = -2*vel1x0, vel3y0 = -2*vel1y0;

		double[] iv_arr = new double[] {pos1x0, pos1y0, vel1x0, vel1y0,
										pos2x0, pos2y0, vel2x0, vel2y0,
										pos3x0, pos3y0, vel3x0, vel3y0};

		vector iv = new vector(iv_arr);

		var xlist = new genlist<double>();
		var ylist = new genlist<vector>();

		rk.driver(f, start, iv, stop, xlist, ylist);

		using(var outfile = new System.IO.StreamWriter("solution.txt")){
			for (int i=0; i<xlist.size; i++) {
				outfile.Write($"{xlist.data[i]} ");
				for (int j=0; j<ylist.data[0].size; j++) {
					outfile.Write($"{ylist.data[i][j]} ");
				}
				outfile.Write("\n");
			}
		}
		
	}
}