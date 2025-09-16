using Assignment11._1.Data;
using Assignment11._1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment11._1.Services
{
    public interface ICRUD
    {
        void Add(Inventory item);
        void Update(Inventory item);
        void Delete(Inventory item);
        List<Models.Inventory> GetAllProducts();
    }
    public class CRUD : ICRUD
    {
        private InventoryContext context; //dependency injection via constructor
        public CRUD(InventoryContext _context)
        {
            context = _context;
        }
        public void Add(Inventory item)
        {
            try
            {
                context.Inventorystable.Add(item);
                MessageBox.Show("Record added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            context.SaveChanges();
        }
        public void Update(Inventory updatedItem)
        {
            context.Inventorystable.Update(updatedItem);
            context.SaveChanges();
        }
        public void Delete(Inventory product)
        {
            if (product != null)
            {
                context.Inventorystable.Remove(product);
                context.SaveChanges();
                MessageBox.Show("Product Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Select a product to delete");
            }
        }
        public List<Inventory> GetAllProducts()
        {
            return context.Inventorystable.ToList();
        }


    }
}
