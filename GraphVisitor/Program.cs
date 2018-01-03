using System;
using GraphLib;

namespace GraphVisitor
{
	class Program
	{
		static void Main(string[] args)
		{
			var printer = new DotGraphPrinter();
			var graph = new LabelGraph("My Label Graph");
			graph.AddEdge(new Label("test1"), new Edge<Label>(new Label("test2"), "0"));
			graph.AddEdge(new Label("test1"), new Edge<Label>(new Label("test3"), "1"));
			graph.AddEdge(new Label("test2"), new Edge<Label>(new Label("test1"), "2"));
			
			graph.Accept(printer);
			Console.WriteLine(printer.Output());
		}
	}
}
