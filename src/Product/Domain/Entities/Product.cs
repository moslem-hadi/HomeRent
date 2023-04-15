﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Product: BaseAuditableEntity
{
    public string Title { get; set; }
    
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string[]? Pictures { get; set; }

    public decimal? Rating { get; set; }

    public int? ReviewCount { get; set; }

    public List<Property>? Properties{ get; set; }

}