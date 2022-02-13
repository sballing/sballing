using System;
using static System.Console;
using static System.Math;
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
		this.print("");
	}

	// Implementing mathematical operators
	public static vec operator*(vec v, double c) {
		return new vec(c*v.x, c*v.y, c*v.z);
	}
	public static vec operator*(double c, vec v) {
		return v*c;
	}
	public static vec operator+(vec u, vec v) {
		return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
	}
	public static vec operator-(vec u, vec v) {
		return new vec(u.x-v.x, u.y-v.y, u.z-v.z);
	}
	public static vec operator-(vec v) {
		return new vec(-v.x, -v.y, -v.z);
	}

	// Implementing dot-product, cross-product, norm and overriding ToString
	public double dot(vec other) {
		return this.x*other.x + this.y*other.y + this.z*other.z;
	}
	public static double dot(vec u, vec v) {
		return u.x*v.x + u.y*v.y + u.z*v.z;
	}
	public vec cross(vec other) {
		return new vec(this.y*other.z-this.z*other.y, this.z*other.x-this.x*other.z, this.x*other.y-this.y*other.x);
	}
	public static vec cross(vec u, vec v) {
		return new vec(u.y*v.z-u.z*v.y, u.z*v.x-u.x*v.z, u.x*v.y-u.y*v.x);
	} 
	public double norm() {
		return Sqrt(this.x*this.x + this.y*this.y + this.z*this.z);
	}
	public override string ToString() {
		return $"vec[({x}, {y}, {z})]";
	}

	// Implementing the approx method
	public bool approx(vec other) {
		double tau = 1e-9; double eps = 1e-9;
		if (Abs(this.x-other.x) < tau && Abs(this.y-other.y) < tau && Abs(this.z-other.z) < tau) {
			return true;
		}
		if (Abs(this.x-other.x)/(Abs(this.x)+Abs(other.x)) < eps && Abs(this.y-other.y)/(Abs(this.y)+Abs(other.y)) < eps && Abs(this.z-other.z)/(Abs(this.z)+Abs(other.z)) < eps) {
			return true;
		}
		else {
			return false;
		}
	}
	public static bool approx(vec u, vec v) {
		return u.approx(v);
	}

}