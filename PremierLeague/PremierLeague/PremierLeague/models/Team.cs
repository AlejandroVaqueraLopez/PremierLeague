using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class Team
{
    #region Attributes

    private int _id;
    private string _name;
    private City _city;
    private bool _status;

    #endregion

    #region Properties
    public int Id { set { _id = value; } get { return _id; } }
    public string Name { set { _name = value; } get { return _name; } }
    public City City { set { _city = value; } get { return _city; } }
    public bool Status { set { _status = value; } get { return _status; } }
    #endregion

    #region Constructors
    public Team()
    {
        _id = 0;
        _name = "";
        _city = new City();
        _status = false;
    }
    public Team(int id, string name, City city, bool status)
    {
        _id = id;
        _name = name;
        _city = city;
        _status = status;
    }

    public Team(int id)
    {
        //query
        string query = @"Select Id, Name, CityId, Status From Teams Where Id = @ID";
        //command
        SqlCommand command = new SqlCommand(query);
        //parameters
        command.Parameters.AddWithValue("@ID", id);
        //execute command
        DataTable table = SqlServerConection.ExecuteQuery(command);

        if (table.Rows.Count > 0)
        {
            DataRow row = table.Rows[0];

            _id = Convert.ToInt32(row["Id"]);
            _name = Convert.ToString(row["Name"]);
            _city = new City(Convert.ToInt32(row["CityId"]));
            _status = Convert.ToBoolean(row["Status"]);
        }
        else
        {
            //MessageBox.Show("Record not found");
        }
    }

    #endregion

    #region Methods
    public static List<Team> GetAll()
    {
        List<Team> list = new List<Team>();
        //query
        string query = @"Select Id, Name, CityId, Status From Teams";
        //command
        SqlCommand command = new SqlCommand(query);
        //execute command
        DataTable table = SqlServerConection.ExecuteQuery(command);

        //DataTable table = SqlServerConection.FillDataGrid();

        int count = 0;

        if (table.Rows.Count > 0)
        {
            while (count < table.Rows.Count)
            {
                DataRow row = table.Rows[count];
                Team data = new Team();
                data.Id = Convert.ToInt32(row["Id"]);
                data.Name = Convert.ToString(row["Name"]);
                data.City = new City(Convert.ToInt32(row["CityId"]));
                data.Status = Convert.ToBoolean(row["Status"]);
                list.Add(data);
                count++;
            }
        }
        else
        {
            MessageBox.Show("Record not found");
        }
        return list;
    }

    //add
    public bool Add()
    {
        return true;
    }

    //update 
    public bool Update()
    {
        return true;
    }

    //delete 
    public bool Delete()
    {
        return true;
    }

    #endregion
}
