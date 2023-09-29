using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PremierLeague
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'premiereLeagueDataSet.Cities' Puede moverla o quitarla según sea necesario.
            this.citiesTableAdapter.Fill(this.premiereLeagueDataSet.Cities);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                //get data from txtId
                var id = int.Parse(txtId.Text);
                //combobox
                switch (comboSelect.Text) {
                    
                    case "City":
                        //object
                        City city = new City(id);
                        City[] cityValue = { city };
                        dataList.DataSource = cityValue;
                        
                        break;
                    case "Team":
                        //object
                        Team team = new Team(id);
                        //this is to display the actual name of the teams city
                        var teamObj = new
                        {
                            id = team.Id,
                            name = team.Name,
                            city = team.City.Name,
                            status = team.Status
                        };
                        List<Object> teamList = new List<Object>();
                        teamList.Add(teamObj);
                        dataList.DataSource = teamList;
                        break;
                    case "Game":
                        //object
                        Game game = new Game(id);
                        //this is to display the actual name of the teams city
                        var gameObj = new
                        {
                            id = game.Id,
                            dateTime = game.DateTime,
                            localId = game.LocalId,
                            visitorId = game.VisitorId,
                            status = game.Status
                        };
                        List<Object> list = new List<Object>();
                        list.Add(gameObj);
                        dataList.DataSource = list;
                        break;
                        /*case "Player":
                            //object
                            City city = new City(id);
                            City[] data = { city };
                            dataList.DataSource = data;
                            break;*/
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboSelect.Text)
                {

                    case "City":
                        //object
                        List<City> cityList = City.GetAll();
                        dataList.DataSource = cityList;
                        break;
                    case "Team":
                        //object
                        List<Team> teamList = Team.GetAll();
                        dataList.DataSource = teamList;
                        break;
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
