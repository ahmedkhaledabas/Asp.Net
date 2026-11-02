# LabStore API

ASP.NET Core Web API for a laptop catalogue, brands, account registration/sign-in, and contact submissions.

## Requirements

- .NET 10 SDK
- SQL Server
- A frontend origin explicitly allowed by the API's CORS configuration

## Configuration

The API expects a connection string named `Default`. Do not commit credentials.

For local development, configure it with .NET user-secrets:

```bash
cd APIs/LabStore
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Default" "YOUR_LOCAL_SQL_SERVER_CONNECTION_STRING"
```

Configure allowed frontend origins with an environment variable or user-secrets. For example:

```bash
dotnet user-secrets set "Cors:AllowedOrigins:0" "http://localhost:4200"
```

The default development origin is `http://localhost:4200`. Production deployments must set the exact trusted origin(s); do not use wildcard origins with cookie authentication.

## Run locally

```bash
dotnet restore
dotnet build
dotnet ef database update
dotnet run --launch-profile https
```

Use the HTTPS launch profile because the Identity authentication cookie is marked Secure and SameSite=Strict. Browser clients must send credentials with API requests (for example, `credentials: "include"` with fetch) and use HTTPS.

## Authentication and authorization

- Registration: `POST /api/Account/Register`
- Login: `POST /api/Account/Login`
- Logout: `POST /api/Account/Logout` (authenticated)
- Get own profile: `GET /api/Account/{id}`
- Admin-only user listing/deletion, product/brand creation, and contact-message retrieval require the `Admin` Identity role.
- Public catalogue reads and contact submissions remain available.

The registration request accepts a plain-text `Password` over HTTPS; Identity hashes it before storage. API responses use `UserResponseDTO` and never include a password or password hash.

After applying migrations, create the `Admin` role and assign it to a trusted administrator through a secure, out-of-band Identity administration process. There is intentionally no public API for granting roles.

## Important API contract changes

- Registration request property is now `Password` (not `PasswordHash`).
- Login returns a safe user profile rather than echoing the login request.
- Logout is now POST and requires authentication.
- User enumeration/deletion and sensitive contact-message reads require the Admin role.
- Product and brand creation require the Admin role.
- The account profile route is `GET /api/Account/{id}`.

## Notes

This repository is a learning/portfolio project. Review deployment configuration, add automated integration tests, configure CSRF protection appropriate to the deployed frontend topology, and verify database migrations against a disposable database before production use.
