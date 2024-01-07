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
  /// <param name="mainViewModel">The main view model instance to use.</param>
  public MainView(MainViewModel mainViewModel)
  {
    DataContext = mainViewModel;
    InitializeComponent();
  }
}