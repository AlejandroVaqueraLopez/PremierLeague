using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    private int _id;
    private DateTime _dateTime;
    private int _localId;
    private int _visitorId;
    private bool _status;

    public int Id { get { return _id; } set { _id = value; } }
    public DateTime DateTime { get { return _dateTime; } set { _dateTime = value; } }
    public int LocalId { get { return _localId; } set { _localId = value; } }
    public int VisitorId { get { return _visitorId; } set { _visitorId = value; } }
    public bool Status { get { return _status; } set { _status = value; } }

    //constructors
    public Game()
    {
        _id = 0;
        _dateTime = new DateTime();
        _localId = 0;
        _visitorId = 0;
        _status = true;
    }
    public Game(int id, DateTime dateTime, int localId, int visitorId, bool status)
    {
        _id = id;
        _dateTime = dateTime;
        _localId = localId;
        _visitorId = visitorId;
        _status = status;
    }
}

