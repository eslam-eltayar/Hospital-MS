using Azure.Core;
using Hospital_MS.Core.Contracts.Admissions;
using Hospital_MS.Core.Enums;
using Hospital_MS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_MS.Core.Specifications.Admissions
{
    public class AdmissionCountSpecification : BaseSpecification<Admission>
    {
        public AdmissionCountSpecification(GetAdmissionsRequest request)
        : base(x =>
        (string.IsNullOrEmpty(request.Status) ||
                    x.Patient.Status == Enum.Parse<PatientStatus>(request.Status)))
        {

        }
    }
}
