using System;
using System.Collections.Generic;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // TODO: Create an inventory
            // TODO: Add 2 items to the inventory
            // Verify the number of items in the inventory.
            Inventory inventory = new Inventory(5);
            Item item = new Item("Apple", 10, ItemGroup.Consumable);
            string itemName = string.Empty;

            Console.WriteLine("There are {0}/{1} available slots", inventory.AvailableSlots, inventory.MaxSlots);
            Console.WriteLine($"The following item will be added twice:" +
                                $"\n  NAME:   {item.Name}" +
                                $"\n  AMOUNT: {item.Amount}" +
                                $"\n  GROUP:  {item.Group}");

            // Adding twice the same item
            inventory.AddItem(item);
            inventory.AddItem(item);

            item = new Item("Main Door", 100, ItemGroup.Key);

            Console.WriteLine($"The following item will be added once:" +
                                $"\n  NAME:   {item.Name}" +
                                $"\n  AMOUNT: {item.Amount}" +
                                $"\n  GROUP:  {item.Group}");

            // Adding the new item
            inventory.AddItem(item);

            Console.WriteLine("There are {0}/{1} available slots", inventory.AvailableSlots, inventory.MaxSlots);

            // Remove existing item
            itemName = "Apple";
            if (inventory.TakeItem(itemName, out item))
            {
                Console.WriteLine($"You use: {item.Name}");
            }
            else 
            {
                Console.WriteLine($"{itemName} not found!");
            }

            Console.WriteLine("There are {0}/{1} available slots", inventory.AvailableSlots, inventory.MaxSlots);

            // Remove a non-existing item
            itemName = "Axe";
            if (inventory.TakeItem(itemName, out item))
            {
                Console.WriteLine($"You use: {item.Name}");
            }
            else
            {
                Console.WriteLine($"{itemName} not found!");
            }

            Console.WriteLine("There are {0}/{1} available slots", inventory.AvailableSlots, inventory.MaxSlots);

            // Reset the inventory

            Console.Write("Dropping all items!");

            inventory.Reset();

            Console.WriteLine("\nThere are {0}/{1} available slots", inventory.AvailableSlots, inventory.MaxSlots);






        }
    }
}
