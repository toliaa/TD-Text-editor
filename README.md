# TD-Text-editor

TD-Text-editor is a Windows Forms application built using C#. This application allows users to create text files and edit text,fonts, align text,insert images and export text file in RTF format. Additionally, this program is lightweight text editor.

## Features

- **Change fonts**: Displays a list of fonts.
- **Insert images**: Provides functional to insert images in files.
- **Align text**: Allows users to align text (left/center/right).
- **Export File**: Exports file in RTF format.
- **Threads and Modules**: Displays detailed information about threads and modules of a selected process.


## Getting Started

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) with .NET Desktop Development workload installed.
- Windows operating system.

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/toliaa/TD-Text-editor.git
    ```
2. Open the solution file (`TD Text edit.sln`) in Visual Studio.
3. Build the solution to restore dependencies and compile the project.

### Usage

1. Run the application from Visual Studio by pressing `F5` or `Ctrl+F5`.
2. Input text,insert images,align text
4. Use the Export button to export in RTF format.

## Code Structure

- **TextEditorForm.cs**: Contains the main logic for loading, displaying, and managing editor.
- **TextEditorForm.Designer.cs**: Contains the designer-generated code for UI layout and component initialization.
- **Program.cs**: Entry point of the application, starting the `TextEditorForm` form.


## License

This project is licensed under the  GNU AFFERO GENERAL PUBLIC LICENSE - see the [LICENSE](LICENSE) file for details.
