
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

var conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=True;";

using (var con = new SqlConnection(conString))
{
    con.Open();

    var countCmd = new SqlCommand("SELECT count(*) FROM Employees", con);
    var count = countCmd.ExecuteScalar();
    Console.WriteLine($"{count} Employees in DB");

    Console.WriteLine("Suche:");
    var such = Console.ReadLine();
    var cmd = new SqlCommand("SELECT * FROM Employees WHERE FirstName LIKE @search", con);
    cmd.Parameters.AddWithValue("@search", such + "%");

    var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        object id = reader[0];
        object firstname = reader["FirstName"];

        string lastName = reader.GetString(1);
        DateTime birthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));

        Console.WriteLine($"{id} {firstname} {lastName} {birthDate:d}");
    }

} //con.Dispose(); --> con.Close();



Console.WriteLine("Ende");
Console.ReadLine();
