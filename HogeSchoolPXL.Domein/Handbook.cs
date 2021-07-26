using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Domein
{
    public class Handbook
    {
        public int HandbookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime IssueDate { get; set; }
        public string PhotoUrl { get; set; }
        public Course Course { get; set; }
    }
}
