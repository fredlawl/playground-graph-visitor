using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GraphVisitor
{
	public abstract class BaseGraph<TGraph, TVertex> where TGraph : BaseGraph<TGraph, TVertex> where TVertex : Vertex<TVertex>
	{
		protected IDictionary<TVertex, IList<Edge<TVertex>>> _adjacencyList = new Dictionary<TVertex, IList<Edge<TVertex>>>();
		public IReadOnlyDictionary<TVertex, IList<Edge<TVertex>>> AdjacencyList => new ReadOnlyDictionary<TVertex, IList<Edge<TVertex>>>(_adjacencyList);

		public void AddVertex(TVertex vertex)
		{
			if (vertex == null)
				throw new ArgumentNullException(nameof(vertex));
			
			if (_adjacencyList.ContainsKey(vertex))
				return;
			
			_adjacencyList.Add(vertex, new List<Edge<TVertex>>());
		}

		public void AddEdge(TVertex from, Edge<TVertex> to)
		{
			AddVertex(from);
			_adjacencyList[from].Add(to);
		}

		public abstract void Accept(IGraphVisitor<TGraph, TVertex> visitor);
	}
}