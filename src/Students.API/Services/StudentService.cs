using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF;
using Students.API.Models;

namespace Students.API.Services
{
    public class StudentService: IStudentService
    {
        private readonly IEfRepository<Student> _repository;
        public StudentService(IEfRepository<Student> efRepository)
        {
            _repository = efRepository;
        }
    }
}
