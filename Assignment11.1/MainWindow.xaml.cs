using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment11._1.Data;
using Assignment11._1.Models;

namespace Assignment11._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Services.ICRUD crud;
        Inventory newProduct = new Inventory();
        public MainWindow(Services.ICRUD _crud)
        {
            InitializeComponent();
            crud = _crud;
            InventoryDG.ItemsSource = crud.GetAllProducts();
            AddProductGrid.DataContext = newProduct;

        }
        Inventory selectedrecord;
        public void UpdateEdit(object sender, EventArgs e)
        {
            selectedrecord = (sender as FrameworkElement).DataContext as Inventory;
            UpdateProductGrid.DataContext = selectedrecord;
        }
        public void AddRecord(object sender, EventArgs e)
        {
            var item = AddProductGrid.DataContext as Inventory;

            if (item == null || string.IsNullOrWhiteSpace(item.ISBN))
            {
                MessageBox.Show("ISBN is required.");
                return;
            }
            crud.Add(item);
            InventoryDG.ItemsSource = crud.GetAllProducts();
            AddProductGrid.DataContext = new Inventory();

        }
        public void DeleteRecord(object sender, EventArgs e)
        {
            var product = (sender as FrameworkElement).DataContext as Inventory;
            crud.Delete(product);
            InventoryDG.ItemsSource = crud.GetAllProducts();

        }
        public void UpdateRecord(object sender, EventArgs e)
        {
            crud.Update(selectedrecord);
            InventoryDG.ItemsSource = crud.GetAllProducts();
        }
    }
}