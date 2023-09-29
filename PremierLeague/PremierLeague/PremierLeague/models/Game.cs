using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    #region Attributes

    private int _id;
    private DateTime _dateTime;
    private Team _localId;
    private Team _visitorId;
    private bool _status;

    #endregion

    #region Properties
    #endregion
    public int Id { get { return _id; } set { _id = value; } }
    public DateTime DateTime { get { return _dateTime; } set { _dateTime = value; } }
    public Team LocalId { get { return _localId; } set { _localId = value; } }
    public Team VisitorId { get { return _visitorId; } set { _visitorId = value; } }
    public bool Status { get { return _status; } set { _status = value; } }

    #region Constuctors
    public Game()
    {
        _id = 0;
        _dateTime = new DateTime();
        _localId = new Team();
        _visitorId = new Team();
        _status = false;
    }
    public Game(int id, DateTime dateTime, Team localId, Team visitorId, bool status)
    {
        _id = id;
        _dateTime = dateTime;
        _localId = localId;
        _visitorId = visitorId;
        _status = status;
    }

    public Game(int id) {
        //query
        string query = @"Select Id, DateTime, LocalId, VisitorId, Status From Games Where Id = @ID";
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
            //_dateTime = new DateTime(row["Datetime"]);
            _localId = new Team(Convert.ToInt32(row["LocalId"]));//returns the team object
            _visitorId = new Team(Convert.ToInt32(row["VisitorId"]));//returns the team object
            _status = Convert.ToBoolean(row["Status"]);
        }
        else
        {
            //MessageBox.Show("Record not found");
        }
    }

    #endregion

    #region Methods

    public static List<Game> GetAll()
    {
        return new List<Game>();
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
