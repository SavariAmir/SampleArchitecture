﻿namespace ProductManagement.QueryModel
{
    public class CategoryQuery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
    }
}