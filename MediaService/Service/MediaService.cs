using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaService.MediaDBContext;
using Microsoft.EntityFrameworkCore;

namespace MediaService.Service
{
    public class MediaServices
    {
        private DbContextOptionsBuilder<MyContext> _options;

        public MediaServices(DbContextOptionsBuilder<MyContext> options, string _sql)
        {
            _options = options;
            options.UseNpgsql(_sql);
        }

        //public async Task<List<Student>> GetAllStudent()
        //{
        //    try
        //    {
        //        using (var _context = new EXDBContentText(_options.Options))
        //        {
        //            var list = await _context.Student.ToListAsync();

        //            return list;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        LogHelper.Error(this, e);
        //        throw new Exception("异常", e);
        //    }
        //}
    }
}
