using static System.Math;
public class evd{

	public static void timesJ(matrix A, int p, int q, double phi){ // Classic matrix multiplication
		double c = Cos(phi);
		double s = Sin(phi);
		for(int i=0; i<A.size1; i++){
			double A_ip = A[i,p];
			double A_iq = A[i,q];
			A[i,p] = c*A_ip - s*A_iq;
			A[i,q] = s*A_ip + c*A_iq;
		}
	}

	public static void Jtimes(matrix A, int p, int q, double phi){ // Analogous implementation
		double c = Cos(phi);
		double s = Sin(phi);
		for(int j=0; j<A.size1; j++){
			double A_pj = A[p,j];
			double A_qj = A[q,j];
			A[p,j] = c*A_pj + s*A_qj;
			A[q,j] = -s*A_pj + c*A_qj;
		}
	}

	public static int jacobi_diag(matrix A, matrix V){
		int sweeps = 0;
		int n = A.size1;
		V.set_unity();
		bool stop;

		do{
			sweeps++;
			stop = false;
			for(int p=0; p<n-1; p++){
				for(int q=p+1; q<n; q++){
					double A_pq = A.get(p,q);
					double A_pp = A.get(p,p);
					double A_qq = A.get(q,q);
					double phi = 0.5*Atan2(2*A_pq, A_qq - A_pp);
					double c = Cos(phi);
					double s = Sin(phi);
					double A_pp_new = c*c*A_pp - 2*s*c*A_pq + s*s*A_qq; // Notes, eq. 10
					double A_qq_new = s*s*A_pp + 2*s*c*A_pq + c*c*A_qq; // Notes, eq. 10
					if(A_pp_new != A_pp || A_qq_new != A_qq){ // Check if system has converged
						stop = true;
						timesJ(A, p, q, phi);
						Jtimes(A, p, q, -phi); // -phi, since we deal with J^T
						timesJ(V, p, q, phi);
					}
				}
			}
		} while(stop);	
		return sweeps;
	}

}