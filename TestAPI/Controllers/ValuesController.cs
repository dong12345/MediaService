using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcMediaService;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        #region FormPublic(会刊)

        [Route("createFormPublicInfo")]
        [HttpPost]
        public IActionResult createFormPublicInfo(FormPublicStruct model)
        {
            var result = EGClient.createFormPublicInfo(model);
            return Ok(result);
        }

        [Route("updateFormPublicInfo")]
        [HttpPost]
        public IActionResult updateFormPublicInfo(FormPublicStruct model)
        {
            var result = EGClient.updateFormPublicInfo(model);
            return Ok(result);
        }

        [Route("deleteFormPublicInfoById")]
        [HttpPost]
        public IActionResult deleteFormPublicInfoById(IdRequest IdRequest)
        {
            var result = EGClient.deleteFormPublicInfoById(IdRequest);
            return Ok(result);
        }

        [Route("getFormPublicInfoList")]
        [HttpPost]
        public IActionResult getFormPublicInfoList(Empty empty)
        {
            var result = EGClient.getFormPublicInfoList(empty);
            return Ok(result);
        }

        [Route("getFormPublicInfoById")]
        [HttpPost]
        public IActionResult getFormPublicInfoById(IdRequest IdRequest)
        {
            var result = EGClient.getFormPublicInfoById(IdRequest);
            return Ok(result);
        }

        [Route("getFormPublicList")]
        [HttpPost]
        public IActionResult getFormPublicList(PaginationRequestSearch search)
        {
            var result = EGClient.getFormPublicList(search);
            return Ok(result);
        }
        #endregion


        #region Express(快递单)

        [Route("createExpressInfo")]
        [HttpPost]
        public IActionResult createExpressInfo(ExpressStruct model)
        {
            var result = EGClient.createExpressInfo(model);
            return Ok(result);
        }

        [Route("updateExpressInfo")]
        [HttpPost]
        public IActionResult updateExpressInfo(ExpressStruct model)
        {
            var result = EGClient.updateExpressInfo(model);
            return Ok(result);
        }


        [Route("deleteExpressInfoById")]
        [HttpPost]
        public IActionResult deleteExpressInfoById(IdRequest idRequest)
        {
            var result = EGClient.deleteExpressInfoById(idRequest);
            return Ok(result);
        }

        [Route("getExpressInfoById")]
        [HttpPost]
        public IActionResult getExpressInfoById(IdRequest idRequest)
        {
            var result = EGClient.getExpressInfoById(idRequest);
            return Ok(result);
        }

        [Route("getExpressList")]
        [HttpPost]

        public IActionResult getExpressList(PaginationRequestSearch search)
        {
            var result = EGClient.getExpressList(search);
            return Ok(result);
        }


        #endregion


        #region CatalogueBooks(会刊订购信息)
        [Route("getCatalogueBooks")]
        [HttpPost]
        public IActionResult getCatalogueBooks(PaginationRequestSearch search)
        {
            var result = EGClient.GetAllCatalogueBooksList(search);

            return Ok(result);
        }

        [Route("createCatalogueBooksInfo")]
        [HttpPost]
        public IActionResult createCatalogueBooksInfo(CatalogueBooksStruct model)
        {
            var result = EGClient.CreateCatalogueBooksInfo(model);
            return Ok(result);
        }

        [Route("updateCatalogueBooksInfo")]
        [HttpPost]
        public IActionResult updateCatalogueBooksInfo(CatalogueBooksStruct model)
        {
            var result = EGClient.updateCatalogueBooksInfo(model);
            return Ok(result);
        }

        [Route("deleteCatalogueBooksById")]
        [HttpPost]
        public IActionResult deleteCatalogueBooksById(IdRequest idRequest)
        {
            var result = EGClient.deleteCatalogueBooksById(idRequest);
            return Ok(result);
        }

        [Route("getCatalogueBooksById")]
        [HttpPost]
        public IActionResult getCatalogueBooksById(IdRequest idRequest)
        {
            var result = EGClient.getCatalogueBooksById(idRequest);
            return Ok(result);
        }


        [Route("getFormPublicInfoByExbContractId")]
        [HttpPost]
        public IActionResult getFormPublicInfoByExbContractId(ExbContractIdRequest idRequest)
        {
            var result = EGClient.getFormPublicInfoByExbContractId(idRequest);
            return Ok(result);
        }


        [Route("operateFormPublicInfoByExbContractId")]
        [HttpPost]
        public IActionResult operateFormPublicInfoByExbContractId(FormPublicStruct formPublicStruct)
        {
            var result = EGClient.operateFormPublicInfoByExbContractId(formPublicStruct);
            return Ok(result);
        }
        #endregion


        #region Interview(专题采访)

        [Route("createInterviewInfo")]
        [HttpPost]
        public IActionResult createInterviewInfo(InterviewStruct model)
        {
            var result = EGClient.createInterviewInfo(model);
            return Ok(result);
        }

        [Route("updateInterviewInfo")]
        [HttpPost]
        public IActionResult updateInterviewInfo(InterviewStruct model)
        {
            var result = EGClient.updateInterviewInfo(model);
            return Ok(result);
        }

        [Route("deleteInterviewById")]
        [HttpPost]
        public IActionResult deleteInterviewById(IdRequest idRequest)
        {
            var result = EGClient.deleteInterviewById(idRequest);
            return Ok(result);
        }


        [Route("getInterviewInfoById")]
        [HttpPost]
        public IActionResult getInterviewInfoById(IdRequest idRequest)
        {
            var result = EGClient.getInterviewInfoById(idRequest);
            return Ok(result);
        }

        [Route("getInterviewList")]
        [HttpPost]
        public IActionResult getInterviewList(PaginationRequestSearch search)
        {
            var result = EGClient.getInterviewList(search);
            return Ok(result);
        }

        #endregion



        #region  HighlightsInfo(十大亮点申请)

        [Route("createHighlightsInfo")]
        [HttpPost]
        public IActionResult createHighlightsInfo(HighlightsInfoStruct model)
        {
            var result = EGClient.createHighlightsInfo(model);
            return Ok(result);
        }

        [Route("updateHighlightsInfo")]
        [HttpPost]
        public IActionResult updateHighlightsInfo(HighlightsInfoStruct model)
        {
            var result = EGClient.updateHighlightsInfo(model);
            return Ok(result);
        }

        [Route("deleteHighlightsInfoById")]
        [HttpPost]
        public IActionResult deleteHighlightsInfoById(IdRequest idRequest)
        {
            var result = EGClient.deleteHighlightsInfoById(idRequest);
            return Ok(result);
        }

        [Route("getHighlightsInfoById")]
        [HttpPost]
        public IActionResult getHighlightsInfoById(IdRequest idRequest)
        {
            var result = EGClient.getHighlightsInfoById(idRequest);
            return Ok(result);
        }

        [Route("getHighlightsInfoList")]
        [HttpPost]
        public IActionResult getHighlightsInfoList(PaginationRequestSearch search)
        {
            var result = EGClient.getHighlightsInfoList(search);
            return Ok(result);
        }

        #endregion



        #region Hotel(酒店)

        [Route("createHotelInfo")]
        [HttpPost]
        public IActionResult createHotelInfo(HotelStruct model)
        {
            var result = EGClient.createHotelInfo(model);
            return Ok(result);
        }

        [Route("updateHotelInfo")]
        [HttpPost]
        public IActionResult updateHotelInfo(HotelStruct model)
        {
            var result = EGClient.updateHotelInfo(model);
            return Ok(result);
        }

        [Route("deleteHotelInfoById")]
        [HttpPost]
        public IActionResult deleteHotelInfoById(HotelIdRequest idRequest)
        {
            var result = EGClient.deleteHotelInfoById(idRequest);
            return Ok(result);
        }

        [Route("getHotelById")]
        [HttpPost]
        public IActionResult getHotelById(HotelIdRequest idRequest)
        {
            var result = EGClient.getHotelById(idRequest);
            return Ok(result);
        }

        [Route("getHotelList")]
        [HttpPost]
        public IActionResult getHotelList(Empty empty)
        {
            var result = EGClient.getHotelList(empty);
            return Ok(result);
        }

        #endregion



        #region HotelRoomType(酒店房间类型)

        [Route("createHotelRoomTypeInfo")]
        [HttpPost]
        public IActionResult createHotelRoomTypeInfo(HotelRoomTypeStruct model)
        {
            var result = EGClient.createHotelRoomTypeInfo(model);
            return Ok(result);
        }

        [Route("updateHotelRoomTypeInfo")]
        [HttpPost]
        public IActionResult updateHotelRoomTypeInfo(HotelRoomTypeStruct model)
        {
            var result = EGClient.updateHotelRoomTypeInfo(model);
            return Ok(result);
        }

        [Route("deleteHotelRoomTypeById")]
        [HttpPost]
        public IActionResult deleteHotelRoomTypeById(HotelRoomTypeIdRequest hotelRoomTypeId)
        {
            var result = EGClient.deleteHotelRoomTypeById(hotelRoomTypeId);
            return Ok(result);
        }

        [Route("getHotelRoomTypeInfoById")]
        [HttpPost]
        public IActionResult getHotelRoomTypeInfoById(HotelRoomTypeIdRequest hotelRoomTypeId)
        {
            var result = EGClient.getHotelRoomTypeInfoById(hotelRoomTypeId);
            return Ok(result);
        }

        [Route("getHolteRoomTypeListByHotelId")]
        [HttpPost]
        public IActionResult getHolteRoomTypeListByHotelId(HotelIdRequest hotelId)
        {
            var result = EGClient.getHotelRoomTypeListByHotelId(hotelId);
            return Ok(result);
        }

        #endregion



        #region HotelBookRecord(酒店预订记录)

        [Route("createHotelBookRecordInfo")]
        [HttpPost]
        public IActionResult createHotelBookRecordInfo(HotelBookRecordStruct model)
        {
            var result = EGClient.createHotelBookRecordInfo(model);
            return Ok(result);
        }

        [Route("updateHotelBookRecordInfo")]
        [HttpPost]
        public IActionResult updateHotelBookRecordInfo(HotelBookRecordStruct model)
        {
            var result = EGClient.updateHotelBookRecordInfo(model);
            return Ok(result);
        }


        [Route("deleteHotelBookRecordInfoById")]
        [HttpPost]
        public IActionResult deleteHotelBookRecordInfoById(IdRequest idRequest)
        {
            var result = EGClient.deleteHotelBookRecordInfoById(idRequest);
            return Ok(result);
        }


        [Route("getHotelBookRecordByMemberId")]
        [HttpPost]
        public IActionResult getHotelBookRecordByMemberId(MemberIdRequest memberId)
        {
            var result = EGClient.getHotelBookRecordByMemberId(memberId);
            return Ok(result);
        }


        [Route("cancelHotelBookRecordById")]
        [HttpPost]
        public IActionResult cancelHotelBookRecordById(IdRequest idRequest)
        {
            var result = EGClient.cancelHotelBookRecordById(idRequest);
            return Ok(result);
        }


        [Route("getHotelBookRecordById")]
        [HttpPost]
        public IActionResult getHotelBookRecordById(IdRequest idRequest)
        {
            var result = EGClient.getHotelBookRecordById(idRequest);
            return Ok(result);
        }

        [Route("getHotelBookRecordList")]
        [HttpPost]
        public IActionResult getHotelBookRecordList(PaginationRequestSearch search)
        {
            var result = EGClient.getHotelBookRecordList(search);
            return Ok(result);
        }


        [Route("getHotelOrderList")]
        [HttpPost]
        public IActionResult getHotelOrderList(PaginationRequestSearch search)
        {
            var result = EGClient.getHotelOrderList(search);
            return Ok(result);
        }

        [Route("updateIsChecked")]
        [HttpPost]
        public IActionResult updateIsChecked(UpdateIsCheckedStruct model)
        {
            var result = EGClient.updateIsChecked(model);
            return Ok(result);
        }

        #endregion



    }


}
