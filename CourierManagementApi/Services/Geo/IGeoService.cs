using CourierManagementAPI.Models.Brand;
using CourierManagementAPI.Models.Geo;
using CourierManagementAPI.Repositories.Geo;

namespace CourierManagementAPI.Services.Geo
{
    public interface IGeoService
    {
        public GeoCity GeoCityGetById(int Id, int UserId);
        public List<GeoCity> GeoCitiesGetList(int UserId);
        public GeoState GeoStateGetById(int Id, int UserId);
        public List<GeoState> GeoStatesGetList(int UserId);
        public GeoCountry GeoCountryGetById(int Id, int UserId);
        public List<GeoCountry> GeoCountriesGetList(int UserId);
    }
}
