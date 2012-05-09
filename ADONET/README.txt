Saving Changes to the Database Using the Update Method

The Update method saves the data table modifications to the database by retrieving the 
changes from the data table and then using the respective InsertCommand,  UpdateCommand, 
or DeleteCommand property to send the appropriate changes to the database on a row-by-
row basis. The Update method retrieves the DataRow objects that have changed by looking 
at the RowState property of each row. If RowState is anything but Unchanged, the Update 
method sends the change to the database.
For the Update method to work, all four commands must be assigned to the 
 DbDataAdapter object. Normally, this means creating individual DbCommand objects 
for each command. You can easily create the commands by using the DbDataAdapter 
 Configuration Wizard, which starts when a DbDataAdapter object is dropped onto the 
 Windows form. The wizard can generate stored procedures for all four commands.
Another way to populate the DbDataAdapter object¡¯s commands is to use the 
 DbCommandBuilder object. This object creates the InsertCommand, UpdateCommand, 
and DeleteCommand properties as long as a valid SelectCommand property exists. 
 DbDataAdapter is great for ad hoc changes and demos, but it¡¯s generally better to use stored 
procedures for all database access because, in SQL Server, it¡¯s easier to set permissions on 
stored procedures than it is to set permissions on tables. The following code demonstrates a 
simple update to the database, using SqlDataAdapter, which is the SQL Server¨Cspecific version 
of DbDataAdapter. After the changes are saved, the results are displayed on the DataGridView 
object, called DataGridView2.