using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using BB84.Notifications;

using Net.Codecrete.QrCodeGenerator;

using WIFI.QRCode.Builder.Common;
using WIFI.QRCode.Builder.Enumerators;
using WIFI.QRCode.Builder.Interfaces.Common;
using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.Models;
using WIFI.QRCode.Builder.Services;

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
  public Tuple<string, QrCode.Ecc>[] ErrorCorrectionLevels { get; } = [
    new Tuple<string, QrCode.Ecc>("Low", QrCode.Ecc.Low),
    new Tuple<string, QrCode.Ecc>("Medium", QrCode.Ecc.Medium),
    new Tuple<string, QrCode.Ecc>("Quartile", QrCode.Ecc.Quartile),
    new Tuple<string, QrCode.Ecc>("High", QrCode.Ecc.High)
  ];

  /// <summary>
  /// The transmission types to select from.
  /// </summary>
  public Tuple<string, TransmissionType>[] TransmissionTypes { get; } = [
    new("nopass", TransmissionType.NOPASS),
    new("WPA", TransmissionType.WPA),
    new("WEP", TransmissionType.WEP)
    ];

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
    QrCode qrCode = QrCode.EncodeText(Model.Value, Model.ErrorCorrection);
    QrCodeImage.Source = _qrCodeService.CreateDrawing(qrCode, 192, Model.BorderWidth, Model.ForegroundColor, Model.BackgroundColor);
  }

  /// <summary>
  /// Copies the QR code into the clipboard.
  /// </summary>
  private void CopyQrCode()
  {
    QrCode qrCode = QrCode.EncodeText(Model.Value, Model.ErrorCorrection);
    BitmapSource bitmap = _qrCodeService.CreateBitmapImage(qrCode, 20, Model.BorderWidth, Model.ForegroundColor, Model.BackgroundColor);
    DataObject dataObject = new();
    dataObject.SetData(DataFormats.Bitmap, bitmap);
    Clipboard.SetDataObject(dataObject);
  }
}
