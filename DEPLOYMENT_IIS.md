# Local IIS Deployment (Windows)

1. Install the **.NET 8 Hosting Bundle** on the Windows machine hosting IIS, then restart IIS.
2. Enable IIS and the **Web Server** role. Confirm the `IIS` service is running.
3. In Visual Studio, set the project configuration to **Release** and choose **Publish** → **Folder**.
4. Publish to a folder such as `C:\inetpub\Ordella`. Do not publish into the source-code folder.
5. In IIS Manager, create an Application Pool named `OrdellaPool`; set **.NET CLR version** to **No Managed Code** and enable 64-bit if appropriate.
6. Create a website named `Ordella`, point its physical path to the publish folder, and assign `OrdellaPool`.
7. Grant the application-pool identity read/execute access to the publish folder. Grant write access only to folders that genuinely need uploads/logs.
8. Configure the SQL Server connection string for the IIS environment. **LocalDB is not suitable for a normal IIS deployment** because it is tied to a user profile. Use SQL Server Express or another SQL Server instance accessible to the app pool, and grant the database login/user the required permissions.
9. Apply EF Core migrations to the target database before first use. Never expose development credentials in source control; use environment variables or secure configuration.
10. Browse the site locally using the IIS binding. Check login, role authorization, storefronts, product endpoints, and order flow.

## Publish command alternative

From the project directory:

```powershell
dotnet restore
dotnet publish .\Ordellla_deliverable2.csproj -c Release -o C:\inetpub\Ordella
```

Configure the connection string on the server before launching. Enable HTTPS with an IIS certificate binding for non-local use.
