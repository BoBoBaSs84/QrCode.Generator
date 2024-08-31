using System.Windows;
using System.Windows.Controls;

using BB84.Extensions;

using Microsoft.Win32;

using QrCode.Generator.Common;
using QrCode.Generator.ViewModels;

namespace QrCode.Generator.Controls;

/// <summary>
/// Interaction logic for ContactDataControl.xaml
/// </summary>
public partial class ContactDataControl : UserControl
{
  private ContactDataViewModel _viewModel = default!;

  /// <summary>
  /// Initializes an instance of <see cref="ContactDataControl"/> class.
  /// </summary>
  public ContactDataControl()
  {
    InitializeComponent();
    DataContextChanged += OnDataContextChanged;
  }

  private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
  {
    if (DataContext is ContactDataViewModel viewModel && _viewModel != viewModel)
      _viewModel = viewModel;
  }

  private void OnLoadButtonClick(object sender, RoutedEventArgs e)
  {
    OpenFileDialog fileDialog = new()
    {
      Title = "Load template ...",
      Filter = Statics.TemplateFileFilter,
      InitialDirectory = _viewModel.LoadPath,
    };

    bool? result = fileDialog.ShowDialog();

    if (result.HasValue && result.Value.IsTrue())
    {
      _viewModel.LoadPath = fileDialog.FileName;
      _viewModel.LoadTemplateCommand.Execute(_viewModel.Model);
    }
  }

  private void OnSaveButtonClick(object sender, RoutedEventArgs e)
  {
    SaveFileDialog fileDialog = new()
    {
      Title = "Save template ...",
      Filter = Statics.TemplateFileFilter,
      InitialDirectory = _viewModel.SavePath
    };

    bool? result = fileDialog.ShowDialog();

    if (result.HasValue && result.Value.IsTrue())
    {
      _viewModel.SavePath = fileDialog.FileName;
      _viewModel.SaveTemplateCommand.Execute(_viewModel.Model);
    }
  }
}
