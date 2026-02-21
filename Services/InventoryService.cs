namespace Inventory_Management.Services
{
    public class InventoryService
    {
        private string[,] products;
        private readonly string[] initialStock;

        public InventoryService()
        {
            products = new string[2, 3]
            {
                { "Apples", "Milk", "Bread" },
                { "10",     "5",    "20"    }
            };

            initialStock = new string[3]
            {
                products[1, 0],
                products[1, 1],
                products[1, 2]
            };
        }

        public int GetProductCount()
        {
            return products.GetLength(1);
        }

        public string GetProductName(int index)
        {
            return products[0, index];
        }

        public string GetStock(int index)
        {
            return products[1, index];
        }

        public void UpdateStock(int index, string newQuantity)
        {
            products[1, index] = newQuantity;
        }

        public void ResetInventory()
        {
            for (int i = 0; i < products.GetLength(1); i++)
            {
                products[1, i] = initialStock[i];
            }
        }
    }
}
