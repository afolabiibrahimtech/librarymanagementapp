# Library Management System

This is my Library Management System project for my ASP.NET Core MVC course. I will keep adding to this same project for A1, A2 and the final project.

## A1

For A1 I made the basic version of the app. I created a Book model, a Book controller and views so you can work with books.

What you can do right now:
- see all the books in a list
- add a new book
- edit a book
- see the details of a book
- delete a book

The model is BookModel and it has Id, Title, Author and Year. Title and Author are required so you get an error if you leave them empty.

The books are saved in a list in the controller for now because we are not using a database yet. So if you stop the app, the books you added will be gone.

I used a little bit of Bootstrap for the table, the input boxes and the buttons.

## How to run it

Open the project in Visual Studio and press F5. Then click Books in the menu.