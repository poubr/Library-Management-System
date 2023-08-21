# Backend Project

NB: This project is still in progress.

Features that still need work:

- authorization policy fix (HELP)
- xunit testing (see test, also need HELP)
- improve and update graphs for readme
- improve genre and author Dtos
- improve object creation
- fine tune algorithms (add seach, sort, optimize funcitonality, avoiding duplicate values...)
- document error codes in swagger
- finish readme

![.NET Core](https://img.shields.io/badge/.NET%20Core-v.7-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-v.7-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-v.14-drakblue)

This repository contains the backend implementation of a Library Management System, built using ASP.NET Core 7 with the CLEAN architecture. The system provides functionalities for managing books, authors, genres, users, loans, and more.



- Backend: ASP .NET Core, Entity Framework Core, PostgreSQL


## Features

- basic CRUD operations for all tables, plus extra admin-only and user-only features
- two factor authentication
- browsing books
- adming role
- seeding database w/ admin
- BCrypt password encryption


## Deployment

Database is deployed at ElephantSQL.

Backend is deployed at polibrarymanagementsystem.azurewebsites.net.