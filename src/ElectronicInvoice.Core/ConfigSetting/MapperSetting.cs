using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicInvoice.Models.ViewModel;
using ElectronicInvoice.Models.InvoiceResult;

namespace ElectronicInvoice.Core.ConfigSetting
{
    public class MapperSetting
    {
        public static IMapper Setting()
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<TitleDetail, InvoiceViewModel>());

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}