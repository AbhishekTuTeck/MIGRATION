// Services/LocationService.cs
using Microsoft.Maui.Devices.Sensors;
using Migration.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Migration.Services;

public sealed class LocationService : ILocationService
{
    public async Task<GpsReading?> GetCurrentAsync(
        GeolocationAccuracy accuracy = GeolocationAccuracy.Default,
        TimeSpan? timeout = null,
        bool includeLastKnownFallback = true,
        CancellationToken ct = default)
    {
        try
        {
            var request = new GeolocationRequest(accuracy, timeout ?? TimeSpan.FromSeconds(10));
            var location = await Geolocation.Default.GetLocationAsync(request, ct).ConfigureAwait(false);
            if (location != null)
                return ToReading(location);
        }
        catch (FeatureNotSupportedException)
        {
            return null;
        }
        catch (PermissionException)
        {
            return null;
        }
        catch
        {
            // timeouts/others → fallback if allowed
        }

        if (includeLastKnownFallback)
        {
            try
            {
                var last = await Geolocation.Default.GetLastKnownLocationAsync().ConfigureAwait(false);
                if (last != null)
                    return ToReading(last);
            }
            catch { /* ignore */ }
        }

        return null;
    }

    public IDisposable StartObserving(
        TimeSpan interval,
        GeolocationAccuracy accuracy,
        Action<GpsReading> onReading,
        Action<Exception>? onError = null,
        TimeSpan? perSampleTimeout = null,
        bool includeLastKnownFallback = true)
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;

        _ = Task.Run(async () =>
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var reading = await GetCurrentAsync(
                        accuracy: accuracy,
                        timeout: perSampleTimeout ?? TimeSpan.FromSeconds(10),
                        includeLastKnownFallback: includeLastKnownFallback,
                        ct: token);

                    if (reading != null)
                        onReading(reading);
                }
                catch (Exception ex)
                {
                    onError?.Invoke(ex);
                }

                try
                {
                    await Task.Delay(interval, token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }
        }, token);

        return new CancelOnDispose(cts);
    }

    private static GpsReading ToReading(Location loc) =>
        new(
            Latitude: loc.Latitude,
            Longitude: loc.Longitude,
            AccuracyMeters: loc.Accuracy,
            AltitudeMeters: loc.Altitude,
            SpeedMetersPerSecond: loc.Speed,
            HeadingDegrees: loc.Course,
            TimestampUtc: loc.Timestamp);

    private sealed class CancelOnDispose : IDisposable
    {
        private readonly CancellationTokenSource _cts;
        public CancelOnDispose(CancellationTokenSource cts) => _cts = cts;
        public void Dispose() => _cts.Cancel();
    }
}