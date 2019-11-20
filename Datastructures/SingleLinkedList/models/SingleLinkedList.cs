using System;
using System.Collections.Generic;
using System.Text;

namespace SingleLinkedList.models
{
    // generic
    class SingleLinkedList<T> where T : class
    {
        private SingleLinkedListitem<T> firstItem;
        private SingleLinkedListitem<T> lastItem;

        public SingleLinkedList()
        {
            this.firstItem = null;
            this.lastItem = null;
        }

        public SingleLinkedList(T item)
        {
            this.firstItem = new SingleLinkedListitem<T>(item, null);
            this.lastItem = firstItem;
        }

        public SingleLinkedList(SingleLinkedList<T> sll)
        {
            this.firstItem = sll.firstItem;
            this.lastItem = sll.lastItem;
        }

        // Methoden
        public bool Add(T itemToAdd)
        {
            // 1. Parameter überprüfen
            if (itemToAdd == null)
            {
                return false;
            }

            // 1. Fall: die SLL ist leer
            if (this.firstItem == null)
            {
                this.firstItem = new SingleLinkedListitem<T>(itemToAdd, null);
                this.lastItem = this.firstItem;
            }

            // 2. Fall: die SLL ist nicht leer
            else
            {
                this.lastItem.NextItem = new SingleLinkedListitem<T>(itemToAdd, null);
                this.lastItem = this.lastItem.NextItem;
            }
            return true;
        }
        public bool Remove(T itemToRemove)
        {
            if (itemToRemove == null)
            {
                return false;
            }
            // es exestiert noch kein Eintrag in der Liste
            if (this.firstItem == null)
            {
                return false;
            }

            bool isFirstItem;
            SingleLinkedListitem<T> itemBeforeItemToRemove = this.FinditembeforeItemToFind(itemToRemove, out isFirstItem);

            // Item ist nicht vorhanden
            if ((itemBeforeItemToRemove == null) && !isFirstItem)
            {
                return false;
            }

            // 1ter Fall: 1ter Eintrag
            // 1ter Eintrag ist der gesuchte Eintrag
            if (isFirstItem)
            {
                this.firstItem = this.firstItem.NextItem;
                return true;
            }

            // 2ter Fall: irgendwo zwischen firstItem und lastItem
            if (itemBeforeItemToRemove.NextItem.NextItem == null)
            {
                this.lastItem = itemBeforeItemToRemove;
                this.lastItem.NextItem = null;
                return true;
            }

            // 3ter Fall: es handelt sich um den letzten Eintrag
            if (itemBeforeItemToRemove.NextItem == itemToRemove)
            {
                itemBeforeItemToRemove.NextItem = itemBeforeItemToRemove.NextItem.NextItem;
                return true;
            }
            return false;
        }
        public SingleLinkedListitem<T> Find(T itemToFind)
        {
            if (itemToFind == null)
            {
                return null;
            }
            if (this.firstItem == null)
            {
                return null;
            }

            SingleLinkedListitem<T> tmp = this.firstItem;

            while (tmp != null)
            {
                if (tmp.Item.Equals(itemToFind))
                {
                    return tmp;
                }
                tmp = tmp.NextItem;
            }
            return null;
        }
        public SingleLinkedListitem<T> FinditembeforeItemToFind(T itemToFind, out bool isStartItem)
        {
            isStartItem = false;
            if (itemToFind == null)
            {
                return null;
            }

            if (this.firstItem == null)
            {
                return null;
            }

            if (this.firstItem.Item.Equals(itemToFind))
            {
                isStartItem = true;
                return null;
            }

            SingleLinkedListitem<T> tmp = this.firstItem;
            while (tmp != null)
            {
                if ((tmp.NextItem != null) && (tmp.NextItem.Item.Equals(itemToFind)))
                {
                    return tmp;
                }
                tmp = tmp.NextItem;
            }
            return null;
        }
        public bool Change(T itemToChange, T itemNewData)
        {
            // Parameter überprüfen
            if (itemToChange == null)
            {
                return false;
            }

            if (itemNewData == null)
            {
                return false;
            }

            if (firstItem == null)
            {
                return false;
            }

            SingleLinkedListitem<T> foundItem = Find(itemToChange);

            if (foundItem == null)
            {
                return false;
            }
            else
            {
                foundItem.Item = itemNewData;
                return true;
            }

        }

        public override string ToString()
        {
            string s = "";

            if(this.firstItem != null)
            {
                SingleLinkedListitem<T> actItem = this.firstItem;
                while(actItem != null)
                {
                    s += actItem.Item.ToString() + "\n";
                    actItem = actItem.NextItem;
                }
            }

            if(s == "")
            {
                return "no item";
            }

            return s;
        }

    }
}