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

	public static int jacobi_diag_opti(matrix A, matrix V){
		int sweeps = 0;
		int n = A.size1;
		V.set_unity();
		bool stop;
		do{
			sweeps++;
			stop = false;
			for(int p=0; p<n-1; p++){
				for(int q=p+1; q<n; q++){
					double A_pq = A[p,q];
					double A_pp = A[p,p];
					double A_qq = A[q,q];

					double phi = 0.5*Atan2(2*A_pq, A_qq - A_pp);
					double c = Cos(phi);
					double s = Sin(phi);
					double A_pp_new = c*c*A_pp - 2*s*c*A_pq + s*s*A_qq; // Notes, eq. 10
					double A_qq_new = s*s*A_pp + 2*s*c*A_pq + c*c*A_qq; // Notes, eq. 10		

					if(A_pp_new != A_pp || A_qq_new != A_qq){
						stop = true;
					
						A[p,p] = A_pp_new;
						A[q,q] = A_qq_new;
						A[p,q] = 0.0;

						for(int i=0; i<p; i++){
							double A_ip = A[i,p];
							double A_iq = A[i,q];
							A[i,p] = c*A_ip-s*A_iq;
							A[i,q] = s*A_ip+c*A_iq;
						}	

						
						for(int i=p+1; i<q; i++){
							double A_pi = A[p,i];
							double A_iq = A[i,q];
							A[p,i] = c*A_pi-s*A_iq;
							A[i,q] = s*A_pi+c*A_iq;
						}	



						for(int i=q+1; i<n; i++){
							double A_pi = A[p,i];
							double A_qi = A[q,i];
							A[p,i] = c*A_pi-s*A_qi;
							A[q,i] = s*A_pi+c*A_qi;
						}



						// Update matrix V
						timesJ(V,p,q,phi);
					}
				}
			}

		} while(stop);
		// Now upper right part is diagonalized
		// Update lower triangular part

			for(int i=0; i<n; i++){
				for(int j=0; j<i; j++){
					double A_ji = A[j,i];
					A[i,j] = A_ji;
				}
			}
			
		return sweeps;
	}

}