using System;
using static System.Console;
using static System.Random;
public class main{
	public static void Main(){
		WriteLine("----------------------------------------------");
		int n = 8;

		var rand = new Random();

		matrix A = new matrix(n,n);
		matrix R = new matrix(n,n);
		matrix Q = new matrix(n,n);		
		for(int i=0; i<n; i++){
			for(int j=0; j<n; j++){
				int num = rand.Next(1,8); 
				A[i,j] = num;
				Q[i,j] = num;
			}
		}
		WriteLine("Randomly generated square matrix A (8x8):");
		A.print();
		WriteLine("----------------------------------------------");
		lineq.QRGSdecomp(Q,R);

		matrix A_inv = lineq.QRGSinverse(Q,R);
		WriteLine("Inverse A^-1:");
		A_inv.print();

		WriteLine("----------------------------------------------");
		WriteLine("Checking that A*A^-1 is the identity matrix:");
		matrix A_A_inv = A*A_inv;
		A_A_inv.print();
		WriteLine("\nThis is in fact (approximately) an identity matrix!");

		WriteLine("----------------------------------------------");
		WriteLine("Testing (approx method of the matrix class) that A*A^-1 is I:");
		matrix I = new matrix(n,n);
		I.set_identity();
		WriteLine($"A*A^-1 is approximately equal to I: {A_A_inv.approx(I)}");
		WriteLine("----------------------------------------------");
	}
}