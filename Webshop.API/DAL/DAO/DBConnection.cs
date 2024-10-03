namespace Webshop.API.DAL.DAO;

public class DBConnection
{
    //indsæt db information

    public string GetConnection()
    {
        return $"Server={ServerAddress},{ServerPort};Database={Dbname};User Id={Username};Password={Password};Encrypt=False;";
    }
}
