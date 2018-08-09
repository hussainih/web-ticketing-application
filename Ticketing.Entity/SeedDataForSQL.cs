using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Entity
{
    public class SeedDataForSQL
    {
        public static string GetSQLQuery()
        {

            var resutl = "INSERT[dbo].[DegreeTypes]([RecID], [Name]) VALUES(N'b15fff7c-cc81-e811-82f5-54ab3a80dfa5','Master') " +
"INSERT[dbo].[DegreeTypes] ([RecID], [Name]) VALUES(N'b25fff7c-cc81-e811-82f5-54ab3a80dfa5','Bachelor') " +
"INSERT[dbo].[DegreeTypes]([RecID], [Name]) VALUES(N'b35fff7c-cc81-e811-82f5-54ab3a80dfa5','PHD') " +


"INSERT[dbo].[Departments] ([RecID], [Description], [Name], [CreationDate]) VALUES(N'b7077564-ef77-e811-82f4-54ab3a80dfa5', N'', N'Agrarwirtschaft', CAST(N'2018-06-24 22:44:31.000' AS DateTime))" +
"INSERT[dbo].[Departments] ([RecID], [Description], [Name], [CreationDate]) VALUES(N'b8077564-ef77-e811-82f4-54ab3a80dfa5', N'', N'Informatik und Elektrotechnik', CAST(N'2018-06-24 22:44:40.000' AS DateTime))" +
"INSERT[dbo].[Departments] ([RecID], [Description], [Name], [CreationDate]) VALUES(N'4945df6d-ef77-e811-82f4-54ab3a80dfa5', N'', N'Maschinenwesen', CAST(N'2018-06-24 22:44:46.000' AS DateTime))" +
"INSERT[dbo].[Departments] ([RecID], [Description], [Name], [CreationDate]) VALUES(N'4a45df6d-ef77-e811-82f4-54ab3a80dfa5', N'', N'Medien', CAST(N'2018-06-24 22:44:51.000' AS DateTime))" +
"INSERT[dbo].[Departments] ([RecID], [Description], [Name], [CreationDate]) VALUES(N'4b45df6d-ef77-e811-82f4-54ab3a80dfa5', N'', N'Medien / Bauwesen', CAST(N'2018-06-24 22:44:55.000' AS DateTime))" +
"INSERT[dbo].[Departments] ([RecID], [Description], [Name], [CreationDate]) VALUES(N'eb6aca76-ef77-e811-82f4-54ab3a80dfa5', N'', N'Soziale Arbeit und Gesundheit', CAST(N'2018-06-24 22:45:01.000' AS DateTime))" +
"INSERT[dbo].[Departments] ([RecID], [Description], [Name], [CreationDate]) VALUES(N'ec6aca76-ef77-e811-82f4-54ab3a80dfa5', N'', N'Wirtschaft', CAST(N'2018-06-24 22:45:07.000' AS DateTime))" +
"INSERT[dbo].[Departments] ([RecID], [Description], [Name], [CreationDate]) VALUES(N'de7261ed-f278-e811-82f4-54ab3a80dfa5', N'', N'Social Sciences Department', CAST(N'2018-06-26 05:42:19.000' AS DateTime))" +


"INSERT[dbo].[DegreePrograms] ([RecID], [Description], [Name], [CreationDate], [DegreeType_Recid], [Department_RecID]) VALUES(N'b503f199-ef77-e811-82f4-54ab3a80dfa5', NULL, N'Elektrotechnik (Bachelor)', CAST(N'2018-06-24 22:46:00.000' AS DateTime),N'b25fff7c-cc81-e811-82f5-54ab3a80dfa5', N'b8077564-ef77-e811-82f4-54ab3a80dfa5') " +
"INSERT[dbo].[DegreePrograms] ([RecID], [Description], [Name], [CreationDate], [DegreeType_Recid],[Department_RecID]) VALUES(N'f85bdfaf-ef77-e811-82f4-54ab3a80dfa5', NULL, N'Bachelor Informationstechnologie', CAST(N'2018-06-24 22:46:37.000' AS DateTime), N'b25fff7c-cc81-e811-82f5-54ab3a80dfa5',N'b8077564-ef77-e811-82f4-54ab3a80dfa5') " +
"INSERT[dbo].[DegreePrograms] ([RecID], [Description], [Name], [CreationDate], [DegreeType_Recid],[Department_RecID]) VALUES(N'ca3a91b8-ef77-e811-82f4-54ab3a80dfa5', NULL, N'Bachelor Mechatronik', CAST(N'2018-06-24 22:46:52.000' AS DateTime),N'b25fff7c-cc81-e811-82f5-54ab3a80dfa5', N'b8077564-ef77-e811-82f4-54ab3a80dfa5') " +
"INSERT[dbo].[DegreePrograms] ([RecID], [Description], [Name], [CreationDate], [DegreeType_Recid],[Department_RecID]) VALUES(N'e22a5fc2-ef77-e811-82f4-54ab3a80dfa5', NULL, N'Bachelor of Engineering', CAST(N'2018-06-24 22:47:08.000' AS DateTime),N'b25fff7c-cc81-e811-82f5-54ab3a80dfa5', N'b8077564-ef77-e811-82f4-54ab3a80dfa5') " +
"INSERT[dbo].[DegreePrograms] ([RecID], [Description], [Name], [CreationDate], [DegreeType_Recid],[Department_RecID]) VALUES(N'13b7ffc9-ef77-e811-82f4-54ab3a80dfa5', NULL, N'Bachelor Wirtschaftsingenieurwesen - Elektrotechnik', CAST(N'2018-06-24 22:47:21.000' AS DateTime), N'b25fff7c-cc81-e811-82f5-54ab3a80dfa5',N'b8077564-ef77-e811-82f4-54ab3a80dfa5') " +
"INSERT[dbo].[DegreePrograms] ([RecID], [Description], [Name], [CreationDate], [DegreeType_Recid],[Department_RecID]) VALUES(N'68b01bd0-ef77-e811-82f4-54ab3a80dfa5', NULL, N'Master Elektrische Technologien', CAST(N'2018-06-24 22:47:31.000' AS DateTime),N'b15fff7c-cc81-e811-82f5-54ab3a80dfa5', N'b8077564-ef77-e811-82f4-54ab3a80dfa5') " +
"INSERT[dbo].[DegreePrograms] ([RecID], [Description], [Name], [CreationDate], [DegreeType_Recid],[Department_RecID]) VALUES(N'ad7e90d6-ef77-e811-82f4-54ab3a80dfa5', NULL, N'Master Information Engineering', CAST(N'2018-06-24 22:47:42.000' AS DateTime),N'b15fff7c-cc81-e811-82f5-54ab3a80dfa5', N'b8077564-ef77-e811-82f4-54ab3a80dfa5') " +


"INSERT[dbo].[Specializations] ([RecID], [Name], [CreationDate], [Description], [DegreePrograms_RecID]) VALUES(N'b33cbaef-ef77-e811-82f4-54ab3a80dfa5', N'Intelligent Systems', CAST(N'2018-06-24 22:48:24.000' AS DateTime), NULL, N'ad7e90d6-ef77-e811-82f4-54ab3a80dfa5') " +
"INSERT[dbo].[Specializations] ([RecID], [Name], [CreationDate], [Description], [DegreePrograms_RecID]) VALUES(N'b43cbaef-ef77-e811-82f4-54ab3a80dfa5', N'IT-Security', CAST(N'2018-06-24 22:48:33.000' AS DateTime), NULL, N'ad7e90d6-ef77-e811-82f4-54ab3a80dfa5') " +
"INSERT[dbo].[Specializations] ([RecID], [Name], [CreationDate], [Description], [DegreePrograms_RecID]) VALUES(N'cd5308f8-ef77-e811-82f4-54ab3a80dfa5', N'Information Technology and Systems Development', CAST(N'2018-06-24 22:48:38.000' AS DateTime), NULL, N'ad7e90d6-ef77-e811-82f4-54ab3a80dfa5') " +
"INSERT[dbo].[Specializations] ([RecID], [Name], [CreationDate], [Description], [DegreePrograms_RecID]) VALUES(N'ce5308f8-ef77-e811-82f4-54ab3a80dfa5', N'Business IT-Management', CAST(N'2018-06-24 22:48:43.000' AS DateTime), NULL, N'ad7e90d6-ef77-e811-82f4-54ab3a80dfa5') " +

"INSERT[dbo].[ProposalTypes] ([RecID], [Name]) VALUES(N'e774b5b1-4182-e811-82f6-54ab3a80dfa5', N'Thesis') " +
"INSERT[dbo].[ProposalTypes]([RecID], [Name]) VALUES(N'e874b5b1-4182-e811-82f6-54ab3a80dfa5', N'Project') ";






            return resutl;

        }
    }
}
