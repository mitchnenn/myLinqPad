<Query Kind="Program" />

void Main()
{
	var builder = new Builder();
	for(int i = 1; i <= 10; i++)
	{
		builder.AddVerticalSpacing(100);
		builder._yPosition.Dump();
	}
	"====".Dump();
	var b2 = new Builder();
	b2.AddVerticalSpacing(1000);
	b2._yPosition.Dump();
	"====".Dump();
	var b3 = new Builder();
	b3.AddVerticalSpacing(-10);
	b3._yPosition.Dump();
}

class Builder
{
	const int PageHeight = 792;
	
	public double _yPosition = PageHeight;
	
	public void AddVerticalSpacing(double spacing)
	{
        double newYPosition = _yPosition - spacing;
        if (newYPosition <= 0.0)
        {
            ForceNewPage();
			AddVerticalSpacing(Math.Abs(newYPosition));
        }
        else
        {
            _yPosition -= spacing;
        }
	}
	
	void ForceNewPage()
	{
		_yPosition = PageHeight;
		"New page added.".Dump();
	}
}