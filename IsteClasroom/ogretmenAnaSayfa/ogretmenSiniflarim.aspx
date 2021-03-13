<%@ Page Title="" Language="C#" MasterPageFile="~/ogretmenAnaSayfa/ogretmenAnaSayfa.Master" AutoEventWireup="true" CodeBehind="ogretmenSiniflarim.aspx.cs" Inherits="IsteClasroom.ogretmenAnaSayfa.ogretmenSiniflarim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <form id="form1" runat="server">
    <div class="header" style="background-color:darkslateblue">
  <h2 style="color: #00FFCC">Sınıflarım</h2>
</div>
    <div class="card">
     
          <center><asp:DataList ID="dt_List" runat="server" Height="260px" Width="656px" >
              <ItemTemplate>
                  
                 
                  
                  <table style="width: 100%">
                      <tr>
                          <td style="height: 20px">
                              <h2><strong>

                                  <a href="sinifListe.aspx?SinifID=<%# Eval("ID") %>"><asp:Label ID="Label1" runat="server" style="color: #00FFCC; text-decoration: underline;" Text='<%# Eval("SinifAd") %>'></asp:Label></a>
                                  </strong></h2>
                          </td>
                      </tr
                      <tr>
                      </tr>
                      <td>
                          <center>
                              <h4 style="color: #00FFCC">Sınıf Kodu</h4>
                              <br />
                              <asp:Label ID="Label3" runat="server" Text='<%# Eval("sinifKod") %>'></asp:Label>
                          </center>
                      </td>
                      <tr>
                          <td style="border-bottom-style: solid">&nbsp;</td>
                      </tr>
                  </table>
                  
                 
                  
              </ItemTemplate>
              </asp:DataList></center>
          
      
      
    </div>

    </form>
</asp:Content>
