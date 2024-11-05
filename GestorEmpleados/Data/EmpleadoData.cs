
using Microsoft.EntityFrameworkCore;
using MiWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiWebAPI.Data
{
    public class EmpleadoData
    {

        private readonly string conexion;
        public EmpleadoData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }


        ///// <summary>
        ///// Add empleado
        ///// </summary>
        ///// <param name="aggregate"></param>
        ///// <returns></returns>
        ///// <exception cref="CustomException"></exception>
        //public async Task<RespuestaDB> AddEmpleadoAsync(Empleado aggregate)
        //{
        //    try
        //    {
        //        var Mensaje  = new SqlParameter
        //        {
        //            ParameterName = "Resultado",
        //            SqlDbType = SqlDbType.VarChar,
        //            Size = 100,
        //            Direction = ParameterDirection.Output
        //        };
        //        var TipoError = new SqlParameter
        //        {
        //            ParameterName = "TipoError",
        //            SqlDbType = SqlDbType.Int,
        //            Direction = ParameterDirection.Output
        //        };
        //        SqlParameter[] parameters =
        //        {
        //                new SqlParameter("nombre", aggregate.Nombre),
        //                new SqlParameter("apellidoPaterno", aggregate.ApellidoPaterno),
        //                new SqlParameter("apellidoMaterno", aggregate.ApellidoMaterno),
        //                new SqlParameter("correo", aggregate.Correo),
        //                new SqlParameter("sueldo", aggregate.Sueldo),
        //                new SqlParameter("fechaContrato", aggregate.FechaContrato),
        //                Mensaje,
        //                TipoError
        //        };
        //        string sqlQuery = "EXEC [dbo].[sp_empleado_agrega] @nombre,@apellidoPaterno, @apellidoMaterno, @correo, @sueldo, @fechaContrato, @TipoError OUTPUT, @Mensaje OUTPUT";
        //        var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
        //        return dataSP.FirstOrDefault();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Consulta lista de empleados
        ///// </summary>
        ///// <returns></returns>
        //public async Task<List<Empleado>> GetEmpleados()
        //{
        //    List<Empleado> lista = new List<Empleado>();

        //    using (var con = new SqlConnection(conexion))
        //    {
        //        await con.OpenAsync();
        //        SqlCommand cmd = new SqlCommand("sp_empleado_selecciona", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        using (var reader = await cmd.ExecuteReaderAsync())
        //        {
        //            while (await reader.ReadAsync()) {
        //                lista.Add(new Empleado
        //                {
        //                    Id = Convert.ToInt32(reader["Id"]),
        //                    Nombre = reader["Nombre"].ToString(),
        //                    ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
        //                    ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
        //                    Correo = reader["Correo"].ToString(),
        //                    Sueldo = Convert.ToDecimal(reader["Sueldo"]),
        //                    FechaContrato = reader["FechaContrato"].ToString()
        //                });
        //            }
        //        }
        //    }
        //    return lista;
        //}


        /// <summary>
        /// Agrega un empleado
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public async Task<bool> AddEmpleado(Empleado objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_empleado_agrega", con);
                cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@apellidoPaterno", objeto.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@apellidoMaterno", objeto.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@sueldo", objeto.Sueldo);
                cmd.Parameters.AddWithValue("@fechaContrato", objeto.FechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            return respuesta;
        }

        ///// <summary>
        ///// Actualiza un empleado
        ///// </summary>
        ///// <param name="objeto"></param>
        ///// <returns></returns>
        //public async Task<bool> UpdateEmpleado(Empleado objeto)
        //{
        //    bool respuesta = true;

        //    using (var con = new SqlConnection(conexion))
        //    {

        //        SqlCommand cmd = new SqlCommand("sp_empleado_actualizar", con);
        //        cmd.Parameters.AddWithValue("@id", objeto.Id);
        //        cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
        //        cmd.Parameters.AddWithValue("@appellidoPaterno", objeto.ApellidoPaterno);
        //        cmd.Parameters.AddWithValue("@apellidoMaterno", objeto.ApellidoMaterno);
        //        cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
        //        cmd.Parameters.AddWithValue("@Sueldo", objeto.Sueldo);
        //        cmd.Parameters.AddWithValue("@FechaContrato", objeto.FechaContrato);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            await con.OpenAsync();
        //            respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
        //        }
        //        catch
        //        {
        //            respuesta = false;
        //        }
        //    }
        //    return respuesta;
        //}

        ///// <summary>
        ///// Elimina un empleado
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<bool> DeleteEmpleado(int id)
        //{
        //    bool respuesta = true;

        //    using (var con = new SqlConnection(conexion))
        //    {

        //        SqlCommand cmd = new SqlCommand("sp_empleado_eliminar", con);
        //        cmd.Parameters.AddWithValue("@id", id);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            await con.OpenAsync();
        //            respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
        //        }
        //        catch
        //        {
        //            respuesta = false;
        //        }
        //    }
        //    return respuesta;
        //}
    }
}
