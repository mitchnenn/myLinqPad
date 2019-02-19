<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Engine.dll</Reference>
</Query>

void Main()
{
	var aString = @"C:\Somepath\some\more\path\Cellline_Mixture_DNA.aggregated.json";
	var pattern = @"^.+\\(.+)\.aggregated\.json$";
	var regex = new Regex(pattern);
	regex.Match(aString).Groups[1].Value.Dump();

	var aString3 = @"C:\Somepath\some\more\path\MyStupidFile.json";
	var pattern3 = @"^.+\\(.+)\.aggregated\.json$";
	var regex3 = new Regex(pattern3);
	regex.Match(aString3).Groups[1].Value.Dump();

	var aString2 = @"C:\Somepath\some\more\path\Cellline_Mixture_DNA_QC.json";
	var pattern2 = @"^.+\\(.+)_QC\.json$";
	var regex2 = new Regex(pattern2);
	regex2.Match(aString2).Groups[1].Value.Dump();
}

// Define other methods and classes here
