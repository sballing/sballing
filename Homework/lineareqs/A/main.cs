using System;
using static System.Console;
using static System.Random;
public class main{
	public static void Main(){
		// Testing the decomposition routine
		int n = 10;
		int m = 7;

		matrix A = new matrix(n,m);
		matrix R = new matrix(m,m);
		matrix Q = new matrix(n,m);
		var rand = new Random();

		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				int num = rand.Next(1,5);
				A[i,j] = num;
				Q[i,j] = num;
			}
		}
		WriteLine("----------------------------------------------");
		WriteLine("Initial (random) matrix A:");
		A.print();

		lineq.QRGSdecomp(Q, R);

		WriteLine("----------------------------------------------");
		WriteLine("Q matrix after decomposition:");
		Q.print();
		WriteLine("----------------------------------------------");
		WriteLine("R matrix after decomposition:");
		R.print();
		WriteLine("\nIt is upper triangular!");
		WriteLine("----------------------------------------------");

		WriteLine("Checking that Q^T Q = 1 (identity).");
		matrix Q_trans_Q = Q.transpose()*Q;
		Q_trans_Q.print();
		WriteLine("\nIt is to a good approximation the identity matrix!");
		WriteLine("----------------------------------------------");

		WriteLine("Checking that Q*R = A:");
		matrix QR = Q*R;
		QR.print();
		WriteLine("\nQ*R is in fact A!");
		WriteLine("----------------------------------------------");

		// Testing the linear solver routine
		int n2 = 8;
		int m2 = n2;
		WriteLine("Testing the implemented equation solver:");
		matrix A2 = new matrix(n2,m2);
		matrix R2 = new matrix(n2,m2);
		vector b = new vector(n2);
		for(int i=0; i<n2; i++){
			b[i] = rand.Next(1,9);
			for(int j=0; j<m2; j++){
				A2[i,j] = rand.Next(1,9);
			}
		}

		WriteLine("\nRandomly generated matrix A:");
		A2.print();
		WriteLine("\nRandomly generated vector b:");
		b.print();
		WriteLine("----------------------------------------------");


		WriteLine("Factorizing A into QR:");
		matrix A2_0 = A2.copy();
		lineq.QRGSdecomp(A2, R2);
		A2.print();
		R2.print();
		WriteLine("----------------------------------------------");

		WriteLine("Solving the system of equations. The solution (x) is:");
		matrix Q2 = A2.copy();
		vector x = lineq.QRGSsolve(Q2, R2, b);
		x.print();
		WriteLine("----------------------------------------------");

		WriteLine("Checking that A*x=b\n");
		WriteLine("A*x equals:");
		vector Ax = A2_0*x;
		Ax.print();
		WriteLine("\nb equals:");
		b.print();
		WriteLine("\nThe system of equations have indeed been solved!");
		WriteLine("----------------------------------------------");
		WriteLine("Testing if the solution is adequate, using the approx method from vector class\n");
		WriteLine($"Is A*x approximately equal to b? {Ax.approx(b)}");
		WriteLine("----------------------------------------------");
	}
}