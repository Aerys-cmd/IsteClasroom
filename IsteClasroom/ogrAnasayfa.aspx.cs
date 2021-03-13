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
   
    public partial class ogrAnasayfa : System.Web.UI.Page
    {
        Baglan bg = new Baglan();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Katil_Click(object sender, EventArgs e)
        {
            int snf_ID = 0;
            try
            {
                    bg.baglanti();
                    string kayit = "select ID from tbl_Sinif where sinifKod=@Kod";
                    SqlCommand komut = new SqlCommand(kayit, bg.baglanti());
                    komut.Parameters.AddWithValue("@Kod", txt_sinifKod.Text);
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0] == null) { }
                        else {snf_ID = Convert.ToInt32(dr[0]);}             
                        
                    }
                bg.baglantikes();
                bg.baglanti();
                string kayit2 = "select ID from tbl_ogrenciSinif where sinifID=@sinifID and ogrenciID=@ogrID";
                SqlCommand komut2 = new SqlCommand(kayit2, bg.baglanti());
                komut2.Parameters.AddWithValue("@sinifID", snf_ID);
                komut2.Parameters.AddWithValue("@ogrID", Session["OgrID"]);
                SqlDataReader dr2 = komut2.ExecuteReader();
                bg.baglantikes();
                if (dr2.HasRows)
                {
                    lbl_Hata.Text = "Daha önce katıldığınız bir sınıfa katılamazsınız.";
                   
                }
                else
                {
                    if (snf_ID != 0)
                    {
                        bg.baglanti();
                        string kayit1 = "insert into tbl_ogrenciSinif(ogrenciID,sinifID) values (@ogrenciID,@sinifID)";
                        SqlCommand komut1 = new SqlCommand(kayit1, bg.baglanti());
                        komut1.Parameters.AddWithValue("@ogrenciID", Session["OgrID"]);
                        komut1.Parameters.AddWithValue("@sinifID", snf_ID);
                        komut1.ExecuteNonQuery();
                        bg.baglantikes();
                        lbl_Hata.Text = "Sınıfa Başarıyla Katıldınız.";                    }
                    else
                    {
                        lbl_Hata.Text = "Sınıf Kodu Hatalı ! ";
                    }
                }
               

               
            }
            catch (Exception hata )
            {

                lbl_Hata.Text = "Bir sorunla karşılaştık.Lütfen Sınıf kodunu kontrol ediniz.  " + hata.ToString(); 
            }
           

        }
    }
}