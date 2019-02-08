<Query Kind="Program" />

class Base
{
	public void Method()
	{
		Console.WriteLine("Base method.");
		Method("");
	}
	
	protected virtual void Method(string input)
	{
		Console.WriteLine("Base virtual method.");
	}
}

class Derived : Base
{
	protected override void Method(string input)
	{
		Console.WriteLine("Derived override method.");
	}
}

void Main()
{
	Derived d = new Derived();
	Base b = d;
	d.Method();
	b.Method();
}


