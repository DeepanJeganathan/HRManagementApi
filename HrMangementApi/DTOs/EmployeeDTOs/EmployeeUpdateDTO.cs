using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrManagementApi.DTOs.EmployeeDTOs
{
    public class EmployeeUpdateDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [RegularExpression(@"^([0-9]{4})$", ErrorMessage = "Employee number must be 4 digits")]

        public int EmployeeNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PayLevel { get; set; }

        public int PrimarySkill { get; set; }

        public int? SecondarySkill { get; set; }

        [DataType(DataType.Date)]
        public DateTime? SecondarySkillLastOn { get; set; }

        public int? ThirdSkill { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ThirdSkillLastOn { get; set; }

        public string NoSkill { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool status { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool Utility { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool Shipping { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool FirstAidCertified { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

    }
}
