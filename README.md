Bài toán chia hóa đơn

Mô tả thuật toán sử dụng:
- Bước 1:
    + Tạo 1 stack các sản phẩm từ hóa đơn ban đầu ( lưu ý: là sản phẩm riêng lẻ, không phải tổng của 1 sản phẩm) 
    + Stack được sắp xếp theo giá nhỏ nhất ở đáy và giá lớn nhất ở đỉnh
- Bước 2:
    + Tạo 1 queue cho những người chia sẻ hóa đơn
- Bước 3: 
    + Xét 1 sản phẩm ở đỉnh stack (chỉ Peek/Top stack thôi)
    + Lấy ra 1 người ở đầu queue (Dequeue nhé)
    + Thử set sản phẩm cho người mà ta lấy ra:
        + nếu người này chưa trả đủ thì set sản phẩm này vào hóa đơn của họ, loại bỏ sản phẩm này ra khỏi stack (Pop) và cho họ xuống cuối queue (Enqueue)
        + nếu người này trả đủ số tiền mong muốn rồi thì thôi, không làm gì cả, người này ra khỏi queue (sử dụng Dequeue trước đó rồi)
