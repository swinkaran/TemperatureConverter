using AutoMapper;
using Sw.TemperatureConverter.DomainModels.Models;
using Sw.TemperatureConverter.ServiceDxos.Interfaces;
using Sw.TemperatureConverter.ServiceModel.Dtos;
using System.Collections.Generic;

namespace Sw.TemperatureConverter.ServiceDxos
{
    public class TemperatureDxos : ITemperatureDxos
    {
        private readonly IMapper _mapper;
        

        public TemperatureDxos()
        {
            var confiig = CreateMappings();
            _mapper = confiig.CreateMapper();
        
        }

        public MapperConfiguration CreateMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<VProduct, TemperatureDto>()
                //    .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.productId))
                //    .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description.Replace("\r\n", "")))
                //    .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                //    .ForMember(dst => dst.UnitPrice, opt => opt.MapFrom(src => GetUnitPriceWithMargin(src.unitPrice)))
                //    .ForMember(dst => dst.MaximumQuantity, opt => opt.MapFrom(src => src.MaximumQuantity));
            });
        }

        public IList<TemperatureDto> MapTemperatureDtos(IList<Temperature> products)
        {
            return _mapper.Map<IList<Temperature>, IList<TemperatureDto>>(products);
        }

        TemperatureDto ITemperatureDxos.MapTemperatureDto(Temperature Product)
        {
            throw new System.NotImplementedException();
        }
    }
}
