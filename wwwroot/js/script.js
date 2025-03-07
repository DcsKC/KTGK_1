// Đọc danh sách hàng hóa
async function getHangHoa() {
    try {
        const response = await fetch("http://localhost:5081/api/hang_hoa");
        if (!response.ok) throw new Error("Lỗi khi lấy dữ liệu");

        const data = await response.json();
        let tableContent = "";
        data.forEach(hh => {
            tableContent += `
                <tr>
                    <td>${hh.ma_hanghoa}</td>
                    <td>${hh.ten_hanghoa}</td>
                    <td>${hh.so_luong}</td>
                    <td>${hh.ghi_chu || "Chưa có ghi chú"}</td>
                    <td>
                        <button onclick="updateGhiChu('${hh.ma_hanghoa}')">Sửa ghi chú</button>
                        <button onclick="deleteHangHoa('${hh.ma_hanghoa}')">Xóa</button>
                    </td>
                </tr>
            `;
        });

        document.getElementById("data-table").innerHTML = tableContent;
    } catch (error) {
        console.error(error);
        alert("Không thể lấy dữ liệu hàng hóa!");
    }
}

// Cập nhật ghi chú hàng hóa
async function updateGhiChu(id) {
    const newGhiChu = prompt("Nhập ghi chú mới:");
    if (!newGhiChu) return;

    try {
        const response = await fetch(`http://localhost:5081/api/hang_hoa/ghichu/${id}`, {
            method: "PATCH",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ ghi_chu: newGhiChu }) // Gửi đúng dạng JSON
        });

        if (!response.ok) throw new Error("Lỗi cập nhật ghi chú");
        alert("Cập nhật ghi chú thành công!");
        getHangHoa();
    } catch (error) {
        console.error(error);
        alert("Không thể cập nhật ghi chú!");
    }
}

// Xóa hàng hóa
async function deleteHangHoa(id) {
    if (!confirm("Bạn có chắc muốn xóa?")) return;

    try {
        const response = await fetch(`http://localhost:5081/api/hang_hoa/${id}`, {
            method: "DELETE"
        });

        if (!response.ok) throw new Error("Lỗi xóa hàng hóa");
        alert("Xóa thành công!");
        getHangHoa();
    } catch (error) {
        console.error(error);
        alert("Không thể xóa hàng hóa!");
    }
}

// Thêm hàng hóa
async function createHangHoa() {
    const ma_hanghoa = document.getElementById("ma_hanghoa").value;
    const ten_hanghoa = document.getElementById("ten_hanghoa").value;
    const so_luong = document.getElementById("so_luong").value;
    const ghi_chu = document.getElementById("ghi_chu").value;

    const data = { ma_hanghoa, ten_hanghoa, so_luong: parseInt(so_luong), ghi_chu };

    try {
        const response = await fetch("http://localhost:5081/api/hang_hoa", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        if (!response.ok) throw new Error("Lỗi thêm hàng hóa");
        alert("Thêm hàng hóa thành công!");
        getHangHoa();
    } catch (error) {
        console.error(error);
        alert("Không thể thêm hàng hóa!");
    }
}

// Load danh sách khi trang mở
document.addEventListener("DOMContentLoaded", getHangHoa);
