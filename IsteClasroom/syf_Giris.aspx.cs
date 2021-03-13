using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsteClasroom
{
    public partial class syf_Giris : System.Web.UI.Page
    {
        Baglan bg = new Baglan();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ogretmenGiris(object sender, EventArgs e)
        {
            try
            {
                bg.baglanti();
                SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Ogretmen where Email=@email and Parola=@parola", bg.baglanti());
                da.SelectCommand.Parameters.Add("@email", SqlDbType.NVarChar, 25);
                da.SelectCommand.Parameters.Add("@parola", SqlDbType.NVarChar, 40);
                da.SelectCommand.Parameters["@email"].Value = txt_ogretmenMail.Text;
                da.SelectCommand.Parameters["@parola"].Value = txt_ogretmenParola.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    lbl_ogretmenHata.Text = "Giriş Başarılı";                
                    Session.Add("OgretmenID", dt.Rows[0][0]);
                    //Response.Write("<script>alert('Uyarı Mesajın')/script>");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Giriş Başarılı.');", true);
                    Response.Redirect("ogretmenAnaSayfa/ogretmenSinifEkle.aspx");

                }
                else
                {
                    lbl_ogretmenHata.Text = "Hatalı Giriş Yaptınız!";
                }
                bg.baglantikes();
            }
            catch (Exception hata)
            {

                lbl_ogretmenHata.Text = "Bir hata ile karşılaşıldı. Lütfen girdiğiniz bilgileri kontrol ediniz" + hata;
            }
        }

        protected void btn_ogrenciGiris(object sender, EventArgs e)
        {
         
            try
            {
                bg.baglanti();
                SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Ogrenci where Email=@email and Parola=@parola", bg.baglanti());
                da.SelectCommand.Parameters.Add("@email", SqlDbType.NVarChar, 25);
                da.SelectCommand.Parameters.Add("@parola", SqlDbType.NVarChar, 40);
                da.SelectCommand.Parameters["@email"].Value = txt_ogrenciMail.Text;
                da.SelectCommand.Parameters["@parola"].Value = txt_ogrenciParola.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    lbl_ogrenciHata.Text = "Giriş Başarılı";
                    Session.Add("OgrID", dt.Rows[0][0]);
                  
                    // Response.Write("<script>prompt('Giriş başarılı sayfaya yönlendiriliyorsunuz')</script>");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Giriş Başarılı.'); window.open('ogrAnasayfa.aspx');", true);
                    Response.Redirect("ogrAnasayfa.aspx");


                }
                else
                {
                    lbl_ogrenciHata.Text = "Hatalı Giriş Yaptınız!";
                }
                bg.baglantikes();
            }
            catch (Exception hata)
            {

                lbl_ogrenciHata.Text = "Bir hata ile karşılaşıldı. Lütfen girdiğiniz bilgileri kontrol ediniz" + hata;
            }
            

        }

        protected void txt_ogretmenMail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}