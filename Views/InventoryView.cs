using System;
using Inventory_Management.Services;

namespace Inventory_Management.Views
{
    public class InventoryView
    {
        private readonly InventoryService _inventoryService;

        public InventoryView()
        {
            _inventoryService = new InventoryService();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== Inventory Management =====");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        ViewInventory();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        ResetInventory();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void ViewInventory()
        {
            Console.WriteLine("\n--- Current Inventory ---");
            Console.WriteLine($"{"#",-5} {"Product",-15} {"Stock",10}");
            Console.WriteLine(new string('-', 30));

            for (int i = 0; i < _inventoryService.GetProductCount(); i++)
            {
                Console.WriteLine($"{i + 1,-5} {_inventoryService.GetProductName(i),-15} {_inventoryService.GetStock(i),10}");
            }
        }

        private void UpdateStock()
        {
            ViewInventory();
            Console.Write("\nEnter product number to update (1-3): ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int productNum) &&
                productNum >= 1 && productNum <= _inventoryService.GetProductCount())
            {
                int index = productNum - 1;
                Console.Write($"Enter new stock quantity for {_inventoryService.GetProductName(index)}: ");
                string newQty = Console.ReadLine() ?? "";

                if (int.TryParse(newQty, out int qty) && qty >= 0)
                {
                    _inventoryService.UpdateStock(index, qty.ToString());
                    Console.WriteLine($"Stock for {_inventoryService.GetProductName(index)} updated to {qty}.");
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a non-negative number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product number.");
            }
        }

        private void ResetInventory()
        {
            _inventoryService.ResetInventory();
            Console.WriteLine("Inventory has been reset to initial values.");
            ViewInventory();
        }
    }
}
