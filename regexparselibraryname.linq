<Query Kind="Program" />

void Main()
{
	var pattern = @"^(.+)_QC.json";
	var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
	var filepaths1 = new List<string> { 
		@"C:\Users\mnenn\projects\zodiac-r2\src\OGP2RunnerTests\bin\Debug\TestReferences\QcMetrics\Dna\FFPE-Lung1-DNA-101_QC.json", 
		@"C:\Users\mnenn\projects\zodiac-r2\src\OGP2RunnerTests\bin\Debug\TestReferences\QcMetrics\Dna\FFPE-Lung1-DNA-101_QC.json" 
	};
	var filepaths2 = new List<string> { 
		@"C:\Users\mnenn\projects\zodiac-r2\src\OGP2RunnerTests\bin\Debug\TestReferences\QcMetrics\Msi\FFPE-Lung1-DNA-101_QC.json"
	};
	var sources = new List<List<string>> { filepaths1, filepaths2 };
	
	
	var result = filepaths1
		.Union(filepaths2)
		.Select(Path.GetFileName)
		.Select(f => regex.Match(f).Groups[1].Value)
		.Where(n => !string.IsNullOrEmpty(n))
		.Distinct()
		.Dump();
}

// Define other methods and classes here
