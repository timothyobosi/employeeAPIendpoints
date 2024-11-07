class EmployeeAPI {
    constructor(baseUrl) {
        this.baseUrl = baseUrl;
    }

    async fetchEmployees() {
        const response = await fetch(`${this.baseUrl}/api/Employees`);
        return response.json();
    }

    async addEmployee(employee) {
        const response = await fetch(`${this.baseUrl}/api/Employees`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(employee)
        });
        return response.json();
    }

    async updateEmployee(employeeId, employee) {
        const response = await fetch(`${this.baseUrl}/api/Employees/${employeeId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(employee)
        });
        return response.json();
    }

    async deleteEmployee(employeeId) {
        const response = await fetch(`${this.baseUrl}/api/Employees/${employeeId}`, {
            method: 'DELETE'
        });
        return response.json();
    }
}

class EmployeeTable {
    constructor(api) {
        this.api = api;
        this.editingEmployeeId = null;
        this.init();
    }

    async init() {
        await this.loadEmployees();
    }

    async loadEmployees() {
        const employees = await this.api.fetchEmployees();
        const tableBody = document.querySelector('#employeeTable tbody');
        tableBody.innerHTML = '';
        employees.forEach(employee => {
            const row = `
                <tr>
                    <td>${employee.employeeId}</td>
                    <td>${employee.employeeFirstName}</td>
                    <td>${employee.employeeLastName}</td>
                    <td>${new Date(employee.employeeDateOfBirth).toLocaleDateString()}</td>
                    <td>${employee.age}</td>
                    <td>${employee.location}</td>
                    <td>${employee.gender}</td>
                    <td>${employee.rank}</td>
                    <td>${employee.weight}</td>
                    <td>${employee.organization}</td>
                    <td>${employee.maritalStatus}</td>
                    <td>${employee.route}</td>
                    <td>
                        <button class="btn btn-warning btn-sm" onclick="employeeTable.editEmployee('${employee.employeeId}')">Edit</button>
                        <button class="btn btn-danger btn-sm" onclick="employeeTable.deleteEmployee('${employee.employeeId}')">Delete</button>
                    </td>
                </tr>
            `;
            tableBody.insertAdjacentHTML('beforeend', row);
        });
    }

    openForm(employee = null) {
        this.editingEmployeeId = employee ? employee.employeeId : null;
        document.getElementById('employeeForm').reset();

        if (employee) {
            document.getElementById('employeeId').value = employee.employeeId;
            document.getElementById('employeeFirstName').value = employee.employeeFirstName;
            document.getElementById('employeeLastName').value = employee.employeeLastName;
            document.getElementById('employeeDateOfBirth').value = employee.employeeDateOfBirth.split('T')[0];
            document.getElementById('employeeAge').value = employee.age;
            document.getElementById('employeeLocation').value = employee.location;
            document.getElementById('employeeGender').value = employee.gender;
            document.getElementById('employeeRank').value = employee.rank;
            document.getElementById('employeeWeight').value = employee.weight;
            document.getElementById('employeeOrganization').value = employee.organization;
            document.getElementById('employeeMaritalStatus').value = employee.maritalStatus;
            document.getElementById('employeeRoute').value = employee.route;
        }

        $('#employeeFormModal').modal('show');
    }

    closeForm() {
        $('#employeeFormModal').modal('hide');
    }

    async saveEmployee() {
        const employee = {
            employeeId: document.getElementById('employeeId').value,
            employeeFirstName: document.getElementById('employeeFirstName').value,
            employeeLastName: document.getElementById('employeeLastName').value,
            employeeDateOfBirth: document.getElementById('employeeDateOfBirth').value,
            age: parseInt(document.getElementById('employeeAge').value),
            location
