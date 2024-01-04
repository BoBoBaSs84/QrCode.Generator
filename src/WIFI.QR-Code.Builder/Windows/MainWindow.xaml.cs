using System.Windows;
using System.Windows.Media.Imaging;

using Net.Codecrete.QrCodeGenerator;

using WIFI.QRCode.Builder.Interfaces;
using WIFI.QRCode.Builder.Services;
using WIFI.QRCode.Builder.ViewModels;

namespace WIFI.QRCode.Builder.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
  private readonly IQrCodeService _qrCodeService;
  private readonly MainViewModel _qrCodeModel;

  public MainWindow()
  {
    _qrCodeService = new QrCodeService();
    _qrCodeModel = new();
    _qrCodeModel.PropertyChanged += (s, e) => OnQrCodeModelChanged();

    InitializeComponent();
    DataContext = _qrCodeModel;
    UpdateQrCode();
  }

  private void OnQrCodeModelChanged()
    => UpdateQrCode();

  private void UpdateQrCode()
  {
    QrCode qrCode = QrCode.EncodeText(_qrCodeModel.Text, _qrCodeModel.ErrorCorrection);
    QrCodeImage.Source = _qrCodeService.CreateDrawing(qrCode, 192, _qrCodeModel.BorderWidth);
  }

  private void CopyButton_Click(object sender, RoutedEventArgs e)
  {
    // put the QR code on the clipboard as a bitmap
    QrCode qrCode = QrCode.EncodeText(_qrCodeModel.Text, _qrCodeModel.ErrorCorrection);
    BitmapSource bitmap = _qrCodeService.CreateBitmapImage(qrCode, 20, _qrCodeModel.BorderWidth);
    DataObject dataObject = new();
    dataObject.SetData(DataFormats.Bitmap, bitmap);
    Clipboard.SetDataObject(dataObject);
  }

  private void AboutItem_Click(object sender, RoutedEventArgs e)
  { }

  private void QuitItem_Click(object sender, RoutedEventArgs e)
    => Environment.Exit(1);
}