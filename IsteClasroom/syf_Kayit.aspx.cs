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
    public partial class syf_Kayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        Baglan bg = new Baglan();
                protected void btn_ogrenciKayit(object sender, EventArgs e)
        {

            try
            {
                
                    bg.baglanti();
                    string kayit = "insert into tbl_Ogrenci(Ad,Soyad,Email,Parola) values (@Ad,@Soyad,@Email,@Parola)";
                    SqlCommand komut = new SqlCommand(kayit, bg.baglanti());
                    komut.Parameters.AddWithValue("@Ad", txt_ogrenciAd.Text);
                    komut.Parameters.AddWithValue("@Soyad", txt_ogrenciSoyad.Text);
                    komut.Parameters.AddWithValue("@Email", txt_ogrenciEmail.Text);
                    komut.Parameters.AddWithValue("@Parola", txt_ogrKayitParola.Text);
                    komut.ExecuteNonQuery();
                    bg.baglantikes();
                    lbl_ogrenciHata.Text = "Kayıt işlemi başarılı.Giriş sayfasına yönlendiriliyorsunuz. ";
                    Response.Redirect("syf_Giris.aspx");    
            }
            catch (Exception hata)
            {
                lbl_ogrenciHata.Text = "Kayıt işlemi başarısız oldu.Lütfen girdiğiniz bilgileri kontrol edin.  "+hata;
            }
           
        }
    }
}