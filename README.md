# Loan API

This is README.md that'll guide you though my Loan API made as Final Project Back-end Development intensive course! If you'll get any questions during usage of the API, you can always return to README.md, so sit tight and read carefully :hand_over_mouth: :relaxed:


## Installation

Before launching the API, you should install following packages: 
1. Install the latest version of [.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0); 
2. Install the latest aviable version of [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads?rtc=1); 
3. Install the latest aviable version of [QL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16);
4. Be sure to install all the packages from NutGet I'll mention below :point_down:

## Technologies used

* .NET 5; 
* Microsoft.EntityFrameworkCore; 
* Microsoft.EntityFrameworkCore.SqlServer;
* Microsoft.EntityFrameworkCore.Tools;
* FluentValidation;
*FluentValidation.AspNetCore.

## Description

The API can: 
* Add new users; 
* Get information about users via UserId; 
* Each user is able to add new **loan**; 
* Get list of **all** loans;
* Get info about loan via **Id**;
* If loan is in processing status, user can delete and update it by **id**;

Any type of change is synchronised with Database;

## Working with database
You can add new tables and new databases via API to your local server.
API is already connected to local server via ConnectionString:

```
"Server=localhost\\MSSQLSERVER01;Database=FinalDatabase;
Trusted_Connection=True;MultipleActiveResultSets=True"
```
To update database with API, you should do next steps: 
1. With **package manage console** make sure to add migrations; 
2. After migration is done, make sure to sync database using **package manage console**: Update-DataBase;

The API is using **code first approach** when dealing with databases. 

## Domain

This class library is made to create models of:
* User; 
* Loan; 
* Enums(To create loans); 

In those models there is declared One-To-Many relations between User and Loan (One user can have many loans); 

## Data

This class library contains UserContext that helps us building tables in database. 

Also, it has the folder "migrations" that provides us the info about all the migrations done within API and database. 


## Model "User" 
The user model has following parameters: 

```
 public int UserId { get; set; }
 public string FirstName { get; set; }
 public string UserName { get; set; }
 public string LastName { get; set; }
 public int Age { get; set; }
 public int Monthlyincome { get; set; }
 public string Email { get; set; }
 public ICollection<Loan> Loans { get; set; }
```

## Model "Loan" 
The loan model has following parameters: 

```
 public int Id { get; set; }
 public LoanType TypeOfLoan { get; set; }
 public LoanCurrency CurrencyOfLoan { get; set; }
 public int AmountOfLoan { get; set; }
 public int PeriodOfLoan { get; set; }
 public LoanStatus StatusOfLoan { get; set; }
 public User User { get; set; }
 public int UserId { get; set; } 

```
## Enums
Following enums are used in Loan class to represent constants:
```
  public enum LoanType
    {
        FastLoan,
        AutoLoan,
        Installment
    }

    public enum LoanCurrency
    {
        GEL,
        USD,
        EUR,
        JPY,
        GBP
    }

    public enum LoanStatus
    {
        Processing,
        Confirmed,
        Declined
    }

```
*Reminder*: [Definition Of Enums](https://www.w3schools.com/cs/cs_enums.php);

## Http Methods

The API is designed to return different status codes according to context and
action. 

This way, if a request results is an error, the caller is able to get
insight into what went wrong.

The following table gives an overview of how the API functions generally behave.

| Request type | Description |
| ------------ | ----------- |
| `GET`   | Access one or more resources and return the result as JSON. |
| `POST`  | Return `201 Created` if the resource is successfully created and return the newly created resource as JSON. |
| `GET` / `PUT` | Return `200 OK` if the resource is accessed or modified successfully. The (modified) result is returned as JSON. |
| `DELETE` | Returns `204 No Content` if the resource was deleted successfully. |


## Validation

For validation, I've created some validation using FluentValidation. 

You can review validations for User class da Loan class in folder ```"Validator"```. 

API should contain also exception handling but I am too dumb for this :wink:
