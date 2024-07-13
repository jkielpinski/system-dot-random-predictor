Console.WriteLine("System.Random prediction demo\n------------------------------");

//Make sure that a predictor's output matches a System.Random's output
void Test(Random rand, SystemDotRandomPredictor pred)
{
	Console.WriteLine("* Testing whether predictor output matches System.Random output:");
	for (int i = 0; i < 10; i++)
	{
		var r = rand.Next();
		var p = pred.Next();
		Console.WriteLine($"\t{i}. actual: {rand.Next()} / predicted: {pred.Next()}");
		if (r != p) throw new Exception("Predicted did not match actual");
	}
}

//Create some random bytes with System.Random, use them to predict RNG state, then verify
void TestBytes()
{
	Console.WriteLine("\n----------\nTesting bytes-based prediction");
	var rand = new Random();
	var bytes = new byte[48];
	rand.NextBytes(bytes);
	
	Console.WriteLine($"* Determining RNG state based on random bytes: {BitConverter.ToString(bytes)}");
	var pred = SystemDotRandomPredictor.FromRandomBytes(bytes);
	Console.WriteLine($"* {pred}");

	Test(rand, pred);
}

//Create random longs with System.Random, use them to predict RNG state, then verify
void TestLongs()
{
	Console.WriteLine("\n----------\nTesting long-based prediction");
	var rand = new Random();
	var randomValues = new long[5];
	for (int i = 0; i < randomValues.Length; i++) randomValues[i] = rand.NextInt64();

	Console.WriteLine($"* Determining RNG state based on random longs: {string.Join(",", randomValues)}");
	var pred = SystemDotRandomPredictor.FromRandomInt64s(randomValues);
	Console.WriteLine($"* {pred}");
	
	Test(rand, pred);
}

//Create random doubles with System.Random, use them to predict RNG state, then verify
void TestDoubles()
{
	Console.WriteLine("\n----------\nTesting double-based prediction");
	var rand = new Random();
	var randomValues = new double[10];
	for (int i = 0; i < randomValues.Length; i++) randomValues[i] = rand.NextDouble();

	Console.WriteLine($"* Determining state based on random doubles: {string.Join(",", randomValues)}");
	var pred = SystemDotRandomPredictor.FromRandomDoubles(randomValues);
	Console.WriteLine($"* {pred}");

	Test(rand, pred);
}

TestBytes();
TestLongs();
//TestDoubles(); //Slow
