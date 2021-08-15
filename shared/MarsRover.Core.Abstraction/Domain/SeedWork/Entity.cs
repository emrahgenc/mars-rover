using System;
using System.Collections.Generic;

namespace MarsRover.Core.Abstraction.Domain.SeedWork
{
    public abstract class Entity<TId> where TId : IComparable, IComparable<TId>, IEquatable<TId>
    {
        public virtual TId Id { get; protected set; }

        public bool IsTransient()
        {
            return EqualityComparer<TId>.Default.Equals(this.Id, default(TId));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TId>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity<TId> item = (Entity<TId>)obj;

            return Equals(item);
        }

        protected bool Equals(Entity<TId> item)
        {
            if (item.IsTransient() || this.IsTransient())
                return false;

            return EqualityComparer<TId>.Default.Equals(item.Id, this.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));

            if (Object.Equals(right, null))
                return (Object.Equals(left, null));

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }
    }
}
