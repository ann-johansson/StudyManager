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