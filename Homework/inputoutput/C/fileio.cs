using System;
using static System.Console;
using static System.Math;

public class file {

	public static int Main(string[] args){
        string infile=null,outfile=null;
        foreach(var arg in args){
                var words=arg.Split(':');
                if(words[0]=="-input")infile=words[1];
                else if(words[0]=="-output")outfile=words[1];
                else { Error.WriteLine("wrong argument"); return 1; }
                }
        var instream =new System.IO.StreamReader(infile);
        var outstream=new System.IO.StreamWriter(outfile);
        outstream.WriteLine("-------------------------------------------------");
        outstream.WriteLine("Reading from input file and printing their cosine and sine:\n");
        outstream.WriteLine("x\tsin(x)\t\t\tcos(x)\n");
        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
                double x=double.Parse(line);
                outstream.WriteLine($"{x}\t{Sin(x)}\t{Cos(x)}");
        }
        outstream.WriteLine("-------------------------------------------------");
        instream.Close();
        outstream.Close();
	return 0;
	}

}