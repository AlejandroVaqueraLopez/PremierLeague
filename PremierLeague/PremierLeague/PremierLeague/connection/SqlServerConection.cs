using System.Windows;
using System.Data; //Generic Data
using System.Data.SqlClient; //SQL Server
using System.Configuration;
using System.Windows.Forms;
using System.Web.UI.Design.WebControls;
using System.Drawing;

class SqlServerConection
{
    #region Attributes

    private static string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    public static SqlConnection connection = new SqlConnection(connectionString);

    #endregion

    /// <summary>
    /// Opens a connection to a SQL Server database
    /// </summary>
    /// <returns></returns>
    private static bool Open()
    {
        //Variable
        bool connected = true;
        //Check if the connection is already opened
        if (connection.State != ConnectionState.Open)
        {
            try
            {
                connection.Open();//Open connection
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Resturn result
        return connected;
    }

    /// <summary>
    /// Execute a query returns the resulting table
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public static DataTable ExecuteQuery(SqlCommand command)
    {
        //Resul table
        DataTable table = new DataTable();

        if (Open())
        {
            command.Connection = connection; //Asign connection to command
            SqlDataAdapter adapter = new SqlDataAdapter(command); //Adapter
            try
            {
                adapter.Fill(table); //Execute query and fill result table

            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);//for debugging only, erase before release
            }
            connection.Close();//Close connection
        }

        //Return table
        return table;
    }
    public static bool ExecuteNoQuery(SqlCommand command)
    {
        bool executed = false;
        if (Open())
        {
            command.Connection = connection;
            try
            {
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0) executed = true;
            }
            catch (SqlException ex)
            {
                executed = false;
            }
            connection.Close();
        }
        return executed;
    }
}