using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class Inventory
    {
        // The dictionary items consist of the item and the quantity
        private Dictionary<Item, int> items;

        #region AVAILABLE SLOTS
        public int AvailableSlots 
        { 
            get
            {
                return availableSlots;
            } 
        }
        #endregion

        #region MAX SLOTS
        public int MaxSlots
        {
            get
            {
                return maxSlots;
            }
        }
        #endregion

        // The available slots to add item, once it's 0, you cannot add any more items.
        private int availableSlots;

        // The max available slots which is set only in the constructor.
        private int maxSlots;

        #region INVENTORY
        public Inventory(int slots)
        {
            maxSlots = slots;
            availableSlots = maxSlots;
            // Never forget to initialize
            items = new Dictionary<Item, int>();
        }
        #endregion

        /// <summary>
        /// Removes all the items, and restore the original number of slots.
        /// </summary>
        #region RESET
        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }
        #endregion

        /// <summary>
        /// Removes the item from the items dictionary if the count is 1 otherwise decrease the quantity.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="found">The item if found</param>
        /// <returns>True if you find the item, and false if it does not exist.</returns>
        #region TAKE ITEM
        public bool TakeItem(string name, out Item found)
        {
            found = null;

            try
            {
                foreach (KeyValuePair<Item,int> item in items)
                {
                    if (name.Equals(item.Key.Name))
                    {
                        found = item.Key;

                        if(items[item.Key] > 1)
                        {
                            --items[item.Key];
                        }
                        else
                        {
                            items.Remove(found);
                        }

                        ++availableSlots;

                        return true;
                    }
                }
                return false;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"EXCEPTION {ex.Message}");

                return false;
            }
        }
        #endregion

        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        #region ADD ITEM
        public bool AddItem(Item item)
        {
            // Add it in the items dictionary and increment it the number if it already exist
            // Reduce the slot once it's been added.
            // returns false if the inventory is full
            // Meaning there are no available slots
            if(availableSlots == 0)
            {
                Console.WriteLine("Inventory is full!");
                return false;
            }
            else
            {
                if(items.ContainsKey(item))
                {
                    items[item] += 1;
                }
                else
                {
                    items.Add(item, 1);
                }
                // Decrease the amount of available slots in the inventory
                --availableSlots;
                return true;
            }
        }
        #endregion

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        #region LIST ALL ITEMS
        List<Item> ListAllItems()
        {
            // use a foreach loop to iterate through the key value pairs and duplicate the item base on the quantity.
            throw new NotImplementedException();
        }
        #endregion
    }
}
