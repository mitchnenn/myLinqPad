<Query Kind="Program" />

void Main()
{
	var solutionDir = @"C:\Users\mnenn\projects\zodiac-r2";	
	
	var projectFiles = Directory.EnumerateFiles(solutionDir, "*.csproj", SearchOption.AllDirectories)
		.Where(f => !Path.GetFileName(f).StartsWith("._"))
		.ToList();
	projectFiles.ForEach(UpdateVersion);
	
	var appConfigFiles = Directory.EnumerateFiles(solutionDir, "app.config", SearchOption.AllDirectories)
		.Where(f => !f.Contains("Dependencies"))
		.ToList();
	appConfigFiles.ForEach(UpdateAppConfig);
}

void UpdateAppConfig(string appConfigPath)
{
	var doc = new XmlDocument();
	doc.Load(appConfigPath);
	foreach(XmlElement elem in doc.DocumentElement)
	{
		if(elem.Name == "startup")
		{
			foreach(XmlElement startupElem in elem.ChildNodes)
			{
				foreach(XmlAttribute attr in startupElem.Attributes)
				{
					if(attr.Name == "sku")
					{
						attr.Value = ".NETFramework,Version=v4.7.2";
						doc.Save(appConfigPath);
						break;
					}
				}
			}
		}
	}
	doc = null;
}

void UpdateVersion(string csprojPath)
{
	var doc = new XmlDocument();
	doc.Load(csprojPath);
	foreach(XmlNode node in doc.DocumentElement.ChildNodes)
	{
		foreach(XmlNode node2 in node)
		{
			if(node2.Name == "TargetFrameworkVersion")
			{
				node2.InnerText = "v4.7.2";
				doc.Save(csprojPath);
				break;
			}
		}
	}
	doc = null;
}