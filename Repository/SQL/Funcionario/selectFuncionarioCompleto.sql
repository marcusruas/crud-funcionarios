﻿SELECT PK_FUNCIONARIO AS CODIGO, NOME, EMAIL, DATANASCIMENTO, SALARIO, FK_ESTADO AS ESTADO FROM FUNCIONARIO WHERE PK_FUNCIONARIO = @FUNCIONARIO