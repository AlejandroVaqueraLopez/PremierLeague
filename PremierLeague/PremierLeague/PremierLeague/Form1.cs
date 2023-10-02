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
using System.Xml.Linq;
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
                            localId = game.LocalId.Name,//it has an object of Team class
                            visitorId = game.VisitorId.Name,//it has an object of Team class
                            status = game.Status
                        };
                        List<Object> gameList = new List<Object>();
                        gameList.Add(gameObj);
                        dataList.DataSource = gameList;
                        break;
                    //object
                    case "Player":
                        Player player = new Player(id);
                        //this is to display the actual name of the teams city
                        var playerObj = new
                        {
                            id = player.Id,
                            name = player.Name,
                            lastName = player.LastName,
                            dob = player.DOB,
                            teamId = player.TeamId.Name,//it has a Team object 
                            number = player.Number,
                            position = player.Position,
                            status = player.Status
                        };
                        List<Object> playerList = new List<Object>();
                        playerList.Add(playerObj);
                        dataList.DataSource = playerList;
                        break;
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
                        int teamItem = 0;
                        List<Team> teamList = Team.GetAll();
                        if (teamList.Count > 0)
                        {
                            List<Object> newTeamList = new List<Object>();
                            while (teamItem < teamList.Count)
                            {
                                var listObj = new
                                {
                                    Id = teamList[teamItem].Id,
                                    Name = teamList[teamItem].Name,
                                    city = teamList[teamItem].City.Name,
                                    Status = teamList[teamItem].Status
                                };   
                                newTeamList.Add(listObj);
                                teamItem++;
                            }
                            dataList.DataSource = newTeamList;
                        }
                        break;
                    case "Game":
                        //object
                        int gameItem = 0;
                        List<Game> gameList = Game.GetAll();
                        if(gameList.Count > 0)
                        {
                            List<Object> newGameList = new List<Object>();
                            while (gameItem < gameList.Count)
                            {
                                var gameObj = new
                                {
                                    id = gameList[gameItem].Id,
                                    dateTime = gameList[gameItem].DateTime,
                                    localId = gameList[gameItem].LocalId.Name,//it has an object of Team class
                                    visitorId = gameList[gameItem].VisitorId.Name,//it has an object of Team class
                                    status = gameList[gameItem].Status
                                };
                                newGameList.Add(gameObj);
                                gameItem++;
                            }
                            dataList.DataSource = newGameList;
                        }
                        break;
                    case "Player":
                        //object
                        int playerItem = 0;
                        List<Player> playerList = Player.GetAll();
                        if (playerList.Count > 0)
                        {
                            MessageBox.Show(playerList.Count.ToString());
                            List<Object> newPlayerList = new List<Object>();
                            while (playerItem < playerList.Count)
                            {
                                var gameObj = new
                                {
                                    id = playerList[playerItem].Id,
                                    name = playerList[playerItem].Name,
                                    lastName = playerList[playerItem].LastName,
                                    dob = playerList[playerItem].DOB,
                                    teamId = playerList[playerItem].TeamId.Name,
                                    number = playerList[playerItem].Number,
                                    position = playerList[playerItem].Position,
                                    status = playerList[playerItem].Status
                                };
                                newPlayerList.Add(gameObj);
                                playerItem++;
                            }
                            dataList.DataSource = newPlayerList;
                        }
                        else
                        {
                            MessageBox.Show("there are 0 entries");
                        }
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
