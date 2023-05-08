create proc filterLoaiKH @idLoaiKH int
as begin
select * from KhachHang 
inner join PhanLoaiKhachHang on KhachHang.IdLoaiKhachHang = PhanLoaiKhachHang.Id
where (KhachHang.IdLoaiKhachHang = @idLoaiKH or @idLoaiKH is null)  
end

exec filterLoaiKH null
