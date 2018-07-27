using API.Models;
using Geocoding;
using Geocoding.Microsoft;
using System.Collections.Generic;
using System.Linq;

namespace API.Helpers
{
    public class SettingCoordinates
    {
        public static async void SetCoordinates()
        {
            IGeocoder geocoder = new BingMapsGeocoder("Am2EX-qk3vxDWfcvExTEY9frj2m0Y5I4_YEayIlQvDInm-t6ueJ52uOOvEqGgTvE");
            IEnumerable<Address> addresses = await geocoder.GeocodeAsync("petrosani hunedoara romania");
            CoordinatesModel.Latitude = addresses.First().Coordinates.Latitude;
            CoordinatesModel.Longitude = addresses.First().Coordinates.Longitude;
        }
    }
}
