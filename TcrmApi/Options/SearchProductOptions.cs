using System;

namespace TinyCrm.Core.Model.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchProductOptions
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PriceMin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

    }
}