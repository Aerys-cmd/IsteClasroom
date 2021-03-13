using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsteClasroom
{
    public partial class SinifDetay : System.Web.UI.Page
    {
        Baglan bg = new Baglan();
        String sinifID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sinifID = Request.QueryString["SinifID"];
            if (sinifID != null)
            {
               
            try
            {
                bg.baglanti();
                SqlCommand komut = new SqlCommand("select * from tbl_Duyuru where sinifID=@sinifID", bg.baglanti());
                komut.Parameters.AddWithValue("@sinifID", sinifID);
                SqlDataReader dr = komut.ExecuteReader();      
                dtListDuyuru.DataSource = dr;
                dtListDuyuru.DataBind();
                bg.baglantikes();

                    bg.baglanti();
                    SqlDataAdapter da = new SqlDataAdapter("select sinifAd from tbl_Sinif where ID="+sinifID, bg.baglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lbl_SinifAd.Text = dt.Rows[0][0].ToString();                   
                    bg.baglantikes();
                }
            catch (Exception)
            {
            }
                try
                {
                    bg.baglanti();
                    SqlCommand komut = new SqlCommand("select * from tbl_Odev where sinifID=@sinifID", bg.baglanti());
                    komut.Parameters.AddWithValue("@sinifID", sinifID);
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