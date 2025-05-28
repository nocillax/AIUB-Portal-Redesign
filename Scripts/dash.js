
      function toggleDropdown() {
        const dropdown = document.getElementById("userDropdown");
        dropdown.classList.toggle("show");
      }

      function toggleSidebar() {
        const sidebar = document.getElementById("sidebar");
        const mainContent = document.getElementById("mainContent");

        sidebar.classList.toggle("collapsed");
        mainContent.classList.toggle("expanded");
      }

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

      // Close dropdown
      document.addEventListener("click", function (event) {
        const userProfile = document.querySelector(".user-profile");
        const dropdown = document.getElementById("userDropdown");

        if (!userProfile.contains(event.target)) {
          dropdown.classList.remove("show");
        }
      });

      // Add time grid lines to calendar
      document.addEventListener("DOMContentLoaded", function () {
        const dayContents = document.querySelectorAll(".day-content");
        dayContents.forEach((dayContent) => {
          for (let i = 1; i <= 14; i++) {
            const gridLine = document.createElement("div");
            gridLine.className = "time-grid-line";
            gridLine.style.top = i * 60 + "px";
            dayContent.appendChild(gridLine);
          }
        });

        // Update current time line position
        updateCurrentTimeLine();
        setInterval(updateCurrentTimeLine, 60000);
      });

      function updateCurrentTimeLine() {
        const now = new Date();
        const hours = now.getHours();
        const minutes = now.getMinutes();

        // Calculate position (8 AM = 0, each hour = 60px)
        if (hours >= 8 && hours <= 22) {
          const position = (hours - 8) * 60 + minutes;
          const timeLine = document.querySelector(".current-time-line");
          if (timeLine) {
            timeLine.style.top = position + "px";
          }
        }
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
    