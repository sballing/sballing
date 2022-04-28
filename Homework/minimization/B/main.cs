using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public class main{

	static List<double> Es,Ss,Us;

	public static double chi2(vector x){
		double m = x[0];
		double gamma = x[1];
		double A = x[2];
		double sum = 0;
		for(int i = 0; i<Es.Count; i++){
			double E = Es[i];
			double S = Ss[i];
			double U = Us[i];
			sum += (A*BW(E,m,gamma) - S)*(A*BW(E,m,gamma) - S)/(U*U);
		}
		return sum;
	} 

	public static double BW(double E, double m, double gamma){
		return 1/((E-m)*(E-m) + gamma*gamma/4);
	}

	public static void Main(){
		WriteLine("---------------------------------------------------");
		WriteLine("The implemented minimization algorithm is used for investigating the Higgs boson");
		WriteLine("In particular, the Breit-Wigner function is fitted");
		WriteLine("This is done by minimizing the chi2 function");

		// Loading the data properly
		List<double> data = new List<double>();
		int i = 0;

		string infile = "data.txt";
        var instream =new System.IO.StreamReader(infile);
        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
                string[] words = line.Split(" ");
                foreach(var word in words){
					double val = double.Parse(word);
					data.Add(val);
					i++;
                }
        }
        instream.Close();
        Es = new List<double>();
        Ss = new List<double>();
        Us = new List<double>();
        for(i=0; i<data.Count; i++){
        	if(i%3 == 0){Es.Add(data[i]);}
        	if(i%3 == 1){Ss.Add(data[i]);}
        	if(i%3 == 2){Us.Add(data[i]);}
        }

        vector x0 = new double[3] {100, 1, 1};
        WriteLine($"The initial guess is: ({x0[0]}, {x0[1]}, {x0[2]})");
        var(x, steps) = mini.qnewton(chi2, x0, acc: 1e-4);

        double m = Abs(x[0]);
        double gamma = Abs(x[1]);
        double A = Abs(x[2]);

        WriteLine($"Using the minimization algorithm, it is found that");
        WriteLine($"\n\tMass = {m}\n\tWidth = {gamma}\n\tAmplitude = {A}\n");
        WriteLine($"The minimization was done in {steps} steps");

		using(var outfile = new System.IO.StreamWriter("fit.txt")){
			for(double e = 100; e <= 160; e+=1.0/64){
				outfile.WriteLine($"{e} {A*BW(e, m, gamma)}");
			}
		}
		WriteLine("---------------------------------------------------");

		WriteLine("The fitted function is plotted alongside the data points");
		WriteLine("This can be seen in \'higgs.png\'");
		WriteLine("---------------------------------------------------");

	}

}