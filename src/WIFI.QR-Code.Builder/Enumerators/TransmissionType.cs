namespace WIFI.QRCode.Builder.Enumerators;

/// <summary>
/// The transmission type enumerator.
/// </summary>
public enum TransmissionType
{
  /// <summary>
  /// No password needed
  /// </summary>
  NOPASS = 0,

  /// <summary>
  /// Wi-Fi Protected Access
  /// </summary>
  /// <remarks>
  /// This means WPA/WPA2
  /// </remarks>
  /// 
  WPA = 1,
  /// <summary>
  /// Wired Equivalent Privacy
  /// </summary>
  WEP = 2
}
