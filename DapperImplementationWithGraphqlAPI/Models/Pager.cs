﻿namespace DapperImplementationWithGraphqlAPI.Models
{
    public class Pager
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public int Offset { get; set; }
        public int Next { get; set; }

        public Pager(int page, int pageSize = 10)
        {
            Page = page < 1 ? 1 : page;
            PageSize = pageSize < 1 ? 10 : pageSize;

            Next = PageSize;
            Offset = (Page - 1) * Next;
        }
    }
}
