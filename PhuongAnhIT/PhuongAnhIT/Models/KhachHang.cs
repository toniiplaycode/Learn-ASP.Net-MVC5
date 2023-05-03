using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuongAnhIT.Models
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Number { get ; set; }   
        public string Address { get; set; }
        public string Email { get; set; }  
        public string Sex { get; set; } 
        public string Avatar { get; set; } 
    }
}