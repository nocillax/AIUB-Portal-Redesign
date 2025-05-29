function toggleDropdown() {
	const dropdown = document.getElementById("userDropdown");
	dropdown.classList.toggle("show");
}

// Close dropdown
document.addEventListener("click", function (event) {
	const userProfile = document.querySelector(".user-profile");
	const dropdown = document.getElementById("userDropdown");

	if (!userProfile.contains(event.target)) {
		dropdown.classList.remove("show");
	}
});

