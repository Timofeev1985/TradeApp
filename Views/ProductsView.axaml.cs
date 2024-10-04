using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TradeApp.Entities;
namespace TradeApp.Views;

public partial class ProductsView : UserControl
{
     public List<Product> Products { get; set; }
     public User User{ get; set; }
    Trade1Context context;
    public ProductsView(User user)
    {
        InitializeComponent();
         context = new Trade1Context();
         User=user;
        Products = context.Products.ToList();
        DataContext = this;
    }
     private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
     private void CloseButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentControl.Content = new AuthorizationView();
    }
}