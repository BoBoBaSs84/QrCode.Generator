using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using QrCode.Generator.Common;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Interfaces.ViewModels;
using QrCode.Generator.Models.Base;

using static QRCoder.QRCodeGenerator;

namespace QrCode.Generator.ViewModels.Base;

/// <summary>
/// The qr code view model base class.
/// </summary>
/// <remarks>
/// Initializes an instance of <see cref="QrCodeViewModel{T}"/> class.
/// </remarks>
/// <param name="qrCodeService">The QR code service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public abstract class QrCodeViewModel<T>(IQrCodeService qrCodeService, T model) : ViewModelBase, ITemplatable<T> where T : class
{
  private Image _qrCodeImage = new();
  private string _payload = string.Empty;

  /// <summary>
  /// The model instance to use.
  /// </summary>
  public T Model { get; } = model;

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

  /// <inheritdoc/>
  public string LoadPath { get; set; } = Statics.DefaultTemplatePath;

  /// <inheritdoc/>
  public string SavePath { get; set; } = Statics.DefaultTemplatePath;

  /// <summary>
  /// The command to create or update the QR code.
  /// </summary>
  public IActionCommand<QrCodeModel> CreateCommand
    => new ActionCommand<QrCodeModel>(UpdateQrCode);

  /// <summary>
  /// The command for copying the QR code.
  /// </summary>
  public IActionCommand<QrCodeModel> CopyCommand
    => new ActionCommand<QrCodeModel>(CopyQrCode);

  /// <inheritdoc/>
  public IActionCommand<T> LoadTemplateCommand
    => new ActionCommand<T>(LoadTemplate);

  /// <inheritdoc/>
  public IActionCommand<T> SaveTemplateCommand
    => new ActionCommand<T>(SaveTemplate);

  /// <summary>
  /// Loads the template into the current model.
  /// </summary>
  /// <param name="model">The model to load into.</param>
  protected abstract void LoadTemplate(T model);

  /// <summary>
  /// Saves the template from the current model.
  /// </summary>
  /// <param name="model">The model to save from.</param>
  protected abstract void SaveTemplate(T model);

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

    DrawingImage drawing = qrCodeService
      .CreateDrawing(Payload, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection);

    QrCodeImage.Source = drawing;
  }

  /// <summary>
  /// Copies the QR code into the clipboard.
  /// </summary>
  protected void CopyQrCode(QrCodeModel model)
  {
    SetPayLoad();

    BitmapSource bitmap = qrCodeService
      .CreateBitmap(Payload, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection);

    DataObject dataObject = new();
    dataObject.SetData(DataFormats.Bitmap, bitmap);
    Clipboard.SetDataObject(dataObject);
  }
}
