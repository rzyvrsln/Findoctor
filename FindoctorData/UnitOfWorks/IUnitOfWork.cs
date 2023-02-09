using FindoctorData.Repositories;

namespace FindoctorData.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChangeAsync();

        //Task<int> SavaAsync();

        //int Save();
    }
}
