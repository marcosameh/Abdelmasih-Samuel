﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models;

public partial class FaqCategoryLocalized
{
    public int CategoryId { get; set; }

    public int LanguageId { get; set; }

    public string Name { get; set; }

    public virtual FaqCategory Category { get; set; }

    public virtual Language Language { get; set; }
}