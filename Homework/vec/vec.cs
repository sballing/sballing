using System;
using static System.Console;
public class vec{
	public double x,y,z; // 3 entries of the vector

	// Constructors
	public vec() { // Instantiate a null vector
		x=y=z=0; 
	}
	public vec(double a, double b, double c) { // Instantiate a non-zero vector
		x = a;
		y = b;
		z = c;
	}

	// Print methods for the vector class (intended for debugging)
	public void print(string s) {
		WriteLine($"{s}({x}, {y}, {z})");
	}
	public void print() {
		print("");
	}

}