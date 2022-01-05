﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.ViewModels.Common
{
    public class PaginationViewModel<TModel>
    {
        const int MaxPageSize = 30;


        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public IList<TModel> Items { get; set; }

        public PaginationViewModel() => Items = new List<TModel>();

    }
}
