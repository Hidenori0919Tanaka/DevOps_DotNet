using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Repository
{
    public class StudentsRepository : IStudent<Student>
    {
        private SchoolContext dbContext;
        public StudentsRepository(SchoolContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Student> GetAll()
        {
            return dbContext.Set<Student>().ToList();
        }
    }
}
