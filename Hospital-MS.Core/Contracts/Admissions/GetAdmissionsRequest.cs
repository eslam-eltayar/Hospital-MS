﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_MS.Core.Contracts.Admissions
{
    public class GetAdmissionsRequest
    {
        public string? Status { get; set; }

        private const int maxPageSize = 20;
        private int pageSize = 16;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public int PageIndex { get; set; } = 1;
    }
}
