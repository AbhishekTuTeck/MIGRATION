// Services/ILocationService.cs
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;

namespace Migration.Services;

public sealed record GpsReading(
    double Latitude,
    double Longitude,
    double? AccuracyMeters,
    double? AltitudeMeters,
    double? SpeedMetersPerSecond,
    double? HeadingDegrees,
    DateTimeOffset TimestampUtc);

public interface ILocationService
{
    Task<GpsReading?> GetCurrentAsync(
        GeolocationAccuracy accuracy = GeolocationAccuracy.Default,
        TimeSpan? timeout = null,
        bool includeLastKnownFallback = true,
        CancellationToken ct = default);

    IDisposable StartObserving(
        TimeSpan interval,
        GeolocationAccuracy accuracy,
        Action<GpsReading> onReading,
        Action<Exception>? onError = null,
        TimeSpan? perSampleTimeout = null,
        bool includeLastKnownFallback = true);
}