# Simple Web Browser
- this project was developed for the **Object Oriented Programming** class in university
- the purpose of this project is to put into practice the OOP concepts learned in class

## Functionality
- the app works as a HTML file opener
- Windows Forms application where you upload a HTML file and its content is displayed on the screen
- the app can display plain, bold, italic, heading text and tables 


![Demo](https://user-images.githubusercontent.com/109103774/223117906-e0025a07-00ef-406f-9f1a-0831dccdaf91.png)

## Technologies
- IDE: Visual Studio 2022
- Framework: .NET Framework 4.7.2
- programming language: C#

## Implementation
- the uploaded file is traversed from HTML tag to HTML tag and the text between the opening and the closing one is appended to the RichTextBox
- when the ```<p>```, ```<b>```, ```<i>```, ```<h1>```, ```<table>```, ```<tr>``` and ```<td>``` tags are encountered, the text will be displayed accordingly
- the **ParseHtml class** includes methods which are used to parse the HTML file
- the **ManageHtml class** inherits **ParseHtml** and is used for the formatting and displaying of the text
- the **TagFormatter class** is an abstract class that contains the abstract method *Format()*
- the **Bold, Italic, Heading, Text classes** inherit the **TagFormatter** class and override the *Format()* method in order to display the formatted text; thus is the concept of polymorphism illustrated
