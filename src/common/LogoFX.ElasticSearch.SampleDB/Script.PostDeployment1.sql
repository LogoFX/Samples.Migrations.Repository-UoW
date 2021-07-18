/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
INSERT INTO [dbo].[CourtLevels] ([id], [name]) VALUES (1, N'שלום');

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (17, N'שלום נצרת', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (18, N'שלום טבריה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (19, N'שלום בית שאן', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (20, N'שלום צפת', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (21, N'שלום עפולה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (22, N'שלום קריית שמונה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (23, N'שלום קצרין', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (24, N'שלום מסעדה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (25, N'שלום קריות', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (26, N'שלום חיפה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (27, N'שלום עכו', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (28, N'שלום חדרה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (30, N'שלום ירושלים', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (31, N'שלום בית שמש', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (32, N'שלום תל אביב - יפו', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (34, N'שלום הרצליה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (35, N'שלום פתח תקווה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (36, N'שלום רמלה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (37, N'שלום רחובות', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (38, N'שלום נתניה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (39, N'שלום כפר סבא', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (40, N'שלום ראשון לציון', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (41, N'שלום באר שבע', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (42, N'שלום אשקלון', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (43, N'שלום אשדוד', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (44, N'שלום קריית גת', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (45, N'שלום דימונה', 1);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (46, N'שלום אילת', 1);

GO
INSERT INTO [dbo].[CourtLevels] ([id], [name]) VALUES (2, N'עניינים מקומיים');

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (58, N'עניינים מקומיים אריאל', 2);

GO
INSERT INTO [dbo].[Courts] ([id], [name], [levelId]) VALUES (237, N'שלום בת ים', 1);
