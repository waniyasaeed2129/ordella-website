# Ordella — Deliverable 2 (ASP.NET Core MVC)

Ordella is a storefront builder and order-request prototype for independent sellers. Each seller owns a separate public storefront and shares its URL directly; this is intentionally **not** a central multi-vendor marketplace.

## Technology
- ASP.NET Core MVC / .NET 8
- C# and Razor views
- ASP.NET Core Identity with Seller and Customer roles
- Entity Framework Core 8 and SQL Server LocalDB
- Bootstrap 5

## Included functionality
- Responsive Ordella landing page
- Registration with Seller / Customer role selection and login/logout
- Seller-only dashboard and shop profile management
- Unique public shop slug and publish/unpublish control
- Product create/list/delete and availability
- Public seller-specific storefront
- Customer order-request form and confirmation reference
- Seller order list and status updates
- Identity role seed on application startup

## Run locally (Visual Studio 2022)
1. Install the .NET 8 SDK and open `Ordellla_deliverable2.csproj`.
2. Ensure SQL Server LocalDB is installed. In PowerShell run `sqllocaldb start MSSQLLocalDB`.
3. Open **Tools → NuGet Package Manager → Package Manager Console**. Set Default project to this project.
4. Run:
   ```powershell
   Add-Migration InitialCreate
   Update-Database
   ```
   If `Add-Migration` is unavailable, restore/build the project and ensure `Microsoft.EntityFrameworkCore.Tools` 8.0.34 is installed.
5. Run the project (F5). Register a Seller account, create a shop, add products, publish it, then open the public storefront URL from the dashboard. Register a Customer account separately if you want to test the customer login flow.

## Notes / academic prototype scope
- The order form currently creates a basic order request from all currently available products (quantity one each). It is a simplified demonstration, not a full cart/checkout implementation.
- Payment gateway, delivery integrations, AI menu extraction, preorder slot/capacity validation, image upload storage, expense tracking, and advanced analytics are not implemented in this version.
- Customer storefront ordering is guest-friendly and does not require customer login.
- LocalDB is for development. For IIS/public hosting, configure an appropriate SQL Server instance and update the connection string.
- Do not commit real credentials or production secrets.

## Project structure
- `Controllers/` MVC controllers
- `Models/` shop, product, order and view models
- `Data/` EF Core context and role seeding
- `Views/` Razor UI
- `wwwroot/` Bootstrap, JavaScript and site styling


## Deliverable 3 additions
- Dapper data access with three repository interfaces and implementations.
- Dependency Injection registration for repositories.
- AJAX JSON endpoints for shops/products and seller-only availability updates.
- Strengthened Identity password and lockout configuration.
- Optional Razor layout sections for page-specific headers and scripts.
- See `DELIVERABLE_3_GUIDE.md`, `DEPLOYMENT_IIS.md`, and `TESTING_CHECKLIST.md`.
