using Avalonia.Controls;
using TradeApp.Views;
namespace TradeApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        App.MainWindow = this;
        App.MainWindow.MainContentControl.Content= new AuthorizationView();
    }
}