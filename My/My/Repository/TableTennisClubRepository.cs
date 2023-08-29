using Table_Tennis_UK.Data;
using Table_Tennis_UK.Models;
using Table_Tennis_UK.Models.Dto;
using Table_Tennis_UK.Repository.IRepository;

namespace Table_Tennis_UK.Repository
{
    public class TableTennisClubRepository : Repository<TableTennisClub>, ITableTennisClubRepository
    {
        private readonly ApplicationDbContext _db;
        public TableTennisClubRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<TableTennisClub> UpdateAsync(TableTennisClub entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.TableTennisClubs.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
