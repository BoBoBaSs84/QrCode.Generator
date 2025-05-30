﻿// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using QrCode.Generator.ViewModels.Base;

namespace QrCode.Generator.Interfaces.Services;

/// <summary>
/// The navgigation service interface.
/// </summary>
public interface INavigationService
{
  /// <summary>
  /// The current view model.
  /// </summary>
  ViewModelBase CurrentView { get; }

  /// <summary>
  /// Navigates to the provided view model.
  /// </summary>
  /// <typeparam name="T">The view model to navigate to.</typeparam>
  void NavigateTo<T>() where T : ViewModelBase;
}
