USE InLock_Games_Tarde;

SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuarios;

SELECT IdEstudio, NomeEstudio FROM Estudios;

SELECT Jogos.IdJogo, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio
FROM Jogos
INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio;