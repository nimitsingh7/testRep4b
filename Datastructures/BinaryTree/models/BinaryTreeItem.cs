using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeApp.models
{
    class BinaryTreeItem
    {
        public int? Item { get; set; }
        public BinaryTreeItem leftItem { get; set; }
        public BinaryTreeItem rightItem { get; set; }
        public int Counter { get; set; }

        public BinaryTreeItem() : this(null, null, null) { }
        public BinaryTreeItem(int? item, BinaryTreeItem leftitem, BinaryTreeItem rightitem)
        {
            this.Item = item;
            this.leftItem = leftitem;
            this.rightItem = rightitem;
            if (item == null)
            {
                this.Counter = 0;
            }
            else
            {
                this.Counter = 1;
            }
        }

        // ToString
        public override string ToString()
        {
            if (this.Item == null)
            {
                return "Leerer Eintrag" + " (#: " + this.Counter + ") ";
            }
            else
            {
                return this.Item + " (#: " + this.Counter + ") ";
            }
        }


    }
}