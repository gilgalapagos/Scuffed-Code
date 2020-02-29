using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    enum State
    {
        MainMenu,
        EditItems,
        Display
    }

    class Inventory
    {
        private List<string> inventory;

        public string Name { get; private set; }
        public int Count { get; private set; }

        public Inventory(string name)
        {
            inventory = new List<string>();
            Name = name;
        }

        public void DisplayItems()
        {
            Console.Clear();
            Console.WriteLine("{0}\nTotal Item Count: {1}\n\n", Name, Count);
            foreach (string item in inventory)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void AddItem()
        {
            Console.WriteLine("Enter item name: ");
            string item = Console.ReadLine();
            inventory.Add(item);
            Count++;
        }

        public void RemoveItem()
        {
            while (true)
            {
                Console.WriteLine("Enter item name for removal: ");
                string item = Console.ReadLine();
                if (inventory.Contains(item))
                {
                    inventory.Remove(item);
                    Count--;
                    break;
                }
                else
                {
                    Console.WriteLine("Item does not exist");
                    Console.ReadLine();
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Inventory inventory = new Inventory("Fruit");
            while (true)
            {
                Console.Clear();
                State state = State.MainMenu;
                bool validSelection;
                int menuSelection = 0;
                if (state == State.MainMenu)
                {
                    Console.WriteLine(
                    "|Make Selection|\n-------------------\n[1] Display Items\n[2] Edit Inventory");
                    while (true)
                    {
                        if (!int.TryParse(Console.ReadLine(), out menuSelection) || menuSelection != 1 && menuSelection != 2)
                        {
                            Console.WriteLine("Invalid Input");
                            continue;
                        }
                        break;
                    }

                    if (menuSelection == 1) { state = State.Display; }
                    else { state = State.EditItems; }
                }
                if (state == State.Display)
                {
                    inventory.DisplayItems();
                    continue;
                }
                if (state == State.EditItems)
                {
                    Console.WriteLine("Make editing selection\n[1] Add Item\n[2] Remove Item\n[3] Exit");
                    while (true)
                    {
                        if (!int.TryParse(Console.ReadLine(), out menuSelection) || menuSelection != 1 && menuSelection != 2 && menuSelection != 3)
                        {
                            Console.WriteLine("Invalid Input");
                            continue;
                        }
                        break;
                    }
                }

                if (menuSelection == 1)
                {
                    inventory.AddItem();
                }

                if (menuSelection == 2)
                {
                    inventory.DisplayItems();
                    inventory.RemoveItem();
                }
            }
        }
    }
}
