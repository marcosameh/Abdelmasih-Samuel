﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models;

public partial class InfoPageCategory
{
    public int Id { get; set; }

    public string UrlName { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<InfoPageCategoryLocalized> InfoPageCategoryLocalizeds { get; } = new List<InfoPageCategoryLocalized>();

    public virtual ICollection<InfoPage> InfoPages { get; } = new List<InfoPage>();
}