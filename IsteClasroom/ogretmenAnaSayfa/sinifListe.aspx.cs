using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IsteClasroom.ogretmenAnaSayfa
{
    public partial class sinifListe : System.Web.UI.Page
    {
        Baglan bg = new Baglan();
       static string sinifID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // ogretmenSiniflarim sayfasından yönlendirme olur ise QueryString unk'den farklı olacağı için veriyi SinifID değişkenine    attık
            if (Request.QueryString["SinifID"]!="unk")
            {
                sinifID = Request.QueryString["SinifID"];
            }
           //Bu sınıftan çıkılıp başka sınıfa gidildiğini kontrol etmek için ise Session'daki değeri şuanki SınıfID ile değiştiriyoruz   
            if (Session["SinifID"] != sinifID)
            {
                Session["SinifID"] = sinifID;
            }
            else if (Session["SinifID"] == null) //Session[SınıfID] değeri null ise daha önce bu sayfaya girilmemiş anlamına gelir.Bu yüzden Session'a SınıfID eklenir.         
            {
                Session.Add("SinifID", sinifID);
            }
            else { }
           
            PopulateGridview();
        }
        void PopulateGridview()
        {
            if (Session["SinifID"]!=null)
            {
                DataTable dtbl = new DataTable();

                bg.baglanti();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select tbl_Ogrenci.Ad,tbl_Ogrenci.Soyad,tbl_ogrenciSinif.ID from tbl_ogrenciSinif INNER JOIN tbl_Ogrenci on tbl_ogrenciSinif.ogrenciID=tbl_Ogrenci.ID where tbl_ogrenciSinif.sinifID=@SinifID", bg.baglanti());
                sqlDa.SelectCommand.Parameters.Add("@SinifID", SqlDbType.Int);
                sqlDa.SelectCommand.Parameters["@SinifID"].Value =Convert.ToInt32( Session["SinifID"]);
                sqlDa.Fill(dtbl);
                bg.baglantikes();
                if (dtbl.Rows.Count > 0)
                {
                    sinif_List.DataSource = dtbl;
                    sinif_List.DataBind();
                }
                else
                {

                    dtbl.Rows.Add(dtbl.NewRow());
                    sinif_List.DataSource = dtbl;
                    sinif_List.DataBind();
                    sinif_List.Rows[0].Cells.Clear();
                    sinif_List.Rows[0].Cells.Add(new TableCell());
                    sinif_List.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                    sinif_List.Rows[0].Cells[0].Text = "Veri Bulunamadı .....!";
                    sinif_List.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
           

        }
      
      
    }
}