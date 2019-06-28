using MediaService.DBModel;
using Microsoft.EntityFrameworkCore;

namespace MediaService.MediaDBContext
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<CatalogueBooks> CatalogueBooks { get; set; }

        public DbSet<Express> Express { get; set; }

        public DbSet<FormPublic> FormPublic { get; set; }

        public DbSet<HighlightsInfo> HighlightsInfo { get; set; }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<HotelBookRecord> HotelBookRecord { get; set; }

        public DbSet<HotelRoomType> HotelRoomType { get; set; }

        public DbSet<Interview> Interview { get; set; }
    }
}
