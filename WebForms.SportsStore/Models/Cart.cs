using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.SportsStore.Models
{
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();

        public void Add(Product prod, int qty)
        {
            CartItem newOrExistingItem = new CartItem { Product = prod, Quantity = qty };

            if (items.Contains(newOrExistingItem))
            {
                int existingItemIndex = items.IndexOf(newOrExistingItem);
                items[existingItemIndex].Quantity += newOrExistingItem.Quantity;
            }
            else
            {
                items.Add(newOrExistingItem);
            }
        }


        public void Remove(Product prod)
        {
            CartItem itemToDelete = new CartItem { Product = prod};

            items.Remove(itemToDelete);
        }

        public void Clear()
        {
            items.Clear();
        }

        public IEnumerable<CartItem> Items { get { return items; } }

        public decimal ComputeTotalValue()
        {
            return items.Sum(i => i.Quantity * i.Product.Price);
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            return this.Product.ProductID == (obj as CartItem).Product.ProductID;
        }

        public override int GetHashCode()
        {
            return Product.ProductID.GetHashCode();
        }
    }
}