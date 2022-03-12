public class lspline{
	private double[] x,y;

	private static int binsearch(double[] x, double z){
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public lspline(double[] xs, double[] ys){
		x = xs;
		y = ys;
	}

	public double linterp(double z){
		int idx=binsearch(x,z);
		double dy=y[idx+1]-y[idx], dx=x[idx+1]-x[idx];
		return y[idx]+dy/dx*(z-x[idx]);
	}

	public double linterpInteg(double z, double cst){
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
}