using System;
using GraphLib;

namespace GraphVisitor
{
	public class Label : Vertex<Label>
	{
		public string Value { get; protected set; }

		public Label(string label)
		{
			Value = label;
		}
		
		public override bool EqualsCore(Label other)
		{
			return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
		}

		public override int GetHashCodeCore()
		{
			return Value.GetHashCode();
		}

		public override void Accept(IVertexVisitor<Label> visitor)
		{
			visitor.Visit(this);
		}
	}
}