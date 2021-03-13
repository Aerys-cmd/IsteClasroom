<%@ Page Title="" Language="C#" MasterPageFile="~/ogrenciAnaSayfa.Master" AutoEventWireup="true" CodeBehind="SinifDetay.aspx.cs" Inherits="IsteClasroom.SinifDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="header" style="background-color:darkslateblue">
        <center>
      <h2 style="color: #00FFCC"><asp:Label ID="lbl_SinifAd" runat="server" Text="Sınıf Adı"></asp:Label></h2>
            </center>
 
</div>
        <div class="card">
            <center>
                <div><h2 style="color: #00FFCC">Duyurular</h2></div>
                <asp:DataList ID="dtListDuyuru" runat="server" Width="494px">
        <ItemTemplate>
            <table style="width: 100%">
                 <tr>
                          <td style="border-bottom-style: solid">&nbsp;</td>
                      </tr>
                 <tr>
                    <td>
                        <h3 style="color: #00FFCC"> Duyuru : </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Duyuru") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                        
                        <asp:Label ID="Label2" runat="server"  style="color: #00FFCC" Text="Duyuru Tarihi : "></asp:Label>
                        -<asp:Label ID="Label3" runat="server" Text='<%# Eval("duyuruTarih") %>'></asp:Label>
                            
                    </td>
                </tr>
                
            </table>
        </ItemTemplate>
    </asp:DataList>
                <div style="border-bottom-style: solid"></div>
              <div><h2 style="color: #00FFCC">Ödevler</h2></div>
                <asp:DataList ID="dtListOdev" runat="server">
        <ItemTemplate>
            <table style="width: 100%">
                <tr>
                    <td>
                        <h2><strong>

                                  <a href="OdevDetay.aspx?OdevID=<%# Eval("ID") %>"><asp:Label ID="Label1" runat="server" style="color: #00FFCC; text-decoration: underline;" Text='<%# Eval("odevBaslik") %>'></asp:Label></a>
                                  </strong></h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4 style="color: #00FFCC">Ödev Konusu</h4>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("odevKonu") %>'></asp:Label>
                    </td>
                </tr>
                <caption>
                    <br />
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Style="color:#00FFCC" Text="Teslim Tarihi : "></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("teslimTarih") %>'></asp:Label>
                        </td>
                    </tr>
                     <tr>
                          <td style="border-bottom-style: solid">&nbsp;</td>
                      </tr>
                    
                </caption>
            </table>
        </ItemTemplate>
    </asp:DataList>
            </center>
        </div>
        

    </form>

</asp:Content>
