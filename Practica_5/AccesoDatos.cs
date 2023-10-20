using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Windows.Media;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Reflection.Metadata;

namespace Practica_5
{
    public class AccesoDatos
    {
        String myConnectionString = "server=localhost;" +
            "port=3306;" +
            "user=root;" +
            "database=sakila;" +
            "password=1234;"
            ;
        MySqlConnection _conn;
        private int _numeroPeliculas;
        MySqlCommand _cmd = new MySqlCommand();
        public AccesoDatos()
        {
            try
            {
                _conn = new MySqlConnection(myConnectionString);
                _conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    public int AltaDePelicula(string title, string description, int release_year, int language_id, int original_lenguage_id, int rental_duration, double rental_rate, int length, double replacement_cost, string rating, string special_features)
    {
        int resultado = -98;
        try
        {
            _cmd = new MySqlCommand();
            _cmd.Connection = _conn;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "InsertaAltaPelicula";

            //Parametros Input

            _cmd.Parameters.AddWithValue("_title", title);
            _cmd.Parameters["_title"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_description", description);
            _cmd.Parameters["_description"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_release_year", release_year);
            _cmd.Parameters["_release_year"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_language_id", language_id);
            _cmd.Parameters["_language_id"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_original_lenguage_id", original_lenguage_id);
            _cmd.Parameters["_original_lenguage_id"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_rental_duration", rental_duration);
            _cmd.Parameters["_rental_duration"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_rental_rate", rental_rate);
            _cmd.Parameters["_rental_rate"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_length", length);
            _cmd.Parameters["_length"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_replacement_cost", replacement_cost);
            _cmd.Parameters["_replacement_cost"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_rating", rating);
            _cmd.Parameters["_rating"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_special_features", special_features);
            _cmd.Parameters["_special_features"].Direction = ParameterDirection.Input;

            //Parametros Output

            _cmd.Parameters.Add(new MySqlParameter("_res", MySqlDbType.Int32));
            _cmd.Parameters["_res"].Direction = ParameterDirection.Output;

            _cmd.ExecuteNonQuery();

            resultado = (int)_cmd.Parameters["_res"].Value;
            return resultado;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return resultado;
        }
    }
    
    public int AltaEmpleado(string first_name, string last_name, string email, int store_id, string username, string password)
    {
        int resultado = -97;
        try
        {
            _cmd = new MySqlCommand();
            _cmd.Connection = _conn;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "InsertUser";

            //Parametros Input

            _cmd.Parameters.AddWithValue("_first_name", first_name);
            _cmd.Parameters["_first_name"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_last_name", last_name);
            _cmd.Parameters["_last_name"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_email", email);
            _cmd.Parameters["_email"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_store_id", store_id);
            _cmd.Parameters["_store_id"].Direction = ParameterDirection.Input;

            _cmd.Parameters.AddWithValue("_username", username);
            _cmd.Parameters["_username"].Direction = ParameterDirection.Input;

            string passwordHash = CreateMD5(password).Substring(0, 20);

            _cmd.Parameters.AddWithValue("_password", passwordHash);      
            _cmd.Parameters["_password"].Direction = ParameterDirection.Input;

            //Parametros Output

            _cmd.Parameters.Add(new MySqlParameter("_res", MySqlDbType.Int32));
            _cmd.Parameters["_res"].Direction = ParameterDirection.Output;

            _cmd.ExecuteNonQuery();

            resultado = (int)_cmd.Parameters["_res"].Value;
            return resultado;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return resultado;
        }
    }

    public int Login(string username, string password)
        {
            int resultado = -96;
            try
            {
                
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "Login";

                _cmd.Parameters.AddWithValue("_username", username);
                _cmd.Parameters["_username"].Direction = ParameterDirection.Input;

                string pswHash = CreateMD5(password).Substring(0, 20);

                _cmd.Parameters.AddWithValue("_password", pswHash);
                _cmd.Parameters["_password"].Direction = ParameterDirection.Input;

                _cmd.Parameters.Add(new MySqlParameter("_res", MySqlDbType.Int32));
                _cmd.Parameters["_res"].Direction = ParameterDirection.Output;

                _cmd.ExecuteNonQuery();

                resultado = (int)_cmd.Parameters["_res"].Value;
                return resultado;
            }catch(Exception ex)
            {
                MessageBox.Show("Error en el login");
                return resultado;
            }
        }
    public string CreateMD5(string password)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }

    public int DameNumeroPeliculas()
        {
            int res = -98;
            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "CuentaPeliculas";

                //OUTPUT
                _cmd.Parameters.AddWithValue("_res", MySqlDbType.Int32);
                _cmd.Parameters["_res"].Direction = ParameterDirection.Output;
                _cmd.ExecuteNonQuery();
                res = (int)_cmd.Parameters["_res"].Value;
                return res;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return res;
            }           
        }

    }
}