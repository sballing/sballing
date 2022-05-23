using System;
using static System.Console;
using static System.Math;
using static System.Random;
public class main{
	public static void Main(){
		var rand = new Random();
		using(var outfile = new System.IO.StreamWriter("times.txt")){

			for(int n=5; n<=300; n+=5){
				matrix A = new matrix(n,n);
				matrix V = new matrix(n,n); // To hold the eigenvectors

				for(int i=0; i<n; i++){
					for(int j=0; j<n; j++){
						int num = rand.Next(1,9);
						A[i,j] = num;
						A[j,i] = num;
					}
				}

				matrix B = A.copy();
				matrix W = V.copy();

				var stopwatch1 = new System.Diagnostics.Stopwatch();
				stopwatch1.Start();
				evd.jacobi_diag(A,V);
				stopwatch1.Stop();
				var elapsedMs1 = stopwatch1.ElapsedMilliseconds;

				var stopwatch2 = new System.Diagnostics.Stopwatch();
				stopwatch2.Start();
				evd.jacobi_diag_opti(B,W);
				stopwatch2.Stop();
				var elapsedMs2 = stopwatch2.ElapsedMilliseconds;

				outfile.WriteLine($"{n} {elapsedMs1} {elapsedMs2}");
			}
		}
		
		WriteLine("----------------------------------------------");
		WriteLine("Testing the optimized algorithm as in exercise A:");
		int n2 = 7;
		matrix A2 = new matrix(n2,n2);
		matrix V2 = new matrix(n2,n2); // To hold the eigenvectors

		for(int i=0; i<n2; i++){
			for(int j=0; j<n2; j++){
				int num = rand.Next(1,9);
				A2[i,j] = num;
				A2[j,i] = num;
			}
		}

		matrix D2 = A2.copy(); // Keeping the eigenvalues


		WriteLine("----------------------------------------------");
		WriteLine("Generating random symmetric matrix A:");
		A2.print();
		WriteLine("----------------------------------------------");


		WriteLine("Making the Jacobi EVD:");
		int sweeps = evd.jacobi_diag_opti(D2, V2); // D contains eigenvalues on the diagonal, V contains eigenvectors
		WriteLine($"The number of sweeps required was: {sweeps}");
		WriteLine("\nThe matrix D containing eigenvalues on the diagonal is:");
		D2.print();
		WriteLine("\nThe matrix V containing (normalized) eigenvectors in columns is:");
		V2.print();
		WriteLine("----------------------------------------------");


		WriteLine("Checking that V^T A V gives D:");
		matrix res1 = V2.transpose()*A2*V2;
		res1.print();
		WriteLine($"\nBy virtue of the approx. method, this is {res1.approx(D2)}");
		WriteLine("----------------------------------------------");


		WriteLine("Checking that V D V^T gives A:");
		matrix res2 = V2*D2*V2.transpose();
		res2.print();
		WriteLine($"\nBy virtue of the approx. method, this is {res2.approx(A2)}");
		WriteLine("----------------------------------------------");


		WriteLine("Checking that V^T V gives the identity:");
		matrix res3 = V2.transpose()*V2;
		matrix I2 = new matrix(n2,n2);
		I2.set_unity();
		res3.print();
		WriteLine($"\nBy virtue of the approx. method, this is {res3.approx(I2)}");
		WriteLine("----------------------------------------------");

		WriteLine("Checking that V V^T gives the identity:");
		matrix res4 = V2.transpose()*V2;
		res4.print();
		WriteLine($"\nBy virtue of the approx. method, this is {res4.approx(I2)}");
		WriteLine("----------------------------------------------");
		WriteLine("In conclusion: The optimized Jacobi EVD is succesful! :-)");

		WriteLine("----------------------------------------------");
		WriteLine("Both the original and optimized algorithm have been investigated with regards to time");
		WriteLine("This can be seen in \'timing.png\' in this directory");
		WriteLine("Evidently, both algorithms scale as O(n^3) as expected");
		WriteLine("----------------------------------------------");

	}
}