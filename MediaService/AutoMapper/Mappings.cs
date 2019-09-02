using AutoMapper;
using GrpcMediaService;
using MediaService.Common;
using MediaService.DBModel;
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
                config.CreateMap<FormPublic, FormPublicStruct>();
                config.CreateMap<FormPublicStruct, FormPublic>();

                config.CreateMap<Express, ExpressStruct>();
                config.CreateMap<ExpressStruct, Express>();

                config.CreateMap<CatalogueBooks, CatalogueBooksStruct>();
                config.CreateMap<CatalogueBooksStruct, CatalogueBooks>();

                config.CreateMap<Interview, InterviewStruct>();
                config.CreateMap<InterviewStruct, Interview>();

                config.CreateMap<HighlightsInfo, HighlightsInfoStruct>();
                config.CreateMap<HighlightsInfoStruct, HighlightsInfo>();

                config.CreateMap<Hotel, HotelStruct>();
                config.CreateMap<HotelStruct, Hotel>();

                config.CreateMap<HotelRoomType, HotelRoomTypeStruct>();
                config.CreateMap<HotelRoomTypeStruct, HotelRoomType>();


                config.CreateMap<HotelBookRecord, HotelBookRecordStruct>();
                config.CreateMap<HotelBookRecordStruct, HotelBookRecord>();

                config.CreateMap<HotelBookRecord, HotelBookRecordStructVM>();
                config.CreateMap<HotelBookRecordStruct, HotelBookRecordStructVM>();

               

                config.CreateMap<ModifyReplyModel, ModifyReply>();
                config.CreateMap<ModifyReply, ModifyReplyModel>();

                config.CreateMap<Hotel, HotelVM>();

            });
        }
    }
}
