using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    private int _id;
    private string _name;
    private string _lastName;
    private DateTime _DOB;
    private Team _teamId;
    private int _number;
    private string _position;
    private bool _status;

    public int Id { get { return _id; } set { _id = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public string LastName { get { return _lastName; } set { _lastName = value; } }
    public DateTime DOB { get { return _DOB; } set { _DOB = value; } }
    public Team TeamId { get { return _teamId; } set { _teamId = value; } }
    public int Number { get { return _number; } set { _number = value; } }
    public string Position { get { return _position; } set { _position = value; } }
    public bool Status { get { return _status; } set { _status = value; } }

    //constructors
    public Player()
    {
        _id = 0;
        _name = "";
        _lastName = "";
        _DOB = new DateTime();
        _teamId = new Team();
        _number = 0;
        _position = "";
        _status = true;
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
}

