using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class TaskService
    {
        private ObservableCollection<Models.Task> _tasks;

        public TaskService()
        {
            _tasks = new ObservableCollection<Models.Task>();
            // Add some sample tasks
            _tasks.Add(new Models.Task("Complete iOS app") { IsCompleted = false });
            _tasks.Add(new Models.Task("Learn MAUI") { IsCompleted = true });
            _tasks.Add(new Models.Task("Submit assignment") { IsCompleted = false });
        }

        public ObservableCollection<Models.Task> GetTasks()
        {
            return _tasks;
        }

        public Models.Task? GetTask(string id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(string title)
        {
            _tasks.Add(new Models.Task(title));
        }

        public void UpdateTask(Models.Task task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.IsCompleted = task.IsCompleted;
            }
        }

        public void DeleteTask(string id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        public void DeleteAllTasks()
        {
            _tasks.Clear();
        }

        public void ToggleTaskCompletion(string id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
            }
        }
    }
}
