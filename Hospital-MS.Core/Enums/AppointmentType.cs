using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_MS.Core.Enums
{
    public enum AppointmentType
    {
        [EnumMember(Value = "كشف")]
        General, // كشف
        [EnumMember(Value = "استشاره")]
        Consultation, // استشاره
        [EnumMember(Value = "عمليه")]
        Surgery, // عمليات
        [EnumMember(Value = "تحاليل")]
        Screening, // تحاليل
        [EnumMember(Value = "اشعه")]
        Radiology ,// أشعه
        [EnumMember(Value = "طوارئ")]
        Emergency, // طوارئ
    }
}
