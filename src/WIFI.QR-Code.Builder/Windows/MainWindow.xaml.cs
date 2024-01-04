using System.Windows;

using WIFI.QRCode.Builder.ViewModels;

namespace WIFI.QRCode.Builder.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
  private readonly MainViewModel _mainViewModel;

  /// <summary>
  /// Initializes an instance of <see cref="MainWindow"/> class.
  /// </summary>
  public MainWindow()
  {
    _mainViewModel = new();
    DataContext = _mainViewModel;
    InitializeComponent();
  }
}