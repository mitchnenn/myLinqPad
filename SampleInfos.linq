<Query Kind="Program">
  <Output>DataGrids</Output>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Engine.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var coll = new SampleInfoCollection();
	coll.SampleInfos.Add(new SampleInfo { SampleId = "1", SampleType = "Type1", Pair_ID = "Pair1" });
	coll.SampleInfos.Add(new SampleInfo { SampleId = "2", SampleType = "Type2", Pair_ID = "Pair2" });
	coll.SampleInfos.Add(new SampleInfo { SampleId = "3", SampleType = "Type3", Pair_ID = "Pair1" });
	coll.SampleInfos.Add(new SampleInfo { SampleId = "4", SampleType = "Type4", Pair_ID = "Pair4" });

	var result =  Newtonsoft.Json.JsonConvert.SerializeObject(coll);
	
	result.Dump("1");
	
	var result2 = JsonConvert.DeserializeObject<SampleInfoCollection>(result);
	
	result2.Dump("2");
	
	var astring = "{\"SampleInfos\":[{\"SampleId\":\"CellLine_Mixture_DNA\",\"SampleType\":\"DNA\",\"Pair_ID\":\"1\"},{\"SampleId\":\"CellLine_Mixture_DNA\",\"SampleType\":\"RNA\",\"Pair_ID\":\"1\"}]}";
	var result3 = JsonConvert.DeserializeObject<SampleInfoCollection>(astring);
	result3.Dump("3");
}

public class SampleInfoCollection
{
	public SampleInfoCollection()
	{
		SampleInfos = new List<SampleInfo>();
	}

	public List<SampleInfo> SampleInfos { get; set; }
}

public class SampleInfo
{
	public string SampleId { get; set; }
	public string SampleType { get; set; }
	public string Pair_ID { get; set; }
}