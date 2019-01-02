﻿using System;
using Domain.Models.Base;
namespace Domain.Models
{
    public class PointExtract:EntityWithCompany
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string History { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Document { get; set; }
        public PointExtractType PointExtractType { get; set; }
        public DateTime? Expiration { get; set; }
    }

    public enum PointExtractType
    {
        Automatic,
        Manual
    }
}