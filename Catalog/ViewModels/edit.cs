using Catalog.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Catalog.ViewModels;

public partial class edit : ViewModelBase
{
    [ObservableProperty]
    private Product _selectedItem;

    public void SetProduct(Product product)
    {
        SelectedItem = product;
    }

    public void RemoveProduct()
    {
        if (SelectedItem == null) 
            return;

        if (dbCountry.Delete(SelectedItem.Id))
            Countrie=.Remove(SelectedCountry);
    }
  
    public void SaveProduct()
    {
        
    }


    
}