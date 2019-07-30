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

        #region Express(快递单)
        public override async Task<ModifyReply> createExpressInfo(ExpressStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.Id = Guid.NewGuid().ToString();
                request.CreatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<ExpressStruct, Express>(request);
                var result = await _service.CreateExpressInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> updateExpressInfo(ExpressStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<ExpressStruct, Express>(request);
                var result = await _service.UpdateExpressInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> deleteExpressInfoById(IdRequest request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                var result = await _service.DeleteExpressInfoById(request.Id);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ExpressStruct> getExpressInfoById(IdRequest request, ServerCallContext context)
        {
            try
            {
                var model = await _service.GetExpressInfoById(request.Id);
                var result = Mapper.Map<Express, ExpressStruct>(model);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<ExpressList> getExpressList(PaginationRequestSearch request, ServerCallContext context)
        {
            try
            {
                ExpressList expressList = new ExpressList();
                var search = Mapper.Map<SearchStruct, SearchModel>(request.Search);
                var list = await _service.GetExpressList(request.Offset, request.Limit, search);

                var result = Mapper.Map<List<Express>, List<ExpressStruct>>(list);
                expressList.Listdata.AddRange(result);
                expressList.Total = await _service.GetExpressListCount(search);
                return expressList;

            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }
        #endregion


        #region CatalogueBooks(web页面会刊订购信息表)
        public override async Task<ModifyReply> createCatalogueBooksInfo(CatalogueBooksStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.Id = Guid.NewGuid().ToString();
                request.CreatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<CatalogueBooksStruct, CatalogueBooks>(request);
                var result = await _service.CreateCatalogueBooksInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> updateCatalogueBooksInfo(CatalogueBooksStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<CatalogueBooksStruct, CatalogueBooks>(request);
                var result = await _service.UpdateCatalogueBooksInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> deleteCatalogueBooksById(IdRequest request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                var result = await _service.DeleteCatalogueBooksById(request.Id);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<CatalogueBooksStruct> getCatalogueBooksById(IdRequest request, ServerCallContext context)
        {
            try
            {
                var model = await _service.GetCatalogueBooksById(request.Id);
                var result = Mapper.Map<CatalogueBooks, CatalogueBooksStruct>(model);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<CatalogueBooksList> getCatalogueBooksList(PaginationRequestSearch request, ServerCallContext context)
        {
            try
            {
                CatalogueBooksList catalogueBooksList = new CatalogueBooksList();
                var search = Mapper.Map<SearchStruct, SearchModel>(request.Search);
                var list = await _service.GetCatalogueBooksList(request.Offset, request.Limit, search);

                var result = Mapper.Map<List<CatalogueBooks>, List<CatalogueBooksStruct>>(list);
                catalogueBooksList.Listdata.AddRange(result);
                catalogueBooksList.Total = await _service.GetCatalogueBooksListCount(search);
                return catalogueBooksList;

            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }
        #endregion



        #region Interview(专题采访)
        public override async Task<ModifyReply> createInterviewInfo(InterviewStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.Id = Guid.NewGuid().ToString();
                request.CreatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<InterviewStruct, Interview>(request);
                var result = await _service.CreateInterviewInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> updateInterviewInfo(InterviewStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<InterviewStruct, Interview>(request);
                var result = await _service.UpdateInterviewInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> deleteInterviewById(IdRequest request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                var result = await _service.DeleteInterviewById(request.Id);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<InterviewStruct> getInterviewInfoById(IdRequest request, ServerCallContext context)
        {
            try
            {
                var model = await _service.GetInterviewInfoById(request.Id);
                var result = Mapper.Map<Interview, InterviewStruct>(model);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<InterviewList> getInterviewList(PaginationRequestSearch request, ServerCallContext context)
        {
            try
            {
                InterviewList interviewList = new InterviewList();
                var search = Mapper.Map<SearchStruct, SearchModel>(request.Search);
                var list = await _service.GetInterviewList(request.Offset, request.Limit, search);

                var result = Mapper.Map<List<Interview>, List<InterviewStruct>>(list);
                interviewList.Listdata.AddRange(result);
                interviewList.Total = await _service.GetInterviewListCount(search);
                return interviewList;

            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }
        #endregion


        #region HighlightsInfo(十大亮点申请)
        public override async Task<ModifyReply> createHighlightsInfo(HighlightsInfoStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.Id = Guid.NewGuid().ToString();
                request.CreatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<HighlightsInfoStruct, HighlightsInfo>(request);
                var result = await _service.CreateHighlightsInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> updateHighlightsInfo(HighlightsInfoStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<HighlightsInfoStruct, HighlightsInfo>(request);
                var result = await _service.UpdateHighlightsInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> deleteHighlightsInfoById(IdRequest request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                var result = await _service.DeleteHighlightsInfoById(request.Id);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<HighlightsInfoStruct> getHighlightsInfoById(IdRequest request, ServerCallContext context)
        {
            try
            {
                var model = await _service.GetHighlightsInfoById(request.Id);
                var result = Mapper.Map<HighlightsInfo, HighlightsInfoStruct>(model);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<HighlightsInfoList> getHighlightsInfoList(PaginationRequestSearch request, ServerCallContext context)
        {
            try
            {
                HighlightsInfoList highlightsInfoList = new HighlightsInfoList();
                var search = Mapper.Map<SearchStruct, SearchModel>(request.Search);
                var list = await _service.GetHighlightsInfoList(request.Offset, request.Limit, search);

                var result = Mapper.Map<List<HighlightsInfo>, List<HighlightsInfoStruct>>(list);
                highlightsInfoList.Listdata.AddRange(result);
                highlightsInfoList.Total = await _service.GetHighlightsInfoListCount(search);
                return highlightsInfoList;

            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }
        #endregion


        #region Hotel(酒店)
        public override async Task<ModifyReply> createHotelInfo(HotelStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.HotelId = Guid.NewGuid().ToString();
                request.CreatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<HotelStruct, Hotel>(request);
                var result = await _service.CreateHotelInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> updateHotelInfo(HotelStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<HotelStruct, Hotel>(request);
                var result = await _service.UpdateHotelInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> deleteHotelInfoById(HotelIdRequest request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                var result = await _service.DeleteHotelInfoById(request.HotelId);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<HotelStruct> getHotelById(HotelIdRequest request, ServerCallContext context)
        {
            try
            {
                var model = await _service.GetHotelById(request.HotelId);
                var result = Mapper.Map<Hotel, HotelStruct>(model);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<HotelList> getHotelList(Empty request, ServerCallContext context)
        {
            try
            {
                HotelList hotelList = new HotelList();
                var list = await _service.GetHotelList();
                var result = Mapper.Map<List<Hotel>, List<HotelStruct>>(list);
                hotelList.Listdata.AddRange(result);
                hotelList.Total = result.Count;
                return hotelList;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }
        #endregion


        #region HotelRoomType(酒店房间类型)
        public override async Task<ModifyReply> createHotelRoomTypeInfo(HotelRoomTypeStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.HotelRoomTypeId = Guid.NewGuid().ToString();
                request.CreatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<HotelRoomTypeStruct, HotelRoomType>(request);
                var result = await _service.CreateHotelRoomTypeInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> updateHotelRoomTypeInfo(HotelRoomTypeStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<HotelRoomTypeStruct, HotelRoomType>(request);
                var result = await _service.UpdateHotelRoomTypeInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> deleteHotelRoomTypeById(HotelRoomTypeIdRequest request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                var result = await _service.DeleteHotelRoomTypeById(request.HotelRoomTypeId);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<HotelRoomTypeStruct> getHotelRoomTypeInfoById(HotelRoomTypeIdRequest request, ServerCallContext context)
        {
            try
            {
                var model = await _service.GetHotelRoomTypeInfoById(request.HotelRoomTypeId);
                var result = Mapper.Map<HotelRoomType, HotelRoomTypeStruct>(model);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<HotelRoomTypeList> getHotelRoomTypeListByHotelId(HotelIdRequest request, ServerCallContext context)
        {
            try
            {
                HotelRoomTypeList hotelRoomTypeList = new HotelRoomTypeList();
                var list = await _service.GetHolteRoomTypeListByHotelId(request.HotelId);
                var result = Mapper.Map<List<HotelRoomType>,List<HotelRoomTypeStruct>>(list);
                hotelRoomTypeList.Listdata.AddRange(result);
                hotelRoomTypeList.Total = result.Count;
                return hotelRoomTypeList;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }
        #endregion


        #region HotelBookRecord(酒店预订记录)
        public override async Task<ModifyReply> createHotelBookRecordInfo(HotelBookRecordStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.Id = Guid.NewGuid().ToString();
                request.CreatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<HotelBookRecordStruct, HotelBookRecord>(request);
                var result = await _service.CreateHotelBookRecordInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> updateHotelBookRecordInfo(HotelBookRecordStruct request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                request.UpdatedAt = DateTime.UtcNow.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

                var model = Mapper.Map<HotelBookRecordStruct, HotelBookRecord>(request);
                var result = await _service.UpdateHotelBookRecordInfo(model);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<ModifyReply> deleteHotelBookRecordInfoById(IdRequest request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                var result = await _service.DeleteHotelBookRecordInfoById(request.Id);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
            return modifyReply;
        }

        public override async Task<HotelBookRecordList> getHotelBookRecordByMemberId(MemberIdRequest request, ServerCallContext context)
        {
            try
            {
                HotelBookRecordList hotelBookRecordList = new HotelBookRecordList();
                var list = await _service.GetHotelBookRecordByMemberId(request.MemberId);
                var result = Mapper.Map<List<HotelBookRecord>, List<HotelBookRecordStruct>>(list);
                hotelBookRecordList.Listdata.AddRange(result);
                hotelBookRecordList.Total = result.Count;
                return hotelBookRecordList;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<ModifyReply> cancelHotelBookRecordById(IdRequest request, ServerCallContext context)
        {
            ModifyReply modifyReply = new ModifyReply();
            try
            {
                var result = await _service.CancelHotelBookRecordById(request.Id);
                modifyReply = Mapper.Map<ModifyReplyModel, ModifyReply>(result);
                return modifyReply;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<HotelBookRecordStruct> getHotelBookRecordById(IdRequest request, ServerCallContext context)
        {
            try
            {
                var model = await _service.GetHotelBookRecordById(request.Id);
                var result = Mapper.Map<HotelBookRecord, HotelBookRecordStruct>(model);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }

        public override async Task<HotelBookRecordList> getHotelBookRecordList(PaginationRequestSearch request, ServerCallContext context)
        {
            try
            {
                HotelBookRecordList hotelBookRecordList = new HotelBookRecordList();
                var search = Mapper.Map<SearchStruct, SearchModel>(request.Search);
                var list = await _service.GetHotelBookRecordList(request.Offset, request.Limit, search);

                var result = Mapper.Map<List<HotelBookRecord>, List<HotelBookRecordStruct>>(list);
                hotelBookRecordList.Listdata.AddRange(result);
                hotelBookRecordList.Total = await _service.GetHotelBookRecordListCount(search);
                return hotelBookRecordList;

            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw ex;
            }
        }
        #endregion






    }
}
