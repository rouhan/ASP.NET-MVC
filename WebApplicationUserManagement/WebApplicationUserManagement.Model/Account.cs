using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationUserManagement.Model
{
    /// <summary>
    /// Account Model Class for Creating account table
    /// </summary>
    /// <author>Muhammad Asad Ashraf </author>
    /// <created>30-May-2020</created>
    /// <revisions>
    ///     <revision>
    ///         <author></author>
    ///         <date></date>
    ///         <remarks></remarks>
    ///     </revision>
    /// </revisions>
    public class Account
    {
        [Key]
        [Index]
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastLoginDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastFailedLoginDate { get; set; }

        [DefaultValue(0)]
        public int RetryCount { get; set; }

        [DefaultValue("true")]
        public bool Active { get; set; }
    }
}
