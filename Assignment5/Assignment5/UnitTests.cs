using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5
{
    public class UnitTests
    {
        #region CHARACTER TESTS

        #region TAKE DAMAGE REDUCE
        [TestCase(10, 90)]
        public void TakeDamage_Reduce(int damage, int expectedHealth)
        {
            Character hero = new Character("Jaime", RaceCategory.Human, 100);
            Console.WriteLine($"{hero.Name} has entered the forest");
            
            string monster = "goblin";

            Console.WriteLine($"A {monster} appeared and attacks {hero.Name}");
            Console.WriteLine($"{hero.Name} takes {damage} damage");

            hero.TakeDamage(damage);
            Console.WriteLine(hero);

            Assert.IsTrue(hero.Health == expectedHealth);
            Assert.Equals(hero.Health, expectedHealth);
        }
        #endregion

        #region PLAYER ELIMINATED
        [TestCase(110, false)]
        public void PlayerEliminated(int damage, bool expectedAliveStatus)
        {
            Character hero = new Character("Tom", RaceCategory.Human, 100);

            Console.WriteLine($"{hero.Name} has entered the forest");

            string monster = "goblin";

            Console.WriteLine($"A {monster} appeared and attacks {hero.Name}");

            Console.WriteLine($"{hero.Name} takes {damage} damage");

            hero.TakeDamage(damage);
            Console.WriteLine(hero);

            Console.WriteLine($"{hero.Name} flees from the enemy");

            string itemCharacter = "small health potion";
            int restoreAmount = 10;

            Console.WriteLine($"{hero.Name} find a {itemCharacter} and drinks it");

            Console.WriteLine($"{hero.Name} restores {restoreAmount} health");

            hero.RestoreHealth(restoreAmount);

            Console.WriteLine(hero);

            if (hero.IsAlive)
            {
                Console.WriteLine($"Congratulations! {hero.Name} survived.");
            }
            else
            {
                Console.WriteLine($"{hero.Name} has died.");
            }

            Assert.IsTrue(hero.IsAlive == expectedAliveStatus);
            Assert.Equals(hero.IsAlive, expectedAliveStatus);
        }
        #endregion

        #region PLAYER BARLEY SURVIVED
        [TestCase(100, true)]
        public void PlayerBarleySurvived(int damage, bool expectedAliveStatus)
        {
            Character hero = new Character("Jake", RaceCategory.Human, 100);

            Console.WriteLine($"{hero.Name} has entered the forest");

            string monster = "goblin";

            Console.WriteLine($"A {monster} appeared and attacks {hero.Name}");

            Console.WriteLine($"{hero.Name} takes {damage} damage");

            hero.TakeDamage(damage);
            Console.WriteLine(hero);

            Console.WriteLine($"{hero.Name} flees from the enemy");

            string itemCharacter = "small health potion";
            int restoreAmount = 10;

            Console.WriteLine($"{hero.Name} find a {itemCharacter} and drinks it");

            Console.WriteLine($"{hero.Name} restores {restoreAmount} health");

            hero.RestoreHealth(restoreAmount);

            Console.WriteLine(hero);

            if (hero.IsAlive)
            {
                Console.WriteLine($"Congratulations! {hero.Name} survived.");
            }
            else
            {
                Console.WriteLine($"{hero.Name} has died.");
            }

            Assert.IsTrue(hero.IsAlive == expectedAliveStatus);
            Assert.Equals(hero.IsAlive, expectedAliveStatus);
        }
        #endregion

        #region HEAL PLAYER
        [TestCase(10, 100)]
        public void HealPlayer(int restoreAmount, int expectedHealth)
        {
            Character hero = new Character("James", RaceCategory.Human, 90);
            
            string itemCharacter = "small health potion";

            Console.WriteLine($"{hero.Name} find a {itemCharacter} and drinks it");
            Console.WriteLine($"{hero.Name} restores {restoreAmount} health");

            hero.RestoreHealth(restoreAmount);
            Console.WriteLine(hero);

            Assert.IsTrue(hero.Health == expectedHealth);
            Assert.Equals(hero.Health, expectedHealth);
        }
        #endregion

        #endregion

        #region INVENTORY TESTS

        #region ADD ITEM
        [Test]
        public void AddItem()
        {
            Inventory inventory = new Inventory(5);
            Item item = new Item("Tea", 15, ItemGroup.Consumable);

            Console.WriteLine($"There are {inventory.AvailableSlots}/{inventory.MaxSlots} available slots");
            Console.WriteLine($"The following item will be added twice:" +
                                $"\n  NAME:   {item.Name}" +
                                $"\n  AMOUNT: {item.Amount}" +
                                $"\n  GROUP:  {item.Group}");

            // Adding twice the same item
            inventory.AddItem(item);
            inventory.AddItem(item);

            item = new Item("Exit Door", 10, ItemGroup.Key);

            Console.WriteLine($"The following item will be added once:" +
                                $"\n  NAME:   {item.Name}" +
                                $"\n  AMOUNT: {item.Amount}" +
                                $"\n  GROUP:  {item.Group}");

            // Adding the new item
            inventory.AddItem(item);

            Console.WriteLine($"There are {inventory.AvailableSlots}/{inventory.MaxSlots} available slots");
        }
        #endregion

        #region REMOVE EXISTING ITEM
        [Test]
        public void RemoveExistingItem()
        {
            Inventory inventory = new Inventory(5);
            Item item = new Item("Shield", 75, ItemGroup.Equipment);
            string itemName = string.Empty;

            Console.WriteLine($"There are {inventory.AvailableSlots}/{inventory.MaxSlots} available slots");
            Console.WriteLine($"The following item will be added twice:" +
                                $"\n  NAME:   {item.Name}" +
                                $"\n  AMOUNT: {item.Amount}" +
                                $"\n  GROUP:  {item.Group}");

            inventory.AddItem(item);

            item = new Item("Sword", 100, ItemGroup.Equipment);

            inventory.AddItem(item);

            // Remove existing item
            itemName = "Sword";
            if (inventory.TakeItem(itemName, out item))
            {
                Console.WriteLine($"You use: {item.Name}");
            }
            else
            {
                Console.WriteLine($"{itemName} not found!");
            }

            Console.WriteLine($"There are {inventory.AvailableSlots}/{inventory.MaxSlots} available slots");

        }
        #endregion

        #region REMOVE NON-EXISTING ITEM
        [Test]
        public void RemoveNonExistingItem()
        {
            Inventory inventory = new Inventory(5);
            Item item = new Item("Fron Door", 5, ItemGroup.Key);
            string itemName = string.Empty;

            Console.WriteLine($"There are {inventory.AvailableSlots}/{inventory.MaxSlots} available slots");
            Console.WriteLine($"The following item will be added twice:" +
                                $"\n  NAME:   {item.Name}" +
                                $"\n  AMOUNT: {item.Amount}" +
                                $"\n  GROUP:  {item.Group}");

            inventory.AddItem(item);

            item = new Item("Back Door", 100, ItemGroup.Key);

            inventory.AddItem(item);

            // Remove non-existing item
            itemName = "Sword";
            if (inventory.TakeItem(itemName, out item))
            {
                Console.WriteLine($"You use: {item.Name}");
            }
            else
            {
                Console.WriteLine($"{itemName} not found!");
            }

            Console.WriteLine($"There are {inventory.AvailableSlots}/{inventory.MaxSlots} available slots");
        }
        #endregion

        #region RESET INVENTORY
        [Test]
        public void ResetInventory()
        {
            Inventory inventory = new Inventory(5);
            Item item = new Item("Green Herb", 10, ItemGroup.Consumable);

            Console.WriteLine($"There are {inventory.AvailableSlots}/{inventory.MaxSlots} available slots");
            Console.WriteLine($"The following item will be added twice:" +
                                $"\n  NAME:   {item.Name}" +
                                $"\n  AMOUNT: {item.Amount}" +
                                $"\n  GROUP:  {item.Group}");

            inventory.AddItem(item);

            item = new Item("Red Herb", 15, ItemGroup.Consumable);

            Console.WriteLine($"The following item will be added once:" +
                                $"\n  NAME:   {item.Name}" +
                                $"\n  AMOUNT: {item.Amount}" +
                                $"\n  GROUP:  {item.Group}");

            inventory.AddItem(item);

            item = new Item("Yellow Herb", 20, ItemGroup.Consumable);

            Console.WriteLine($"The following item will be added once:" +
                                $"\n  NAME:   {item.Name}" +
                                $"\n  AMOUNT: {item.Amount}" +
                                $"\n  GROUP:  {item.Group}");

            inventory.AddItem(item);

            Console.WriteLine($"There are {inventory.AvailableSlots}/{inventory.MaxSlots} available slots");

            // Reset the inventory

            Console.Write("Dropping all items!");

            inventory.Reset();

            Console.WriteLine($"There are {inventory.AvailableSlots}/{inventory.MaxSlots} available slots");
        }
        #endregion

        #endregion

    }
}
