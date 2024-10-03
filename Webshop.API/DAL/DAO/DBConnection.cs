namespace Webshop.API.DAL.DAO;

public class DBConnection
{
    private const string Dbname = "DMA-CSD-S231_10503096";
    private const string ServerAddress = "hildur.ucn.dk";
    private const int ServerPort = 1433;
    private const string Username = "DMA-CSD-S231_10503096";
    private const string Password = "Password1!";

    public string GetConnection()
    {
        return $"Server={ServerAddress},{ServerPort};Database={Dbname};User Id={Username};Password={Password};Encrypt=False;";
    }
}
