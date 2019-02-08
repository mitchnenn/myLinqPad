<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	string LibraryIdPattern = @"^(.+)-(?:DNA|RNA)-[0-9]+$";
	string[] libraryIds = new [] { 
		"1234-DNA-RNA-90",
		"1234-DNA-",
		"1234-DNA-Analysis1",
		"1234-RNA-DNA-90",
		"CellLine_Mixture_RNA",
		"CellLine_Mixture_DNA",
		"CellLine_Mixture-DNA-58"
	};
	
	foreach(var libraryId in libraryIds)
	{
		var match = Regex.Match(libraryId, LibraryIdPattern);
		if(!match.Success)
		{
			$"{libraryId} is not valid".Dump();
		}
		else
		{
			match.Dump();
		}
	}
}