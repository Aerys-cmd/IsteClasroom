<%@ Page Title="" Language="C#" MasterPageFile="~/ogretmenAnaSayfa/ogretmenSinif.master" AutoEventWireup="true" CodeBehind="odevListe.aspx.cs" Inherits="IsteClasroom.ogretmenAnaSayfa.odevListe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
     <title></title>
</head>
<body>
    <div class="card1">
    <form id="form1" runat="server">
        <div>
            <center>
            <asp:GridView ID="gvOdev" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID"
                ShowHeaderWhenEmpty="true"

                OnRowEditing="gvOdev_RowEditing" OnRowCancelingEdit="gvOdev_RowCancelingEdit"
                OnRowUpdating="gvOdev_RowUpdating" OnRowDeleting="gvOdev_RowDeleting"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="152px" style="margin-left: 0" Width="1042px">
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
                    <asp:TemplateField HeaderText="Öğrenci Ad">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Ad") %>' runat="server" />
                        </ItemTemplate>                                              
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Öğrenci Soyad">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Soyad") %>' runat="server" />
                        </ItemTemplate>                                           
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teslim Zamanı">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("teslimZaman") %>' runat="server" />
                        </ItemTemplate>                    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Zamanında Teslim">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("zamanindaTeslim").ToString() == "True" ? "Evet" : Eval("zamanindaTeslim").ToString() == "False" ? "Hayır" : "" %>' runat="server" />
                        </ItemTemplate>         
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Puan">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Puan").ToString() == "-1" ? "Puanlandırılmadı" : Eval("Puan").ToString() != "-1" ? Eval("Puan") : "" %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Puan" Text='<%# Eval("Puan") %>' runat="server" />
                        </EditItemTemplate>          
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Ödev Linki">
                        <ItemTemplate>                    
                          <asp:HyperLink ID="btn_indir" NavigateUrl='<%#"~/Odevler/"+Eval("dosyaYolu")%>'  target="_blank" runat="server" ToolTip="İndir"><%#Eval("dosyaYolu")%></span></asp:HyperLink>
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
