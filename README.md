# AccountsAPI

## Table of Contents

- [Setup](#Setup)
- [Usage](#Usage)
- [Routes](#Routes)
- [Examples](#Examples)

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

<h4 style="color:red;">Change the value of params or check <a href="#examples">examples</a></h4>
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

## Examples

<h4 style="color:red;">Change the values with your values!!! </h4>
<ol>
<li>https://localhost:7168/api/Account/getAll </li>
<li>https://localhost:7168/api/Account/getById?Id=0cd5758f-1f1b-48a4-b08f-0a6ab7c89a36</li>
<li>https://localhost:7168/api/Account/addMoney?id=3dfd3a3c-abba-4e67-97a1-d2554d81e5a8&baseCurrency=BGN&amount=25</li>
<li>https://localhost:7168/api/Transaction/createTransaction?AccountId=98c1ce17-8c8d-4997-97ab-5c6f59be08bd&StockName=OpenAI&Date=2023-11-20&Price=25&Quantity=5</li>
<li>https://localhost:7168/api/Transaction/getTransactionForUser?userId=b18ce351-e9fd-467d-8511-b088acc7f81b</li>
<li>https://localhost:7168/api/Transaction/getTransactionByStock?stockId=OpenAI</li>
</ol>
