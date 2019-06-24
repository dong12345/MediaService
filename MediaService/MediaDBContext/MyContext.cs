using Microsoft.EntityFrameworkCore;

namespace MediaService.MediaDBContext
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
    }
}
