using HogeSchoolPXL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeSchoolPXL.UI.Models
{
    public class HandbookModel
    {
        public int HandbookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public string PhotoUrl { get; set; }


        public static Handbook MapHandbook(HandbookModel model)
        {
            var handbook = new Handbook();
            handbook.HandbookId = model.HandbookId;
            handbook.Title = model.Title;
            handbook.Price = model.Price;
            handbook.IssueDate = model.IssueDate;
            handbook.PhotoUrl = model.PhotoUrl;


            return handbook;
        }
       
    }
}
