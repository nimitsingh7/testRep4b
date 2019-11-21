using System;
using System.Collections.Generic;
using System.Text;
using BinaryTreeApp.models;

namespace BinaryTreeApp.models
{
    class BinaryTree
    {
        private BinaryTreeItem _root;

        //Add 
        //Add
        public void Add(int? itemtoAdd)
        {
            if (itemtoAdd == null)
            {
                return;
            }

            if (_root == null)
            {
                this._root = new BinaryTreeItem(itemtoAdd, null, null);
            }

            BinaryTreeItem tmp = this._root;

            while (tmp != null)
            {
                if (tmp.Item.Equals(itemtoAdd))
                {
                    tmp.Counter++;
                    return;
                }

                if (itemtoAdd > tmp.Item)
                {
                    if (tmp.rightItem == null)
                    {
                        tmp.rightItem = new BinaryTreeItem(itemtoAdd, null, null);
                        return;
                    }
                    tmp = tmp.rightItem;
                }
                
                if (itemtoAdd < tmp.Item)
                {
                    if (tmp.leftItem == null)
                    {
                        tmp.leftItem = new BinaryTreeItem(itemtoAdd, null, null);
                        return;
                    }
                    tmp = tmp.leftItem;
                }

            }
        }
        // Add Rek.
        public bool AddRek(int itemToAdd, BinaryTreeItem actItem = null)
        {

            //Liste gibt es nicht
            if (this._root == null)
            {
                this._root = new BinaryTreeItem(itemToAdd, null, null);
                return true;
            }
            //größer, kleiner, gleich vergleich
            if (actItem == null)
            {
                actItem = this._root;
            }

            if ((itemToAdd < actItem.Item) && (actItem.leftItem != null))
            {
                actItem = actItem.leftItem;
            }
            else if ((itemToAdd > actItem.Item) && (actItem.leftItem != null))
            {
                actItem = actItem.leftItem;
            }


            if ((actItem.rightItem == null) && (itemToAdd > actItem.Item))
            {
                actItem.rightItem = new BinaryTreeItem(itemToAdd, null, null);
                return true;
            }
            else if ((actItem.leftItem == null) && (itemToAdd < actItem.Item))
            {
                actItem.leftItem = new BinaryTreeItem(itemToAdd, null, null);
                return true;
            }
            else if (actItem.Item.Equals(itemToAdd))
            {
                actItem.Counter++;
                return true;
            }
            else
            {
                return AddRek(itemToAdd, actItem);
            }
        }
        // Find
        public BinaryTreeItem Find(int itemToFind, BinaryTreeItem actItem = null)
        {
            if ((itemToFind == 0) || (this._root == null))
            {
                return null;
            }

            if (actItem == null)
            {
                actItem = this._root;
            }

            if (actItem.Item > itemToFind)
            {
                actItem = actItem.leftItem;
            }
            else if (actItem.Item < itemToFind)
            {
                actItem = actItem.rightItem;
            }
            else
            {
                return actItem;
            }

            if (actItem == null)
            {
                return null;
            }
            else if (actItem.Item.Equals(itemToFind))
            {
                return actItem;
            }
            else
            {
                return Find(itemToFind, actItem);
            }
        }
        // Min
        public BinaryTreeItem Minimum(int MinItem, BinaryTreeItem actItem = null)
        {
            if ((MinItem == 0) || (this._root == null))
            {
                return null;
            }
            //MinItem in der Liste finden
            BinaryTreeItem foundItem = Find(MinItem);

            if (foundItem == null)
            {
                return null;
            }
            //actItem zum weiterlaufen der Liste
            if (actItem == null)
            {
                actItem = foundItem;
            }
            //wenn es etwas kleineres gibt
            if (actItem.leftItem != null)
            {
                actItem = actItem.leftItem;
            }
            //überprüfen & Stop für Rekursion
            if (actItem.leftItem == null)
            {
                return actItem;
            }
            else
            {
                return Minimum(MinItem, actItem);
            }
        }
        // Max
        public BinaryTreeItem Maximum(int MaxItem, BinaryTreeItem actItem = null)
        {
            if ((MaxItem == 0) || (this._root == null))
            {
                return null;
            }
            //Maxitem in der Liste finden 
            BinaryTreeItem foundItem = Find(MaxItem);

            if (foundItem == null)
            {
                return null;
            }
            //actItem zum weiterlaufen der Liste
            if (actItem == null)
            {
                actItem = foundItem;
            }
            //gibt es ein größeres Item
            if (actItem.rightItem != null)
            {
                actItem = actItem.rightItem;
            }
            //Überprüfen & Stop für Rekursion
            if (actItem.rightItem == null)
            {
                return actItem;
            }
            else
            {
                return Maximum(MaxItem, actItem);
            }
        }
        // Min Rek.
        public BinaryTreeItem MinimumRecursiv(int? startValue = null, BinaryTreeItem actItem = null)
        {
            //bei "ersten" Aufruf ist actItem null
            if (actItem == null)
            {
                //falls startValue != null ist, suchen wir das Element im Baum und setzen das actItem
                if (startValue != null)
                {
                    actItem = Find(startValue.Value);
                }
                //ansonsten starten wir bei _root
                else
                {
                    actItem = this._root;
                }
            }
            //bei allen weiteren Aufrufen, setzen wir den Zeiger auf den LeftItem
            else
            {
                actItem = actItem.leftItem;
            }

            if (actItem == null)
            {
                return null;
            }

            //Minimum wurde gefunden
            if (actItem.leftItem == null)
            {
                return actItem;
            }
            else
            {
                return MinimumRecursiv(startValue, actItem);
            }
        }
        // Max Rek.
        public BinaryTreeItem MaximumRecursiv(int? startValue = null, BinaryTreeItem actItem = null)
        {
            //bei "ersten" Aufruf ist actItem null
            if (actItem == null)
            {
                //falls startValue != null ist, suchen wir das Element im Baum und setzen das actItem
                if (startValue != null)
                {
                    actItem = Find(startValue.Value);
                }
                //ansonsten starten wir bei _root
                else
                {
                    actItem = this._root;
                }
            }
            //bei allen weiteren Aufrufen, setzen wir den Zeiger auf den RightItem
            else
            {
                actItem = actItem.rightItem;
            }

            if (actItem == null)
            {
                return null;
            }

            //Minimum wurde gefunden
            if (actItem.rightItem == null)
            {
                return actItem;
            }
            else
            {
                return MaximumRecursiv(startValue, actItem);
            }
        }

        public BinaryTreeItem Remove(int itemtoRemove, BinaryTreeItem actItem = null)
        {
            if (itemtoRemove )
            {

            }
        }

    }
}
