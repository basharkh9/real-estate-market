using System.Threading.Tasks;

namespace real_estate_market.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}