﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Domain;

[Table("tuUser")]
public partial class User
{
    [Key]
    [Column("UserID")]
    public long UserId { get; set; }

    [Column("RoleMappingGroupID")]
    public int? RoleMappingGroupId { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Fullname { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; }

    [Required]
    [Unicode(false)]
    public string Password { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string PhoneNo { get; set; }

    [Column("LastIP")]
    [StringLength(50)]
    [Unicode(false)]
    public string LastIp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LastLogin { get; set; }

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