<%@ Page Title="" Language="C#" MasterPageFile="~/ogretmenAnaSayfa/ogretmenSinif.master" AutoEventWireup="true" CodeBehind="sinifListe.aspx.cs" Inherits="IsteClasroom.ogretmenAnaSayfa.sinifListe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <div class="card1">
        <div style="height:70px"></div>
       <center>
         <form id="form1" runat="server">
             <asp:GridView ID="sinif_List" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  Height="126px" Width="684px" >

                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <EditRowStyle BackColor="#999999" />
                 <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                 <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#E9E7E2" />
                 <SortedAscendingHeaderStyle BackColor="#506C8C" />
                 <SortedDescendingCellStyle BackColor="#FFFDF8" />
                 <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                 <Columns>
                <asp:TemplateField HeaderText="ID"  Visible="false">
                         <ItemTemplate >
                             <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Öğrenci Ad">
                         <ItemTemplate >
                             <asp:Label ID="Label2" runat="server" Text='<%# Eval("Ad") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Öğrenci Soyad">
                         <ItemTemplate >
                             <asp:Label ID="Label3" runat="server" Text='<%# Eval("Soyad") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
   
                 </Columns>
             </asp:GridView>
             </form>
            </center>
    </div>
</asp:Content>
