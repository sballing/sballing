using System;
using static System.Console;
public class main{
	public static int Main(string[] args) {
		if(args.Length != 1) {
			Error.WriteLine("Need only one argument, i.e. the name of the file");
			return 1;
		}

		WriteLine("-------------------------------------------------------");
		WriteLine("Testing that the input file can be read, parsed,");
		WriteLine("and stored in a genlist and printed in scientific format:\n");

		var reader = new System.IO.StreamReader(args[0]);
		var list = new genlist<double[]>(); // Using the implemented genlist
		char[] delimiters = {' ','\t'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = reader.ReadLine(); line!=null; line = reader.ReadLine()) { // Reading the numbers from input file
			var words = line.Split(delimiters,options);
			int n = words.Length;
			var numbers = new double[n];
			for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
			list.push(numbers);
       		}
		for(int i=0;i<list.size;i++){ // Writing the parsed numbers in scientific format
			var numbers = list.data[i];
			foreach(var number in numbers)Write($"{number:e} ");
			WriteLine();
        }
        WriteLine("-------------------------------------------------------");
        return 0;
	}
}