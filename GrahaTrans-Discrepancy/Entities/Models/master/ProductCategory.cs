﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Domain;

[Table("trProductCategory")]
[Index("CategoryName", "ApproveBy", "Status", Name = "NonClusteredIndex-20241212-093054")]
[Index("CategoryName", Name = "UQ_trProductCategory_CategoryName", IsUnique = true)]
public partial class ProductCategory
{
    [Key]
    [Column("ProductCategoryID")]
    public long ProductCategoryId { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string CategoryName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Description { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ApproveBy { get; set; }

    [Column("ApproveDT", TypeName = "datetime")]
    public DateTime? ApproveDt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreateBy { get; set; }

    [Column("CreateDT", TypeName = "datetime")]
    public DateTime CreateDt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string UpdateBy { get; set; }

    [Column("UpdateDT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    public byte Status { get; set; }
    [NotMapped]
    public string StringStatus { get; set; }

}