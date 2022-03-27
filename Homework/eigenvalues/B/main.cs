using System;
using static System.Console;
using static System.Math;
public class main{
	public static void Main(){
		WriteLine("----------------------------------------------");
		WriteLine("Investigating the eigenvalue convergence with rmax");
		WriteLine("The spacing dr is fixed to 0.2 Bohr radius");
		WriteLine("The numerical eigenenergies are compared to analytical table values (in Hartree)");
		using(var outfile = new System.IO.StreamWriter("conv_rmax.txt")){
			for(int r_max = 2; r_max<=30; r_max++){
				double rmax=r_max;
				double dr=0.2;
				int npoints = (int)(rmax/dr-1);
				vector r = new vector(npoints);
				for(int i=0;i<npoints;i++) r[i]=dr*(i+1);
				matrix H = new matrix(npoints,npoints);
				for(int i=0;i<npoints-1;i++){
					matrix.set(H,i,i,-2);
					matrix.set(H,i,i+1,1);
					matrix.set(H,i+1,i,1);
				}
				matrix.set(H,npoints-1,npoints-1,-2);
				H*=-0.5/dr/dr;
				for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];

				matrix D = H.copy();
				matrix V = new matrix(npoints,npoints);
				V.set_unity();
				evd.jacobi_diag(D,V);

				outfile.WriteLine($"{r_max} {D[0,0]} {D[1,1]} {D[2,2]}");
			}		
		}
		WriteLine("The resulting energies can be seen in figure \"rmax_conv.png\"");
		WriteLine("----------------------------------------------");
		WriteLine("The problem converges faster for lower energies as expected");
		WriteLine("Apparently, the energies have converged at rmax = 30 for the three lowest solutions");
		WriteLine("----------------------------------------------");

		// ---------------------------
		WriteLine("Investigating the eigenvalue convergence with npoints");
		WriteLine("The spacing dr is fixed to 0.2 Bohr radius");
		WriteLine("The numerical eigenenergies are compared to analytical table values (in Hartree)");
		using(var outfile = new System.IO.StreamWriter("conv_npoints.txt")){
			for(int npoints = 10; npoints<=200; npoints+=10){
				double dr=0.2;
				vector r = new vector(npoints);
				for(int i=0;i<npoints;i++) r[i]=dr*(i+1);
				matrix H = new matrix(npoints,npoints);
				for(int i=0;i<npoints-1;i++){
					matrix.set(H,i,i,-2);
					matrix.set(H,i,i+1,1);
					matrix.set(H,i+1,i,1);
				}
				matrix.set(H,npoints-1,npoints-1,-2);
				H*=-0.5/dr/dr;
				for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];

				matrix D = H.copy();
				matrix V = new matrix(npoints,npoints);
				V.set_unity();
				evd.jacobi_diag(D,V);

				outfile.WriteLine($"{npoints} {D[0,0]} {D[1,1]} {D[2,2]}");
			}		
		}
		WriteLine("The resulting energies can be seen in figure \"npoints_conv.png\"");
		WriteLine("----------------------------------------------");
		WriteLine("The problem converges faster for lower energies as expected");
		WriteLine("Apparently, the energies have converged at npoints = 150 for the three lowest solutions");
		WriteLine("----------------------------------------------");

		WriteLine("Having invistigated the convergence, we would like to inspect the resulting wavefunctions");
		WriteLine("This is done for rmax = 30, npoints = 150, dr = 0.2");
		double rmax2 = 30;
		double dr2 = 0.2;
		int npoints2 = 150;
		vector r2 = new vector(npoints2);
		for(int i=0;i<npoints2;i++) r2[i]=dr2*(i+1);
		matrix H2 = new matrix(npoints2,npoints2);
		for(int i=0;i<npoints2-1;i++){
			matrix.set(H2,i,i,-2);
			matrix.set(H2,i,i+1,1);
			matrix.set(H2,i+1,i,1);
			}
		matrix.set(H2,npoints2-1,npoints2-1,-2);
		H2*=-0.5/dr2/dr2;
		for(int i=0;i<npoints2;i++)H2[i,i]+=-1/r2[i];
		matrix D2 = H2.copy();
		matrix V2 = new matrix(npoints2,npoints2);
		V2.set_unity();
		evd.jacobi_diag(D2,V2);

		using(var outfile = new System.IO.StreamWriter("solutions.txt")){
			for(int i = 0; i<r2.size; i++){
				outfile.WriteLine($"{r2[i]} {V2[0][i]/Sqrt(dr2)} {-V2[1][i]/Sqrt(dr2)} {V2[2][i]/Sqrt(dr2)}");
			} // Normalize with 1/Sqrt(stepsize), known from another course
		}
		using(var outfile = new System.IO.StreamWriter("analytical.txt")){
			for(double z = 0; z<rmax2; z+=1.0/16){
				// Expression taken from Griffiths, Bohr radius set to 1
				double R1 = z*2*Exp(-z);
				double R2 = z*1.0/Sqrt(2)*(1-1.0/2*z)*Exp(-z/2);
				double R3 = z*2.0/(3*Sqrt(3))*(1-2.0/3*z+2.0/27*z*z)*Exp(-z/3);
				outfile.WriteLine($"{z} {R1} {R2} {R3}");
			}
		}
		WriteLine("----------------------------------------------");
		WriteLine("The resulting radial wavefunctions are computed");
		WriteLine("The three lowest solutions are plotted in figure \"hydrogen.png\"");
		WriteLine("The results agree very well with analytical expressions (taken from Griffiths)");
		WriteLine("----------------------------------------------");
	}
}