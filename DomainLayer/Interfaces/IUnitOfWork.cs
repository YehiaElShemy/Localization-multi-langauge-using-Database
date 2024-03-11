
namespace DomainLayer.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        //add anthor of reference property
        public IRepositoryProject project { get; set; }
        Task<int> SaveChangeAsync();
    }
}
