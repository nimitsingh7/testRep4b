using System;
using System.Collections.Generic;
using System.Text;

namespace SingleLinkedList.models
{
    // generic
    class SingleLinkedListitem<T> where T : class
    {
        public T Item { get; set; }
        // Referenz auf das nächste Item
        public SingleLinkedListitem<T> NextItem { get; set; }

        // ctors
        public SingleLinkedListitem() : this(null, null) {}

        public SingleLinkedListitem(T item, SingleLinkedListitem<T> nextItem)
        {
            this.Item = item;
            this.NextItem = nextItem;
        }

        public override string ToString()
        {
            return this.Item.ToString();
        }

    }
}