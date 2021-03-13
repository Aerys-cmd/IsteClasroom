<%@ Page Title="" Language="C#" MasterPageFile="~/ogretmenAnaSayfa/ogretmenSinif.master" AutoEventWireup="true" CodeBehind="duyuruPanel.aspx.cs" Inherits="IsteClasroom.ogretmenAnaSayfa.duyuruPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
<body>
    <div class="card1">
    <form id="form1" runat="server">
        <div>
            <center>
            <asp:GridView ID="gvDuyuru" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID"
                ShowHeaderWhenEmpty="true"

                OnRowCommand="gvDuyuru_RowCommand"
                OnRowEditing="gvDuyuru_RowEditing" OnRowCancelingEdit="gvDuyuru_RowCancelingEdit"
                OnRowUpdating="gvDuyuru_RowUpdating" OnRowDeleting="gvDuyuru_RowDeleting"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="90px" style="margin-left: 0" Width="1221px">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                <Columns>
                    <asp:TemplateField HeaderText="Duyuru İçerik">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Duyuru") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Duyuru" Text='<%# Eval("Duyuru") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="ft_Duyuru" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duyuru Tarihi">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DuyuruTarih") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/IMAGE/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="30px" Height="30px"/>
                            <asp:ImageButton ImageUrl="~/IMAGE/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="30px" Height="30px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/IMAGE/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="30px" Height="30px"/>
                            <asp:ImageButton ImageUrl="~/IMAGE/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="30px" Height="30px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/IMAGE/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="30px" Height="30px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </center>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />

        </div>
    </form>
        </div>
</body>
</asp:Content>
