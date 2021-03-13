using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsteClasroom.ogretmenAnaSayfa
{

    public partial class odevEkle : System.Web.UI.Page

    {
        Baglan bg = new Baglan();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (list_Saat.Items.Count==0)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (i < 10)
                    {
                        list_Saat.Items.Add("0" + i);
                    }
                    else
                    {
                        list_Saat.Items.Add(""+i+"");
                    }

                }
            }
            
            lblErrorMessage.Text = "";
            lblSuccessMessage.Text = "";

        }
        String tarih = "";
        protected void btn_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                tarih = takvim.SelectedDate.ToString("yyyy-MM-dd ");
                tarih += list_Saat.SelectedValue.ToString() + ":00:00.000";
                DateTime tarih1 = Convert.ToDateTime(tarih);
            int sonuc = DateTime.Compare(DateTime.Now, tarih1);
                if (sonuc < 0 && Session["SinifID"] != null)
                {
                    string kayit = "insert into tbl_Odev(sinifID,odevKonu,odevBaslik,teslimTarih) values (@sinifID,@odevKonu,@odevBaslik,@teslimTarih)";
                    SqlCommand komut = new SqlCommand(kayit, bg.baglanti());
                    komut.Parameters.AddWithValue("@sinifID", Session["SinifID"]);
                    komut.Parameters.AddWithValue("@odevKonu", txt_odevKonu.Value.ToString());
                    komut.Parameters.AddWithValue("@odevBaslik", txt_odevBaslik.Text);
                    komut.Parameters.AddWithValue("@teslimTarih", tarih1.ToString("yyyy-MM-dd HH:mm:ss.FFF"));
                    komut.ExecuteNonQuery();
                    bg.baglantikes();
                    lblErrorMessage.Text = "";
                    lblSuccessMessage.Text = "Ödev başarıyla eklendi.";
                }
                else if (sonuc > 0)
                    lblErrorMessage.Text = "Seçtiğiniz tarih hatalı.";
                else
                    lblErrorMessage.Text = "Seçtiğiniz tarih hatalı.";

            }
            catch (Exception ex)
            {

                lblErrorMessage.Text = "Girdiğiniz tarihleri kontrol ediniz. Hata Kodu : " + ex.ToString();
            }
            





        }
    }
}