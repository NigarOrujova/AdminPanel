﻿

namespace WebApplication.ViewModel
{
    public class BasketItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public int StockCount { get; set; }
        public bool IsActive { get; set; }
    }
}
