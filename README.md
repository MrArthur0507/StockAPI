# AccountsAPI

## Table of Contents

- [Setup](#Setup)
- [Usage](#Usage) -[Routes](#Routes)

## Setup

<ol>
<li>Open StockAPI.Database solution</li>
<li>Find folder Data and then class DataConfiguration</li>
<li>Change the connection string with your connection string for the database</li>
<li>If you have database with that name change it</li>
<li>Open the Accounts.API solution and run it. This will make a database for you.</li>
</ol>

## Usage

<h3>If you want to use database for saving or updating do this:</h3>
<ol>
<li>Make a project reference to these solutions: AccountsAPI.Data and StockAPI.Database</li>
<li>Change the connection string in solutions StockAPI.Database fodler Data and then in class DataConfiguration</li>
<li>Add these lines of code:
builder.Services.AddSingleton<ITypeDictionary, TypeDictionary>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IDataInserter, DataInserter>();
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
builder.Services.AddSingleton<ITableService, TableService>();
builder.Services.AddSingleton<IDataSelector, DataSelector>();
builder.Services.AddSingleton<IDataConfiguration, DataConfiguration>();
builder.Services.AddSingleton<IDataManager, DataManager>();
builder.Services.AddSingleton<ISeed, Seed>();
</li>
<li>Its set up and u can use the DataManager methods for creating,deleting or updating entities</li>

</ol>

## Routes

<h1>Change the value of params or check examples</h1>
<ol>
<li>https://localhost:7168/api/Account/getAll</li>
<p>Get all users</p>
<li>https://localhost:7168/api/Account/getById?Id=USERID</li>
<p>Get user by id</p>
<li>https://localhost:7168/api/Account/addMoney?id=USERID&baseCurrency=CURRENCY&amount=AMOUNT</li>
<p>Add money to user account</p>
<li>https://localhost:7168/api/Transaction/createTransaction?AccountId=USERID&StockName=STOCKNAME&Date=DATE&Price=PRICE&Quantity=QUANTITY</li>
<p>User buys stock</p>
<li>https://localhost:7168/api/Transaction/getTransactionForUser?userId=USERID</li>
<p>Get all transactions for specific user</p>
<li>https://localhost:7168/api/Transaction/getTransactionByStock?stockId=STOCKNAME</li>
<p>Gives ifnormation about the stock</p>

</ol>
