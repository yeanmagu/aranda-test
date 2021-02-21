using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArandaSoftwareData.Helpers
{
    public class AutoMapp<T, T2>
    {
        public static T2 Convert(T obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T2>();
            });

            Mapper mapper = new Mapper(config);

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<T, T2>(obj);
        }

        public static List<T2> ConvertList(List<T> obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T2>();
            });

            Mapper mapper = new Mapper(config);

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<List<T>, List<T2>>(obj);
        }
    }
}
