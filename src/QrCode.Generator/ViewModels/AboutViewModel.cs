using System.Windows.Media;
using System.Windows.Threading;

using QrCode.Generator.Models;
using QrCode.Generator.ViewModels.Base;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The about view model
/// </summary>
public sealed class AboutViewModel : ViewModel
{
  private static readonly Random Random = new();
  private readonly DispatcherTimer _timer;
  private Brush _fill;

  /// <summary>
  /// Initializes an instance of <see cref="AboutViewModel"/> class.
  /// </summary>
  /// <param name="model">The model instance to use.</param>
  public AboutViewModel(AboutModel model)
  {
    Model = model;

    _timer = new() { Interval = TimeSpan.FromMilliseconds(500) };
    _timer.Tick += OnTick;
    _timer.Start();
    _fill = Brushes.Transparent;
  }

  private void OnTick(object? sender, EventArgs e)
    => Fill = new SolidColorBrush(Color.FromRgb((byte)Random.Next(0, 256), (byte)Random.Next(0, 256), (byte)Random.Next(0, 256)));

  /// <summary>
  /// The model instance to use.
  /// </summary>
  public AboutModel Model { get; }

  /// <summary>
  /// The filling of the rectangle.
  /// </summary>
  public Brush Fill
  {
    get => _fill;
    private set => SetProperty(ref _fill, value);
  }
}
