document.addEventListener("DOMContentLoaded", function () {
    const userName = localStorage.getItem("userName");
    if (userName) {
        document.getElementById("userNameDisplay").textContent = `Xin chào, ${userName}`;
    }
});
function logout() {
    localStorage.removeItem("token");
    localStorage.removeItem("userName");
    window.location.href = "login.html";
}

// Kiểm tra nếu chưa đăng nhập thì chuyển về trang login
if (window.location.pathname.includes("home.html") && !localStorage.getItem("token")) {
    window.location.href = "login.html";
}
