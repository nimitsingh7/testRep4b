using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList.models
{
    class DoubleLinkedList<T> where T : class
    {
        private DoubleLinkedListitem<T> firstItem;
        private DoubleLinkedListitem<T> lastItem;

        public DoubleLinkedList()
        {
            this.firstItem = null;
            this.lastItem = null;
        }

        public DoubleLinkedList(T item)
        {
            this.firstItem = new DoubleLinkedListitem<T>(item, null,null);
            this.lastItem = firstItem;
        }

        public DoubleLinkedList(DoubleLinkedList<T> dll)
        {
            this.firstItem = dll.firstItem;
            this.lastItem = dll.lastItem;
        }

        // Methoden

        // Add
        public bool Add(T itemtoAdd)
        {
            // Parameter überprüfen
            if (itemtoAdd == null)
            {
                return false;
            }

            // 1. Fall
            if (firstItem == null)
            {
                this.firstItem = new DoubleLinkedListitem<T>(itemtoAdd, null, null);
                this.lastItem = this.firstItem;
            }

            // 2. Fall
            else
            {
                this.lastItem.NextItem = new DoubleLinkedListitem<T>(itemtoAdd, null, lastItem);
                this.lastItem = this.lastItem.NextItem;
            }

            return false;
        }
        // Find
        public DoubleLinkedListitem<T> Find(T itemtoFind)
        {
            // Parameter überprüfen
            if (itemtoFind == null)
            {
                return null;
            }

            if (firstItem == null)
            {
                return null;
            }

            // Zeiger erstellen
            DoubleLinkedListitem<T> tmp = this.firstItem;

            // Liste durchlaufen
            while (tmp != null)
            {
                if (tmp.Item.Equals(itemtoFind))
                {
                    return tmp;
                }
                tmp = tmp.NextItem;
            }
            return null;
        }
        // AddItemAfterItem
        public bool AddItemAfterItem(T itemtoAdd, T itemtoFind)
        {
            // Parameter überprüfen
            if (itemtoAdd == null)
            {
                return false;
            }

            if (itemtoFind == null)
            {
                return false;
            }

            if (firstItem == null)
            {
                return Add(itemtoAdd);
            }

            DoubleLinkedListitem<T> tmp = Find(itemtoFind);

            if (tmp == null)
            {
                return Add(itemtoAdd);
            }

            if (tmp == lastItem)
            {
                this.lastItem.NextItem = new DoubleLinkedListitem<T>(itemtoAdd, null, lastItem);
                this.lastItem = this.lastItem.NextItem;
            }
            else
            {
                DoubleLinkedListitem<T> newItem = new DoubleLinkedListitem<T>(itemtoAdd, null, lastItem);
                tmp.NextItem = newItem;
                newItem = newItem.NextItem.ItemBefore;
            }

            return true;
        }
        // Change
        public bool Change(T itemtoChange, T newData)
        {
            // Parameter überprüfen
            if (itemtoChange == null || newData == null || this.firstItem == null)
            {
                return false;
            }

            DoubleLinkedListitem<T> foundItem = Find(itemtoChange);

            if (foundItem == null)
            {
                return false;
            }
            else
            {
                foundItem.Item = newData;
                return true;
            }

        }
        // Remove
        public bool Remove(T itemToRemove)
        {
            DoubleLinkedListitem<T> foundItem = Find(itemToRemove);

            // Parameter überprüfen
            if (itemToRemove == null)
            {
                return false;
            }

            if (this.firstItem == null)
            {
                return false;
            }

            if (foundItem == null)
            {
                return false;
            }

            //1. Fall (firstItem löschen)
            if (firstItem == itemToRemove)
            {
                firstItem = firstItem.NextItem;
                firstItem.ItemBefore = null;
            }

            // 2. Fall (lastItem löschen)
            if (this.lastItem == itemToRemove)
            {
                this.lastItem = this.lastItem.ItemBefore;
                this.lastItem.NextItem = null;
            }

            // 3. Fall (itemToRemove ist irgendwo dazwischen)
            if (foundItem == itemToRemove)
            {
                foundItem.ItemBefore.NextItem = foundItem.NextItem;
                foundItem.NextItem.ItemBefore = foundItem.ItemBefore;
            }

            return true;
        }
        //  AddItemBeforeItem
        public bool AddItemBeforeItem(T itemtoAdd, T itemtoFind)
        {
            // Parameter überprüfen
            if (itemtoAdd == null)
            {
                return false;
            }
            if (itemtoFind == null)
            {
                return false;
            }

            DoubleLinkedListitem<T> foundItem = Find(itemtoFind);
            if (foundItem == null)
            {
                return false;
            }

            // 1. Fall (foundItem ist gleich firstItem)
            if (foundItem == firstItem)
            {
                foundItem.ItemBefore = new DoubleLinkedListitem<T>(itemtoAdd, this.firstItem, null);
                this.firstItem = firstItem.ItemBefore;
                return true;
            }

            // 2. Fall (Item irgendwo hinzufügen, bleibt auch gleich wenn ich vor dem lastItem es hinzufügen will)
            // (foundItem.Item.Equals(itemtoFind))
            else
            {
                // Eine Variante:
                // DoubleLinkedListitem<T> tmp = new DoubleLinkedListitem<T>(itemtoAdd, foundItem, foundItem.ItemBefore);
                // foundItem.ItemBefore.NextItem = tmp;
                // foundItem.ItemBefore = tmp;

                foundItem.ItemBefore = new DoubleLinkedListitem<T>(itemtoAdd, foundItem, foundItem.ItemBefore);
                foundItem.ItemBefore.ItemBefore.NextItem = foundItem.ItemBefore;
            }

            return true;

        }

        public override string ToString()
        {
            string s = "";

            if (this.firstItem != null)
            {
                DoubleLinkedListitem<T> actItem = this.firstItem;
                while (actItem != null)
                {
                    s += actItem.Item.ToString() + "\n";
                    actItem = actItem.NextItem;
                }
            }

            if (s == "")
            {
                return "no item";
            }

            return s;
        }

    }
}