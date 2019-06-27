namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1f4e3962-0934-424a-b66c-b973508c7303', N'guest@vidly.com', 0, N'AGOlfActvJDb2PhrT+bP372Ww4JBnZYU8tD3uokAaXXnWcw36NQTm+oIBVCC9jo8dw==', N'1610aa46-bcbf-4d6b-8ebd-ca6a60bac7d3', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'6ef98c5c-e832-45f3-8a70-b8c1a150db27', N'admin@vidly.com', 0, N'AE+FMj6i/BKUOjrA8iaJ2K2ls4/0rG4F2BVtanXC/LJZ3ScODFewlGQLf8+lJQNqow==', N'cf87d07e-8e5f-4289-b72d-7d011a902aba', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'44b323f9-7ea5-4281-be03-0fd907501bd4', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6ef98c5c-e832-45f3-8a70-b8c1a150db27', N'44b323f9-7ea5-4281-be03-0fd907501bd4')");
        }
        
        public override void Down()
        {
        }
    }
}
