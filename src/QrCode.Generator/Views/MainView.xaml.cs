using System.Windows;

using WIFI.QRCode.Builder.ViewModels;

namespace WIFI.QRCode.Builder.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainView : Window
{
  /// <summary>
  /// Initializes an instance of <see cref="MainView"/> class.
  /// </summary>
  public MainView()
  {
    DataContext = new MainViewModel();
    InitializeComponent();
  }
}