using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsteClasroom.ogretmenAnaSayfa
{
    public partial class ogretmenSiniflarim : System.Web.UI.Page
    {
        Baglan bg = new Baglan();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bg.baglanti();
                SqlCommand komut = new SqlCommand("select * from tbl_Sinif where ogretmenID=@ogretmenID", bg.baglanti());
                komut.Parameters.AddWithValue("@ogretmenID", Session["OgretmenID"]);
                SqlDataReader dr = komut.ExecuteReader();
                dt_List.DataSource = dr;
                dt_List.DataBind();
                bg.baglantikes();
            }
            catch (Exception)
            {
            }

        }
    }
}