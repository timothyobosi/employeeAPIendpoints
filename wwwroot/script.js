const apiUrl = "http://localhost:5048/api/employees"; // Replace with your actual API endpoint

// Load employees on page load
document.addEventListener("DOMContentLoaded", loadEmployees);

// Fetch and display employees
async function loadEmployees() {
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) throw new Error(`Error: ${response.statusText}`);
        const employees = await response.json();

        const tbody = document.querySelector("#employeeTable tbody");
        tbody.innerHTML = ""; // Clear table

        employees.forEach(employee => {
            const row = document.createElement("tr");

            // Parse and format the date of birth
            let formattedDate = "No Date Provided";
            if (employee.employeeDateOfBirth) {
                try {
                    const dob = new Date(employee.employeeDateOfBirth);
                    formattedDate = dob.toLocaleDateString();
                } catch (error) {
                    console.error("Error parsing date:", error);
                }
            }

            row.innerHTML = `
        <td>${employee.employeeId}</td>
        <td>${employee.employeeFirstName}</td>
        <td>${employee.employeeLastName}</td>
        <td>${formattedDate}</td>
        <td>
            <button class="update-btn" onclick="updateEmployee('${employee.employeeId}')">Update</button>
            <button class="delete-btn" onclick="deleteEmployee('${employee.employeeId}')">Delete</button>
        </td>
    `;
            tbody.appendChild(row);
        });

    } catch (error) {
        console.error("Failed to load employees:", error);
    }
}

// Add new employee
document.getElementById("addEmployeeForm").addEventListener("submit", async (e) => {
    e.preventDefault();

    const employeeId = document.getElementById("employeeId").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const dateOfBirth = document.getElementById("dateOfBirth").value;

    const newEmployee = {
        employeeId: employeeId,
        employeeFirstName: firstName,
        employeeLastName: lastName,
        employeeDateOfBirth: dateOfBirth // Send the date as is (in yyyy-mm-dd format)
    };

    try {
        await fetch(apiUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(newEmployee)
        });

        loadEmployees(); // Reload the employee list
        e.target.reset(); // Clear the form
    } catch (error) {
        console.error("Error adding employee:", error);
    }
});

// Delete employee
async function deleteEmployee(employeeId) {
    try {
        await fetch(`${apiUrl}/${employeeId}`, { method: "DELETE" });
        loadEmployees(); // Reload the employee list after deletion
    } catch (error) {
        console.error("Error deleting employee:", error);
    }
}

// Update employee (dummy function - adjust to open a modal or inline form)
// Update employee
function updateEmployee(employeeId) {
    const firstName = prompt("Enter new first name:");
    const lastName = prompt("Enter new last name:");
    const dateOfBirth = prompt("Enter new date of birth (YYYY-MM-DD):");

    if (firstName && lastName && dateOfBirth) {
        const updatedEmployee = {
            employeeId: employeeId, // Ensure the ID is included in the payload if needed by your API
            employeeFirstName: firstName,
            employeeLastName: lastName,
            employeeDateOfBirth: dateOfBirth
        };

        fetch(`${apiUrl}/${employeeId}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(updatedEmployee)
        })
            .then(response => {
                if (!response.ok) throw new Error("Failed to update employee.");
                return response.json();
            })
            .then(() => {
                alert("Employee updated successfully!");
                loadEmployees(); // Reload the employee list after updating
            })
            .catch(error => {
                console.error("Error updating employee:", error);
                alert("An error occurred while updating the employee.");
            });
    } else {
        alert("All fields are required for updating.");
    }
}
