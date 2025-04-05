// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels.Base;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The about view model
/// </summary>
/// <param name="model">The model instance to use.</param>
public sealed class AboutViewModel(AboutModel model) : ViewModelBase
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public AboutModel Model { get; } = model;
}
