BlazorStore project using command line + VS Code. This will be a basic store app (products list + add product) so you understand create → build → run → debug → publish.

1️⃣ Install Required Software

You need:

.NET SDK (version 8 recommended)

Visual Studio Code

Check .NET installation

Open terminal:

dotnet --version

If version appears (example 8.0.x), installation is OK.

2️⃣ Create Blazor Project (Command Line)

Open terminal and run:

dotnet new blazor -n BlazorStore

Go to project folder:

cd BlazorStore

Open in VS Code:

code .

3️⃣ Project Folder Structure

Important files:

BlazorStore
│
├── Components
│   ├── Pages
│   │   ├── Home.razor
│   │   └── Counter.razor
│
├── wwwroot
│
├── Program.cs
└── BlazorStore.csproj

4️⃣ Build Project

Compile project:

dotnet build

If successful:

Build succeeded.

5️⃣ Run Project

Start application:

dotnet run

Terminal will show something like:

Now listening on: https://localhost:5001

Open browser:

https://localhost:5001

Blazor project is running.

Stop server:

Ctrl + C

6️⃣ Create Product Model

Create folder:

Models

Create file:

Models/Product.cs

Code:

namespace BlazorStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}

7️⃣ Create Store Page

Create file:

Components/Pages/Store.razor

Code:

@page "/store"

<h3>Blazor Store</h3>

<input placeholder="Product Name" @bind="name" />
<input placeholder="Price" @bind="price" />

<button @onclick="AddProduct">Add Product</button>

<table border="1">
<tr>
<th>ID</th>
<th>Name</th>
<th>Price</th>
</tr>

@foreach(var p in products)
{
<tr>
<td>@p.Id</td>
<td>@p.Name</td>
<td>@p.Price</td>
</tr>
}

</table>

@code {

string name;
double price;

List<Product> products = new();

void AddProduct()
{
products.Add(new Product
{
Id = products.Count + 1,
Name = name,
Price = price
});
}

}

8️⃣ Add Navigation Menu

Open file:

Components/Layout/NavMenu.razor

Add menu item:

<li class="nav-item px-3">
    <NavLink href="store">
        Store
    </NavLink>
</li>

9️⃣ Run Again
dotnet run

Open:

https://localhost:5001/store

You now have a simple Blazor Store page.

🔟 Debug in VS Code

Press:

Ctrl + Shift + D

Click:

create launch.json

Select:

.NET

Start debugging:

F5

1️⃣1️⃣ Publish Project

Build production version:

dotnet publish -c Release

Output location:

bin/Release/net8.0/publish

1️⃣2️⃣ Deploy Project

Run published app:

dotnet BlazorStore.dll

Or deploy to cloud like:

Microsoft Azure

Docker

Linux server

IIS

📌 Full Commands Summary

dotnet new blazor -n BlazorStore

cd BlazorStore

code .

dotnet build

dotnet run

dotnet publish -c Release

✅ You created a Blazor Store Project with:

Product model

Store page

Add product functionality

Build

Run

Debug

Publish


BlazorStore project with:

Product CRUD

Shopping cart

Database (SQL Server)

Entity Framework

Login system




BlazorStore is a sample e-commerce web application built using Blazor on the .NET framework.
It demonstrates how to build an online store using C#, Razor components, and .NET instead of JavaScript frameworks.

In simple words:

👉 BlazorStore = Online Store Application built with Blazor

It is usually used for learning Blazor concepts like components, data binding, routing, and CRUD operations.

Main Purpose of BlazorStore

The goal of a BlazorStore project is to learn how to build:

Product catalog

Add / edit / delete products

Shopping cart

Product details page

Order management

Database connection

It works like a mini Amazon / Flipkart style demo store.

Technologies Used in BlazorStore

A typical BlazorStore project uses:

Technology	Purpose
Blazor	Build UI components
.NET	Backend framework
Visual Studio Code	Code editor
Entity Framework Core	Database connection
SQL Server	Store product data
Razor	UI markup
Basic Features of BlazorStore

1️⃣ Product Catalog

Shows all store products.

Example:

Laptop

Phone

Headphones

Shoes

User can view product list.

2️⃣ Product Details

User can click a product to see:

Name

Price

Description

Image

3️⃣ Add Product (Admin)

Admin can add products.

Example form:

Product Name: Laptop
Price: 70000
Category: Electronics

4️⃣ Shopping Cart

User can:

Add product to cart

Remove product

See total price

Example:

Cart
-----
Laptop   ₹70000
Mouse    ₹500

Total = ₹70500

5️⃣ Order System

After adding items to cart:

User can place order.

BlazorStore Project Structure

Example structure:

BlazorStore

│
├── Models
│   └── Product.cs
│
├── Services
│   └── ProductService.cs
│
├── Components
│   ├── Pages
│   │   ├── Home.razor
│   │   ├── Store.razor
│   │   └── Cart.razor
│
├── wwwroot
│
├── Program.cs
└── BlazorStore.csproj
Example Product Model
public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }
}

This stores product data.

Example Store Page

Example UI:

Blazor Store

Product Name: [Laptop]
Price: [70000]

[Add Product]

Product List
----------------
1 Laptop 70000
2 Phone  30000

How BlazorStore Works (Flow)

1️⃣ User opens store page

2️⃣ Blazor loads product data

3️⃣ Products displayed in UI

4️⃣ User adds item to cart

5️⃣ Cart calculates total

6️⃣ User places order

Advantages of BlazorStore

✔ Uses C# for frontend
✔ No JavaScript framework needed
✔ Easy integration with .NET backend
✔ Component-based architecture
✔ Real-time UI updates

Simple Architecture

Browser

   │

Blazor UI Components

   │
Services

   │

Database


Real World Use

BlazorStore teaches how to build:

E-commerce websites

Admin dashboards

Product management systems

Inventory systems

Companies using Blazor can build full web apps using C# only.

