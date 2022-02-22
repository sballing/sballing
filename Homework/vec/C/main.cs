using static vec;
public class main{
	static void Main() {
		// Test the approx method
		vec a = new vec();
		vec b = new vec();
		vec c = new vec(1,1,1);
		vec d = new vec(1,1,1);
		vec e = new vec(1+1e-10, 1+1e-10, 1+1e-10);
		vec f = new vec(1+1e-5, 1+1e-5, 1+1e-5);
		vec g = new vec(1+1e-9, 1+1e-9, 1+1e-9);
		vec h = new vec(1+1e-8, 1+1e-8, 1+1e-8);
		vec i = new vec(1-1e-10, 1-1e-10, 1-1e-10);
		vec j = new vec(1-1e-5, 1-1e-5, 1-1e-5);
		vec k = new vec(1-1e-9, 1-1e-9, 1-1e-9);
		vec l = new vec(1-1e-8, 1-1e-8, 1-1e-8);
		System.Console.WriteLine("");
		System.Console.WriteLine("Testing the approx method");
		System.Console.WriteLine($"{a.ToString()} == {b.ToString()}: {approx(a,b)}");
		System.Console.WriteLine($"{a.ToString()} == {c.ToString()}: {approx(a,c)}");
		System.Console.WriteLine($"{c.ToString()} == {d.ToString()}: {approx(c,d)}");
		System.Console.WriteLine($"{c.ToString()} == {e.ToString()}: {approx(c,e)}");
		System.Console.WriteLine($"{c.ToString()} == {f.ToString()}: {approx(c,f)}");
		System.Console.WriteLine($"{c.ToString()} == {g.ToString()}: {approx(c,g)}");
		System.Console.WriteLine($"{c.ToString()} == {h.ToString()}: {approx(c,h)}");
		System.Console.WriteLine($"{c.ToString()} == {i.ToString()}: {approx(c,i)}");
		System.Console.WriteLine($"{c.ToString()} == {j.ToString()}: {approx(c,j)}");
		System.Console.WriteLine($"{c.ToString()} == {k.ToString()}: {approx(c,k)}");
		System.Console.WriteLine($"{c.ToString()} == {l.ToString()}: {approx(c,l)}");
		System.Console.WriteLine($"The result of all tests fits with the criteria of the approx method!");
	}
}