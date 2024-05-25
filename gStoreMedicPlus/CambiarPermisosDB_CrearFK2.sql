use db_gstore_medic;

SELECT SYSTEM_USER;

GRANT REFERENCES TO "ZINKY-LENOVO\luisg";


ALTER TABLE tb_consultas
   ADD CONSTRAINT FK_tb_consultas_tb_personas FOREIGN KEY (tb_personas_id)
      REFERENCES tb_personas (id)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;