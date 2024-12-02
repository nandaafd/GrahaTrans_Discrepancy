﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Domain;

[Table("td_Product_OUT")]
public partial class ProductOut
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ProductIn_ID")]
    public int ProductInId { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string StockInNo { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductCode { get; set; }

    [Column("ProductCode_External")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductCodeExternal { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductName { get; set; }

    [Column("ProductCategoryID")]
    public int? ProductCategoryId { get; set; }

    [Column("NoSJ")]
    [StringLength(50)]
    [Unicode(false)]
    public string NoSj { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ExpiredDate { get; set; }

    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string SupplierName { get; set; }

    [Column("VehicleID")]
    public long? VehicleId { get; set; }

    [Column("OrderDetailID")]
    public int OrderDetailId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string OrderNo { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Qty { get; set; }

    [Column("UnitID")]
    public int? UnitId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Amount { get; set; }

    [Column("OutTypeID")]
    public int? OutTypeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Remark { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string DocumentFile { get; set; }

    public int? Status { get; set; }

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