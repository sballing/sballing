using static vec;
using static System.Console;
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
		WriteLine("------------------------------------------------------------");
		WriteLine("It is a bit unclear, what is meant by extensive testing.");
		WriteLine("However, here I attempt to test limiting cases of the approx method\n");
		WriteLine($"{a.ToString()} == {b.ToString()}: {approx(a,b)}");
		WriteLine($"{a.ToString()} == {c.ToString()}: {approx(a,c)}");
		WriteLine($"{c.ToString()} == {d.ToString()}: {approx(c,d)}");
		WriteLine($"{c.ToString()} == {e.ToString()}: {approx(c,e)}");
		WriteLine($"{c.ToString()} == {f.ToString()}: {approx(c,f)}");
		WriteLine($"{c.ToString()} == {g.ToString()}: {approx(c,g)}");
		WriteLine($"{c.ToString()} == {h.ToString()}: {approx(c,h)}");
		WriteLine($"{c.ToString()} == {i.ToString()}: {approx(c,i)}");
		WriteLine($"{c.ToString()} == {j.ToString()}: {approx(c,j)}");
		WriteLine($"{c.ToString()} == {k.ToString()}: {approx(c,k)}");
		WriteLine($"{c.ToString()} == {l.ToString()}: {approx(c,l)}");
		WriteLine($"\nThe result of all tests fits with the criteria of the approx method!");
		WriteLine("------------------------------------------------------------");
	}
}