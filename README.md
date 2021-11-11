# assignment-1-GabrielStancu
assignment-1-GabrielStancu created by GitHub Classroom

The application is called FightClubPlanner. Although "nobody talks about the Fight Club", we will give it a brief description here. For more information check the documentation.

The app provides a place for managers to create and organize their MMA fights tournaments (create them, send invites to fighters and generate fights for these tournaments), while the fighters can accept invites and test themselves, as we have to ensure Covid - safety measures. In order too fight, a fighter must have at least 3 weeks of negative tests.

The application uses a layered architecture, divided in the Presentation Layer (the UI windows), Business Logic Layer (where the logic of the application takes place, in form of View - Models or services) and the Data Layer, where we have Models of the database entities and database accessors (DAOs) as well.

Over the layered architecture, we mapped a MVVM pattern. This felt naturally, as the application is developed under the WPF framework. For dependency injection management over the app, we used the Autofac DI container.

Database provider: SQL Server

Application Framework: .NET Core WPF Desktop application

Language: C#

For a visual demo of the application, please check the following link:

https://www.youtube.com/watch?v=LZRbhd6ILug
