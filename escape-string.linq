<Query Kind="Program" />

void Main()
{
	var expected = "{\"InputSamples\":[{\"Sample\":\"TestSample1\",\"MetricFiles\":{\"DnaQcMetrics\":[\"DnaQc\"],\"RnaQcMetrics\":null,\"ContaminationFiles\":null,\"CollapsedReadsFiles\":null,\"TmbFiles\":null,\"MsiFiles\":null}},{\"Sample\":\"TestSample2\",\"MetricFiles\":{\"DnaQcMetrics\":null,\"RnaQcMetrics\":[\"RnaQc\"],\"ContaminationFiles\":null,\"CollapsedReadsFiles\":null,\"TmbFiles\":null,\"MsiFiles\":null}}]}";
	var actual = @"{""InputSamples"":[{""Sample"":""TestSample1"",""MetricFiles"":{""DnaQcMetrics"":[""DnaQc""],""RnaQcMetrics"":null,""ContaminationFiles"":null,""CollapsedReadsFiles"":null,""TmbFiles"":null,""MsiFiles"":null}},{""Sample"":""TestSample2"",""MetricFiles"":{""DnaQcMetrics"":null,""RnaQcMetrics"":[""RnaQc""],""ContaminationFiles"":null,""CollapsedReadsFiles"":null,""TmbFiles"":null,""MsiFiles"":null}}]}";
	(expected == actual).Dump();
}

