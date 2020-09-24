using HrMangementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrManagementApi.DTOs.CommentDTOs
{
    public class CommentViewIdDTO
    {
        public int CommentId { get; set; }


        public string Title { get; set; }


        public int EmployeeNumber { get; set; }


        public DateTime Date { get; set; }

        public string Post { get; set; }


        public string SubmittedBy { get; set; }


        public Category Category { get; set; }


        public Employee Employee { get; set; }

    }
}
