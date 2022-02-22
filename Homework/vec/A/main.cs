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

		// Check the mathematical operators
		System.Console.WriteLine("");
		System.Console.WriteLine("Testing the basic mathematical operators");
		(u+v).print($"u + v = ");
		(u-v).print($"u - v = ");
		(-u).print($"-u = ");
		(2.5*u).print($"2.5 * u = ");
		vec x = (u*2.5);
		x.print($"u * 2.5 = "); // For some reason, this cannot be put into one statement?
	}
}