using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TiendaWeb.Models;

namespace TiendaWeb.Repository
{
    public class ProductoRepository
    {



        public List<Producto> getProductoAll()
        {

            List<Producto> x = new List<Producto>();

            string connString = "Data Source=localhost;Initial Catalog=TiendaBD; Integrated Security=True";
                                     //0 ,1         ,2
            string sqlString = "Select Id,Referencia,Precio From Producto ";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        try
                        {
                            Producto p1 = new Producto();

                            p1.Id = Convert.ToInt32(reader[0].ToString());
                            p1.Referencia = reader[1].ToString();

                            if (!reader.IsDBNull(2))
                            {
                                p1.Precio = Convert.ToDecimal(reader[2].ToString());
                            }

                               

                            x.Add(p1);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        
                    }
                    reader.Close();
                }
            }
            return x;                       
        }

    //      este es el mock
   //     public List<Producto> getProductoAll()
   //     {
   //         List<Producto> x = new List<Producto>();
   //
   //         Producto w = new Producto();
   //         w.Id = 1;
   //         w.Referencia = "gggg";
   //         w.Precio = 2222;
   //         Producto z = new Producto();
   //         z.Id = 2;
   //         z.Referencia = "tttt";
   //         z.Precio = 3333;
   //
   //         x.Add(w);
   //         x.Add(z);
   //         return x;
   //     }
    }
}