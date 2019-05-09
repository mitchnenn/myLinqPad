<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Engine.dll</Reference>
  <NuGetReference>Newtonsoft.Json.Akshay</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
	var aclass = new AClass {Property1 = 34343434, Property2 = false, Property3 = "This is it."};
	var json = JsonConvert.SerializeObject(aclass);
	var runQcLabelMap = new Dictionary<string, string> {
		{ "Property1", "Longitude" },
		{ "Property3", "Description" }
	};
	json = runQcLabelMap.Aggregate(json, (c, r) => c.Replace(r.Key, r.Value));
	json.Dump();
}

class AClass
{
	public int Property1 {get; set;}
	public bool Property2 {get; set;}
	public string Property3 {get; set;}
}