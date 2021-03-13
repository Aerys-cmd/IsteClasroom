using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsteClasroom
{
    public partial class OdevDetay : System.Web.UI.Page
    {
        Baglan bg = new Baglan();
        static String odevID = "";
        static DateTime tarih;
        static bool kayitVar = true;
        static string eskikayit = "";
        String[] uzantilar = { ".doc", ".docx", ".7z", ".zip", ".rar", ".pptx", ".txt",".pdf"};
        protected void Page_Load(object sender, EventArgs e)
        {
            if (lbl_Uzanti.Text== "İzin verilen uzantılar : ")
            {
                foreach (var a in uzantilar)
                {
                    lbl_Uzanti.Text += " " + a;
                }
            }
           
            
            odevID = Request.QueryString["OdevID"];
            if (odevID!=null)
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Odev where ID="+odevID, bg.baglanti());   
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lbl_odevKonu.Text = dt.Rows[0][2].ToString();
                    lbl_odevAd.Text = dt.Rows[0][3].ToString();
                    lbl_teslimTarih.Text = dt.Rows[0][4].ToString();
                    tarih = Convert.ToDateTime(dt.Rows[0][4]);
                    bg.baglantikes();
                    ////////////////////////////////////////////////////////////////////////////////////////////////////
                    SqlDataAdapter da1 = new SqlDataAdapter("select zamanindaTeslim,Puan,dosyaYolu from tbl_odevTeslim where odevID=@odevID and ogrenciID=@ogrenciID", bg.baglanti());
                    da1.SelectCommand.Parameters.Add("@odevID", SqlDbType.Int);
                    da1.SelectCommand.Parameters.Add("@ogrenciID", SqlDbType.Int);
                    da1.SelectCommand.Parameters["@odevID"].Value = Convert.ToInt32(odevID);
                    da1.SelectCommand.Parameters["@ogrenciID"].Value = Convert.ToInt32(Session["OgrID"]);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count==0)
                    {
                        kayitVar = false;
                        lbl_zamanındaTeslim.Text = "-";
                        lbl_Puan.Text = "-";
                        lbl_teslimDurum.Text = " Hayır";
                        btn_odevTeslim.Text = "Ödev Yükle";
                    }
                    else
                    {
                        kayitVar = true;
                        eskikayit = dt1.Rows[0][2].ToString();
                        btn_odevTeslim.Text = "Gönderimi Düzenle";
                        lbl_teslimDurum.Text = " Evet";
                        if (dt1.Rows[0][0].ToString()=="1")
                        {
                            lbl_zamanındaTeslim.Text = "Evet";
                        }
                        else
                        {
                            lbl_zamanındaTeslim.Text = "Hayır";
                        }
                        if (dt1.Rows[0][1].ToString()=="-1")
                        {
                            lbl_Puan.Text = "Puanlandırılmadı.";
                        }
                        else
                        {
                            lbl_Puan.Text = dt1.Rows[0][1].ToString();
                        }
                    }                   
                    bg.baglantikes();

                }
                catch (Exception) {}
               
               

            }
            

        }

        protected void btn_odevTeslim_Click(object sender, EventArgs e)
        {
            int zamanindaTeslim = 0;
            int sonuc = DateTime.Compare(DateTime.Now, tarih);
            if (sonuc < 0)
                zamanindaTeslim = 1;
            else if (sonuc > 0)
                zamanindaTeslim = 0;
            else
                zamanindaTeslim = 1;                                                              
            string dy = "";
            if (dosyaYukle.HasFile)
            {
                String dosyauzantisi = System.IO.Path.GetExtension(dosyaYukle.FileName).ToLower();
                

                for (int i = 0; i < uzantilar.Length; i++)
                {
                    if (dosyauzantisi == uzantilar[i])
                    {
                        var dateAndTime = DateTime.Now;
                        var date = dateAndTime.Date;
                        dy =date.ToString("ddMMyyyy").Replace(".", "-") + dosyaYukle.FileName.ToLower();
                        break;
                    }
                }
            }
            if (dy != "")
            {
                if (kayitVar==false)
                {
                    try
                    {
                        bg.baglanti();
                        string kayit = "insert into tbl_odevTeslim(OdevID,OgrenciID,dosyaYolu,teslimZaman,zamanindaTeslim) values (@OdevID,@OgrenciID,@dosyaYolu,@teslimZaman,@zamanindaTeslim)";
                        SqlCommand komut = new SqlCommand(kayit, bg.baglanti());
                        komut.Parameters.AddWithValue("@OdevID", odevID);
                        komut.Parameters.AddWithValue("@OgrenciID", Session["OgrID"]);
                        komut.Parameters.AddWithValue("@dosyaYolu", dy);
                        komut.Parameters.AddWithValue("@teslimZaman", DateTime.Now);
                        komut.Parameters.AddWithValue("@zamanindaTeslim", zamanindaTeslim);
                        komut.ExecuteNonQuery();
                        bg.baglantikes();
                        dosyaYukle.SaveAs(Server.MapPath("~/Odevler/") + dy);
                       
                        lbl_hata.Text = "Ödev Başarıyla Teslim Edildi.";


                        Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    bg.baglanti();
                    string kayit = "UPDATE tbl_odevTeslim Set dosyaYolu = @dosyaYolu, teslimZaman = @teslimZaman,zamanindaTeslim=@zamanindaTeslim WHERE OdevID=@OdevID and OgrenciID=@OgrenciID";
                    SqlCommand komut = new SqlCommand(kayit, bg.baglanti());
                    komut.Parameters.AddWithValue("@OdevID", odevID);
                    komut.Parameters.AddWithValue("@OgrenciID", Session["OgrID"]);
                    komut.Parameters.AddWithValue("@dosyaYolu", dy);
                    komut.Parameters.AddWithValue("@teslimZaman", DateTime.Now);
                    komut.Parameters.AddWithValue("@zamanindaTeslim", zamanindaTeslim);
                    komut.ExecuteNonQuery();
                    bg.baglantikes();
                    dosyaYukle.SaveAs(Server.MapPath("~/Odevler/") + dy);
                    File.Delete(MapPath("~/Odevler/" + eskikayit)); 
                    //Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                    lbl_hata.Text = "Gönderim Başarıyla Düzenlendi.";
                    // Page.Response.Write("<script>alert('Gönderim başarıyla düzenlendi')</script>");

                }


            }
        }
              
    }
}