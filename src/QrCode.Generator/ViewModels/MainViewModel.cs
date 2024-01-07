using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using BB84.Notifications;

using WIFI.QRCode.Builder.Common;
using WIFI.QRCode.Builder.Interfaces.Common;
using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.Models;
using WIFI.QRCode.Builder.Services;

using static QRCoder.PayloadGenerator.WiFi;
using static QRCoder.QRCodeGenerator;

namespace WIFI.QRCode.Builder.ViewModels;

/// <summary>
/// The main view model class.
/// </summary>
public sealed class MainViewModel : NotifyPropertyBase
{
  private readonly IQrCodeService _qrCodeService;
  private IRelayCommand? _aboutCommand;
  private IRelayCommand? _createCommand;
  private IRelayCommand? _copyCommand;
  private IRelayCommand? _exitCommand;

  /// <summary>
  /// Initializes an instance of <see cref="MainViewModel"/> class.
  /// </summary>
  public MainViewModel()
  {
    _qrCodeService = new QrCodeService();
    QrCodeImage = new();
    Model = new();
  }

  /// <summary>
  /// The rendered QR code image.
  /// </summary>
  public Image QrCodeImage { get; private set; }

  /// <summary>
  /// The main model instance.
  /// </summary>
  public MainModel Model { get; }

  /// <summary>
  /// The error correction levels to select from.
  /// </summary>
  public Tuple<string, ECCLevel>[] ErrorCorrectionLevels
    => [new("Low", ECCLevel.L), new("Medium", ECCLevel.M), new("Quartile", ECCLevel.Q), new("High", ECCLevel.H)];

  /// <summary>
  /// The Authentication types to select from.
  /// </summary>
  public Tuple<string, Authentication>[] AuthenticationTypes
    => [new("nopass", Authentication.nopass), new("WPA", Authentication.WPA), new("WEP", Authentication.WEP)];

  /// <summary>
  /// The command to show the about window.
  /// </summary>
  public IRelayCommand AboutCommand
    => _aboutCommand ??= new RelayCommand(() => Environment.Exit(1));

  /// <summary>
  /// The command to create or update the QR code.
  /// </summary>
  public IRelayCommand CreateCommand
    => _createCommand ??= new RelayCommand(UpdateQrCode);

  /// <summary>
  /// The command for copying the QR code.
  /// </summary>
  public IRelayCommand CopyCommand
    => _copyCommand ??= new RelayCommand(CopyQrCode);

  /// <summary>
  /// The command to exit the application.
  /// </summary>
  public IRelayCommand ExitCommand
    => _exitCommand ??= new RelayCommand(() => Environment.Exit(0));

  /// <summary>
  /// Updates the QR code.
  /// </summary>
  private void UpdateQrCode()
  {
    DrawingImage drawing =
      _qrCodeService.CreateDrawing(Model.PayLoad, 20, Model.ForegroundColor, Model.BackgroundColor, Model.ErrorCorrection);

    QrCodeImage.Source = drawing;
  }

  /// <summary>
  /// Copies the QR code into the clipboard.
  /// </summary>
  private void CopyQrCode()
  {
    BitmapSource bitmap =
      _qrCodeService.CreateBitmap(Model.PayLoad, 20, Model.ForegroundColor, Model.BackgroundColor, Model.ErrorCorrection);

    DataObject dataObject = new();
    dataObject.SetData(DataFormats.Bitmap, bitmap);
    Clipboard.SetDataObject(dataObject);
  }
}
