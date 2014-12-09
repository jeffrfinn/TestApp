using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace TestApplication.Models
{
    public class UserModel
    {
        [StringLength(50), Required]
        public object Name { get; set; }
        [Range(0, 9999)]
        public object Age { get; set; }
        
    }

    
}