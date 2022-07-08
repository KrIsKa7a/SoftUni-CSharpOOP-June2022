namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Interfaces;

    public class AddCollection<T> : IAddCollection<T>
    {
        private readonly ICollection<T> data;

        public AddCollection()
        {
            this.data = new List<T>();
        }

        public int Add(T item)
        {
            this.data.Add(item);

            return this.data.Count - 1;
        }
    }
}
