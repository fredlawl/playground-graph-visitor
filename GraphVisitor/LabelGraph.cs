using GraphLib;

namespace GraphVisitor
{
	public class LabelGraph : BaseGraph<LabelGraph, Label>
	{
		public string Title { get; protected set; }

		public LabelGraph(string title)
		{
			Title = title;
		}
		
		public override void Accept(IGraphVisitor<LabelGraph, Label> visitor)
		{
			visitor.Visit(this);
		}

		protected override BaseGraph<LabelGraph, Label> Clone()
		{
			return new LabelGraph(this.Title);
		}
	}
}