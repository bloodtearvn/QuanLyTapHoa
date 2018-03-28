# QuanLyTapHoa
Phần mềm quản lý tiệm tạp hóa bao gồm các chức năng:
	1. Đăng nhập thực hiện việc chứng thực là nhân viên của tiệm tạp hóa		
	2. Quản lý hàng hóa thực hiện các chức năng về hàng hóa như sau:
		+ Thêm hàng hóa
		+ Cập nhật thông tin hàng hóa
		+ Tìm hàng hóa
		+ Thêm tồn kho (nhập thêm số lượng hàng hóa đã có)
	3. Quản lý khách hàng thực hiện các chức năng về khách hàng như sau
		+ Thêm khách hàng
		+ Cập nhật thông tin khách hàng
		+ Tìm khách hàng
	4. Quản lý nhân viên thực hiện các chức năng nhân viên như sau
		+ Thêm nhân viên
		+ Cập nhật thông tin nhân viên
		+ Tìm nhân viên
	5. Quản lý người dùng hiện việc quản lý các tài khoản của nhân viên như sau
		+ Thêm người dùng
		+ Cập nhật thông tin người dùng (mật khẩu, phân quyền)
		+ Danh sách người dùng
		+ Xóa người dùng
	6. Quản lý hóa đơn (đơn hàng) thực hiện chức năng bán hàng 
		+ Thêm hóa đơn
		+ Xem hóa đơn
	7. Quản lý tồn kho thực hiện chức năng kiểm kê
		+ Xem tồn kho
		+ Xem xuất bán
	8. Quản lý báo cáo thực hiện các báo cáo định kỳ theo ngày, tháng	
		+ Xem báo cáo xuất
		+ Xem báo cáo nhập
Qua quá trình phân tích và thiết kế CSDL cho hệ thống tiệm tạp hóa (sử dụng Access) cho ta được hệ thống các bảng, mẫu biểu, quan hệ như sau:
Bảng Customer dùng để chưa thông tin khách hàng
Tên cột	Kiểu dữ liệu	Diễn giải	Ghi chú
CustomerNO	AutoNumber	Mã khách hàng	PK
CustName	Short Text	Tên khách hàng	
Address	Short Text	Địa chỉ khách hàng	
ContactNo	Short Text	Số điện thoại	Có thể dùng CMND
Bảng POS chứa thông tin hóa đơn (đơn hàng của khách)
Tên cột	Kiểu dữ liệu	Diễn giải	Ghi chú
InvoiceNo	Short Text	Mã hóa đơn	PK
POSDate	Date/Time	Ngày mua	
POSTime	Date/Time	Giờ mua	
NonVatAmount	Number	Thành tiền chưa thuế	
VatAmount	Number	Thuế GTGT	
TotalAmount	Number	Thành tiền	
CustomerNo	Number	Mã khách hàng	FK
StaffID	Number	Mã nhân viên	FK
Bảng POSDetail chưa thông tin các chi tiết của hóa đơn (đơn hàng )
Tên cột	Kiểu dữ liệu	Diễn giải	Ghi chú
POSDetailNo	AutoNumber	ID	PK
InvoiceNo	Short Text	Mã hóa đơn	FK
ItemNo	Number	ID sản phẩm	FK
ItemPrice	Number	Đơn giá	
Quantity	Number	Số lượng sản phẩm	
Discount	Number	Giảm giá	

Bảng Item chứa thông tin các chi tiết sản phẩm mà tiệm tạp hóa đang có
Tên cột	Kiểu dữ liệu	Diễn giải	Ghi chú
ItemNo	AutoNumber	ID sản phẩm	PK
ItemCode	Short Text	Mã sản phẩm	
IDescription	Short Text	Tên sản phẩm	
StocksOnHand	Number	Số lượng	
UnitPrice	Number	Đơn giá sản phẩm	
Bảng Staff chứa thông tin các nhân viên mà tiệm tạp hóa đang có
Tên cột	Kiểu dữ liệu	Diễn giải	Ghi chú
StaffID	AutoNumber	ID	PK
Fullname	Short Text	Tên nhân viên	
Address	Short Text	Địa chỉ nhân viên	
ContactNo	Short Text	Số điện thoại	
Position	Number	Vị trí làm việc	
Bảng StocksIn chứa thông tin các hàng hóa mà tiệm tạp hóa đang có
Tên cột	Kiểu dữ liệu	Diễn giải	Ghi chú
StocksInNo	AutoNumber	ID	PK
ItemNo	Number	ID sản phẩm	FK
ItemQuantity	Number	Số lượng tồn kho	
SIDate	Date/Time	Ngày nhập	
CurrentStocks	Number	Số lượng hiện tại	
Bảng User chứa thông tin các tài khoản của nhân viên	
Tên cột	Kiểu dữ liệu	Diễn giải	Ghi chú
Username	Short Text	Tên đăng nhập	
pwd	Short Text	Mật khẩu	
role	Short Text	Phân quyền	
StaffID	Number	Mã nhân viên	FK

Bảng các mố quan hệ
 
Mức độ hoàn thành:
Các chức năng chưa hoàn thành do kiến thức về lập trình và thời gian hạn hẹp
		+ Chức năng xóa sản phẩm, xóa khách hàng, xóa hóa đơn, xóa nhân viên,…
		+ Chức năng quản lý nhà cung cấp sản phẩm	
