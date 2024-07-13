# SystemDotRandomPredictor

Proof of concept for predicting the output of `System.Random` in .NET 6+ (Xoshiro256** algorithm) given previous outputs.

## Usage

Create a `SystemDotRandomPredictor` in one of the following ways:

|Method|Description|Est. time|
|---|---|---|
|FromRandomBytes(byte[])|From `System.Random.NextBytes()` output|instant|
|FromRandomLongs(long[])|From `System.Random.NextInt64()` output|<1sec|
|FromRandomDoubles(double[]|From `System.Random.NextDouble()` output)|2.75 days|
|FromRandomInts(int[])|From `System.Random.Next()` output|70 sextillion centuries|

A demo is provided in `Program.cs` -- run it with `dotnet run`.