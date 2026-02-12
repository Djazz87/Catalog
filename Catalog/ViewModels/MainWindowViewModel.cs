using System.Collections.ObjectModel;
using Catalog.Models;
using Catalog.Services;
using Catalog.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Catalog.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   [ObservableProperty]
   private ObservableCollection<Product> _product;

   private Product _selectedItem;
   
   private  DatabaseService DBService = new DatabaseService();

   public MainWindowViewModel()
   {
      
      Product =  new ObservableCollection<Product>(DatabaseService.GetProducts());
     
      
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
[RelayCommand]
   public void Delete()
   {
      if (SelectedItem == null)
         return;
      if (DatabaseService.Delete(SelectedItem.ProductId))
         Product.Remove(SelectedItem);
   }
}