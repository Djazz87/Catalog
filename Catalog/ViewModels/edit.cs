using System.Collections.ObjectModel;
using Catalog.Models;
using Catalog.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MySqlConnector;

namespace Catalog.ViewModels;

public partial class edit : ViewModelBase
{
    [ObservableProperty]
    private Product _selectedItem;
    
    ObservableCollection<Product> _products;
    private DatabaseService DBServicee { get; set; }

    public edit()
    {
        DBServicee = new DatabaseService();
        
    }

    public void SetProduct(Product product)
    {
        SelectedItem = product;
    }

   
    [RelayCommand]
    public void Save()
    {
        DatabaseService.Update(SelectedItem);
    }

    [RelayCommand]
    public void Delete()
    {
        DatabaseService.Delete(SelectedItem.ProductId);
    }
    
    




}