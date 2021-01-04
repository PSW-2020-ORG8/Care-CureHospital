using Backend.Model.Tender;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.TenderRepository
{
    public interface ITenderRepository : IRepository<Tender, int>
    {
    }
}
