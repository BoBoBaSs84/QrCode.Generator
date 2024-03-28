using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using BB84.Notifications;
using BB84.Notifications.Interfaces;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models.Base;

using static QRCoder.QRCodeGenerator;

namespace QrCode.Generator.ViewModels.Base;

/// <summary>
/// The qr code view model base class.
/// </summary>
/// <remarks>
/// Initializes an instance of <see cref="QrCodeViewModel"/> class.
/// </remarks>
/// <param name="qrCodeService">The QR code service instance to use.</param>
public abstract class QrCodeViewModel(IQrCodeService qrCodeService) : ViewModelBase
{
  private IRelayCommand? _createCommand;
  private IRelayCommand? _copyCommand;
  private Image _qrCodeImage = new();
  private string _payload = string.Empty;

  /// <summary>
  /// The actual qr code payload to encode.
  /// </summary>
  public string Payload
  {
    get => _payload;
    set => SetProperty(ref _payload, value);
  }

  /// <summary>
  /// The rendered QR code image.
  /// </summary>
  public Image QrCodeImage
  {
    get => _qrCodeImage;
    private set => SetProperty(ref _qrCodeImage, value);
  }

  /// <summary>
  /// The error correction levels to select from.
  /// </summary>
  public Tuple<string, ECCLevel>[] ErrorCorrectionLevels
    => [new("Low", ECCLevel.L), new("Medium", ECCLevel.M), new("Quartile", ECCLevel.Q), new("High", ECCLevel.H)];

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
  /// Sets the payload to encode.
  /// </summary>
  protected abstract void SetPayLoad();

  /// <summary>
  /// Updates the QR code.
  /// </summary>
  protected void UpdateQrCode(QrCodeModel model)
  {
    SetPayLoad();

    DrawingImage drawing =
      qrCodeService.CreateDrawing(Payload, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection);

    QrCodeImage.Source = drawing;
  }

  /// <summary>
  /// Copies the QR code into the clipboard.
  /// </summary>
  protected void CopyQrCode(QrCodeModel model)
  {
    SetPayLoad();

    BitmapSource bitmap =
      qrCodeService.CreateBitmap(Payload, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection);

    DataObject dataObject = new();
    dataObject.SetData(DataFormats.Bitmap, bitmap);
    Clipboard.SetDataObject(dataObject);
  }
}
