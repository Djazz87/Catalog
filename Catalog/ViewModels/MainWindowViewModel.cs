using System.Collections.ObjectModel;
using Catalog.Models;
using Catalog.Services;
using Catalog.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Catalog.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   [ObservableProperty]
   private ObservableCollection<Product> _product;

   private Product _selectedItem;
   
   private readonly DatabaseService DBService = new DatabaseService();

   public MainWindowViewModel()
   {
      Product =  new ObservableCollection<Product>(DatabaseService.GetProducts());
      DBService = new DatabaseService();
      
   }
   public Product SelectedItem
   {
      get => _selectedItem;
      set
      {
         if (Equals(value, _selectedItem)) return;
         _selectedItem = value;
         OnPropertyChanged();
      }
   }

   public void Rename()
   {
      var window = new ProductEidtWindow(SelectedItem);
      window.Show();

   }
}