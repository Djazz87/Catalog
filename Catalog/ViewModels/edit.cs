using Catalog.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Catalog.ViewModels;

public partial class edit : MainWindowViewModel
{
    [ObservableProperty]
    private Product _selectedItem;

    public void SetProduct(Product product)
    {
        SelectedItem = product;
    }


    
}