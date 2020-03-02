USE InLock_Games_Tarde;

INSERT INTO TipoUsuario (Titulo)
VALUES ('Administrador'),
       ('Cliente');

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES ('cliente@cliente.com', 'cliente', 2),
       ('admin@admin.com', 'admin', 1);

INSERT INTO Estudios (NomeEstudio)
VALUES ('Blizzard'),
       ('Rockstar Studios'),
	   ('Square Enix');

INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
VALUES ('Dablo 3', 'É um jogo que contém bastante ação e é viciante, seja 
        você um novato ou um fã', '15/05/2012', 99.00, 1),
	   ('Red Dead Redemption', 'Jogo eletrônico de ação-aventura western',
	    '26/10/2018', 120.00, 2);