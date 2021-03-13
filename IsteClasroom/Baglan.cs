using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace IsteClasroom
{
    public class Baglan
    {
        public SqlConnection baglanti() {
            SqlConnection baglan = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["baglantim"].ConnectionString);
            baglan.Open();
            return baglan;

        }
        public SqlConnection baglantikes() {
            SqlConnection baglan = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["baglantim"].ConnectionString);
            baglan.Close();
            return baglan;

        }
    }
}