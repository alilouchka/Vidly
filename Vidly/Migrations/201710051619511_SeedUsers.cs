namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'68a7a66c-e7fe-4b1b-b2e4-1534a7a6722b', N'admin@vidly.com', 0, N'AA8VxIExkZqtX7Iu2UAZAy6mZsZqgOc6OHpM4tcw258w9QJ/n5A1QhelStF8+kgxdQ==', N'76c9212f-4018-4481-8bc5-cd30ca65435d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bd9060e3-bb56-4e6a-9925-4f69a3e7cec3', N'guest@vidly.com', 0, N'AEOXXy+GATzNlcJQvwgwbOIgEgzS+DCUXhuf9KujEGJ2esQeezm2H2J5aBPL/KuRIg==', N'fc735849-08d5-427b-a660-eb146fb6721d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7c59169b-4e36-4588-8ad1-7d4a2d04f712', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'68a7a66c-e7fe-4b1b-b2e4-1534a7a6722b', N'7c59169b-4e36-4588-8ad1-7d4a2d04f712')
                "); 
        }
        
        public override void Down()
        {
        }
    }
}
