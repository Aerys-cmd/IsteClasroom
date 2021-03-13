using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsteClasroom.ogretmenAnaSayfa
{
    public partial class ogrtOdevler : System.Web.UI.Page
    {
        Baglan bg = new Baglan();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SinifID"]!=null)
            {
                try
                {
                    bg.baglanti();
                    SqlCommand komut = new SqlCommand("select * from tbl_Odev where sinifID=@sinifID", bg.baglanti());
                    komut.Parameters.AddWithValue("@sinifID", Session["SinifID"]);
                    SqlDataReader dr = komut.ExecuteReader();
                    dtListOdev.DataSource = dr;
                    dtListOdev.DataBind();
                    bg.baglantikes();

                }
                catch (Exception)
                {
                }
            }
            
        }
    }
}