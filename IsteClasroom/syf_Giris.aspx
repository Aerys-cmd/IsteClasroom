5<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="syf_Giris.aspx.cs" Inherits="IsteClasroom.syf_Giris" %>

<!DOCTYPE html>  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css' />
   
    
</head>  
<body style="background-image:url(/IMAGE/arkaplan.jpg);"   >  

    <form id="form1" runat="server" >
    <div style="width: 100%; margin-top:250px; ">

        <div style="float: left; width: 500px; height:500px; background-color: Silver; border-radius:50px;margin-left:20%; ">
        
         <div style="max-width: 400px; position:relative; margin:auto;">
    <h2 class="form-signin-heading">
       Öğretmen Giriş</h2>
    <label for="txtUsername">
        E-posta</label>
    <asp:TextBox ID="txt_ogretmenMail" runat="server" CssClass="form-control" placeholder="E-posta giriniz" OnTextChanged="txt_ogretmenMail_TextChanged"  />
    <br />
    <label for="txtPassword">
        Şifre</label>
    <asp:TextBox ID="txt_ogretmenParola" runat="server" TextMode="Password" CssClass="form-control"
        placeholder="Şifre Giriniz" />
             <div style="height: 23px"></div>
    <asp:Button ID="btn_ogretmenGiris2" Text="Giriş" runat="server" OnClick="btn_ogretmenGiris" Class="btn btn-primary" />
    <br />
    <br />
    <div id="dvMessage" runat="server" visible="true" class="alert alert-danger">
        <strong></strong>
        <asp:Label ID="lbl_ogretmenHata" runat="server" />
    
             </div>
</div>
         
     </div>
     <div style="float: right; width: 500px; height:500px; margin-right:20%; background-color: Silver;border-radius:50px;  ">
         <div style="max-width: 400px; position:relative; margin:auto;">
   <h2 class="form-signin-heading">
       Öğrenci Giriş</h2>
    <label for="txtUsername">
        E-posta</label>
    <asp:TextBox ID="txt_ogrenciMail" runat="server" CssClass="form-control" placeholder="E-posta giriniz" />
    <br />
    <label for="txtPassword">
        Şifre</label>
    <asp:TextBox ID="txt_ogrenciParola" runat="server" TextMode="Password" CssClass="form-control"
        placeholder="Şifre Giriniz"  />
    <div style="height:23px;">
    </div>
    <asp:Button ID="btn_ogrenciGiris1" Text="Giriş" runat="server" OnClick="btn_ogrenciGiris" Class="btn btn-primary" />
    <br />
    <br />
    <div id="Div1" runat="server" visible="true" class="alert alert-danger">
        <strong></strong>
        <asp:Label ID="lbl_ogrenciHata" runat="server" />
    </div>
             <div>
                 <a href="syf_Kayit.aspx">Kayıt Ol</a></div>
</div>
     </div>

    </div>
        </form>

</body>  
</html>

