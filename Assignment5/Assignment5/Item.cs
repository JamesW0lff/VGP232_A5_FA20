using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public enum ItemGroup { Consumable, Key, Equipment };
    public class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public ItemGroup Group { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="group"></param>
        #region ITEM
        public Item(string name, int amount, ItemGroup group)
        {
            Name = name;
            Amount = amount;
            Group = group;
        }
        #endregion

        #region TO STRING
        public override string ToString()
        {
            // TODO: display the output like this Axe
            return base.ToString();
        }
        #endregion
    }
}
