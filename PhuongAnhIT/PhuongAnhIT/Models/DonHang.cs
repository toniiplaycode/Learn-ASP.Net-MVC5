using System;
using System.Collections.Generic;

namespace PhuongAnhIT.Models
{
    public class DonHang
    {
        public int Id { set; get; }
        public string NameCustomer { set; get; }
        public int PhoneNumber { set; get; }
        public string Address { set; get; }
        public DateTime? OrderDate { set; get; } // dấu ? là cho phép thuộc tính được null
        public List<MayTinh> MayTinhDatMua = new List<MayTinh>(); // Danh sách máy tính đặt mua, new List<MayTinh>() để khởi tạo danh sách máy tính để bên View không bị lỗi do MayTinhDatMua là null
    }
}