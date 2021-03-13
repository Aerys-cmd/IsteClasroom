<%@ Page Title="" Language="C#" MasterPageFile="~/ogretmenAnaSayfa/ogretmenSinif.master" AutoEventWireup="true" CodeBehind="ogrtOdevler.aspx.cs" Inherits="IsteClasroom.ogretmenAnaSayfa.ogrtOdevler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <div><h2 style="color: #00FFCC">Ödevler</h2></div>
    <center>
                <asp:DataList ID="dtListOdev" runat="server">
        <ItemTemplate>
            <table style="width: 100%">
                <tr>
                    <td>
                        <h2><strong>

                                  <a href="OdevListe.aspx?OdevID=<%# Eval("ID") %>"><asp:Label ID="Label1" runat="server" style="color: #00FFCC; text-decoration: underline;" Text='<%# Eval("odevBaslik") %>'></asp:Label></a>
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
    </asp:DataList>   </center>       

</asp:Content>
