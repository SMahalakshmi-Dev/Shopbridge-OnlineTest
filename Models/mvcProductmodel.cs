using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopbridge.Models
{
    public class mvcProductmodel
    {        
        public int prodId { get; set; }
        [DisplayName("ItemName")]
        [Required(ErrorMessage = "This field is required")]            
        public string prodName { get; set; }
        [DisplayName("Item Description")]
        public string prodDesc { get; set; }
        [DisplayName("Upload Image")]
        public string prodImage { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}