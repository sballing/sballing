using System.Diagnostics;
public class qspline{
	double[] x,y,b,c;

	private static int binsearch(double[] x, double z){
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public qspline(double[] xs, double[] ys){
		int n = xs.Length; Trace.Assert(ys.Length>=n);
		x = new double[n];
		y = new double[n];
		b = new double[n-1];
		c = new double[n-1];
		for(int i=0;i<n;i++){x[i]=xs[i];y[i]=ys[i];} // Fill the arrays
		double[] dx = new double[n-1];
		double[] p = new double[n-1];
		for(int i=0;i<n-1;i++){
			dx[i] = x[i+1]-x[i];
			p[i] = (y[i+1]-y[i])/dx[i];
		}
		c[0] = 0;
		for(int i=0; i<n-2; i++){
			c[i+1] = 1/dx[i+1] * (p[i+1]-p[i] - c[i]*dx[i]); // Eq. 13, recursion up
		}
		c[n-2] = c[n-2]/2;
		for(int i=n-3; i>=0; i--){
			c[i] = 1/dx[i] * (p[i+1] - p[i] - c[i+1]*dx[i+1]);
		}
		for(int i=0; i<n-1; i++){
			b[i] = p[i] - c[i]*dx[i];
		}
	}


	public double qspline_eval(double z){
		Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
		int idx = binsearch(x, z); 
		double dx = z-x[idx]; /* Computing interpolating spline */
		return y[idx]+dx*(b[idx]+dx*c[idx]);
	}

	public double integ(double z, double cst){
		double cumsum=0;
		int idx=binsearch(x,z);
		for(int i=0; i<=idx; i++){
			double p = (y[i+1] - y[i])/(x[i+1] - x[i]); // Slope
			double l =  y[i]*x[i] + p*(x[i]*x[i]/2-x[i]*x[i]); // Compute leftmost edge of integral
			if(z>=x[i+1]){ // Check if we are at the edge
				double r = y[i]*x[i+1] + p*(x[i+1]*x[i+1]/2 -x[i]*x[i+1]); // Compute rightmost edge of integral
				cumsum += r-l; 
			}
			else{
				double r = y[i]*z + p*(z*z/2 -x[i]*z); // Anywhere except the rightmost point
				cumsum += r - l;
			}
		}
		return cumsum + cst;	
	}

	public double deriv(double z){
		int idx=binsearch(x,z);
		double dx=z-x[idx];
		return b[idx]+2*dx*c[idx];
	}

}