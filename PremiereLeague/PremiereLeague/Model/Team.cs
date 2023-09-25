using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Team
{
    private int _id;
    private string _name;
    private City _cityId;
    private bool _status;

    public int Id { get { return _id; } set { _id = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public City CityId { get { return _cityId; } set { _cityId = value; } }
    public bool Status { get { return _status; } set { _status = value; } }

    //constructors
    public Team()
    {
        _id = 0;
        _name = "";
        _cityId = new City();
        _status = true;
    }
    public Team(int id, string name, City cityId, bool status)
    {
        _id = id;
        _name = name;
        _cityId = cityId;
        _status = status;
    }
}
