namespace GraphVisitor
{
	public interface IVertexVisitor<TVertex> where TVertex : Vertex<TVertex>
	{
		void Visit(TVertex vertex);
		void Visit(Edge<TVertex> edge);
	}
}