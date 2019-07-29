<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Engine.dll</Reference>
</Query>

void Main()
{
	var path = @"C:\Users\mnenn\projects\AnalysisLog-20190322-123226.txt";
	var regex = new Regex(@".?OGP2Runner.Program - Step (\d{1,}) of (\d{1,}): (.*)");
	var descPath = Path.Combine(Path.GetDirectoryName(path), "stepDescriptions.txt");
	using(var target = File.CreateText(descPath))
	{
		File.ReadAllLines(path)
			.Where(l => regex.IsMatch(l))
			.Select(l => regex.Match(l))
			.Select(m => new { Index = m.Groups[1].Value, Description = m.Groups[3].Value})
			.ToList()
			.ForEach(n => target.WriteLine($"{n.Index}. {n.Description}"));
	}
	
	var stepPath = Path.Combine(Path.GetDirectoryName(descPath), "stepNames.txt");
	var regex2 = new Regex(@"(\d{1,}). (.*)");
	using (var stepFile = File.CreateText(stepPath))
	{
		File.ReadAllLines(descPath)
			.Select(l => regex2.Match(l).Groups[2].Value)
			.Select(l => FindStepFileName(l))
			.Select(l => ReadFirstStepClassName(l))
			.ToList()
			.ForEach(n => stepFile.WriteLine(n));
	}
}

string FindStepFileName(string description)
{
	var codePath = @"C:\Users\mnenn\projects\zodiac-r2\src\OGP2Runner\Pipeline";
	var files = Directory.EnumerateFiles(codePath, @"*.cs", SearchOption.TopDirectoryOnly);
	foreach(var filename in files.Where(f => !f.Contains("OGP2StepName")))
	{
		if(ContainsDescription(filename, description))
		{
			return filename;
		}
	}
	return string.Empty;
}

bool ContainsDescription(string filename, string description)
{
	foreach(var line in File.ReadAllLines(filename))
	{
		if(line.Contains($"\"{description}\""))
		{
			return true;
		}
	}
	return false;
}

string ReadFirstStepClassName(string filename)
{
	var regex = new Regex(@".*public class (\w.*)Step(?:\s{0,}):.*");
	foreach (var line in File.ReadAllLines(filename))
	{
		var match = regex.Match(line);
		if(match.Success)
		{
			return match.Groups[1].Value;
		}
	}	
	return string.Empty;
}

