using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class Player
{
    #region Attributes

    private int _id;
    private string _name;
    private string _lastName;
    private DateTime _DOB;
    private Team _teamId;
    private int _number;
    private string _position;
    private bool _status;

    #endregion

    #region Properties
    public int Id { get { return _id; } set { _id = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public string LastName { get { return _lastName; } set { _lastName = value; } }
    public DateTime DOB { get { return _DOB; } set { _DOB = value; } }
    public Team TeamId { get { return _teamId; } set { _teamId = value; } }
    public int Number { get { return _number; } set { _number = value; } }
    public string Position { get { return _position; } set { _position = value; } }
    public bool Status { get { return _status; } set { _status = value; } }
    #endregion

    #region Constructors
    public Player()
    {
        _id = 0;
        _name = "";
        _lastName = "";
        _DOB = new DateTime();
        _teamId = new Team();
        _number = 0;
        _position = "";
        _status = false;
    }
    public Player(int id, string name, string lastName, DateTime dob, Team teamId, int number, string position, bool status)
    {
        _id = id;
        _name = name;
        _lastName = lastName;
        _DOB = dob;
        _teamId = teamId;
        _number = number;
        _position = position;
        _status = status;
    }

    public Player(int id)
    {
        //query
        string query = @"Select Id, Name, Lastname, DOB, TeamId, Number, Position, Status From Players Where Id = @ID";
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
            _lastName = Convert.ToString(row["Lastname"]);
            _DOB = Convert.ToDateTime(row["DOB"]);
            _teamId = new Team(Convert.ToInt32(row["TeamId"]));
            _number = Convert.ToInt32(row["Number"]);
            _position = row["Position"].ToString();
            _status = Convert.ToBoolean(row["Status"]);
        }
        else
        {
            //MessageBox.Show("Record not found");
        }
    }
    #endregion

    #region Methods

    public static List<Player> GetAll()
    {
        List<Player> list = new List<Player>();
        //query
        string query = @"Select Id, Name, Lastname, DOB, TeamId, Number, Position, Status From Players";
        //command
        SqlCommand command = new SqlCommand(query);
        //execute command
        DataTable table = SqlServerConection.ExecuteQuery(command);

        int count = 0;
        if (table.Rows.Count > 0)
        {
            while (count < table.Rows.Count)
            {
                DataRow row = table.Rows[count];
                Player data = new Player();
                data.Id = Convert.ToInt32(row["Id"]);
                data.Name = Convert.ToString(row["Name"]);
                data.LastName = Convert.ToString(row["Lastname"]);
                data.DOB = Convert.ToDateTime(row["DOB"]);
                data.TeamId = new Team(Convert.ToInt32(row["TeamId"]));
                data.Number = Convert.ToInt32(row["Number"]);
                data.Position = row["Position"].ToString();
                data.Status = Convert.ToBoolean(row["Status"]);
                list.Add(data);
                count++;
            }
        }
        else
        {
            //MessageBox.Show("Record not found");
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
