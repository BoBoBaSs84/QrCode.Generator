using System.Windows;

using QrCode.Generator.ViewModels;

namespace QrCode.Generator.Windows;

/// <summary>
/// Interaction logic for AboutWindow.xaml
/// </summary>
public partial class AboutWindow : Window
{
  /// <summary>
  /// Initializes an instance of <see cref="AboutWindow"/> class.
  /// </summary>
  public AboutWindow(AboutViewModel viewModel)
  {
    DataContext = viewModel;
    InitializeComponent();
  }
}
