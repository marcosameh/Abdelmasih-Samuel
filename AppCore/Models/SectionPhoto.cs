﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models;

public partial class SectionPhoto
{
    public int Id { get; set; }

    public int SectionId { get; set; }

    public string Photo { get; set; }

    public virtual Section Section { get; set; }
}