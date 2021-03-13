<%@ Page Title="" Language="C#" MasterPageFile="~/ogretmenAnaSayfa/ogretmenAnaSayfa.Master" AutoEventWireup="true" CodeBehind="ogretmenSinifEkle.aspx.cs" Inherits="IsteClasroom.ogretmenAnaSayfa.ogretmenSinifEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
     <form id="form1" runat="server">
    <div class="header"><h1>Bir sınıf ekleyin.</h1></div>  
<div style="width: 1080px;">
 <div style="float: left; width: 507px;"></div>
 <div style="float: left; width: 323px;">
     <center>
   <div class="login-box">
      <h4 class="login-text">Sınıf adı giriniz&nbsp;</h4>
      <center>
     <asp:TextBox ID="txt_sinifAd" runat="server"></asp:TextBox>
     <asp:Button ID="btn_Ekle" runat="server" Text="Sınıf Ekle" CssClass="#btn-login" Height="46px" OnClick="btn_Ekle_Click"></asp:Button>
          <br/>
          <asp:Label ID="lbl_Hata" runat="server" Text=""></asp:Label>
      </center>
    </div>
     </center>
 </div>
 <div style="float: left; width: 320px;">
    </div>
</div>
    </form>
</asp:Content>
