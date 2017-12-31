namespace GraphVisitor
{
	public interface IGraphVisitor<TGraph, TVertex> where TGraph : BaseGraph<TGraph, TVertex> where TVertex : Vertex<TVertex>
	{
		void Visit(TGraph graph);
	}
}