using System.Collections.ObjectModel;
using Catalog.Models;
using Catalog.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using MySqlConnector;

namespace Catalog.ViewModels;

public partial class edit : ViewModelBase
{
    [ObservableProperty]
    private Product _selectedItem;
    
    ObservableCollection<Product> _products;
    private readonly DatabaseService DBService = new DatabaseService();

    public edit()
    {
        DBService = new DatabaseService();
    }

    public void SetProduct(Product product)
    {
        SelectedItem = product;
    }

   





}