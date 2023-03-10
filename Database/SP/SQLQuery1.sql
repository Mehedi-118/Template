USE [PrimeTech100]
GO
/****** Object:  StoredProcedure [dbo].[GetDetailsByCode]    Script Date: 2/1/2023 8:19:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetDetailsByCode] 
(@StudentCode varchar(10))
AS
BEGIN

-- GetDetailsByCode 'I01'

SELECT        s.Name, s.Code, d.Name AS Department,c.Name as CourseName,
                             (SELECT        Grade
                               FROM            GenericLookup AS g
                               WHERE        (Id = sc.GradeId)) AS Grade, c.Name AS Expr1
FROM            Students AS s INNER JOIN
                         Departments AS d ON s.DepartmentId = d.Id INNER JOIN
                         StudentsCourses AS sc ON s.Id = sc.StudentInfoId INNER JOIN
                         Courses AS c ON sc.CourseId = c.Id
			
			
			
			where s.Code=@StudentCode
END