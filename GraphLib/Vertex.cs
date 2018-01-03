using System;

namespace GraphVisitor
{
	public abstract class Vertex<T> : IEquatable<T> where T : Vertex<T>
	{
		public abstract bool EqualsCore(T other);
		public abstract int GetHashCodeCore();
		
		public virtual bool Equals(T other)
		{
			if (other == null)
				return false;
			
			if (ReferenceEquals(this, other))
				return true;

			return EqualsCore(other);
		}

		public override bool Equals(object other)
		{
			var casted = other as T;
			if (casted == null)
				return false;

			if (ReferenceEquals(this, casted))
				return true;

			return EqualsCore(casted);
		}

		public override int GetHashCode()
		{
			return GetHashCodeCore();
		}

		public abstract void Accept(IVertexVisitor<T> visitor);
	}
}