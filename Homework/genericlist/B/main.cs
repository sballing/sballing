using System;
using static System.Console;
public class main{
	public static int Main(string[] args) {
		if(args.Length != 1) {
			Error.WriteLine("Need only one argument, i.e. the name of the file");
			return 1;
		}
		WriteLine("-------------------------------------------------");
		WriteLine("Testing the new push functionality on the input file");
		WriteLine();
		var reader = new System.IO.StreamReader(args[0]);

		var list = new genlist<double[]>();
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

        WriteLine();
        WriteLine("-------------------------------------------------");
        WriteLine("Testing the remove method on a genlist of integers");
        WriteLine();
        var list2 = new genlist<int>();
        list2.push(1);
        list2.push(1);
        list2.push(2);
        list2.push(3);
        list2.push(5);
        list2.push(8);
        list2.push(13);
        WriteLine("Printing original list of numbers");
        for(int i=0;i<list2.data.Length-1;i++) {
			WriteLine($"{list2.data[i]}");
		}
		WriteLine();
		WriteLine("Removing element 4 (C# has 0-indexing) and printing again");
		list2.remove(4);
        for(int i=0;i<list2.data.Length-1;i++) {
			WriteLine($"{list2.data[i]}");
		}
		WriteLine("-------------------------------------------------");

        return 0;
	}
}