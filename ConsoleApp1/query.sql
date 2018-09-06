-- в SQLiteStudio создаем базу "study"
-- далее - Инструменты - открываем редактор
-- и выполняем следующие запросы

-- создаем таблицу Students
CREATE TABLE Students				
(                                      
	StudentId int IDENTITY NOT NULL  PRIMARY KEY,				  
	FName varchar(50) NOT NULL,
	LName varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Phone varchar(50) NOT NULL
);

-- создаем таблицу Courses
CREATE TABLE Courses
( 
	CourseId int IDENTITY NOT NULL PRIMARY KEY,
	CourseName varchar(50) NOT NULL,
	Price money Not Null
);

-- создаем таблицу StudentsCourses
CREATE TABLE StudentsCourses (
    StudentId INT NOT NULL
                  REFERENCES Students (StudentId),
    CourseId  INT NOT NULL
                  REFERENCES Courses (CourseId),
    PRIMARY KEY (
        StudentId,
        CourseId
    )
);

-- вставляем данные в таблицы
INSERT INTO Students																			   
(StudentId, FName, LName, Email, Phone)
VALUES
('1', 'Петр', 'Петренко', 'PetrPetrenko@mail.com', '(093)1231212'),
('2', 'Иван', 'Иваненко', 'IvanenkoIvan@mail.com', '(095)2313244'),
('3', 'Максим', 'Максимов', 'MaximovMax@mail.com', '(095)7658786');	

INSERT INTO Courses
(CourseId, CourseName, Price)
VALUES
('1','SQL Essential', 100.00),
('2','C# Professional', 200.00),
('3','ASP.NET MVC', 300.00),
('4','Patterns GoF', 400.00);

INSERT INTO StudentsCourses
(StudentId, CourseId)
VALUES
(1,1),
(2,1),
(3,3),
(3,1),
(2,2);
--

-- просматриваем содержимое таблиц
SELECT * FROM Students;
SELECT * FROM StudentsCourses;
SELECT * FROM Courses;

-- запросы чуть посложнее )))
SELECT  FName, LName, CourseName, Price
FROM Students,Courses,StudentsCourses
WHERE  Students.StudentId =  StudentsCourses.StudentId AND Courses.CourseId = 1;

SELECT  FName, LName, CourseName, Price
FROM Students,Courses,StudentsCourses
WHERE Students.StudentId =  StudentsCourses.StudentId AND 
  StudentsCourses.CourseId = Courses.CourseId AND FName = 'Петр';