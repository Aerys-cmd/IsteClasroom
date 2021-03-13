<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="syf_Kayit.aspx.cs" Inherits="IsteClasroom.syf_Kayit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css' />
</head>
<body style="background-image:url(/IMAGE/arkaplan.jpg);">
    <form id="form1" runat="server">
      <div style="width: 100%; margin-top:250px; ">

     <div style=" width: 500px; height:500px; background-color: Silver; border-radius:50px;margin-left:20%; ">
        
         <div style="max-width: 400px; position:relative; margin:auto;">
    <h2 class="form-signin-heading">
       Öğrenci Kayıt</h2>
    <label for="txtUsername">
        Ad</label>
    <asp:TextBox ID="txt_ogrenciAd" runat="server" CssClass="form-control" placeholder="Ad Giriniz"  />
    <br />
    <label for="txtPassword">
        Soyad</label>
    <asp:TextBox ID="txt_ogrenciSoyad" runat="server"  CssClass="form-control" placeholder="Şifre Giriniz" />
             <br />
              <label for="txtUsername">
        E-posta</label>
    <asp:TextBox ID="txt_ogrenciEmail" runat="server" CssClass="form-control" placeholder="Soyad Giriniz"  />
    <br />
    <label for="">
        Şifre</label>
    <asp:TextBox ID="txt_ogrKayitParola" runat="server" TextMode="Password" CssClass="form-control" placeholder="Şifre Giriniz" />
             <div style="height: 23px"></div>
    <asp:Button ID="btn_ogrenciKayit1" Text="Kayıt" runat="server" OnClick="btn_ogrenciKayit" Class="btn btn-primary" />
    <br />
    <br />
    <div id="dvMessage" runat="server" visible="true" class="alert alert-danger">
        <asp:Label ID="lbl_ogrenciHata" runat="server" />
    
             </div>
</div>
         
     </div>
    </form>
</body>
</html>
