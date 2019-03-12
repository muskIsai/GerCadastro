SELECT CadastralObject.Id, HandBookOfCOTypes.tHCOname, CadastralObject.cadastralNumber, CadastralObject.dateOfEntry, 
CadastralObject.dateOfEntry, CadastralObject.legalStatus, CadastralObject.address, CadastralObject.square, 
CadastralObject.cost FROM HandBookOfCOTypes INNER JOIN CadastralObject ON 
HandBookOfCOTypes.Id = CadastralObject.fk_tipeCO