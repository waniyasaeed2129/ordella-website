# Ordella — Deliverable 3 Implementation Guide

This package extends the MVC/Identity Deliverable 2 project with the milestones visible in the classroom photo.

## Milestones covered

1. **AJAX** — `Controllers/AjaxController.cs` exposes JSON GET endpoints for published shops and available products, plus a seller-authorized POST endpoint to change product availability. `wwwroot/js/ordella-ajax.js` provides a small Fetch/AJAX helper.
2. **Dapper** — Dapper 2 is added to the project. The Dapper repositories use parameterized SQL and the configured SQL Server connection string.
3. **Repository pattern (3 repositories)** — `IShopRepository`, `IProductRepository`, and `IOrderRepository`, with Dapper implementations.
4. **Interfaces and Dependency Injection** — interfaces are registered in `Program.cs` using scoped lifetimes; the connection factory is singleton.
5. **Identity customization** — the existing Seller/Customer role-based Identity login/register flow remains. Password length/digit/uppercase rules and lockout settings are strengthened in `Program.cs`; custom login/register views remain in `Views/Account`.
6. **Layout sections** — `_Layout.cshtml` now defines optional `PageHeader` and `Scripts` sections, allowing individual Razor views to inject page-specific content/scripts.
7. **Local deployment (IIS)** — see `DEPLOYMENT_IIS.md`.
8. **All pages testing** — see `TESTING_CHECKLIST.md` for a page-by-page manual verification checklist.

## Setup

- Open `Ordellla_deliverable2.csproj` in Visual Studio 2022 with the .NET 8 SDK.
- Restore NuGet packages (Dapper, EF Core, Identity).
- Start SQL Server LocalDB and apply the existing EF Core schema:
  ```powershell
  sqllocaldb start MSSQLLocalDB
  Add-Migration InitialCreate
  Update-Database
  ```
  If you already created the D2 migration/database, do not create a duplicate migration; simply run `Update-Database`.
- Run the app and test the checklist.

## AJAX endpoints

- `GET /ajax/shops` — list published shops as JSON.
- `GET /ajax/shops/{slug}/products` — list available products for a published shop.
- `POST /ajax/products/{id}/availability` — authenticated Seller-only update. JSON body: `{"isAvailable":true}` or false. The SQL update verifies the product belongs to the signed-in seller.

The POST endpoint expects the request verification token header if antiforgery is enabled for the controller/action. For a production deployment, include the token in the page and send it as `RequestVerificationToken`; do not disable antiforgery globally.

## Important academic scope

The Dapper repository layer is added alongside the existing EF Core application services. Existing MVC pages continue to use the D2 EF Core workflow; the new AJAX endpoints demonstrate repository-based Dapper data access. This keeps the earlier deliverable intact while making each D3 topic visible and testable. This package has not been executed against your local SQL Server/IIS environment; restore, build, migrate, and run the checklist locally before submission.
