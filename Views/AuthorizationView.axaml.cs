using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TradeApp.Entities;
using TradeApp.Utils;
using TradeApp.Views;

namespace TradeApp.Views;

public partial class AuthorizationView : UserControl
{
    string captcha;
    public AuthorizationView()
    {
        InitializeComponent();
        var CaptchaTextBox = this.FindControl<TextBox>("CaptchaTextBox"); 
        var tuple = Captcha.CreateImage(300, 100, 5);
        var CaptchaImage = this.FindControl<Image>("CaptchaImage");
        CaptchaImage.Source = tuple.image;
        captcha = CaptchaTextBox.Text = tuple.captcha;
    }
       private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private void AuthButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) 
    { 
        Trade1Context context = new Trade1Context(); 
        var LoginTB = this.FindControl<TextBox>("LoginTB"); 
        var PasswordTB = this.FindControl<TextBox>("PasswordTB"); 
        var CaptchaTextBox = this.FindControl<TextBox>("CaptchaTextBox");
        var currentUser = context.Users.FirstOrDefault(x => x.UserLogin == LoginTB.Text && x.UserPassword == PasswordTB.Text);
        if (currentUser != null && captcha == CaptchaTextBox.Text) 
        { 
            App.MainWindow.MainContentControl.Content = new ProductsView(currentUser); 

        } 
        else{
            var CaptchaPanel = this.FindControl<StackPanel>("CaptchaPanel");
            CaptchaPanel.IsVisible = true;
            var tuple = Captcha.CreateImage(300, 100, 5);
            var CaptchaImage = this.FindControl<Image>("CaptchaImage");
            CaptchaImage.Source = tuple.image;
            captcha = tuple.captcha;
        }
 
        //App.MainWindow.MainContentControl.Content = new UserEditView(new User()); 
    } 
    private void Guestutton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) 
    { 
        //App.MainWindow.MainContentControl.Content = new UserEditView(new User()); 
    } 
}
