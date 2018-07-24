using System.Threading.Tasks;

namespace bookglobe_backend.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}