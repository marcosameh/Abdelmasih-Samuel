﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Career> Careers { get; } = new List<Career>();

    public virtual ICollection<CityLocalized> CityLocalizeds { get; } = new List<CityLocalized>();
}