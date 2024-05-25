
CREATE PROCEDURE sp_validar_usuario
	@UserName VARCHAR(15),
	@Password VARCHAR(100)
AS
BEGIN
	SELECT *
	FROM tb_usuarios
	WHERE tb_usuarios.usuario=@UserName 
	AND tb_usuarios.password=@Password
END

EXEC sp_validar_usuario 'LUISGUTI','12345'


