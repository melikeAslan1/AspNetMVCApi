using AspNetMVCApi_EL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMVCApi_BLL.Contracts
{
    public interface IStudentService   //bu kısım diğer projedeki engine kısmıdır.
    {
        ResponseData GetAllStudent();

        ResponseData AddStudent(StudentVM student);

        ResponseData UpdateStudent(int studentId, string newName, string newSurname);

        ResponseData DeleteStudent(int studentId);








    }
}
