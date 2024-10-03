using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TradeApp.Entities;
using TradeApp.Views;

namespace TradeApp.Views;

public partial class AuthorizationView : UserControl
{
    public AuthorizationView()
    {
        InitializeComponent();
        
    }
       private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private void AuthButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) 
    { 
        var LoginTB = this.FindControl<TextBox>("LoginTB"); 
        var PasswordTB = this.FindControl<TextBox>("PasswordTB"); 
        
        Trade1Context context = new Trade1Context(); 
        // var userNameTB = 
        var currentUser = context.Users.FirstOrDefault(x => x.UserLogin == LoginTB.Text && x.UserPassword == PasswordTB.Text); 
        if (currentUser != null) 
        { 
            App.MainWindow.MainContentControl.Content = new ProductsView(currentUser); 

        } 
 
        //App.MainWindow.MainContentControl.Content = new UserEditView(new User()); 
    } 
    private void Guestutton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) 
    { 
        //App.MainWindow.MainContentControl.Content = new UserEditView(new User()); 
    } 
}
