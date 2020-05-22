using System.Collections;
using System.Collections.Generic;
using cw5.DTOs;
using cw5.Models;

namespace cw5.Service
{
    public interface IStudentsDbService
    {
        public IEnumerable<Student> GetStudents();
        public IEnumerable<Enrollment> GetEnrollmentByIndexNumber(string indexNumber);
        public Studies GetStudies(string name);
        public bool AddStudent(Student student, Enrollment enrollment);
        public Enrollment EnrollStudent(EnrollmentRequest request);
    }
}