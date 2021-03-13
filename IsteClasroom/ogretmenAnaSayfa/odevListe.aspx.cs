using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace IsteClasroom.ogretmenAnaSayfa
{
    public partial class odevListe : System.Web.UI.Page
    {
        Baglan bg = new Baglan();
        static string odevID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            odevID = Request.QueryString["OdevID"];
            if (!IsPostBack)
            {
                PopulateGridview();
            }
           
        }

        void PopulateGridview()
        {
            if (odevID!=null)
            {
                DataTable dtbl = new DataTable();


                SqlDataAdapter sqlDa = new SqlDataAdapter("select tbl_odevTeslim.ID,tbl_Ogrenci.Ad,tbl_Ogrenci.Soyad,tbl_odevTeslim.teslimZaman,tbl_odevTeslim.zamanindaTeslim,tbl_odevTeslim.Puan,tbl_odevTeslim.dosyaYolu from tbl_odevTeslim INNER JOIN tbl_Ogrenci on tbl_odevTeslim.ogrenciID=tbl_Ogrenci.ID where tbl_odevTeslim.odevID=@odevID", bg.baglanti());
                sqlDa.SelectCommand.Parameters.Add("@odevID", SqlDbType.Int);
                sqlDa.SelectCommand.Parameters["@odevID"].Value = odevID;
                sqlDa.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    gvOdev.DataSource = dtbl;
                    gvOdev.DataBind();
                }
                else
                {

                    dtbl.Rows.Add(dtbl.NewRow());
                    gvOdev.DataSource = dtbl;
                    gvOdev.DataBind();
                    gvOdev.Rows[0].Cells.Clear();
                    gvOdev.Rows[0].Cells.Add(new TableCell());
                    gvOdev.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                    gvOdev.Rows[0].Cells[0].Text = "Veri Bulunamadı .....!";
                    gvOdev.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }

            }



        }

       
        protected void gvOdev_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOdev.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvOdev_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOdev.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvOdev_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                String not = (gvOdev.Rows[e.RowIndex].FindControl("txt_Puan") as TextBox).Text.Trim();
                   
                
                if (Convert.ToInt32(not)<=100 && Convert.ToInt32(not) >= 0)
                {
                    string query = "UPDATE tbl_odevTeslim SET Puan=@Puan WHERE ID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, bg.baglanti());
                    sqlCmd.Parameters.AddWithValue("@Puan", not);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvOdev.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvOdev.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Seçili satır başarıyla güncellendi.";
                    lblErrorMessage.Text = "";
                }
                else
                {
                    lblSuccessMessage.Text = "";
                    lblErrorMessage.Text = "0 ile 100 arasında bir değer giriniz.";
                }
                    
                
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvOdev_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                string id = gvOdev.DataKeys[e.RowIndex].Value.ToString();
                SqlDataAdapter da = new SqlDataAdapter("select dosyaYolu from tbl_odevTeslim where ID=" + id, bg.baglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                String dosyaYolu = dt.Rows[0][0].ToString();

                bg.baglantikes();
                string query = "DELETE FROM tbl_odevTeslim WHERE ID = @id";
                SqlCommand sqlCmd = new SqlCommand(query, bg.baglanti());
                sqlCmd.Parameters.AddWithValue("@id",id);
                sqlCmd.ExecuteNonQuery();
                bg.baglantikes();
                File.Delete(MapPath("~/Odevler/" + dosyaYolu)); //Dosyanın veriyolunu veritabanından kaldırdıktan sonra dosyanın kendisinide kaldırıyoruz.
                PopulateGridview();

                lblSuccessMessage.Text = "Seçilen satır başarıyla kaldırıldı.";
                lblErrorMessage.Text = "";

            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}
