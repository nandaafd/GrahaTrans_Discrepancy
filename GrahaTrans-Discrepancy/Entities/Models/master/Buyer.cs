﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Domain;

[Table("trBuyer")]
public partial class Buyer
{
    [Key]
    [Column("BuyerID")]
    public long BuyerId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string BuyerNo { get; set; }

    [Column("BuyerCategoryID")]
    public int BuyerCategoryId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string BuyerName { get; set; }

    [Column("NIK")]
    [StringLength(25)]
    [Unicode(false)]
    public string Nik { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string KtpNumber { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string JobTitle { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string BuyerAddress { get; set; }

    [Required]
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

    public bool IsDeleted { get; set; }
}