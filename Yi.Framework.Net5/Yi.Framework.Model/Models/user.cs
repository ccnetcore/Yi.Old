using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
   public class user:baseModel<int>
    {
        public string username { get; set; }
        public string password { get; set; }
        public string icon { get; set; }
        public string nick { get; set; }
        public string email { get; set; }
        public string ip { get; set; }
        public int? age { get; set; }
        public string introduction { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        

        public List<role> roles { get; set; }
        
    }
}
