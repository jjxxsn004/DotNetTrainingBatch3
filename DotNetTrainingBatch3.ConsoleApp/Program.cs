// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//F5 to run


SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
{
    DataSource = "PSAG\\SQLEXPRESS",
    InitialCatalog = "TestDb",
    UserID = "sa",
    Password = "sa@123"
};
SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
sqlConnection.Open();
Console.WriteLine("Connection tested.");

string query = "select * from Tbl_blog";

SqlCommand cmd = new SqlCommand(query, sqlConnection);

SqlDataAdapter adapter   = new SqlDataAdapter(cmd);

DataTable dt = new DataTable();

adapter.Fill(dt);
sqlConnection.Close();

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}

Console.WriteLine("tested");

Console.ReadKey();