USE InLock_Games_Tarde;

SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuarios;

SELECT IdEstudio, NomeEstudio FROM Estudios;

SELECT Jogos.IdJogo, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio
FROM Jogos
INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio;

SELECT Estudios.NomeEstudio, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor
FROM Estudios
LEFT JOIN Jogos ON Estudios.IdEstudio = Jogos.IdJogo;

SELECT Usuarios.IdUsuario, Usuarios.Email, Usuarios.IdTipoUsuario, TipoUsuario.Titulo FROM Usuarios 
INNER JOIN TipoUsuario 
ON Usuarios.IdTipoUsuario = TipoUsuario.IdTipoUsuario
WHERE Usuarios.Email = 'admin@admin.com' AND Usuarios.Senha = 'admin'

SELECT Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio
FROM Jogos
INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio
WHERE Jogos.IdJogo = '1';

SELECT  Estudios.IdEstudio, Estudios.NomeEstudio FROM Estudios 
WHERE Estudios.IdEstudio = '2';




