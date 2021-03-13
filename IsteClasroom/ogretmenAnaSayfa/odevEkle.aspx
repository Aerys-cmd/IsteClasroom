<%@ Page Title="" Language="C#" MasterPageFile="~/ogretmenAnaSayfa/ogretmenSinif.master" AutoEventWireup="true" CodeBehind="odevEkle.aspx.cs" Inherits="IsteClasroom.ogretmenAnaSayfa.odevEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <form id="form1" runat="server">
        <div style="height:30px"></div>
    <div class="card1">
    
        <table style="width: 100%">
            <tr>
                <td><h3><asp:Label ID="Label1" runat="server" style="color: #00FFCC"  Text="Ödev Başlığı"></asp:Label></h3></td>
            </tr>
            <br 
            <br />
            <tr>
                <td >
                    <center>
                    <asp:TextBox ID="txt_odevBaslik" runat="server" Width="433px"></asp:TextBox>
                        <br />
                        </center>
                </td>
            </tr>
            <tr>
                <td><h3><asp:Label ID="Label2" runat="server" style="color: #00FFCC"  Text="Ödev Konusu"></asp:Label></h3>
                    <p>&nbsp;</p></td>

            </tr>
            <br />
            <br />
            <tr>
                <td><center><textarea ID="txt_odevKonu" runat="server" style="width: 600px; height: 117px"></textarea></center></td>
            </tr>
            <tr>
                <td><h3><asp:Label ID="Label3" runat="server" style="color: #00FFCC"  Text="Son Teslim Tarihi"></asp:Label></h3>
                    <p>&nbsp;</p></td>

            </tr>
            <tr>
                <td>
                    <center>
                    <asp:Calendar ID="takvim" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="142px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="733px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                        <DayStyle Width="14%" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                        <TodayDayStyle BackColor="#CCCC99" />
                        </asp:Calendar>
                        </center>
                </td>

            </tr>
            <tr>
                <td><h3><asp:Label ID="Label4" runat="server" style="color: #00FFCC"  Text="Saat Seçiniz"></asp:Label></h3>
                    <p>&nbsp;</p></td>

            </tr>
            <tr>
                <td>
                    <center>
                    <asp:DropDownList ID="list_Saat" runat="server"></asp:DropDownList>
                        </center>
            </tr>
            <tr>
                <td>
                    <center>
                       <asp:Button ID="btn_Kaydet" runat="server" Text="Kaydet" Height="51px" OnClick="btn_Kaydet_Click"></asp:Button>
                        <br />
                        </center>
            </tr>



        </table>
         <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
    
        </div>
    </form>
</asp:Content>
