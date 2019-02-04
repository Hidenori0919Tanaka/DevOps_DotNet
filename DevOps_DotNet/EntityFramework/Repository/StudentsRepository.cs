using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
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
          
        //public Task<List<Student>> GetAll()
        //{
        //    return dbContext.Student.ToListAsync();
        //}
        public Task<List<Student>> GetAll()
        {
            using (var _context = dbContext)
            {
                return (from q in _context.Student
                        select q).ToListAsync();
            }
        }

    }
}
