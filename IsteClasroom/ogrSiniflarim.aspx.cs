using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsteClasroom
{
    public partial class ogrSiniflarim : System.Web.UI.Page
    {
        Baglan bg = new Baglan();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bg.baglanti();
                SqlCommand komut = new SqlCommand("select * from tbl_Sinif where ID in (Select sinifID from tbl_ogrenciSinif where ogrenciID=@OgrID)", bg.baglanti());
                komut.Parameters.AddWithValue("@OgrID", Session["OgrID"]);
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