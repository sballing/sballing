using System;
using static System.Console;
using static System.Math;

public class stdin {
	public static void Main(string[] args) {
		char[] delimiters = {' ','\t','\n'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = ReadLine(); line != null; line = ReadLine()){
			var words = line.Split(delimiters,options);
			foreach(var word in words){
				double x = double.Parse(word);
				WriteLine($"{x} {Sin(x)} {Cos(x)}");
            }
        }
	}
}