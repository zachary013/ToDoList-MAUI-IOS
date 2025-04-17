using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TaskService? _taskService;
        private ObservableCollection<Models.Task> _tasks = new ObservableCollection<Models.Task>();
        private string _newTaskTitle = string.Empty;

        public ObservableCollection<Models.Task> Tasks
        {
            get => _tasks;
            set
            {
                if (_tasks != null)
                {
                    _tasks.CollectionChanged -= Tasks_CollectionChanged;
                }
                
                _tasks = value;
                
                if (_tasks != null)
                {
                    _tasks.CollectionChanged += Tasks_CollectionChanged;
                }
                
                OnPropertyChanged();
            }
        }

        private void Tasks_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // When new items are added, subscribe to their property changed events
            if (e.NewItems != null)
            {
                foreach (Models.Task task in e.NewItems)
                {
                    if (task is INotifyPropertyChanged notifyPropertyChanged)
                    {
                        notifyPropertyChanged.PropertyChanged += Task_PropertyChanged;
                    }
                }
            }

            // When items are removed, unsubscribe from their property changed events
            if (e.OldItems != null)
            {
                foreach (Models.Task task in e.OldItems)
                {
                    if (task is INotifyPropertyChanged notifyPropertyChanged)
                    {
                        notifyPropertyChanged.PropertyChanged -= Task_PropertyChanged;
                    }
                }
            }
        }

        private void Task_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is Models.Task task && e.PropertyName == nameof(Models.Task.IsCompleted))
            {
                // When a task's IsCompleted property changes, update the task in the service
                _taskService?.UpdateTask(task);
            }
        }

        public string NewTaskTitle
        {
            get => _newTaskTitle;
            set
            {
                _newTaskTitle = value;
                OnPropertyChanged();
                ((Command)AddTaskCommand).ChangeCanExecute();
            }
        }

        public ICommand AddTaskCommand { get; private set; }
        public ICommand DeleteTaskCommand { get; private set; }
        public ICommand DeleteAllTasksCommand { get; private set; }
        public ICommand ToggleTaskCompletionCommand { get; private set; }

        // Default constructor for XAML
        public MainViewModel()
        {
            // Create a temporary service for design-time data
            _taskService = new TaskService();
            InitializeCommands();
            Tasks = _taskService.GetTasks();
        }

        public MainViewModel(TaskService taskService)
        {
            _taskService = taskService;
            InitializeCommands();
            Tasks = _taskService.GetTasks();
        }

        private void InitializeCommands()
        {
            AddTaskCommand = new Command(
                execute: () =>
                {
                    _taskService?.AddTask(NewTaskTitle);
                    NewTaskTitle = string.Empty;
                },
                canExecute: () => !string.IsNullOrWhiteSpace(NewTaskTitle)
            );

            DeleteTaskCommand = new Command<string>(
                execute: async (id) =>
                {
                    bool confirm = await Application.Current.MainPage.DisplayAlert(
                        "Confirm Delete", 
                        "Are you sure you want to delete this task?", 
                        "Yes", "No");
                    
                    if (confirm)
                    {
                        _taskService?.DeleteTask(id);
                    }
                }
            );

            DeleteAllTasksCommand = new Command(
                execute: async () =>
                {
                    if (Tasks.Count == 0)
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "No Tasks", 
                            "There are no tasks to delete.", 
                            "OK");
                        return;
                    }
                    
                    bool confirm = await Application.Current.MainPage.DisplayAlert(
                        "Confirm Delete All", 
                        "Are you sure you want to delete all tasks? This cannot be undone.", 
                        "Delete All", "Cancel");
                    
                    if (confirm)
                    {
                        _taskService?.DeleteAllTasks();
                    }
                }
            );

            ToggleTaskCompletionCommand = new Command<string>(
                execute: (id) =>
                {
                    _taskService?.ToggleTaskCompletion(id);
                }
            );
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
