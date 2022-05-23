using System;
using static System.Console;
using static System.Math;
public class cmdline {

	public static void Main(string[] args){
		WriteLine("-------------------------------------------------");
		WriteLine("Reading from command line and printing their cosine and sine:\n");
		WriteLine("x\tsin(x)\t\t\tcos(x)\n");
		foreach(var arg in args){
			double x = double.Parse(arg);
			WriteLine($"{x}\t{Sin(x)}\t{Cos(x)}");
		}	
		WriteLine("-------------------------------------------------");
	}
}