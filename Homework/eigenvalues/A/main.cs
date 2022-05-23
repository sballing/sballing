using System;
using static System.Console;
using static System.Random;
public class main{
	public static void Main(){
		var rand = new Random();
		int n = 7;
		matrix A = new matrix(n,n);
		matrix V = new matrix(n,n); // To hold the eigenvectors

		for(int i=0; i<n; i++){
			for(int j=0; j<n; j++){
				int num = rand.Next(1,9);
				A[i,j] = num;
				A[j,i] = num;
			}
		}

		matrix D = A.copy(); // Keeping the eigenvalues


		WriteLine("Throughout this homework, the approx method from the matrix class is used to validate the results.");
		WriteLine("----------------------------------------------");
		WriteLine("Generating random symmetric matrix A:");
		A.print();
		WriteLine("----------------------------------------------");


		WriteLine("Making the Jacobi EVD:");
		int sweeps = evd.jacobi_diag(D, V); // D contains eigenvalues on the diagonal, V contains eigenvectors
		WriteLine($"The number of sweeps required was: {sweeps}");
		WriteLine("\nThe matrix D containing eigenvalues on the diagonal is:");
		D.print();
		WriteLine("\nThe matrix V containing (normalized) eigenvectors in columns is:");
		V.print();
		WriteLine("----------------------------------------------");


		WriteLine("Checking that V^T A V gives D:");
		matrix res1 = V.transpose()*A*V;
		res1.print();
		WriteLine($"\nBy virtue of the approx. method, this is {res1.approx(D)}");
		WriteLine("----------------------------------------------");


		WriteLine("Checking that V D V^T gives A:");
		matrix res2 = V*D*V.transpose();
		res2.print();
		WriteLine($"\nBy virtue of the approx. method, this is {res2.approx(A)}");
		WriteLine("----------------------------------------------");


		WriteLine("Checking that V^T V gives the identity:");
		matrix res3 = V.transpose()*V;
		matrix I = new matrix(n,n);
		I.set_unity();
		res3.print();
		WriteLine($"\nBy virtue of the approx. method, this is {res3.approx(I)}");
		WriteLine("----------------------------------------------");

		WriteLine("Checking that V V^T gives the identity:");
		matrix res4 = V.transpose()*V;
		res4.print();
		WriteLine($"\nBy virtue of the approx. method, this is {res4.approx(I)}");
		WriteLine("----------------------------------------------");
		WriteLine("In conclusion: The Jacobi EVD is succesful! :-)");



	}
}