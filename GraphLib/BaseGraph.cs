using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GraphLib
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
			AddVertex(to.Vertex);
			_adjacencyList[from].Add(to);
		}

		public BaseGraph<TGraph, TVertex> GetTranspose()
		{
			var graph = Clone();
			if (graph == null)
				throw new InvalidOperationException("Call to Clone() returned null.");
			
			// todo: Write this function
			throw new NotImplementedException();
			
			return graph;
		}

		public abstract void Accept(IGraphVisitor<TGraph, TVertex> visitor);

		protected abstract BaseGraph<TGraph, TVertex> Clone();
	}
}