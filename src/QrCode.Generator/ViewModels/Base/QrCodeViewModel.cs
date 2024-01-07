using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using WIFI.QRCode.Builder.Common;
using WIFI.QRCode.Builder.Interfaces.Common;
using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.Models.Base;

using static QRCoder.QRCodeGenerator;

namespace WIFI.QRCode.Builder.ViewModels.Base;

/// <summary>
/// The qr code view model base class.
/// </summary>
/// <remarks>
/// Initializes an instance of <see cref="QrCodeViewModel"/> class.
/// </remarks>
public abstract class QrCodeViewModel(IQrCodeService qrCodeService) : ViewModel
{
  private IRelayCommand? _createCommand;
  private IRelayCommand? _copyCommand;
  private Image _qrCodeImage = new();

  /// <summary>
  /// The error correction levels to select from.
  /// </summary>
  public Tuple<string, ECCLevel>[] ErrorCorrectionLevels
    => [new("Low", ECCLevel.L), new("Medium", ECCLevel.M), new("Quartile", ECCLevel.Q), new("High", ECCLevel.H)];

  /// <summary>
  /// The rendered QR code image.
  /// </summary>
  public Image QrCodeImage { get => _qrCodeImage; private set => SetProperty(ref _qrCodeImage, value); }

  /// <summary>
  /// The command to create or update the QR code.
  /// </summary>
  public IRelayCommand CreateCommand
    => _createCommand ??= new RelayCommand<QrCodeModel>(UpdateQrCode);

  /// <summary>
  /// The command for copying the QR code.
  /// </summary>
  public IRelayCommand CopyCommand
    => _copyCommand ??= new RelayCommand<QrCodeModel>(CopyQrCode);

  /// <summary>
  /// Updates the QR code.
  /// </summary>
  protected void UpdateQrCode(QrCodeModel model)
  {
    DrawingImage drawing =
      qrCodeService.CreateDrawing(model.PayLoad, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection);

    QrCodeImage.Source = drawing;
  }

  /// <summary>
  /// Copies the QR code into the clipboard.
  /// </summary>
  protected void CopyQrCode(QrCodeModel model)
  {
    BitmapSource bitmap =
      qrCodeService.CreateBitmap(model.PayLoad, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection);

    DataObject dataObject = new();
    dataObject.SetData(DataFormats.Bitmap, bitmap);
    Clipboard.SetDataObject(dataObject);
  }
}
