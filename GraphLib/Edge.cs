﻿using System;

namespace GraphLib
{
	public class Edge<T> where T : Vertex<T>
	{
		public T Vertex { get; protected set; }
		public string Label { get; protected set; }

		public Edge(T to, string label = null)
		{
			if (to == null)
				throw new ArgumentNullException(nameof(to));
			
			Vertex = to;
			Label = label ?? string.Empty;
		}

		public void Accept(IVertexVisitor<T> visitor)
		{
			visitor.Visit(this);
		}
	}
}