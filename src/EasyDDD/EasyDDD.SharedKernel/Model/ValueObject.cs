using Ardalis.GuardClauses;

namespace EasyDDD.SharedKernel.Model
{
    /// <summary>
    /// Represent a value object base.
    /// </summary>
    public abstract class ValueObject : IComparable, IComparable<ValueObject>
    {
        private int? cachedHashCode;

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The entity a.</param>
        /// <param name="b">The entity b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Override a equals method.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>If object to compare is equal, return true, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            Guard.Against.Null(obj, nameof(obj));

            if (obj is null)
            {
                Console.WriteLine("dsffsd");
            }

            if (obj == null)
            {
                return false;
            }

            if (GetUnproxiedType(this) != GetUnproxiedType(obj))
            {
                return false;
            }

            var valueObject = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        /// <summary>
        /// Get the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            if (!this.cachedHashCode.HasValue)
            {
                this.cachedHashCode = this.GetEqualityComponents()
                    .Aggregate(1, (current, obj) =>
                    {
                        unchecked
                        {
                            return (current * 23) + (obj?.GetHashCode() ?? 0);
                        }
                    });
            }

            return this.cachedHashCode.Value;
        }

        /// <summary>
        /// Compare two objects.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>If object is compare to, return true, otherwise false.</returns>
        public int CompareTo(object obj)
        {
            Guard.Against.Null(obj, nameof(obj));

            Type thisType = GetUnproxiedType(this);
            Type otherType = GetUnproxiedType(obj);

            if (thisType != otherType)
            {
                return string.Compare(thisType.ToString(), otherType.ToString(), StringComparison.Ordinal);
            }

            var other = (ValueObject)obj;

            object[] components = this.GetEqualityComponents().ToArray();
            object[] otherComponents = other.GetEqualityComponents().ToArray();

            for (int i = 0; i < components.Length; i++)
            {
                int comparison = this.CompareComponents(components[i], otherComponents[i]);
                if (comparison != 0)
                {
                    return comparison;
                }
            }

            return 0;
        }

        /// <summary>
        /// Compare two objects.
        /// </summary>
        /// <param name="other">The object.</param>
        /// <returns>If object is compare to, return true, otherwise false.</returns>
        public int CompareTo(ValueObject other)
        {
            return this.CompareTo(other as object);
        }

        /// <summary>
        /// Get object type.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The type.</returns>
        internal static Type GetUnproxiedType(object obj)
        {
            Guard.Against.Null(obj, nameof(obj));

            const string EFCoreProxyPrefix = "Castle.Proxies.";
            const string NHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
            {
                return type.BaseType;
            }

            return type;
        }

        /// <summary>
        /// Return a Ienumerable of objects.
        /// </summary>
        /// <returns>IEnumerable of objecys.</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();

        private int CompareComponents(object object1, object object2)
        {
            if (object1 is null && object2 is null)
            {
                return 0;
            }

            if (object1 is null)
            {
                return -1;
            }

            if (object2 is null)
            {
                return 1;
            }

            if (object1 is IComparable comparable1 && object2 is IComparable comparable2)
            {
                return comparable1.CompareTo(comparable2);
            }

            return object1.Equals(object2) ? 0 : -1;
        }
    }
}
