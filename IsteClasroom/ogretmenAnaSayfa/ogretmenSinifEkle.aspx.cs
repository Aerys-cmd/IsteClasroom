using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsteClasroom.ogretmenAnaSayfa
{
    public partial class ogretmenSinifEkle : System.Web.UI.Page
    {
        Baglan bg = new Baglan();
        string[] KodHarfler = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z","0","1","2","3","4","5","6","7","8","9" };
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Ekle_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            String kod = "";
            for (int i = 0; i < 5; i++)
            {
                kod += KodHarfler[rand.Next(36)];
            }
            bg.baglanti();
            string kayit2 = "select ID from tbl_Sinif where sinifKod=@Kod";
            SqlCommand komut2 = new SqlCommand(kayit2, bg.baglanti());
            komut2.Parameters.AddWithValue("@Kod", kod);
            SqlDataReader dr2 = komut2.ExecuteReader();
            bg.baglantikes();
            if (dr2.HasRows)
            {
                lbl_Hata.Text = "Bir hata oluştu lütfen tekrar deneyiniz";
            }
            else
            {
                bg.baglanti();
                string kayit1 = "insert into tbl_Sinif(ogretmenID,sinifAd,sinifKod) values (@ogretmenID,@sinifAd,@sinifKod)";
                SqlCommand komut1 = new SqlCommand(kayit1, bg.baglanti());
                komut1.Parameters.AddWithValue("@OgretmenID", Session["OgretmenID"]);
                komut1.Parameters.AddWithValue("@sinifAd", txt_sinifAd.Text);
                komut1.Parameters.AddWithValue("@sinifKod", kod);
                komut1.ExecuteNonQuery();
                bg.baglantikes();
                lbl_Hata.Text = "Sınıf Başarıyla Oluşturuldu. Sınıf Kodu : "+kod;
            }

        }
    }
}