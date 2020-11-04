using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System;

namespace ClasesBase
{
    class TrabajarTicket
    {
        /// <summary>
        /// Alta Ticket con stored procedure
        /// </summary>
        /// <param name="ticket"></param>
        public static void altaTicket(Ticket ticket)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaTicket";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fechaVenta", ticket.Tick_FechaVenta);
            cmd.Parameters.AddWithValue("@cliDni", ticket.Cli_DNI);
            cmd.Parameters.AddWithValue("@butacaId", ticket.But_Id);
            cmd.Parameters.AddWithValue("@proyeccionCodigo", ticket.Proy_Codigo);
            cmd.Parameters.AddWithValue("@usuId", ticket.Usu_Id);
            cmd.Parameters.AddWithValue("@estado", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        /// <summary>
        /// Baja de ticket logica con stored procedure
        /// </summary>
        /// <param name="numeroTicket"></param>
        /// <param name="estado"></param>
        public static void bajaTicket(int numeroTicket, bool estado)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaTicket";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@numeroTicket", numeroTicket);
            cmd.Parameters.AddWithValue("@estado", estado);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
               
        /// <summary>
        /// Baja de ticket fisica con stored procedure
        /// </summary>
        /// <param name="ticketNumero"></param>
        public static void bajaTicketFisica(int ticketNumero)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaTicketFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@ticketNumero", ticketNumero);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Modificar Ticket con stored procedure
        /// </summary>
        /// <param name="ticket"></param>
        public static void modificarProyeccion(Ticket ticket)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarTicket";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@numero", ticket.Tick_Nro);
            cmd.Parameters.AddWithValue("@fechaVenta", ticket.Tick_FechaVenta);
            cmd.Parameters.AddWithValue("@cliDni", ticket.Cli_DNI);
            cmd.Parameters.AddWithValue("@butacaId", ticket.But_Id);
            cmd.Parameters.AddWithValue("@proyeccionCodigo", ticket.Proy_Codigo);
            cmd.Parameters.AddWithValue("@usuId", ticket.Usu_Id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Coleccion de Tickets
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Ticket> traerTicket()
        {
            ObservableCollection<Ticket> coleccionTicket = new ObservableCollection<Ticket>();
            Ticket ticket = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarTickets";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ticket = new Ticket();
                ticket.Tick_Estado = (bool)reader["Estado"];
                ticket.Tick_FechaVenta = (DateTime)reader["Fecha de Venta"];
                ticket.Tick_Nro = (int)reader["Numero"];
                ticket.Usu_Id = (int)reader["ID Vendedor"];
                ticket.Proy_Codigo = (int)reader["Codigo de Proyeccion"];
                ticket.Cli_DNI = (int)reader["DNI Cliente"];
                ticket.But_Id = (int)reader["ID de Butaca"];

                coleccionTicket.Add(ticket);
            }
            cnn.Close();
            return coleccionTicket;
        }


        /// <summary>
        /// Coleccion de Tickets Disponibles
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Ticket> traerTicketsDisponibles()
        {
            ObservableCollection<Ticket> coleccionTicket = new ObservableCollection<Ticket>();
            Ticket ticket = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarTicketDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ticket = new Ticket();
                ticket.Tick_Estado = (bool)reader["Estado"];
                ticket.Tick_FechaVenta = (DateTime)reader["Fecha de Venta"];
                ticket.Tick_Nro = (int)reader["Numero"];
                ticket.Usu_Id = (int)reader["ID Vendedor"];
                ticket.Proy_Codigo = (int)reader["Codigo"];
                ticket.Cli_DNI = (int)reader["DNI Cliente"];
                ticket.But_Id = (int)reader["ID de Butaca"];

                coleccionTicket.Add(ticket);
            }
            cnn.Close();
            return coleccionTicket;
        }

    }
}
