using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinExampleFeatures
{
    public static class Localizator
    {
        public static async Task<Location> GetLocation()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

             

                return location;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return null;
        }

        public static async Task<string> EncodeLocation(this Location location)
        {
            var lat = location.Latitude;
            var lon = location.Longitude;

            var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

            var placemark = placemarks?.FirstOrDefault();
            if (placemark == null)
            {
                return null;
            }

            var geocodeAddress =
                $"AdminArea:       {placemark.AdminArea}\n" +
                $"CountryCode:     {placemark.CountryCode}\n" +
                $"CountryName:     {placemark.CountryName}\n" +
                $"FeatureName:     {placemark.FeatureName}\n" +
                $"Locality:        {placemark.Locality}\n" +
                $"PostalCode:      {placemark.PostalCode}\n" +
                $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                $"SubLocality:     {placemark.SubLocality}\n" +
                $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                $"Thoroughfare:    {placemark.Thoroughfare}\n";

            return geocodeAddress;
        }
    }
}