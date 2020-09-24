using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrManagementApi.DTOs.CommentDTOs
{
    public class CommentCreateDTO
    {
        public enum Category
        {
            Coach,
            Quality,
            PersonalProctectiveEquipment,
            Safety,
            AbsenteeismFollowUp,
            Discipline,
            Other

        }
        public class Comment
        {
           

            [Required]
            [MinLength(5, ErrorMessage = "Please enter a message longer than 5 characters")]
            public string Title { get; set; }

            [Required]
            public int EmployeeNumber { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime Date { get; set; }

            [Required(ErrorMessage = "Comment is required")]
            [MinLength(10, ErrorMessage = "Please enter a message longer than 10 characters")]
            public string Post { get; set; }

            //retrieved using user login id        
            public string SubmittedBy { get; set; }

            [Required]
            public Category Category { get; set; }

           
        }
    }
}
