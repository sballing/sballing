using System;
using static System.Console;
using static System.Random;
public class main{
	public static void Main(string[] args){
		var rand = new Random();
		int N = 400;
		for(int n=10; n<=N; n+=10){
			matrix A = new matrix(n,n);
			matrix R = new matrix(n,n);
			for(int i=0; i<n; i++){
				for(int j=0; j<n; j++){
					A[i,j] = rand.Next(1,9);
				}
			}
			var stopwatch = new System.Diagnostics.Stopwatch();
			stopwatch.Start();
			lineq.QRGSdecomp(A,R);
			stopwatch.Stop();
			var elapsedMs = stopwatch.ElapsedMilliseconds;
			WriteLine($"{n} {elapsedMs}");
		}
	}
}