DROP DATABASE IF EXISTS `watchlistnetflixdb`;
CREATE DATABASE `watchlistnetflixdb` DEFAULT CHARACTER SET utf8;
USE `watchlistnetflixdb`;
CREATE TABLE User (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50),
    Pass VARCHAR(50)
);
CREATE TABLE Company (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Company_name VARCHAR(30) UNIQUE NOT NULL
);
CREATE TABLE Genre (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Genre_name VARCHAR(30) UNIQUE NOT NULL
);
CREATE TABLE Movie (
    Id INT AUTO_INCREMENT  PRIMARY KEY,
    Title VARCHAR(50) UNIQUE NOT NULL,
    Descr VARCHAR(500) NOT NULL,
    CompanyId INT,
    GenreId INT, 
    Rating INT,
    Length INT,
    CONSTRAINT FK_Movie_Company_name
        FOREIGN KEY (CompanyId)
        REFERENCES Company(Id),
	CONSTRAINT FK_Movie_Genre
        FOREIGN KEY (GenreId)
        REFERENCES Genre(Id)        
);
CREATE TABLE Serie (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(50),
    Descr VARCHAR(500) NOT NULL,
    CompanyId INT,
    Seasons INT NOT NULL,
    Chapters INT NOT NULL,
    GenreId INT, 
    Rating INT,
    CONSTRAINT FK_Serie_Company_name
        FOREIGN KEY (CompanyId)
        REFERENCES Company(Id),
	CONSTRAINT FK_Serie_Genre
        FOREIGN KEY (GenreId)
        REFERENCES Genre(Id)          
);
CREATE TABLE WatchList (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(20),
    UserId INT,
    CONSTRAINT FK_WatchList_User
        FOREIGN KEY (UserId)
        REFERENCES User(Id)
);

INSERT INTO User(Username, Pass) VALUES 
('hola', '1234');

INSERT INTO Company (Company_name) VALUES
('Walt Disney Pictures'),
('Warner Bros.'),
('Universal Pictures'),
('Lionsgate'),
('Sony Pictures');


-- Insertar 10 géneros
INSERT INTO Genre (Genre_name) VALUES
('Action'),
('Drama'),
('Comedy'),
('Sci-Fi'),
('Horror'),
('Romance'),
('Thriller'),
('Adventure'),
('Fantasy'),
('Mystery');


INSERT INTO Movie (Title, Descr, CompanyId, GenreId, Rating, Length) VALUES
('Piratas del Caribe', 'Una aventura pirata llena de acción', 1, 1, 4, 120),
('El Caballero Oscuro', 'Un drama oscuro y emocionante', 2, 2, 5, 150),
('Jurassic Park', 'Una emocionante película de ciencia ficción', 3, 3, 4, 120),
('Los juegos del hambre', 'Una película de acción y aventura', 4, 4, 3, 130),
('Spider-Man: Lejos de casa', 'Una película de superhéroes llena de emoción', 5, 5, 4, 135),
('Titanic', 'Un drama romántico ambientado en el desastre del Titanic', 1, 6, 5, 195),
('El Conjuro', 'Una película de terror basada en hechos reales', 2, 6, 4, 112),
('Harry Potter y la piedra filosofal', 'Una auserventura mágica llena de fantasía', 3, 7, 4, 152),
('El código Da Vinci', 'Un emocionante misterio basado en la novela de Dan Brown', 4, 8, 4, 149),
('Frozen', 'Una película animada de Disney llena de magia y aventuras', 5, 8, 4, 102);

INSERT INTO Serie (Title, Descr, CompanyId, Seasons, Chapters, GenreId, Rating) VALUES
('The Mandalorian', 'Una serie de aventuras en el universo de Star Wars', 1, 2, 16, 9, 5),
('Friends', 'Una comedia sobre un grupo de amigos en Nueva York', 2, 10, 236, 3, 5),
('Stranger Things', 'Un thriller de ciencia ficción ambientado en los años 80', 3, 4, 34, 9, 4),
('Breaking Bad', 'Un drama sobre un profesor de química que se convierte en narcotraficante', 4, 5, 62, 2, 5),
('The Crown', 'Un drama histórico sobre la reina Isabel II', 5, 4, 40, 10, 4),
('The Big Bang Theory', 'Una comedia sobre un grupo de científicos brillantes y sus vidas sociales', 1, 12, 279, 3, 4),
('Black Mirror', 'Una serie de ciencia ficción que explora los aspectos oscuros de la tecnología', 2, 5, 22, 10, 5),
('Sherlock', 'Un drama de misterio basado en las historias de Sherlock Holmes', 3, 4, 13, 7, 5),
('The Boys', 'Una serie de superhéroes subversiva y violenta', 4, 2, 16, 1, 4),
('Juego de Tronos', 'Una épica serie de fantasía y drama', 5, 8, 73, 9, 5);
