using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace LaptopShop.Models.database
{
    public class User:IdentityUser
    {
       

        [ForeignKey("Cart")]
        public int Cart_id { get; set; }
        public string?  groupname { get; set; }

        public virtual Cart Cart { get; set; }
       
        public virtual List<Order> Order { get; set; }

    }
}
