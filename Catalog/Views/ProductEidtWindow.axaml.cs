using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Catalog.Models;
using Catalog.ViewModels;

namespace Catalog.Views;

public partial class ProductEidtWindow : Window
{
    public ProductEidtWindow(Product product)
    {
        InitializeComponent();
        (DataContext as edit).SetProduct(product);
    }
}