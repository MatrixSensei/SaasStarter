# Saas
I have the tables.  Have the Tenants, Datalinks and some User management going on.
When admin logs in, there should be a choice of Tenants for the admin to start from the TenantUser table.
Once the Tenant is selected, the Tenant ID goes into a Session variable and managing the list of products should begin.

There is default data created, so, that will require removal in due course.

What's next?
============
Hardest requirement
 * Use ApplicationUser instead of IndentityUser

Menu needs cleaning.
 * On startup, there should only be the public home index and privacy pages.
 * When admin logs in, Web Api and Tenant/User Management options should appear. (may consider Identity Role SaasAdmin)
 * When user has selected their business
   - Web Api and Tenant/User Management options should disappear.
   - Products should appear

Create/Invite User and Tenant management
 * More thought needs to go into this process
 * Possibly, once user logs into a company
   - User can invite a user with an email address
   - If email address does not exist in system, it is added
   - When new user logs in next, they have option to join or reject
