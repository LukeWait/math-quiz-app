# Math Quiz LAN App
## Description
The Math Quiz LAN App is a C# solution comprising two applications designed for real-time server-client communication in a math quiz environment. It utilizes binary tree manipulation techniques for managing quiz questions, providing a seamless experience for instructors and students. The application features a custom message box for alerts and information, along with various question traversal display options. Additionally, unit tests using NUnit ensure the core functionalities are validated.

### Features
- Real-time server-client communication for a math quiz application.
- Supports binary tree manipulation for managing quiz questions.
- Custom message box for displaying alerts and information.
- Various question traversal display options: Pre-Order, In-Order, and Post-Order.
- Unit testing framework using NUnit for validation of functionality.

<p align="center">
  <img src="https://github.com/LukeWait/math-quiz-app/raw/main/screenshots/math-quiz-app-screenshot.png" alt="App Screenshot" width="600">
</p>

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Development](#development)
- [License](#license)
- [Acknowledgments](#acknowledgments)
- [Source Code](#source-code)
- [Dependencies](#dependencies)

## Installation
This app is designed for Windows only. It leverages both the .NET 4.7.2 and .NET 5 frameworks for different projects within the solution:
- **Instructor & Student:** Development tools including the .NET 4.7.2 SDK and Visual Studio 2019 (v16.8+) or later versions are necessary.
- **NUnitTest:** Development tools including the .NET 5 SDK and Visual Studio 2019 (v16.8+) or later versions are necessary.

### From Source
To install and run the application from source:
1. Clone the repository:
    ```sh
    git clone https://github.com/LukeWait/math-quiz-app.git
    cd math-quiz-app
    ```
2. Open the solution file `MathQuizApp.sln` in Visual Studio.
3. Restore NuGet packages if prompted.
4. Build or run the solution using Visual Studio.

## Usage
For the applications to run smoothly, they must be executed concurrently to prevent socket-related issues. If the Student (client) application is started before the Instructor (server) application, it may lead to errors; conversely, launching the Instructor first can cause the application to freeze as it waits indefinitely for a connection. 

To run the applications concurrently, follow these steps:
1. Launch the solution from source by opening the file `MathQuizApp.sln` in Visual Studio.
2. Right-click on the Solution in the right-hand pane and choose `Properties`.
3. Under `Startup Project`, select `Multiple startup projects` and set both Instructor and Student to `Start`, then click Apply/OK.
4. The dropdown box next to the `Start` button will now display `<Multiple Startup Projects>`.
5. When Visual Studio starts, both applications will launch concurrently.

### Application Functions
The Instructor (server) and Student (client) communicate via sockets and threads. Upon establishing a successful connection, the following functions will be available:

#### Instructor Functions
- **Question Creation**: Create questions by entering the first and second numbers and selecting an operator from a combo box. The answer is automatically calculated upon clicking the "Send" button.
- **Question Management**: Display all questions sent by the instructor under "Array of Questions Asked" and sort them using three different methods (ascending and descending based on the selected method).
- **Status Output**: A text box on the left displays the status of the question (e.g., waiting for a student response, result of student response) and allows the instructor to perform binary or hash searches on the array of questions.
- **Display and Save Options**: The text box can present questions in three traversal orders:
  - **Pre-Order**: Displays questions starting from the root node, followed by the left subtree, and then the right subtree.
  - **In-Order**: Questions are displayed by first traversing the left subtree, then the root node, and finally the right subtree.
  - **Post-Order**: Questions are displayed by traversing the left subtree, then the right subtree, and finally the root node.

  Output can be saved to an external `.txt` file in a user-defined location by clicking the corresponding "Save" button.
- **Linked List Display**: A second text box on the right displays the contents of a linked list that organizes all incorrectly answered questions when the "Display Linked List" button is clicked.
- **Exit Notification**: The instructor can exit at any time, and the student will be notified via a message box.

#### Student Functions
- **Question Reception**: The student waits to receive questions. When a question is received, the user is alerted via a message box.
- **Answer Submission**: The question is displayed with the answer obscured. The student can input their answer and submit it.
- **Submission Outcome**: A message box displays the outcome of the submission, including the correct answer and overall score (number of questions answered).
- **Exit Notification**: The student can exit at any time, and the instructor will be notified via a message box.

### Test Units
To run the user-created test units in the `NUnitTest` project, click `Test` from the Visual Studio menu bar and choose `Run All Tests`. All methods in `UnitTest1.cs` will be executed, and the results will be displayed.

<p align="center">
  <img src="https://github.com/LukeWait/math-quiz-app/raw/main/screenshots/nunit-test-screenshot.png" alt="NUnit Test Screenshot" width="500">
</p>

## Development
This project was developed using Visual Studio and utilizes Windows Forms. For the best experience with Windows Forms projects involving extensive use of the Form Designer, it is recommended to use Visual Studio. If you explore alternatives and are willing to handle some design tasks manually, JetBrains Rider on Windows could be a viable option, but it might not offer the same level of designer support as Visual Studio.

### Project Structure
```sh
math-quiz-app/
├── Instructor/
│   ├── Properties/                # Project properties
│   ├── Resources/                 # GUI design elements
│   ├── App.config                 # Application configuration file
│   ├── BinaryTree.cs              # BinaryTree class definition
│   ├── Form1.Designer.cs          # Main form designer code
│   ├── Form1.cs                   # Main form code
│   ├── Form1.resx                 # Main form resources
│   ├── Instructor.csproj          # Project file
│   ├── Instructor.xml             # XML documentation for classes and methods
│   ├── MathQues.cs                # Math question handling class
│   ├── MyMessageBox.cs            # Custom message box class
│   ├── Node.cs                    # Node class definition
│   └── Program.cs                 # Main program entry point
├── Student/
│   ├── Properties/                # Project properties
│   ├── Resources/                 # GUI design elements
│   ├── App.config                 # Application configuration file
│   ├── Form1.Designer.cs          # Main form designer code
│   ├── Form1.cs                   # Main form code
│   ├── Form1.resx                 # Main form resources
│   ├── Program.cs                 # Main program entry point
│   ├── Student.csproj             # Project file
│   ├── Student.xml                # XML documentation for classes and methods
├── NUnitTest/
│   ├── NUnitTest.csproj           # Project file
│   └── UnitTest1.cs               # Unit test class
└── MathQuizApp.sln                # Visual Studio Solution file
```

### Project Classes
- **BinaryTree**
  - A generic class using `IComparable<T>` for node management.
  - Provides methods to add nodes, check existence, and perform various traversals to retrieve data.
  - Includes public getter methods for private variables and methods to compare nodes.
  
- **Node**
  - Represents a node in the binary tree, using a generic type `T` and implementing `IComparable<T>`.
  - Contains public data and references to left and right child nodes.
  - Features methods for displaying node data and searching for specific values.
  
- **MathQues**
  - Represents a math question instance with private variables accessible through public methods.
  - Implements `IComparable<MathQues>` for comparing instances based on answers.
  - Includes overloaded `ToString()` and a `CompareTo()` method for comparison purposes.

- **MyMessageBox**
  - Custom message box class that mimics `MessageBox` functionality with added flexibility for resizing based on content.
  - Allows specification of a parent form to position the message box above the corresponding application window.

## Test Units
The `NUnitTest` project contains several unit tests designed to validate the core functionalities of the application. The tests included are:
- **BinarySearchFoundTest**: Verifies that the binary search correctly identifies an existing math question in the list.
- **BinarySearchNotFoundTest**: Ensures that the binary search returns -1 when a math question is not present in the list.
- **BubbleSortAscTest**: Tests the ascending order sorting functionality using the bubble sort algorithm.
- **BubbleSortDescTest**: Tests the descending order sorting functionality using the bubble sort algorithm.


### Creating New Releases
Currently, the applications require an active socket connection to function properly. If the Student (client) application is launched first, it may result in errors, whereas starting the Instructor (server) application first can lead to the program freezing. Therefore, it is advised not to release the applications in executable form until further enhancements are made to facilitate controlled connections through user input.
- **Build the Application**: Use Visual Studio to compile and package the application into an executable (.exe) file. Ensure that all dependencies and necessary files are included in the build process.
  - Open the solution file (`MathQuizApp.sln`) in Visual Studio.
  - Restore any NuGet packages if prompted.
  - Build the solution by selecting `Build` > `Build Solution` from the menu.
  - Locate the compiled `.exe` file in the `bin/Release` or `bin/Debug` directory, depending on your build configuration.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Acknowledgments
This project was developed as part of an assignment at TAFE Queensland for subject ICTPRG443.

Project requirements and initial GUI design/codebase provided by Hans Telford.

## Source Code
The source code for this project can be found in the GitHub repository: [https://github.com/LukeWait/math-quiz-app](https://www.github.com/LukeWait/math-quiz-app).

## Dependencies
- Windows 10 or later
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) (Instructor & Student Projects)
- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) (NUnitTest Project)
- [Visual Studio 2019 (v16.8+)](https://visualstudio.microsoft.com/vs/) or [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [NUnit](https://nunit.org/)
