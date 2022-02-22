using static vec;
public class main{
	static void Main() {
		// Iniialize a null vector and two non-zero vector
		vec n = new vec();
		vec u = new vec(2,1,3);
		vec v = new vec(4,1,5);

		// Check the print function
		System.Console.WriteLine("Print the 3 three initialized vectors");
		n.print("n = ");
		u.print("u = ");	
		v.print("v = ");

		// Check the vector operators
		System.Console.WriteLine("");
		System.Console.WriteLine("Testing the vector operators");
		System.Console.WriteLine($"First dot method: u*v = {u.dot(v)}");
		System.Console.WriteLine($"Second dot method: u*v = {dot(u,v)}");
		System.Console.Write($"First cross-product method: "); u.cross(v).print("u x v = ");
		System.Console.Write($"Second cross-product method: "); cross(u,v).print("u x v = ");
		System.Console.WriteLine($"Norm |u| = {u.norm()}");
		System.Console.WriteLine($"Overriden ToString method for vector u: {u.ToString()}, standard just states \"vec\"");
	}
}