
using Grpc.Core;
using GrpcMediaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI
{
    public class EGClient
    {
        private static Channel _channel;
        private static MediaServiceToGrpc.MediaServiceToGrpcClient _client;

        static EGClient()
        {
            _channel = new Channel("mediaservice:40001", ChannelCredentials.Insecure);
            _client = new MediaServiceToGrpc.MediaServiceToGrpcClient(_channel);
        }

        #region FormPublic(会刊)

        public static ModifyReply createFormPublicInfo(FormPublicStruct model)
        {
            return _client.createFormPublicInfo(model);
        }


        public static ModifyReply updateFormPublicInfo(FormPublicStruct model)
        {
            return _client.updateFormPublicInfo(model);
        }

        public static ModifyReply deleteFormPublicInfoById(IdRequest IdRequest)
        {
            return _client.deleteFormPublicInfoById(IdRequest);
        }

        public static FormPublicList getFormPublicInfoList(Empty empty)
        {
            return _client.getFormPublicInfoList(empty);
        }

        public static FormPublicStruct getFormPublicInfoById(IdRequest IdRequest)
        {
            return _client.getFormPublicInfoById(IdRequest);
        }

        public static FormPublicList getFormPublicList(PaginationRequestSearch search)
        {
            return _client.getFormPublicList(search);
        }
        #endregion




        #region Express(快递单)

        public static ModifyReply createExpressInfo(ExpressStruct model)
        {
            return _client.createExpressInfo(model);
        }


        public static ModifyReply updateExpressInfo(ExpressStruct model)
        {
            return _client.updateExpressInfo(model);
        }



        public static ModifyReply deleteExpressInfoById(IdRequest idRequest)
        {
            return _client.deleteExpressInfoById(idRequest);
        }



        public static ExpressStruct getExpressInfoById(IdRequest idRequest)
        {
            return _client.getExpressInfoById(idRequest);
        }



        public static ExpressList getExpressList(PaginationRequestSearch search)
        {
            return _client.getExpressList(search);
        }





        #endregion


        #region CatalogueBooks(会刊订购信息)

        public static CatalogueBooksList GetAllCatalogueBooksList(PaginationRequestSearch search)
        {
            return _client.getCatalogueBooksList(search);
        }

        public static ModifyReply CreateCatalogueBooksInfo(CatalogueBooksStruct model)
        {
            return _client.createCatalogueBooksInfo(model);
        }

        public static ModifyReply updateCatalogueBooksInfo(CatalogueBooksStruct model)
        {
            return _client.updateCatalogueBooksInfo(model);
        }

        public static ModifyReply deleteCatalogueBooksById(IdRequest idRequest)
        {
            return _client.deleteCatalogueBooksById(idRequest);
        }

        public static CatalogueBooksStruct getCatalogueBooksById(IdRequest idRequest)
        {
            return _client.getCatalogueBooksById(idRequest);
        }
        #endregion



        #region Interview(专题采访)

        public static ModifyReply createInterviewInfo(InterviewStruct model)
        {
            return _client.createInterviewInfo(model);
        }


        public static ModifyReply updateInterviewInfo(InterviewStruct model)
        {
            return _client.updateInterviewInfo(model);
        }


        public static ModifyReply deleteInterviewById(IdRequest idRequest)
        {
            return _client.deleteInterviewById(idRequest);
        }


        public static InterviewStruct getInterviewInfoById(IdRequest idRequest)
        {
            return _client.getInterviewInfoById(idRequest);
        }


        public static InterviewList getInterviewList(PaginationRequestSearch search)
        {
            return _client.getInterviewList(search);
        }

        #endregion



        #region  HighlightsInfo(十大亮点申请)

        public static ModifyReply createHighlightsInfo(HighlightsInfoStruct model)
        {
            return _client.createHighlightsInfo(model);
        }

        public static ModifyReply updateHighlightsInfo(HighlightsInfoStruct model)
        {
            return _client.updateHighlightsInfo(model);
        }

        public static ModifyReply deleteHighlightsInfoById(IdRequest idRequest)
        {
            return _client.deleteHighlightsInfoById(idRequest);
        }


        public static HighlightsInfoStruct getHighlightsInfoById(IdRequest idRequest)
        {
            return _client.getHighlightsInfoById(idRequest);
        }


        public static HighlightsInfoList getHighlightsInfoList(PaginationRequestSearch search)
        {
            return _client.getHighlightsInfoList(search);
        }

        #endregion



        #region Hotel(酒店)


        public static ModifyReply createHotelInfo(HotelStruct model)
        {
            return _client.createHotelInfo(model);
        }


        public static ModifyReply updateHotelInfo(HotelStruct model)
        {
            return _client.updateHotelInfo(model);
        }


        public static ModifyReply deleteHotelInfoById(HotelIdRequest idRequest)
        {
            return _client.deleteHotelInfoById(idRequest);
        }


        public static HotelStruct getHotelById(HotelIdRequest idRequest)
        {
            return _client.getHotelById(idRequest);
        }

        public static HotelList getHotelList(Empty empty)
        {
            return _client.getHotelList(empty);
        }

        #endregion



        #region HotelRoomType(酒店房间类型)

        public static ModifyReply createHotelRoomTypeInfo(HotelRoomTypeStruct model)
        {
            return _client.createHotelRoomTypeInfo(model);
        }

        public static ModifyReply updateHotelRoomTypeInfo(HotelRoomTypeStruct model)
        {
            return _client.updateHotelRoomTypeInfo(model);
        }


        public static ModifyReply deleteHotelRoomTypeById(HotelRoomTypeIdRequest hotelRoomTypeId)
        {
            return _client.deleteHotelRoomTypeById(hotelRoomTypeId);
        }


        public static HotelRoomTypeStruct getHotelRoomTypeInfoById(HotelRoomTypeIdRequest hotelRoomTypeId)
        {
            return _client.getHotelRoomTypeInfoById(hotelRoomTypeId);
        }


        public static HotelRoomTypeList getHolteRoomTypeListByHotelId(HotelIdRequest hotelId)
        {
            return _client.getHolteRoomTypeListByHotelId(hotelId);
        }

        #endregion



        #region HotelBookRecord(酒店预订记录)

        public static ModifyReply createHotelBookRecordInfo(HotelBookRecordStruct model)
        {
            return _client.createHotelBookRecordInfo(model);
        }

        public static ModifyReply updateHotelBookRecordInfo(HotelBookRecordStruct model)
        {
            return _client.updateHotelBookRecordInfo(model);
        }

        public static ModifyReply deleteHotelBookRecordInfoById(IdRequest idRequest)
        {
            return _client.deleteHotelBookRecordInfoById(idRequest);
        }


        public static HotelBookRecordList getHotelBookRecordByMemberId(MemberIdRequest memberId)
        {
            return _client.getHotelBookRecordByMemberId(memberId);
        }


        public static ModifyReply cancelHotelBookRecordById(IdRequest idRequest)
        {
            return _client.cancelHotelBookRecordById(idRequest);
        }


        public static HotelBookRecordStruct getHotelBookRecordById(IdRequest idRequest)
        {
            return _client.getHotelBookRecordById(idRequest);
        }


        public static HotelBookRecordList getHotelBookRecordList(PaginationRequestSearch search)
        {
            return _client.getHotelBookRecordList(search);
        }

        #endregion


    }
}
