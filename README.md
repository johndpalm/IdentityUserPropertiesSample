IdentityUserPropertiesSample
============================

The ASP.NET Identity User Properties Sample project is a collection of Visual Studio projects that show how to create a custom user, request user properties at registration, and edit properties after login.

The MySample.WebMVC project takes the Visual Studio (RC) MVC template, adds a CustomUser entity, and modified the AccountController and views to prompt for first name and last name at registration and then allow users to add email and phone number from the manage user page.

The MySample.WebAPI project takes the Visual Studio (RC) SPA template, applies the same CustomUser as the MVC project but modifies the JavaScript files so the SPA registration and manage pages  to work with the Web API controller.

The custom user entity and the view models are common to both the MVC and Web API projects and are consolidated in the MySample.Models project.
The DbContext and Migrations code is also common to both and are in the MySample.Data project.

The projects are configured with identical connection strings so that you can register a local user on one site and login in another (as long as the connection string is correct and you using (LocalDb)\v11.0 as your data source).  If you enable external authentication providers, you will be able to use a local login across sites but the external authentication providers will see each site as a different sites.  (This is a good thing.)  If you register an external login on one site, you not be able to use it to login to another if the hostname/port is different.  This is apparent to most of the external login providers (except Google) since you must register the hostname/port with the provider to get a client id and secret.

The projects have been updated to Bootstrap 3.0 which requires some changes to the MVC and SPA template CSS and DIV structures.  The Bootstrap site has a page on changes to make this migration: http://getbootstrap.com/getting-started/#migration


