SELECT Application.Id, surnameName, name, date, tHCOname, tCWname, description, sName 
FROM Status INNER JOIN((HandBookOfCOTypes INNER JOIN CadastralObject ON HandBookOfCOTypes.Id=CadastralObject.fk_tipeCO)
 INNER JOIN (TypeCW INNER JOIN ([User] INNER JOIN Application ON [User].Id = Application.fk_customer) ON 
 TypeCW.Id=Application.fk_typeCW) ON CadastralObject.Id=Application.fk_cadastralObject) ON 
 Status.Id=Application.fk_status