<Query Kind="Program">
  <Output>DataGrids</Output>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Engine.dll</Reference>
</Query>

void Main()
{
	var path = @"C:\Users\mnenn\projects\zodiac-r2\src\OGP2Runner\Pipeline\OGP2StepName.cs";
	var regex = new Regex(@"new OGP2StepName\(""(.+)"",\s{0,}""""\)", RegexOptions.Compiled);
	var names = File.ReadAllLines(path)
		.Where(l => l.Contains("public static readonly IStepName"))
		.Select(l => l.Trim())
		.Select(l => regex.Match(l).Groups[1].Value)
		.ToList();
	string.Join(",", names.ToArray()).Dump("Comma");
	string.Join("\n", names.ToArray()).Dump("Newline");
}

