using System.Text;
using GraphLib;

namespace GraphVisitor
{
	public class DotGraphPrinter : IGraphVisitor<LabelGraph, Label>
	{
		private StringBuilder _sb;
		private IVertexVisitor<Label> _vertexVisitor;
		public IVertexVisitor<Label> VertexVisitor => _vertexVisitor;

		public DotGraphPrinter()
		{
			_sb = new StringBuilder();
			_vertexVisitor = new DotVertexPrinter(_sb);
		}
		
		public void Visit(LabelGraph graph)
		{
			_sb.AppendLine($"digraph \"{graph.Title}\" {{");
			_sb.AppendLine("\trankdir=LR;");
			_sb.AppendLine("\tsize=\"8,5\"");
			_sb.AppendLine("\tnode [shape = circle];");
				
			foreach (var pair in graph.AdjacencyList)
			{
				foreach (var edge in pair.Value)
				{
					_sb.Append("\t");
					pair.Key.Accept(_vertexVisitor);
					edge.Accept(_vertexVisitor);
					_sb.AppendLine();	
				}
			}
			_sb.AppendLine("}");
		}

		public string Output()
		{
			return _sb.ToString();
		}
	}
}