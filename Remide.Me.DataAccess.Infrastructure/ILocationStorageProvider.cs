using System.Collections.Generic;

using Remide.Me.Business.Entities;

namespace Remide.Me.DataAccess.Infrastructure
{
    public interface ILocationStorageProvider
    {
        void Save(int userID, List<Location> locations);
    }
}