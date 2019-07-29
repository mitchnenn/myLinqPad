<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Engine.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var status = new SampleStatusAggregate
	{
		SampleStatuses = new List<SampleStatusAggregate.SampleStatusEntry> {
//			new SampleStatusAggregate.SampleStatusEntry {
//				LibraryName = "ALibraryName1",
//				Status = new SampleStatus {
//					StepsExecutedAndPassed = new List<string> { "Step1", "Step2" },
//					StepsExecutedAndFailed = new List<string> { "Step3", "Step4" },
//					StepsDidNotExecute = new List<string> { "Step5", "Step6" }
//				}
//			},
//			new SampleStatusAggregate.SampleStatusEntry {
//				LibraryName = "ALibraryName2",
//				Status = new SampleStatus {
//					StepsExecutedAndPassed = new List<string> { "Step3", "Step4" },
//					StepsExecutedAndFailed = new List<string> { "Step5", "Step6" },
//					StepsDidNotExecute = new List<string> { "Step1", "Step2" }
//				}
//			}
		}
	};

	JsonConvert.SerializeObject(status).Dump();
}

public class SampleStatus
{
	[JsonProperty("executedAndPassed")]
	public List<string> StepsExecutedAndPassed { get; set; }

	[JsonProperty("executedAndFailed")]
	public List<string> StepsExecutedAndFailed { get; set; }

	[JsonProperty("didNotExecute")]
	public List<string> StepsDidNotExecute { get; set; }
}

public class SampleStatusAggregate
{
	public class SampleStatusEntry
	{
		public string LibraryName { get; set; }
		public SampleStatus Status { get; set; }
	}

	public List<SampleStatusEntry> SampleStatuses { get; set; }
}