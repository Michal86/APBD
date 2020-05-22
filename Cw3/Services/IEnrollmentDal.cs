using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Services
{
    interface IEnrollmentDal
    {
        void EnrollStudent(EnrollmentDTO request);
    }
}
