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
    public partial class ogretmenSinif : System.Web.UI.MasterPage
    {
        Baglan bg = new Baglan();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sinifID"]!=null)
            {
                SqlDataAdapter da = new SqlDataAdapter("select sinifAd from tbl_Sinif where ID=" + Session["sinifID"], bg.baglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                Label1.Text = dt.Rows[0][0].ToString();
                bg.baglantikes();
            }
           

        }
    }
}