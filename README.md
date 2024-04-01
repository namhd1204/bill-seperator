# Mô tả bài toán:
- Có một hóa đơn có tổng số tiền phải trả là X, trong đó gồm nhiều loại hàng hóa có đơn giá là P và số lượng là Q. X = Tổng(P x Q mỗi loại).
- Có Y số người mong muốn cùng nhau chia sẻ hóa đơn này, tức là mỗi người có 1 hóa đơn con
- Kết quả mong muốn là tìm ra số lượng của mỗi sản phẩm trong một hóa đơn con của mỗi người là bao nhiều.
# Mô tả giải thuật:
- Bước 1: Kiểm tra đầu vào bài toán xem tổng của hóa đơn đã bằng tổng số tiền của những người chia sẻ có bằng nhau không. Nếu không bằng thì dừng chương trình
- Bước 2: Tạo stack A dùng để chứa các sản phẩm riêng lẻ từ hóa đơn, mỗi một item là 1 sản phẩm và được sắp xếp theo giá từ nhỏ đến lớn, giá nhỏ nhất ở đấy stack, giá lớn nhất ở đỉnh stack
- Bước 3: Tạo stack B sử dụng như một bộ đệm, sẽ mô tả kĩ hơn ở dưới đây
- Bước 4: Tạo một queue bao gồm những người muốn chia sẻ hóa đơn
- Bước 5: Tìm kiếm sản phẩm có giá trị nhỏ nhất, gọi là Pmin
- Bước 6: Trong khi stack A còn dữ liệu, ta xét 1 sản phẩm từ stack A (chỉ peek ở bước này), gọi tắt là P
- Bước 7: Xét 1 người từ queue (chỉ peek), gọi là N
- Bước 8: 
Xét người này đã trả đủ số tiền mong muốn hay chưa
Nếu đã trả đủ, đưa người này ra khỏi queue (dequeue) và quay lại bước 6. Ngược lại, tiếp tục bước 9
- Bước 9: 
Xét xem nếu người này trả cho sản phẩm ở bước 6 thì không bị vượt quá số tiền phải trả nhưng lại không thể trả thêm bất kì sản phẩm nào khác nữa
Công thức xét: Số tiền còn lại > 0 và Số tiền còn lại < Pmin hoặc vượt quá số tiền phải trả
Trong đó: Số tiền còn lại = Tổng số tiền người N phải trả - (Số tiền đã trả + giá tiền sản phẩm P)
Nếu vi phạm điều kiện trên, đưa sản phẩm P từ stack A vào stack B, quay lại bước 6. Ngược lại, tiếp tục bước 10
- Bước 10: Xét nếu N trả thêm sản phẩm P thì có bị vượt quá số tiền hay không
Tức là: Tổng số tiền N phải trả < Tổng số tiền N đã trả + giá của P
Nếu vượt quá thì, chuyển N về cuối hàng đợi, quay lại bước 6, ngược lại thì tiếp tục bước 11
- Bước 11:
Gán cho người N sẽ trả sản phẩm P
Xóa sản phẩm P khỏi stack A (Pop)
Cho N di chuyển về cuối queue
Nếu stack B có dữ liệu, chuyển lần lượt tất cả sản phẩm từ stack B về lại stack A
Quay về bước 6
