using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicInvoice.Models.ViewModel;

namespace ElectronicInvoice.Core.ConfigSetting
{
    public class MapperSetting
    {
        private MapperSetting() { }
        static MapperSetting mapper = new MapperSetting();
        public static MapperSetting Current
        {
            get
            {
                return mapper;
            }
        }
        public IMapper Setting
        {
            get
            {
                return GetSetting();
            }
        }

        public IMapper GetSetting()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<TitleDetail, InvoiceViewModel>();
            });
            
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}