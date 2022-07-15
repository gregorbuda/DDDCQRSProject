using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class TestRepository : RepositoryBase<TestClass>, ITestRepository
    {
        public TestRepository(TestDbContext context) : base(context)
        { 

        }

        public async Task<IEnumerable<TestClass>> GetTestByName(string name)
        {
            return await _context.testClass!.Where(o => o.Nombre == name).ToListAsync();
        }
    }
}
