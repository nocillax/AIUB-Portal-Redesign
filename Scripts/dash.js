
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


      function addTodoItem() {
        const todoList = document.getElementById("todoList");
        const newItem = document.createElement("div");
        newItem.className = "todo-item";
        newItem.innerHTML = `
                <div class="todo-icon assignment">📋</div>
                <div class="todo-content">
                    <div class="todo-task">New Task</div>
                    <div class="todo-time">Click to edit</div>
                </div>
            `;
        todoList.appendChild(newItem);
      }

      

      
    