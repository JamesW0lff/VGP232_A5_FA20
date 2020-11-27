using System;
using System.Collections.Generic;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            Character hero = new Character("Bob", RaceCategory.Human, 100);

            Console.WriteLine("{0} has entered the forest", hero.Name );

            string monster = "goblin";
            int damage = 10;

            Console.WriteLine("A {0} appeared and attacks {1}", monster, hero.Name);

            Console.WriteLine("{0} takes {1} damage", hero.Name, damage);

            hero.TakeDamage(damage);
            Console.WriteLine(hero);

            Console.WriteLine("{0} flees from the enemy", hero.Name);

            string item = "small health potion";
            int restoreAmount = 10;

            Console.WriteLine("{0} find a {1} and drinks it", hero.Name, item);

            Console.WriteLine("{0} restores {1} health", hero.Name, restoreAmount);

            hero.RestoreHealth(restoreAmount);

            Console.WriteLine(hero);

            if (hero.IsAlive)
            {
                Console.WriteLine("Congratulations! {0} survived.", hero.Name);
            }
            else
            {
                Console.WriteLine("{0} has died.", hero.Name);
            }
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
