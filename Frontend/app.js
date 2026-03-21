const apiUrl = 'https://localhost:7182/api/StudyTask';

const taskList = document.getElementById('task-list');

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
                <p><strong>Status:</strong> ${task.isCompleted ? "Done" : "Pending"}</p>`;
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

    const newTask = {
        title: document.getElementById('title').value,
        subject: document.getElementById('subject').value,
        description: document.getElementById('description').value,
        deadline: document.getElementById('deadline').value || null
    };

    try{
        const response = await fetch (apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newTask)
        });

        if (response.ok) {
            taskForm.reset();
            fetchTasks();
        }
        else {
            alert("Failed to save task. Check your API.");
        }
    }
    catch{
        console.error("Error saving task:", error);
    }
});