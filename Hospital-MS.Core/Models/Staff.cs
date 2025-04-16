﻿using Hospital_MS.Core.Enums;

namespace Hospital_MS.Core.Models
{
    public sealed class Staff : AuditableEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Specialization { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly HireDate { get; set; }
        public StaffStatus Status { get; set; } 
        public StaffType Type { get; set; } 

        public int? ClinicId { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Property
        public Clinic? Clinic { get; set; }
        public Department Department { get; set; } = default!;
    }
}
