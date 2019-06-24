using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using GrpcMediaService;
using MediaService.Common;
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

        #region report

        //public override async Task<StudentList> GetAllStudent(Empty query, ServerCallContext context)
        //{
        //    try
        //    {
        //        StudentList list = new StudentList();

        //        var studentList = await _service.GetAllStudent();

        //        var reslut = Mapper.Map<List<Student>, List<StudentStruct>>(studentList);

        //        list.Listdata.Add(reslut);

        //        return list;
        //    }
        //    catch (Exception e)
        //    {
        //        LogHelper.Error(this, e);
        //        throw e;
        //    }
        //}
        #endregion

    }
}
