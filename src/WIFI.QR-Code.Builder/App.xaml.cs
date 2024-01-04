using System.Windows;

using WIFI.QRCode.Builder.Windows;

namespace WIFI.QRCode.Builder;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  private void Application_Startup(object sender, StartupEventArgs e)
  {
    MainWindow mainWindow = new();
    mainWindow.Show();
  }
}
