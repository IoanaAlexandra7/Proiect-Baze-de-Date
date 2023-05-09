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
{ //Onofrei Ioana Alexandra, grupa 3132B   
    public partial class Form3 : Form

    {   private static string CONNECTION_STRING = "Data Source=80.96.123.131/ora09;User Id=hr;Password=oracletest;";

        public Form3()
        {
            InitializeComponent();
        }

       
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);

                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                String sqlCommand = "INSERT INTO CheltuieliIAO  (IDCheltuieli, IDVenit, TipCheltuieli, CategorieCheltuieli, SumaCheltuieli, SumaRamasa, DataCheltuieli) VALUES";
                sqlCommand += "('" + int.Parse(textIDChelt.Text) + "','" + textIDVc.Text + "','" + textTipChelt.Text +"','" + textCatChelt.Text + "','" + textSumaC.Text  + "','" + textRamasaS.Text + "','" + textDataC.Text +"')";
                
                MessageBox.Show(sqlCommand);

                cmd.CommandText = sqlCommand;

                int rezult = cmd.ExecuteNonQuery();
                if (rezult > 0)
                {
                    MessageBox.Show("Adaugat!");
                    textIDChelt.Clear();
                    textIDVc.Clear();
                    textCatChelt.Clear();
                    textSumaC.Clear();
                    textTipChelt.Clear();
                    textRamasaS.Clear();
                    textDataC.Clear();
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

        private void Button2_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(CONNECTION_STRING);
            conn.Open();
            OracleDataAdapter oda = new OracleDataAdapter("select * from CheltuieliIAO", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);

                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;


                String sqlCommand = "UPDATE CheltuieliIAO set TipCheltuieli   = '";
                sqlCommand += textTipChelt.Text + "'";
                sqlCommand += " where IDCheltuieli  = " + textIDChelt.Text;



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

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection(CONNECTION_STRING);
                int Delete = Convert.ToInt32(textSterg.Text);

                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                String sqlCommand = "DELETE FROM CheltuieliIAO WHERE IDCheltuieli = '";
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
        
        private void Button1_Click(object sender, EventArgs e)
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


                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                OracleDataAdapter oda = new OracleDataAdapter("" +
                    "SELECT CategorieCheltuieli, SumaCheltuieli " +
                    "FROM CheltuieliIAO " +
                    "WHERE SumaCheltuieli > 100 " +
                    "AND TipCheltuieli = 'Secundara'", conn);

                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Exceptie" + ex.Message);
            }
        }
    }
}
