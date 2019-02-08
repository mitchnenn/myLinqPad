<Query Kind="Program" />

void Main()
{
	string target = "C:\\Users\\mnenn\\projects\\zodiac-r2\\src\\OGP2RunnerTests\\bin\\Debug\\ClinicalOutputCleanupStep\\TestAnalysisFolder\\Fastq\\DBV2-10ng-4C-rep1_S7_L001_R2_001.fastq.gz";
	string search = "C:\\Users\\mnenn\\projects\\zodiac-r2\\src\\OGP2RunnerTests\\bin\\Debug\\ClinicalOutputCleanupStep\\TestAnalysisFolder\\Fastq\\(.*).fastq.gz$";
	search = search.Replace(@"\", @"\\");
	var regex = new Regex(search, RegexOptions.IgnoreCase);
	regex.IsMatch(target).Dump();
}

// Define other methods and classes here
