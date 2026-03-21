const apiUrl = 'https://localhost:7182/api/StudyTask';

const taskList = document.getElementById('task-list');

let currentEditId = null;
let currentEditIsCompleted = false;

async function fetchTasks() 
{
    try
    {
        const response = await fetch(apiUrl);
        const tasks = await response.json();

        taskList.innerHTML = '';

        tasks.forEach(task => {
            const taskCard = document.createElement('div');

            taskCard.className = 'task-card';
            taskCard.innerHTML = 
                `<h3>${task.title}</h3>
                <p><strong>Subject:</strong> ${task.subject}</p>
                <p><strong>Description:</strong> ${task.description || "No Description"}</p>
                <p><strong>Deadline:</strong> ${task.deadline ? task.deadline.split('T')[0] : "No Deadline"}</p>
                <p><strong>Status:</strong> ${task.isCompleted ? "Done" : "Not Finnished"}</p>
                <button onclick="toggleStatus(${task.id}, ${task.isCompleted})" class="status-btn">
                    ${task.isCompleted ? "Undo" : "Mark as Done"}
                </button>
                <button onclick="editTask(${task.id})" class="edit-btn">Edit</button>
                <button onclick="deleteTask(${task.id})" class="delete-btn">Delete</button>`;
            taskList.appendChild(taskCard);
        });
    }
    catch (error) 
    {
        console.error("Something went wrong:", error);
        taskList.innerHTML = '<p style="color: red;">Can\'t load the task?</p>';
    }
}
fetchTasks();

const taskForm = document.getElementById('task-form');

taskForm.addEventListener('submit', async (e) => {
    e.preventDefault();

    const taskData = {
        title: document.getElementById('title').value,
        subject: document.getElementById('subject').value,
        description: document.getElementById('description').value,
        deadline: document.getElementById('deadline').value || null
    };

    try
    {
        if (currentEditId === null) {
            const response = await fetch(apiUrl, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(taskData)
            });

            if (!response.ok) alert("Failed to save task.");
        } else {
            taskData.isCompleted = currentEditIsCompleted;

            const response = await fetch(`${apiUrl}/${currentEditId}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(taskData)
            });

            if (!response.ok) alert("Failed to update task.");

            currentEditId = null;
        }

        taskForm.reset();
        fetchTasks();
    }
    catch (error) {
        console.error("Error saving task:", error);
    }
});

async function deleteTask(id) 
{
    if(!confirm("Are you sure you want to delete this task?")) {
        return;
    }   

    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            fetchTasks();
        }
        else {
            alert("failed to delete task.");
        }
    }
    catch (error) {
        console.error("Error deleting task:", error);
    }
}

async function toggleStatus(id, currentStatus) {
    const newStatus = !currentStatus;

    try{
        const response = await fetch(`${apiUrl}/${id}/status`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newStatus)
        });

        if (response.ok) {
            fetchTasks();
        }
        else {
            alert("Failed to update Status.");
        }
    }
    catch (error) {
        console.error("Error updating status:", error);
    }
}

async function editTask(id) {
    try {
        const response = await fetch(`${apiUrl}/${id}`);
        const task = await response.json();

        document.getElementById('title').value = task.title;
        document.getElementById('subject').value = task.subject;
        document.getElementById('description').value = task.description || '';

        if (task.deadline) {
            document.getElementById('deadline').value = task.deadline.split('T')[0];
        }
        else {
            document.getElementById('deadline').value = '';
        }

        currentEditId = task.id;
        currentEditIsCompleted = task.isCompleted;

        window.scrollTo(0, 0);
    }
    catch (error) { 
        console.error("Error fetching task for edit:", error);
    }
}