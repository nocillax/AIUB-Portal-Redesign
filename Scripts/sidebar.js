function toggleSidebar() {
    const sidebar = document.getElementById("sidebar");
    const mainContent = document.getElementById("mainContent");

    sidebar.classList.toggle("collapsed");
    mainContent.classList.toggle("expanded");
}

// Responsive sidebar for mobile
if (window.innerWidth <= 768) {
    document.getElementById("sidebar").classList.add("collapsed");
    document.getElementById("mainContent").classList.add("expanded");
}

window.addEventListener("resize", function () {
    if (window.innerWidth <= 768) {
        document.getElementById("sidebar").classList.add("collapsed");
        document.getElementById("mainContent").classList.add("expanded");
    } else {
        document.getElementById("sidebar").classList.remove("collapsed");
        document.getElementById("mainContent").classList.remove("expanded");
    }
});