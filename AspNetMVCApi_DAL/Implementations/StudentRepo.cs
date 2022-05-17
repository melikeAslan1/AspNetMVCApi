using AspNetMVCApi_DAL.Contracts;
using AspNetMVCApi_EL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMVCApi_DAL.Implementations
{
    public class StudentRepo : RepositoryBase<Student, int>, IStudentRepo
    {
        public StudentRepo(MyContext myContext) : base(myContext)
        {
        }
    }
}
