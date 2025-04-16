﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_MS.Core.Helpers
{
    public class Pagination<T>(int pageIndex, int pageSize, IReadOnlyList<T> data, int count)
    {
        public int PageIndex { get; set; } = pageIndex;
        public int PageSize { get; set; } = pageSize;
        public int Count { get; set; } = count;

        public IReadOnlyList<T> Data { get; set; } = data;
    }
}
