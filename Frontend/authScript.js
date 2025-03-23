
fetch('header.html')
    .then(response => response.text())
    .then(data => {
        document.getElementById('navbar-container').innerHTML = data;

        // Sau khi navbar được tải xong, cập nhật tên người dùng
        const userName = localStorage.getItem("userName");
        if (userName) {
            document.getElementById("userNameDisplay").textContent = `Xin chào, ${userName}`;
        }
    })
    .catch(error => console.error('Lỗi tải navbar:', error));



function logout() {
    localStorage.removeItem("token");
    localStorage.removeItem("userName");
    window.location.href = "login.html";
}

// Kiểm tra nếu chưa đăng nhập thì chuyển về trang login
if (window.location.pathname.includes("home.html") && !localStorage.getItem("token")) {
    window.location.href = "login.html";
}
