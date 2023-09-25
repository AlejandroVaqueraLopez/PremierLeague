using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class City {
    private int _id;
    private string _name;
    private bool _status;

    public int Id { get { return _id; } set { _id = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public bool Status { get { return _status; } set { _status = value; } }

    //constructors
    public City()
    {
        _id = 0;
        _name = "";
        _status = true;
    }
    public City(int id, string name, bool status)
    {
        _id = id;
        _name = name;
        _status = status;
    }
}
