using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.AutoMapper
{
    public class Mappings
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                //config.CreateMap<Student, StudentStruct>();
                //config.CreateMap<StudentStruct, Student>();
            });
        }
    }
}
