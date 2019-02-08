<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var dir = @"\\Mac\AllFiles\Users\mnenn\Downloads\dev\Bugs\Analysis\Analysis_backup2";
	var targetDir = "\\Users\\mnenn\\projects\\zodiac-r2\\src\\OGP2RunnerTests\\TestReferences\\TestAnalysisFolder";
	if(!Directory.Exists(dir) || !Directory.Exists(targetDir))
	{
		$"{dir} dosn't exist.".Dump();
		return;
	}
	
	var diTarget = new DirectoryInfo(targetDir);
	diTarget.GetFiles().ToList().ForEach(f => f.Delete());
	diTarget.GetDirectories().ToList().ForEach(d => d.Delete(true));
	
	var filenames = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories)
		.Select(f => f.Substring(dir.Length + 1))
		.Dump("Source");
		
	var newFilenames = filenames.Select(f => Path.Combine(targetDir, f)).ToList();
	newFilenames.Dump("Target");
	
	var folders = newFilenames.Select(f => Path.GetDirectoryName(f)).ToList();
	folders.Dump("Folders");
	folders.ForEach(f => Directory.CreateDirectory(f));
	
	newFilenames.ForEach(f => File.Create(f).Dispose());
}