# MyCliApp

MyCliApp is a command-line application that allows you to generate various code components such as classes, interfaces, and templates for your project. This README provides an overview of the application's usage, commands, and how to get started.

## Table of Contents


- [Usage](#usage)
- [Available Commands](#available-commands)
- [Contributing](#contributing)
- [License](#license)


## Usage

To use MyCliApp,
Install this tool by using  command
```console
dotnet tool install --global MyCliApp --version 1.0.7
```

check current version <a href="https://www.nuget.org/packages/MyCliApp"> here</a>

## Available Commands

MyCliApp supports the following commands:

Usage: `dt [command] [type] [classname]`

For command line help `dt --help`

Available commands:

- **generate**, **g**: Generate class, interface, or template.

  
  
Available types:



- **all**: Generate required classes or interfaces based on the folder structure.
  - *Example*: `dt genrate all ClassName`

- **template**, **t**: Add folder structure following the repository pattern.
  - *Example*: `dt genrate template rp` (Repository Pattern).

- **class**, **c**: Generate a class in the 'Models' folder.
  - *Example*: `dt genrate class User`

- **rclass**, **rc**: Generate a repository class in the 'Repositories' folder.
  - *Example*: `dt genrate rclass User  ` Genrates UserRepository.

- **sclass**, **sc**: Generate a service class in the 'Services' folder.
  - *Example*: `dt genrate sclass User ` Genrates UserService.

- **efclass**, **efc**: Generate an Entity Framework context class in the 'Repositories/Contexts' folder.
  - *Example*: `dt genrate efclass User ` Genrates UserContext.

- **interface**, **i**: Generate an interface in the calling directory.
  - *Example*: `dt genrate interface User` Genrates IUserInterface.

- **rinterface**, **ri**: Generate a repository interface in the 'Repositories/Interfaces' folder.
  - *Example*: `dt genrate rinterface  User ` Genrates IUserRepository.

- **sinterface**, **si**: Generate a service interface in the 'Services/Interfaces' folder.
  - *Example*: `dt genrate sinterface User ` Genrates IUserService.

- **controller**, **co**: Generate a controller in the 'Controllers' folder.
  - *Example*: `dt genrate controller User ` Genrates UserController.

## Contributing

If you'd like to contribute to this project, please fork the repository and create a pull request with your changes. We welcome contributions and improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
