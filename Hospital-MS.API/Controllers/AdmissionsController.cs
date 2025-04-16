using Hospital_MS.Core.Contracts.Admissions;
using Hospital_MS.Core.Helpers;
using Hospital_MS.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_MS.API.Controllers
{
    [Authorize]
    public class AdmissionsController(IAdmissionService admissionService) : ApiBaseController
    {
        private readonly IAdmissionService _admissionService = admissionService;

        [HttpPost("")]
        public async Task<IActionResult> CreateAdmission([FromBody] CreateAdmissionRequest request, CancellationToken cancellationToken)
        {
            var result = await _admissionService.CreateAsync(request, cancellationToken);

            return result.IsSuccess
                ? Created()
                : BadRequest(result.Error);
        }

        [HttpGet("")]
        public async Task<ActionResult<Pagination<IReadOnlyList<AdmissionResponse>>>> GetAdmissions([FromQuery] GetAdmissionsRequest request, CancellationToken cancellationToken)
        {
            var result = await _admissionService.GetAllAsync(request, cancellationToken);

            int count = await _admissionService.GetAdmissionsCountAsync(request, cancellationToken);

            return result.IsSuccess
                ? Ok(new Pagination<AdmissionResponse>(request.PageIndex, request.PageSize, result.Value, count))
                : NotFound(result.Error);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetAdmission(int patientId, CancellationToken cancellationToken)
        {
            var result = await _admissionService.GetByIdAsync(patientId, cancellationToken);
            return result.IsSuccess
                ? Ok(result.Value)
                : NotFound(result.Error);
        }

    }
}
