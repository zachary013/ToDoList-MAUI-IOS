# 📝 To-Do List iOS App

A sleek, modern to-do list application built with .NET MAUI for iOS devices.


<div align="center">
  <img width="381" alt="Screenshot 2025-04-17 at 17 20 52" src="https://github.com/user-attachments/assets/97be4f0b-2190-4e0f-a8b6-6030093d31a9" />
</div>


## ✨ Features

- **Task Management**: Create, complete, and delete tasks with ease
- **Visual Feedback**: Completed tasks are visually marked with strikethrough text
- **Timestamp Tracking**: Each task displays its creation date and time
- **Batch Operations**: Delete all tasks at once with a single tap
- **Confirmation Dialogs**: Prevent accidental deletions with confirmation prompts
- **Modern UI**: Clean, intuitive interface with a professional design

## 🚀 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
- [Xcode 16.0+](https://developer.apple.com/xcode/) (for iOS development)

### Installation

1. Clone the repository
   ```bash
   git clone https://github.com/yourusername/ToDoList.git
   cd ToDoList
   ```

2. Restore dependencies
   ```bash
   dotnet restore
   ```

3. Build the project
   ```bash
   dotnet build
   ```

4. Run the application
   ```bash
   dotnet build -t:Run -f net9.0-ios
   ```

## 🏗️ Project Structure

```
ToDoList/
├── Models/
│   └── Task.cs              # Task data model
├── Services/
│   └── TaskService.cs       # Business logic for task operations
├── ViewModels/
│   └── MainViewModel.cs     # ViewModel for the main page
├── Converters/
│   └── BoolToStrikethroughConverter.cs  # Converter for task completion visual
├── Resources/
│   ├── Fonts/               # Application fonts
│   ├── Images/              # Application images
│   └── Styles/              # XAML styles and templates
├── MainPage.xaml            # Main UI page
└── MauiProgram.cs           # Application entry point
```

## 🛠️ Built With

- [.NET MAUI](https://dotnet.microsoft.com/apps/maui) - Cross-platform framework
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Programming language
- [XAML](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/xaml/) - UI markup language

## 📱 Supported Platforms

- iOS 15.0+
- Optimized for iPhone 16 Plus

## 🧩 Architecture

This application follows the MVVM (Model-View-ViewModel) architectural pattern:

- **Models**: Represent the data and business logic
- **Views**: Define the UI structure and appearance
- **ViewModels**: Connect the data models to the views

## 🔄 Future Enhancements

- Task categories and filtering
- Due dates and reminders
- Cloud synchronization
- Dark mode support
- Task priority levels
- Search functionality

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

Your Name - [GitHub Profile](https://github.com/yourusername)

## 🙏 Acknowledgments

- [.NET MAUI Documentation](https://docs.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn](https://learn.microsoft.com/)
- [Icons and design inspiration](https://icons8.com/)
