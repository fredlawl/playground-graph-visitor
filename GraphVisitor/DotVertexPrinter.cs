using System.Text;
using GraphLib;

namespace GraphVisitor
{
	public class DotVertexPrinter : IVertexVisitor<Label>
	{
		private StringBuilder _sb;

		public DotVertexPrinter(StringBuilder sb)
		{
			_sb = sb;
		}
		
		public void Visit(Label vertex)
		{
			_sb.Append($"\"{vertex.Value}\"");
		}

		public void Visit(Edge<Label> edge)
		{
			_sb.Append(" -> ");
			edge.Vertex.Accept(this); 
			_sb.Append($" [ label = \"{edge.Label}\" ];");
		}
	}
}