﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models;

public partial class AlbumLocalized
{
    public int AlbumId { get; set; }

    public int LanguageId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string MetaTitle { get; set; }

    public string MetaDescription { get; set; }

    public virtual Album Album { get; set; }

    public virtual Language Language { get; set; }
}