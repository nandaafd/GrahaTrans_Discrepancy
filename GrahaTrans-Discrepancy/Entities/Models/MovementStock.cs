﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Domain;

[Table("td_MovementStock")]
public partial class MovementStock
{
    [Key]
    [Column("MovementID")]
    public long MovementId { get; set; }

    [Required]
    [StringLength(25)]
    [Unicode(false)]
    public string MovementNo { get; set; }

    [Required]
    [StringLength(25)]
    [Unicode(false)]
    public string StockInNo { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ProductCode { get; set; }

    [Column("ProductCode_External")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductCodeExternal { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string ProductCategory { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [Column("DateBA", TypeName = "datetime")]
    public DateTime? DateBa { get; set; }

    [Column("WarehouseFromID")]
    public int WarehouseFromId { get; set; }

    [Column("WarehouseToID")]
    public int WarehouseToId { get; set; }

    [Column("ProductIn_ID")]
    public long ProductInId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Qty { get; set; }

    [Column("UnitID")]
    public int? UnitId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Remark { get; set; }

    public int? Status { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string DocumentFile { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ApproveBy { get; set; }

    [Column("ApproveDT", TypeName = "datetime")]
    public DateTime? ApproveDt { get; set; }

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