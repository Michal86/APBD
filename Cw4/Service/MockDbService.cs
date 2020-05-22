using System.Collections;
using System.Collections.Generic;
using cw5.DTOs;
using cw5.Models;

namespace cw5.Service
{
    public class MockDbService : IStudentsDbService
    {
        private static IEnumerable<Student> _students;
        

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student(1, "Michał", "Radzewicz"),
                new Student(2, "Anna", "Malewski"),
                new Student(3, "Andrzej", "Kowalski")
            };
        }
        
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public IEnumerable<Enrollment> GetEnrollmentByIndexNumber(string indexNumber)
        {
            throw new System.NotImplementedException();
        }

        public Studies GetStudies(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool AddStudent(Student student, Enrollment enrollment)
        {
            throw new System.NotImplementedException();
        }

        public Enrollment EnrollStudent(EnrollmentRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}