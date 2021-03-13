<%@ Page Title="" Language="C#" MasterPageFile="~/ogrenciAnaSayfa.Master" AutoEventWireup="true" CodeBehind="ogrAnasayfa.aspx.cs" Inherits="IsteClasroom.ogrAnasayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="header"><h1>Bir sınıfa katılın.</h1></div>  
<div style="width: 1080px;">
 <div style="float: left; width: 507px;"></div>
 <div style="float: left; width: 323px;">

   <div class="login-box">
      <h4 class="login-text">Sınıf Kodu Girin&nbsp;</h4>
      <center>
     <asp:TextBox ID="txt_sinifKod" runat="server"></asp:TextBox>
     <asp:Button ID="btn_Katil" runat="server" Text="Sınıfa Katıl" CssClass="#btn-login" Height="46px" OnClick="btn_Katil_Click"></asp:Button>
          <br/>
          <asp:Label ID="lbl_Hata" runat="server" Text=""></asp:Label>
      </center>
    </div>

 </div>
 <div style="float: left; width: 320px;">
    </div>
</div>
    </form>
</asp:Content>
