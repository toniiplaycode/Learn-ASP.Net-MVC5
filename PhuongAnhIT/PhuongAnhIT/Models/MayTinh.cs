using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuongAnhIT.Models
{
    public class MayTinh
    {
        //Tạo một class MayTinh gồm các thuộc tính:
        //1. MaMay: Là một dãy 10 chữ số
        //2. Anh: Ảnh của máy
        //3. Tên dòng máy : vd : Asus x555
        //4. Giá bán: 50000000vnđ
        //5. Ngày sản xuất: Ngày/tháng/năm
        //6. Hãng sản xuất: Asus, Dell, Apple
        // - Điền dữ liệu vào danh sách máy tính: 5 cái
        // - Hiển thị 5 cái máy tính lên trang chủ(view)
        // - Hiển thị 2 cái có giá thấp nhất(view)
        // - Hiển thị sắp xếp từ giá cao đến thấp(view)
        // - Hiển thị các máy thuộc hãng Asus(view)

        public string MaMay { set; get; }
        public string Anh { set; get; }
        public string DongMay { set; get; }
        public double GiaBan { set; get; }
        public DateTime NgaySanXuat { set; get; }
        public string HangSanXuat { set; get; }

        public List<MayTinh> KhoiTao5May()
        {
            List<MayTinh> danhSachMayTinh = new List<MayTinh>();

            // hardcode thêm dữ liệu
            danhSachMayTinh.Add(new MayTinh()
            {
                MaMay = "001",
                DongMay = "Acer nitro 5",
                GiaBan = 24000000,
                NgaySanXuat = new DateTime(2020, 1, 1),
                HangSanXuat = "Acer",
                Anh = "https://nguyenvu-store-medias.tn-cdn.net/2022/09/laptop-acer-nitro-5-tiger-an515-58-769j.jpg"
            });

            danhSachMayTinh.Add(new MayTinh()
            {
                MaMay = "002",
                DongMay = "Asus tuf 15",
                GiaBan = 21200000,
                NgaySanXuat = new DateTime(2021, 8, 12),
                HangSanXuat = "Asus",
                Anh = "https://nguyenvu-store-medias.tn-cdn.net/2023/02/laptop-asus-tuf-dash-f15-fx517zr-hn086w-1.jpg"
            });

            danhSachMayTinh.Add(new MayTinh()
            {
                MaMay = "003",
                DongMay = "Lenovo legion 5",
                GiaBan = 26200000,
                NgaySanXuat = new DateTime(2021, 11, 4),
                HangSanXuat = "Lenovo",
                Anh = "https://nguyenvu-store-medias.tn-cdn.net/2022/08/laptop-lenovo-legion-5-15ach6-82jw00klvn.jpg"
            });

            danhSachMayTinh.Add(new MayTinh()
            {
                MaMay = "004",
                DongMay = "MSI gf 63",
                GiaBan = 18200000,
                NgaySanXuat = new DateTime(2020, 3, 12),
                HangSanXuat = "MSI",
                Anh = "https://nguyenvu-store-medias.tn-cdn.net/2022/12/laptop-msi-gf63-thin-11uc-1228vn.jpg"
            });

            danhSachMayTinh.Add(new MayTinh()
            {
                MaMay = "005",
                DongMay = "Gigabyte G5",
                GiaBan = 19900000,
                NgaySanXuat = new DateTime(2022, 12, 12),
                HangSanXuat = "Gigabyte",
                Anh = "https://nguyenvu-store-medias.tn-cdn.net/2023/04/laptop-gigabyte-g5-kf-e3vn333sh-1.jpg"
            });

            return danhSachMayTinh;
        }
    }
}
