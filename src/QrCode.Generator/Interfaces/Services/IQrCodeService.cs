// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Windows.Media;
using System.Windows.Media.Imaging;

using QRCoder;

namespace QrCode.Generator.Interfaces.Services;

/// <summary>
/// The QR-Code service interface.
/// </summary>
public interface IQrCodeService
{
  /// <summary>
  /// Create a bitmap for the specified qr code payload.
  /// </summary>
  /// <param name="payload">The qr code payload.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <param name="level">The level of error correction to use.</param>
  /// <returns>The qr code abitmap.</returns>
  BitmapSource CreateBitmap(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level);

  /// <summary>
  /// Create a resolution independent drawing for the specified qr code.
  /// </summary>
  /// <param name="payload">The qr code payload.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <param name="level">The level of error correction to use.</param>
  /// <returns>The device independent drawing.</returns>
  DrawingImage CreateDrawing(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level);

  /// <summary>
  /// Create a windows bitmap graphic for the specified qr code payload.
  /// </summary>
  /// <param name="payload">The qr code payload.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <param name="level">The level of error correction to use.</param>
  /// <returns>The content for the windows bitmap graphic.</returns>
  byte[] CreateBmp(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level);

  /// <summary>
  /// Create a portable document format for the specified qr code payload.
  /// </summary>
  /// <param name="payload">The qr code payload.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <param name="level">The level of error correction to use.</param>
  /// <returns>The content for the portable document format.</returns>
  byte[] CreatePdf(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level);

  /// <summary>
  /// Create a portable network graphic for the specified qr code payload.
  /// </summary>
  /// <param name="payload">The qr code payload.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <param name="level">The level of error correction to use.</param>
  /// <returns>The content for the portable network graphic.</returns>
  byte[] CreatePng(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level);

  /// <summary>
  /// Create a scalable vector graphic for the specified qr code payload.
  /// </summary>
  /// <param name="payload">The qr code payload.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <param name="level">The level of error correction to use.</param>
  /// <returns>The content for the scalable vector graphic.</returns>
  byte[] CreateSvg(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level);
}
