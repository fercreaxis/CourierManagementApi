using System.Collections.Generic;
using CourierManagementAPI.Models.Geo;
using CourierManagementAPI.Models.Users;

namespace CourierManagementAPI.Repositories.Geo
{
    public interface IGeoData
    {
        public GeoCity GeoCityGetById(int Id, int UserId);
        public List<GeoCity> GeoCitiesGetList(int UserId);

        public GeoState GeoStateGetById(int Id, int UserId);
        public List<GeoState> GeoStatesGetList(int UserId);

        public GeoCountry GeoCountryGetById(int Id, int UserId);
        public List<GeoCountry> GeoCountriesGetList(int UserId);

    }
}