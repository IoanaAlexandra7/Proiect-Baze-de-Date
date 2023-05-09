using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace ProiectBD
{//Onofrei Ioana Alexandra, grupa 3132B
    public partial class Form2 : Form
    {
        private static string CONNECTION_STRING = "Data Source=80.96.123.131/ora09;User Id=hr;Password=oracletest;";
        

        public Form2()
        {
            InitializeComponent();
        }

        
        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);

                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                String sqlCommand = "INSERT INTO VenituriIAO  (IDVenit, SursaVenit, SumaVenit, DataVenit) VALUES";
                sqlCommand += "('" + int.Parse(textIDV.Text) + "','" + textSursa.Text + "','" + textSuma.Text + "','" + textData.Text + "')";

                MessageBox.Show(sqlCommand);

                cmd.CommandText = sqlCommand;

                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {
                    MessageBox.Show("Adaugat!");
                    textIDV.Clear();
                    textSursa.Clear();
                    textSuma.Clear();
                    textData.Clear();
                }
                else
                {
                    MessageBox.Show("Eroare");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);

                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;


                String sqlCommand = "UPDATE VenituriIAO  set SursaVenit  = '";
                sqlCommand += textSursa.Text + "'";
                sqlCommand += ", SumaVenit = '" + textSuma.Text + "'";

                sqlCommand += " where IDVenit = " + textIDV.Text;

             
                cmd.CommandText = sqlCommand;

                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {
                    MessageBox.Show("Actualizat!");
                }
                else
                {
                    MessageBox.Show("Error");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Close();
            this.Close();
            this.Close();
            this.Close();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);
                int Delete = Convert.ToInt32(textSterg.Text);

                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                String sqlCommand = "DELETE FROM VenituriIAO WHERE IDVenit = '";
                sqlCommand += Delete + "'";

                cmd.CommandText = sqlCommand;

                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {
                    MessageBox.Show("Sters!");
                }
                else
                {
                    MessageBox.Show("Eroare");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(CONNECTION_STRING);
            conn.Open();
            OracleDataAdapter oda = new OracleDataAdapter("select * from VenituriIAO", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        
    }
}
