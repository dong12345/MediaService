using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using GrpcMediaService;
using MediaService.Common;
using MediaService.DBModel;
using MediaService.MediaDBContext;
using MediaService.Service;
using Microsoft.EntityFrameworkCore;


namespace MediaService.Implement
{
    public class MsgServiceImpl: MediaServiceToGrpc.MediaServiceToGrpcBase
    {
        private string _sql = ContextConnect.ReadConnstrContent();
        private MediaServices _service;
        public MsgServiceImpl()
        {
            try
            {
                var optionsBulider = new DbContextOptionsBuilder<MyContext>();
                _service = new MediaServices(optionsBulider, _sql);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                LogHelper.Info(this, e);
                LogHelper.Debug(this, e.Message);
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        #region FormPublic(会刊)

      
        public override async Task<ModifyReply> createFormPublicInfo(FormPublicStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.Id = Guid.NewGuid().ToString();
                request.CreatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<FormPublicStruct, FormPublic>(request);
                var result = await _service.CreateFormPublicInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> updateFormPublicInfo(FormPublicStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<FormPublicStruct, FormPublic>(request);
                var result = await _service.UpdateFormPublicInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> deleteFormPublicInfoById(IdRequest request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                var result = await _service.DeleteFormPublicInfoById(request.Id);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<FormPublicList> getFormPublicInfoList(Empty request, ServerCallContext context)
        {
            try
            {
                FormPublicList list = new FormPublicList();
                var formPublicList= await _service.GetFormPublicInfoList();
                var result = Mapper.Map<List<FormPublic>, List<FormPublicStruct>>(formPublicList);
                list.Listdata.AddRange(result);
                return list;
            }
            catch(Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<FormPublicStruct> getFormPublicInfoById(IdRequest request, ServerCallContext context)
        {
            try
            {
                var model = await _service.GetFormPublicInfoById(request.Id);
                var result = Mapper.Map<FormPublic, FormPublicStruct>(model);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<FormPublicList> getFormPublicList(PaginationRequestSearch request, ServerCallContext context)
        {
            try
            {
                FormPublicList formPublicList = new FormPublicList();
                var search = Mapper.Map<SearchStruct, SearchModel>(request.Search);
                var list= await _service.GetFormPublicList(request.Offset, request.Limit, search);

                var result=Mapper.Map<List<FormPublic>,List<FormPublicStruct>> (list);
                formPublicList.Listdata.AddRange(result);
                formPublicList.Total = await _service.GetFormPublicListCount(search);
                return formPublicList;

            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }
        #endregion


        public override Task<ModifyReply> createExpressInfo(ExpressStruct request, ServerCallContext context)
        {
            return base.createExpressInfo(request, context);
        }

        public override Task<ModifyReply> updateExpressInfo(ExpressStruct request, ServerCallContext context)
        {
            return base.updateExpressInfo(request, context);
        }

        public override Task<ModifyReply> deleteExpressInfoById(IdRequest request, ServerCallContext context)
        {
            return base.deleteExpressInfoById(request, context);
        }

        public override Task<ExpressStruct> getExpressInfoById(IdRequest request, ServerCallContext context)
        {
            return base.getExpressInfoById(request, context);
        }

        public override Task<ExpressList> getExpressList(PaginationRequestSearch request, ServerCallContext context)
        {
            return base.getExpressList(request, context);
        }

        public override Task<ModifyReply> createCatalogueBooksInfo(CatalogueBooksStruct request, ServerCallContext context)
        {
            return base.createCatalogueBooksInfo(request, context);
        }

        public override Task<ModifyReply> updateCatalogueBooksInfo(CatalogueBooksStruct request, ServerCallContext context)
        {
            return base.updateCatalogueBooksInfo(request, context);
        }

        public override Task<ModifyReply> deleteCatalogueBooksById(IdRequest request, ServerCallContext context)
        {
            return base.deleteCatalogueBooksById(request, context);
        }

        public override Task<ModifyReply> createInterviewInfo(InterviewStruct request, ServerCallContext context)
        {
            return base.createInterviewInfo(request, context);
        }

        public override Task<ModifyReply> updateInterviewInfo(InterviewStruct request, ServerCallContext context)
        {
            return base.updateInterviewInfo(request, context);
        }

        public override Task<ModifyReply> deleteInterviewById(IdRequest request, ServerCallContext context)
        {
            return base.deleteInterviewById(request, context);
        }

        public override Task<InterviewStruct> getInterviewInfoById(IdRequest request, ServerCallContext context)
        {
            return base.getInterviewInfoById(request, context);
        }

        public override Task<InterviewList> getInterviewList(PaginationRequestSearch request, ServerCallContext context)
        {
            return base.getInterviewList(request, context);
        }

        public override Task<ModifyReply> createHighlightsInfo(HighlightsInfoStruct request, ServerCallContext context)
        {
            return base.createHighlightsInfo(request, context);
        }

        public override Task<ModifyReply> updateHighlightsInfo(HighlightsInfoStruct request, ServerCallContext context)
        {
            return base.updateHighlightsInfo(request, context);
        }

        public override Task<ModifyReply> deleteHighlightsInfoById(IdRequest request, ServerCallContext context)
        {
            return base.deleteHighlightsInfoById(request, context);
        }

        public override Task<HighlightsInfoStruct> getHighlightsInfoById(IdRequest request, ServerCallContext context)
        {
            return base.getHighlightsInfoById(request, context);
        }

        public override Task<HighlightsInfoList> getHighlightsInfoList(PaginationRequestSearch request, ServerCallContext context)
        {
            return base.getHighlightsInfoList(request, context);
        }

        public override Task<ModifyReply> createHotelInfo(HotelStruct request, ServerCallContext context)
        {
            return base.createHotelInfo(request, context);
        }

        public override Task<ModifyReply> updateHotelInfo(HotelStruct request, ServerCallContext context)
        {
            return base.updateHotelInfo(request, context);
        }

        public override Task<ModifyReply> deleteHotelInfoById(HotelId request, ServerCallContext context)
        {
            return base.deleteHotelInfoById(request, context);
        }

        public override Task<HotelStruct> getHotelById(HotelId request, ServerCallContext context)
        {
            return base.getHotelById(request, context);
        }

        public override Task<HotelList> GetHotelList(Empty request, ServerCallContext context)
        {
            return base.GetHotelList(request, context);
        }

        public override Task<ModifyReply> createHotelRoomTypeInfo(HotelRoomTypeStruct request, ServerCallContext context)
        {
            return base.createHotelRoomTypeInfo(request, context);
        }

        public override Task<ModifyReply> updateHotelRoomTypeInfo(HotelRoomTypeStruct request, ServerCallContext context)
        {
            return base.updateHotelRoomTypeInfo(request, context);
        }

        public override Task<ModifyReply> deleteHotelRoomTypeById(HotelRoomTypeId request, ServerCallContext context)
        {
            return base.deleteHotelRoomTypeById(request, context);
        }

        public override Task<HotelRoomTypeStruct> getHotelRoomTypeInfoById(HotelRoomTypeId request, ServerCallContext context)
        {
            return base.getHotelRoomTypeInfoById(request, context);
        }

        public override Task<HotelRoomTypeList> getHolteRoomTypeListByHotelId(HotelId request, ServerCallContext context)
        {
            return base.getHolteRoomTypeListByHotelId(request, context);
        }

        public override Task<ModifyReply> createHotelBookRecordInfo(HotelBookRecordStruct request, ServerCallContext context)
        {
            return base.createHotelBookRecordInfo(request, context);
        }

        public override Task<ModifyReply> updateHotelBookRecordInfo(HotelBookRecordStruct request, ServerCallContext context)
        {
            return base.updateHotelBookRecordInfo(request, context);
        }

        public override Task<ModifyReply> deleteHotelBookRecordInfoById(IdRequest request, ServerCallContext context)
        {
            return base.deleteHotelBookRecordInfoById(request, context);
        }

        public override Task<HotelBookRecordList> getHotelBookRecordByMemberId(MemberId request, ServerCallContext context)
        {
            return base.getHotelBookRecordByMemberId(request, context);
        }

        public override Task<ModifyReply> cancelHotelBookRecordById(IdRequest request, ServerCallContext context)
        {
            return base.cancelHotelBookRecordById(request, context);
        }

        public override Task<HotelBookRecordStruct> getHotelBookRecordById(IdRequest request, ServerCallContext context)
        {
            return base.getHotelBookRecordById(request, context);
        }

        public override Task<HotelBookRecordList> getHotelBookRecordList(PaginationRequestSearch request, ServerCallContext context)
        {
            return base.getHotelBookRecordList(request, context);
        }


      

    }
}
