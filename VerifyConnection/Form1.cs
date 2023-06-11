using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public string strConexion = string.Empty;
        public string mensaje = string.Empty;
        public static string titulo = "VerifyConnection";
        public bool MySQl()
        {
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(strConexion);
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
        public bool SQLServer()
        {
            SqlConnection cnn;           
            try
            {
                cnn = new SqlConnection(strConexion);
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
        public bool Oracle()
        {
            OracleConnection cnn;      
            try
            {
                cnn = new OracleConnection(strConexion);
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnTestConexion_Click(object sender, EventArgs e)
        {
            strConexion = txtConnectionstring.Text.Trim();
            string bd = cboBD.Text.Trim();
            if (!string.IsNullOrEmpty(strConexion) && !string.IsNullOrEmpty(bd))
            {
                switch (bd)
                {
                    case "ORACLE":
                        mensaje = (Oracle()) ? "Conexion Exitosa" : mensaje;
                        MessageBox.Show(mensaje, titulo);
                        break;
                    case "MySQL":
                        mensaje = (MySQl()) ? "Conexion Exitosa" : mensaje;
                        MessageBox.Show(mensaje, titulo);
                        break;
                    case "SQL Server":
                        mensaje = (SQLServer()) ? "Conexion Exitosa" : mensaje;
                        MessageBox.Show(mensaje, titulo);
                        break;
                    default:
                        
                        break;
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", titulo);
            }

        }
    }
}
