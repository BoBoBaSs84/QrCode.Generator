using System.Windows;

using WIFI.QRCode.Builder.Views;

namespace WIFI.QRCode.Builder;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  private void Application_Startup(object sender, StartupEventArgs e)
  {
    MainView mainView = new();
    mainView.Show();
  }
}
