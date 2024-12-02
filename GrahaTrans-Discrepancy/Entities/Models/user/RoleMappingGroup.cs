﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Domain;

[Table("tuRoleMappingGroup")]
public partial class RoleMappingGroup
{
    [Key]
    [Column("GroupID")]
    public int GroupId { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string GroupName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Remark { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Mapping { get; set; }

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