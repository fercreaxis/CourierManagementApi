using CourierManagementAPI.Models.Geo;
using CourierManagementAPI.Repositories.Geo;
using CourierManagementAPI.Repositories.DB;

namespace CourierManagementAPI.Services.Geo
{
    public class GeoService : IGeoService
    {

        private readonly IGeoData _aux;

        public GeoService(IGeoData ParamContext)
        {
            _aux = ParamContext;
        }

        public GeoCity GeoCityGetById(int Id, int UserId)
        {
            return _aux.GeoCityGetById(Id, UserId);
        }

        public List<GeoCity> GeoCitiesGetList(int UserId)
        {
            return _aux.GeoCitiesGetList(UserId);
        }

        public GeoState GeoStateGetById(int Id, int UserId)
        {
            return _aux.GeoStateGetById(Id, UserId);
        }

        public List<GeoState> GeoStatesGetList(int UserId)
        {
            return _aux.GeoStatesGetList(UserId);
        }

        public GeoCountry GeoCountryGetById(int Id, int UserId)
        {
            return _aux.GeoCountryGetById(Id, UserId);
        }

        public List<GeoCountry> GeoCountriesGetList(int UserId)
        {
            return _aux.GeoCountriesGetList(UserId);
        }

    }
}