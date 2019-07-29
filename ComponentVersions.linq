<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Engine.dll</Reference>
</Query>

void Main()
{
	var depDir = @"C:\Users\mnenn\projects\zodiac-r2\src\Dependencies";
	var folderNames = Directory.EnumerateDirectories(depDir, "*", SearchOption.AllDirectories)
		.Dump();
	
	folderNames.Count().Dump();
	
	var components = Directory.EnumerateFiles(depDir, "*.*", SearchOption.AllDirectories)
		.Select(d => new FileInfo(d))
		.Select(d => new { Name = Path.GetFileName(d.Name), Version = FileVersionInfo.GetVersionInfo(d.FullName).FileVersion })
		.Where(d => d.Name.EndsWith(".dll") || d.Name.EndsWith(".exe"))
		.Where(d => !d.Name.StartsWith("System") 
				&& !d.Name.StartsWith("Microsoft")
				&& d.Name != "log4net.dll"
				&& d.Version != null
				&& d.Name != "mscorelib.dll")
		.OrderBy(d => d.Name)
		.Dump("Filenames");
}

class DependencyFileVersion
{
	public string Name;
	public string Version;

	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}
}