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
    public partial class duyuruPanel : System.Web.UI.Page
    {
        Baglan bg = new Baglan();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                PopulateGridview();
            }

        }

        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();


            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from tbl_Duyuru where sinifID=@sinifID", bg.baglanti());
            sqlDa.SelectCommand.Parameters.Add("@sinifID", SqlDbType.Int);
            sqlDa.SelectCommand.Parameters["@sinifID"].Value = Session["SinifID"];
            sqlDa.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvDuyuru.DataSource = dtbl;
                gvDuyuru.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvDuyuru.DataSource = dtbl;
                gvDuyuru.DataBind();
                gvDuyuru.Rows[0].Cells.Clear();
                gvDuyuru.Rows[0].Cells.Add(new TableCell());
                gvDuyuru.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvDuyuru.Rows[0].Cells[0].Text = "Veri Bulunamadı .....!";
                gvDuyuru.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }



        }

        protected void gvDuyuru_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {

                    if ((gvDuyuru.FooterRow.FindControl("ft_Duyuru") as TextBox).Text.Trim()!="")
                    {
                        string query = "INSERT INTO tbl_Duyuru (sinifID,Duyuru,duyuruTarih) VALUES (@sinifID,@Duyuru,@duyuruTarih)";
                        SqlCommand sqlCmd = new SqlCommand(query, bg.baglanti());
                        sqlCmd.Parameters.AddWithValue("@Duyuru", (gvDuyuru.FooterRow.FindControl("ft_Duyuru") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@duyuruTarih", DateTime.Now);
                        sqlCmd.Parameters.AddWithValue("@sinifID", Session["SinifID"]);
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "Kayıt başarıyla eklendi";
                        lblErrorMessage.Text = "";
                    }
                    else
                    {
                        lblSuccessMessage.Text = "";
                        lblErrorMessage.Text = "Hatalı giriş..";
                    }
                   

                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void gvDuyuru_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDuyuru.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvDuyuru_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDuyuru.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvDuyuru_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                string query = "UPDATE tbl_Duyuru SET Duyuru=@Duyuru WHERE ID = @id";
                SqlCommand sqlCmd = new SqlCommand(query, bg.baglanti());
                sqlCmd.Parameters.AddWithValue("@Duyuru", (gvDuyuru.Rows[e.RowIndex].FindControl("txt_Duyuru") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvDuyuru.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvDuyuru.EditIndex = -1;
                PopulateGridview();
                lblSuccessMessage.Text = "Seçili satır başarıyla güncellendi.";
                lblErrorMessage.Text = "";

            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvDuyuru_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try

            { 
                string query = "DELETE FROM tbl_Duyuru WHERE ID = @id";
                SqlCommand sqlCmd = new SqlCommand(query, bg.baglanti());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvDuyuru.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                bg.baglantikes();
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