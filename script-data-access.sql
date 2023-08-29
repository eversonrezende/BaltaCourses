-- Criar a procedure spDeleteStudent
CREATE OR ALTER PROCEDURE [spDeleteStudent] (
    @StudentId UNIQUEIDENTIFIER
)
AS
    BEGIN TRANSACTION
        DELETE FROM 
            [StudentCourse] 
        WHERE 
            [StudentId] = @StudentId

        DELETE FROM 
            [Student] 
        WHERE 
            [Id] = @StudentId
    COMMIT
GO


SELECT * FROM Category where Id = '3e3212a4-7b40-4607-8a0f-111dea43e6ab';

INSERT INTO Student VALUES (
    NEWID(), 
    'Everson Rezende', 
    'rezende.everson@gmail.com', 
    '12254785697',
    '1199999999', 
    CONVERT(datetime, '29/08/1995', 103), 
    GETDATE()); 
GO

-- Criar a procedure spGetCoursesByCategory
CREATE OR ALTER PROCEDURE [spGetCoursesByCategory] 
    @CategoryId UNIQUEIDENTIFIER
AS
    SELECT * FROM [Course] WHERE [CategoryId] = @CategoryId

-- Executar a procedure passando o parâmetro
EXEC spGetCoursesByCategory '09ce0b7b-cfca-497b-92c0-3290ad9d5142';
