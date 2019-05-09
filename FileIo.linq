<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Engine.dll</Reference>
</Query>

void Main()
{
	var string1 = @"C:\ADir\Afile.txt";
	string1.Dump();

	var string2 = "C:\\ADir\\Afile.txt";
	string2.Dump();

	var string3 = "C:\\\\ADir\\\\Afile.txt";
	string3.Dump();
	
	var aPath = Path.GetFullPath(string3);
	aPath.Dump();
}

// Define other methods and classes here
