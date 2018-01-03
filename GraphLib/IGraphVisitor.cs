namespace GraphLib
{
	public interface IGraphVisitor<TGraph, TVertex> where TGraph : BaseGraph<TGraph, TVertex> where TVertex : Vertex<TVertex>
	{
		IVertexVisitor<TVertex> VertexVisitor { get; }
		void Visit(TGraph graph);
	}
}