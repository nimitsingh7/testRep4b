using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList.models
{
    class DoubleLinkedListitem<T> where T : class
    {
        public T Item { get; set; }
        public DoubleLinkedListitem<T> NextItem { get; set; }
        public DoubleLinkedListitem<T> ItemBefore { get; set; }

        public DoubleLinkedListitem() : this(null, null, null) { }
        public DoubleLinkedListitem(T item, DoubleLinkedListitem<T> nextitem, DoubleLinkedListitem<T> itembefore)
        {
            this.Item = item;
            this.NextItem = nextitem;
            this.ItemBefore = itembefore;
        }

        public override string ToString()
        {
            return this.Item.ToString();
        }

    }
}
