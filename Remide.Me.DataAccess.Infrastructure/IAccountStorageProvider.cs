using System.Threading.Tasks;

using Remide.Me.Business.Entities;

namespace Remide.Me.DataAccess.Infrastructure
{
    public interface IAccountStorageProvider
    {
        Task Save(AccountInfo accountInfo);
        Task<AccountInfo> GetByCredentials(string name, string password);
    }
}