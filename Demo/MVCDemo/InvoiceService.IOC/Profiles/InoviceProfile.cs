using AutoMapper;
using ElectronicInvoice.Models.ViewModel;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.IOC.Profiles
{
    public class InoviceProfile : Profile
    {
        public InoviceProfile()
        {
            CreateMap<QryWinningListViewModel, QryWinningListModel>();
            CreateMap<CarrierTilteViewModel, CarrierTilteModel>();
        }
    }
}
