<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	string regex = @"^([a-zA-Z0-9]+[-_]?)*[a-zA-Z0-9]+$";
	string sampleid = "CellLine_Mixture_Me";
	var m = Regex.Match(sampleid, regex);
	m.Dump();
}
