<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Engine.dll</Reference>
</Query>

void Main()
{
	Node n1 = new Node { Value = 1 };
	Node n4 = new Node { Value = 4 };
	Node n2 = new Node { Value = 2, Left = n1, Right = n4 };
	Node n5 = new Node { Value = 5 };
	Node n3 = new Node { Value = 3, Left = n2, Right = n5 };

	n3.IsValidBst().Dump();
}

public static class Validate
{
	public static bool IsValidBst(this Node n)
	{
		if (n.Left != null && n.Left.Value > n.Value)
			return false;
		if (n.Right != null && n.Right.Value < n.Value)
			return false;
		return n.Left == null ? true : n.Left.IsValidBst() 
			&& n.Right == null ? true : n.Right.IsValidBst();
	}
}

public class Node
{
	public int Value;
	public Node Left;
	public Node Right;
}
