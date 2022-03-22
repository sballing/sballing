using System;
using static System.Math;
public class lsfit{

	public static (double[], matrix) fit(double[] xs, double[] ys, double[] dys, Func<double,double>[] funcs){
		matrix A = new matrix(xs.Length, funcs.Length);
		matrix Q = A.copy();
		matrix R = new matrix(Q.size2, Q.size2);
		vector b = new vector(xs.Length);
		for(int i=0; i<A.size1; i++){
			b[i] = ys[i]/dys[i];
			for(int j=0; j<A.size2; j++){
				Q[i,j] = funcs[j](xs[i])/dys[i];
			}
		}


		lineq.QRGSdecomp(Q,R);
		vector c = lineq.QRGSsolve(R, Q.transpose()*b);

		double[] res = new double[c.size];
		for(int i=0; i<res.Length; i++){
			res[i] = c[i];
		}

		matrix R_trans_R = R.transpose()*R;
		matrix R2 = new matrix(R_trans_R.size2, R_trans_R.size2);
		lineq.QRGSdecomp(R_trans_R, R2);
		matrix S = lineq.QRGSinverse(R_trans_R, R2);

		return (res, S);

	}

}