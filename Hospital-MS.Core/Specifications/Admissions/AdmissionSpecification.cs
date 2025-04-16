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
    public class AdmissionSpecification : BaseSpecification<Admission>
    {
        public AdmissionSpecification()
        {
            AddIncludes();
        }
        public AdmissionSpecification(int patientId)
            : base(x => x.PatientId == patientId)
        {
            AddIncludes();
        }

        public AdmissionSpecification(GetAdmissionsRequest request)
            : base(x =>
                    (string.IsNullOrEmpty(request.Status) ||
                    x.Patient.Status == Enum.Parse<PatientStatus>(request.Status)))

        {
            AddIncludes();
            ApplyOrderByDescending(x => x.Id);

            var pageIndexHelper = 0;

            if ((request.PageIndex - 1) < 0)
            {
                pageIndexHelper = 0;
            }
            else
            {
                pageIndexHelper = request.PageIndex - 1;

            }

            ApplyPagination(pageIndexHelper * request.PageSize, request.PageSize);
        }

        private void AddIncludes()
        {
            Includes.Add(x => x.CreatedBy);
            Includes.Add(x => x.UpdatedBy);
            Includes.Add(x => x.Patient);
            Includes.Add(x => x.Bed);
            Includes.Add(x => x.Room);
            Includes.Add(x => x.Doctor);
            Includes.Add(x => x.Department);
        }
    }
}
