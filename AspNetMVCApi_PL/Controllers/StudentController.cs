using AspNetMVCApi_BLL.Contracts;
using AspNetMVCApi_EL.ViewModels;
using System;
using System.Web.Http;


namespace AspNetMVCApi_PL.Controllers
{
    [System.Web.Http.RoutePrefix("s")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET s --> prefix var böyle çağrılır
        // GET api/student/GetAllStudents
        [System.Web.Http.Route("")]
        public ResponseData GetAllStudents()
        {
            try
            {
                var result = _studentService.GetAllStudent().Data;
                return new ResponseData() { IsSuccess = true, Data = result };
            }
            catch (Exception ex)
            {
                // ex loglanabilir
                return new ResponseData()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


        // GET api/<controller>/5

        //öğrenci ekleme
        [HttpPost]
        [System.Web.Http.Route("")]

        public ResponseData AddStudent([FromBody] StudentVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResponseData()
                    {
                        IsSuccess = false,
                        Message = "Veri girişleri düzgün olmalıdır!"
                    };
                }
                model.RegisterDate = DateTime.Now;
                ResponseData result = _studentService.AddStudent(model);
                return new ResponseData()
                {
                    IsSuccess = true,
                    Message = "Yeni öğrenci kaydı yapılmıştır."
                };
            }
            catch (Exception ex)
            {
                // ex loglanabilir
                return new ResponseData()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        //öğrenci güncelleme
        //HttpPut yada HttpPost kullanılır
        [HttpPut] 
        [System.Web.Http.Route("")]

        public ResponseData UpdateStudent(int studentId, string name, string surname)
        {
            try
            {
                if(studentId>0)
                {
                    ResponseData result=_studentService.UpdateStudent(studentId, name, surname);

                    if(result.IsSuccess)
                    {

                        return new ResponseData()
                        {
                            IsSuccess = true,
                            Message = "Öğrenci başarılı bir şekilde güncellendi!"
                        };
                    }

                    else
                    {
                        return new ResponseData()
                        {
                            IsSuccess = false,
                            Message = "HATA: Öğrenci güncelleme işleminde beklenmedik bir sorun oluştu!"
                        };
                    }
                }
                else
                {
                    return new ResponseData()
                    {
                        IsSuccess = false,
                        Message = "Öğrenci Bulunamadı!"
                    };
                }
            }
            catch (Exception ex)
            {

                // ex loglanabilir
                return new ResponseData()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        [HttpDelete]
        [System.Web.Http.Route("")]

        public ResponseData DeleteStudent(int id)
        {
            try
            {
                if (id>0)
                {
                    var result = _studentService.DeleteStudent(id);
                    if(result.IsSuccess)
                    {
                        return new ResponseData()
                        {
                            IsSuccess = false,
                            Message = "Öğrenci sistemden silinmiştir!"
                        };
                    }
                    else
                    {
                        return new ResponseData()
                        {
                            IsSuccess = false,
                            Message = "HATA: Öğrenci silme işlemi başarısız oldu!"
                        };
                    }
                }
                else
                {
                    //ex loglanabilir.
                    return new ResponseData()
                    {
                        IsSuccess = false,
                        Message = "HATA: id bilgisi girişi düzgün olmalıdır!"

                    };
                }
            }
            catch (Exception ex)
            {

                return new ResponseData()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


        // POST api/<controller>

        // PUT api/<controller>/5

        // DELETE api/<controller>/5
    }
}