using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.WebCore.Mapper
{
    public class MapperHelper
    {
        public static IMapper Profile()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AddProfile<AutoMapperProfile>();
            cfg.AddProfile<RegisterMapProfile>();
            var config = new MapperConfiguration(cfg);
            IMapper mapper = new AutoMapper.Mapper(config);
            return mapper;
        }

        public static Target Map<Target, Source>(Source source)
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Source, Target>();
            var config = new MapperConfiguration(cfg);
            IMapper mapper = new AutoMapper.Mapper(config);
            return  mapper.Map<Source, Target>(source);
        }
    }
}
