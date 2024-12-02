﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Domain;

[Table("td_BadStock_IN")]
public partial class BadStockIn
{
    [Key]
    [Column("BadStockID")]
    public long BadStockId { get; set; }

    [Required]
    [StringLength(25)]
    [Unicode(false)]
    public string BadStockNo { get; set; }

    [Required]
    [StringLength(25)]
    [Unicode(false)]
    public string StockInNo { get; set; }

    [Column("ProductIn_ID")]
    public int? ProductInId { get; set; }

    [Column("Product_ID")]
    public int? ProductId { get; set; }

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

    [Column("NoSJ")]
    [StringLength(25)]
    [Unicode(false)]
    public string NoSj { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpiredDate { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Condition { get; set; }

    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [Column("VehicleID")]
    public int? VehicleId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string SupplierName { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Qty { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal QtyOut { get; set; }

    [Column("UnitID")]
    public int? UnitId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? TotalAmount { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Remark { get; set; }

    public int? Status { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string DocumentFile { get; set; }

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