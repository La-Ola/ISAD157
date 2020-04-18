using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ISAD157
{
    public partial class DBConnect : Form
    {
        public DBConnect()
        {
            InitializeComponent();
        }
        //event listener for dropdown to be selected
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            //toConnect = the string needed to acess the database within the server
            string toConnect = "SERVER=" + Credentials.SERVER + ";" +
                    "DATABASE=" + Credentials.DATABASE_NAME + ";" + "UID=" +
                    Credentials.USER_NAME + ";" + "PASSWORD=" +
                    Credentials.PASSWORD + ";" + "SslMode=" +
                    Credentials.SslMode + ";";

            //conditions for if the first option of drop down is selected
            if (comboBox.SelectedIndex == 0)
            {
                //sets up the connection between here and the SQLdatabase
                using (MySqlConnection connection =
                    new MySqlConnection(toConnect))
                {
                    //this query selects all information held within the users table
                    string userQuery = "SELECT * FROM isad157_sskinner.user";

                    //opens connection allowing for data retreival
                    connection.Open();

                    //SQL query has been sent, ready for execution
                    MySqlCommand command =
                        new MySqlCommand(userQuery, connection);

                    //MySQLAdapter is a set of commands that are used to fill a data set (and update it)
                    MySqlDataAdapter sqlDA =
                        new MySqlDataAdapter(command);
                    DataTable user =
                        new DataTable();
                    sqlDA.Fill(user);

                    //binds the user table the grid view
                    dataGridView.DataSource = user;
                    // end of user display.
                }
            }

            else if (comboBox.SelectedIndex == 1)
            {
                using (MySqlConnection connection =
                    new MySqlConnection(toConnect))
                {
                    string friendQuery = "SELECT * FROM isad157_sskinner.friendships";

                    connection.Open();

                    MySqlCommand command =
                        new MySqlCommand(friendQuery, connection);

                    MySqlDataAdapter sqlDA =
                        new MySqlDataAdapter(command);
                    DataTable friendship =
                        new DataTable();
                    sqlDA.Fill(friendship);

                    dataGridView.DataSource = friendship;
                }
            }

            else if (comboBox.SelectedIndex == 2)
            {
                using (MySqlConnection connection =
                    new MySqlConnection(toConnect))
                {
                    string messageQuery = "SELECT * FROM isad157_sskinner.messages";

                    connection.Open();

                    MySqlCommand command =
                        new MySqlCommand(messageQuery, connection);

                    MySqlDataAdapter sqlDA =
                        new MySqlDataAdapter(command);
                    DataTable message =
                        new DataTable();
                    sqlDA.Fill(message);

                    dataGridView.DataSource = message;
                }
            }
        }

    }
}
