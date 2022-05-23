using System;
using static System.Console;
using static System.Math;

public class stdin {
	
	public static void Main() {
		WriteLine("-------------------------------------------------");
		WriteLine("Reading from standard input stream and printing their cosine and sine:\n");
		WriteLine("x\tsin(x)\t\t\tcos(x)\n");
		char[] delimiters = {' ','\t','\n'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = ReadLine(); line != null; line = ReadLine()){
			var words = line.Split(delimiters,options);
			foreach(var word in words){
				double x = double.Parse(word);
				WriteLine($"{x}\t{Sin(x)}\t{Cos(x)}");
            }
        }
		WriteLine("-------------------------------------------------");
	}
}