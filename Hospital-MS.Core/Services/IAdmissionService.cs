using Hospital_MS.Core.Abstractions;
using Hospital_MS.Core.Contracts.Admissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_MS.Core.Services
{
    public interface IAdmissionService
    {
        Task<Result> CreateAsync(CreateAdmissionRequest request, CancellationToken cancellationToken = default);
        Task<Result<AdmissionResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Result<IReadOnlyList<AdmissionResponse>>> GetAllAsync(GetAdmissionsRequest request, CancellationToken cancellationToken = default);

        Task<int> GetAdmissionsCountAsync(GetAdmissionsRequest request, CancellationToken cancellationToken = default);

    }
}
