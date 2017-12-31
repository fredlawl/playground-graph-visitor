namespace GraphVisitor
{
	public class Edge<T> where T : Vertex<T>
	{
		public T Vertex { get; protected set; }
		public string Label { get; protected set; }

		public Edge(T to, string label)
		{
			Vertex = to;
			Label = label;
		}

		public void Accept(IVertexVisitor<T> visitor)
		{
			visitor.Visit(this);
		}
	}
}