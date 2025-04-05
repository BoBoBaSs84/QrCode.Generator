﻿// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Windows;
using System.Windows.Controls;

using BB84.Extensions;

using Microsoft.Win32;

using QrCode.Generator.Common;
using QrCode.Generator.Extensions;
using QrCode.Generator.ViewModels;

namespace QrCode.Generator.Controls;

/// <summary>
/// Interaction logic for EventCodeControl.xaml
/// </summary>
public partial class EventCodeControl : UserControl
{
  private EventCodeViewModel _viewModel = default!;

  /// <summary>
  /// Initializes an instance of <see cref="EventCodeControl"/> class.
  /// </summary>
  public EventCodeControl()
  {
    InitializeComponent();
    DataContextChanged += OnDataContextChanged;
  }

  private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
  {
    if (DataContext is EventCodeViewModel viewModel && _viewModel != viewModel)
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

  private void OnExportButtonClick(object sender, RoutedEventArgs e)
  {
    SaveFileDialog fileDialog = new()
    {
      Title = "Export qr code ...",
      Filter = _viewModel.ExportType.GetFilterFromType(),
      InitialDirectory = _viewModel.ExportPath,
      FileName = $"Export.{_viewModel.ExportType.ToString().ToLowerInvariant()}"
    };

    bool? result = fileDialog.ShowDialog();

    if (result.HasValue && result.Value.IsTrue())
    {
      _viewModel.ExportPath = fileDialog.FileName;
      _viewModel.ExportCommand.Execute();
    }
  }
}
