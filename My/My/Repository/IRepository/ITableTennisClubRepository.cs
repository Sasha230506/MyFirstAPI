using Table_Tennis_UK.Models;

namespace Table_Tennis_UK.Repository.IRepository
{
    public interface ITableTennisClubRepository : IRepository<TableTennisClub>
    {
        Task<TableTennisClub> UpdateAsync(TableTennisClub entity);
    }
}
