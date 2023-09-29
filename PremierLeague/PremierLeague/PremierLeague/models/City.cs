using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

public class City
{
    #region Attributes

    private int _id;
    private string _name;
    private bool _status;

    #endregion

    #region Properties

    public int Id { set { _id = value; } get { return _id; } }
    public string Name { set { _name = value; } get { return _name; } }
    public bool Status { set { _status = value; } get { return _status; } }

    #endregion

    #region Constructors

    public City()
    {
        _id = 0;
        _name = "";
        _status = false;
    }

    public City(int id, string name, bool status)
    {
        _id = id;
        _name = name;
        _status = status;
    }

    public City(int id)
    {
        //query
        string query = @"Select Id, Name, Status From Cities Where Id = @ID";
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
            _status = Convert.ToBoolean(row["Status"]);
        }
        else
        {
            MessageBox.Show("Record not found");
        }
    }

    #endregion

    #region Methods
    //get all
    public static List<City> GetAll()
    {
        List<City> list = new List<City>();
        //query
        string query = @"Select Id, Name, Status From Cities";
        //command
        SqlCommand command = new SqlCommand(query);
        //execute command
        DataTable table = SqlServerConection.ExecuteQuery(command);

        //DataTable table = SqlServerConection.FillDataGrid();

        int count = 0;
        
        if(table.Rows.Count > 0) { 
            while (count < table.Rows.Count)
            {
                DataRow row = table.Rows[count];
                City data = new City();
                data.Id = Convert.ToInt32(row["Id"]);
                data.Name = Convert.ToString(row["Name"]);
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
