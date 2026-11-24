# Ordella Deliverable 3 — Manual Testing Checklist

## Startup and Identity
- [ ] NuGet restore completes without errors.
- [ ] Project builds in Release configuration.
- [ ] Database migrations apply successfully.
- [ ] Register a Seller account; verify it is assigned the Seller role.
- [ ] Register a Customer account; verify it is assigned the Customer role.
- [ ] Log in and log out with both account types.
- [ ] Verify invalid login and password validation messages.
- [ ] Verify repeated failed logins trigger configured lockout behavior.
- [ ] Verify Customer cannot open Seller dashboard routes.

## Seller and storefront pages
- [ ] Seller dashboard loads.
- [ ] Create/update shop profile and confirm unique slug behavior.
- [ ] Add a product, list products, and delete a product.
- [ ] Publish/unpublish the shop.
- [ ] Open the published public storefront; unpublished storefront returns 404.
- [ ] Submit an order request and verify confirmation page.
- [ ] Seller can view orders and update an order status.

## AJAX and Dapper repositories
- [ ] Open `/ajax/shops` and confirm JSON list of published shops.
- [ ] Open `/ajax/shops/{actual-shop-slug}/products` and confirm available products JSON.
- [ ] Confirm unknown/unpublished slug returns 404.
- [ ] Confirm the three repository interfaces are resolved through DI at runtime.
- [ ] As a Seller, test POST `/ajax/products/{id}/availability` with JSON `{ "isAvailable": false }` and an antiforgery token; confirm only the owning seller can update it.
- [ ] Confirm SQL parameters are used and no SQL is built by concatenating user input.

## Layout and IIS
- [ ] Verify the shared navigation/footer render on all Razor pages.
- [ ] Verify a view can define optional `PageHeader` and `Scripts` sections.
- [ ] Publish Release build to a folder and create the IIS site/application pool.
- [ ] Configure non-LocalDB SQL Server connection string and database permissions.
- [ ] Verify the published IIS site loads and Identity/database operations work.

Record actual results and screenshots after running tests on your own machine. Do not mark a test as passed until you have executed it.
