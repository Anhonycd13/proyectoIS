USE db_gstore_medic 

EXEC sp_rename 'tb_cita','tb_citas'

EXEC sp_rename 'tb_horario_disponible','tb_horarios_disponibles'

EXEC sp_rename 'tb_producto','tb_productos'

EXEC sp_rename 'tb_dato','tb_datos'

EXEC sp_rename 'tb_receta_detalle','tb_recetas_detalle'

USE db_gstore_medic
ALTER TABLE tb_antecedentes
ALTER COLUMN descripcion nvarchar(max)

USE db_gstore_medic
ALTER TABLE tb_consultas
ALTER COLUMN descripcion nvarchar(max)

USE db_gstore_medic
ALTER TABLE tb_datos
ALTER COLUMN descripcion nvarchar(max)

USE db_gstore_medic
ALTER TABLE tb_configuraciones
ALTER COLUMN valor nvarchar(max)

USE db_gstore_medic
ALTER TABLE tb_usuarios
ALTER COLUMN password nvarchar(max)

