# Task Manager C# 
Console-based task management application written in C#.

## Features

* Create, edit, and delete tasks
* Set task name, description, and deadline
* Mark tasks as complete/incomplete
* Navigate tasks using arrow keys
* Persistent storage (tasks saved to file)
* Custom date/time picker interface
* Visual focus indicators

## Requirements

.NET 6.0 or higher
Windows/Linux/macOS with console support

## Build and Run
```bash
# Clone repository
git clone https://github.com/Yarikbot34/Task-Manager-Csharp

# Navigate to project directory
cd Task-Manager-Csharp

# Build and run
dotnet run
```
## Usage
### Controls

* Arrow Up/Down - Navigate between tasks
* N - Create new task
* R - Edit selected task
* D - Delete selected task
* Enter - Toggle task completion status
* Q - Exit application (with save prompt)

### Task Editor

* Arrow Up/Down - Navigate options
* Enter - Select option
* Arrow Left/Right - Navigate date/time fields (in date picker)

### Date Picker
Use arrow keys to adjust year, month, day, hour, and minute. Press Enter to confirm.

## Data Storage
Tasks in JSON-format are saved to:

Windows: 
   ```%USERPROFILE%\AppData\Local\data.targ```
   
Linux/macOS:
    ```~/.local/share/data.targ```

## Screens

### **Main menu**
<img width="900" height="400" alt="Main menu" src="https://github.com/user-attachments/assets/2bf25c88-6f27-4fce-94c8-1443706e6811" />

### **Date shoise menu**
<img width="900" height="400" alt="Date shoise menu" src="https://github.com/user-attachments/assets/047e1df3-beb8-42f0-8502-4d4baa5b004d" />


