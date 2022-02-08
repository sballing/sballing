class math{
	static void Main() {
		double sqrt2 = System.Math.Sqrt(2.0);
		System.Console.Write($"sqrt(2) = {sqrt2}\n");
		System.Console.Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be equal 2)\n");

		double epi = System.Math.Exp(System.Math.PI); 
		System.Console.Write($"e^pi = {epi}\n");

		double pie = System.Math.Pow(System.Math.PI, System.Math.E);
		System.Console.Write($"pi^e = {pie}\n");

	}

}