using System.Windows;

using QrCode.Generator.ViewModels;

namespace QrCode.Generator.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
  /// <summary>
  /// Initializes an instance of <see cref="MainWindow"/> class.
  /// </summary>
  /// <param name="viewModel">The view model instance to use.</param>
  public MainWindow(MainViewModel viewModel)
  {
    DataContext = viewModel;
    InitializeComponent();
  }
}