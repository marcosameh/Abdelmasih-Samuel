﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models;

public partial class CareerLocalized
{
    public int CareerId { get; set; }

    public int LanguageId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public virtual Career Career { get; set; }

    public virtual Language Language { get; set; }
}