using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class VMMasterSearchForm
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool? Approval { get; set; }
        public int? Status { get; set; }
        public DateTime? Date1 { get; set; }
        public DateTime? Date2 { get; set; }
        public string? FlagString { get; set; }
        public int? FlagInt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
