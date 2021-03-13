<%@ Page Title="" Language="C#" MasterPageFile="~/ogrenciAnaSayfa.Master" AutoEventWireup="true" CodeBehind="OdevDetay.aspx.cs" Inherits="IsteClasroom.OdevDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form id="form1" runat="server">
       <div class="card">
           
           <table style="width: 100%">
               <tr>
                   <td><asp:Label ID="lbl_odevAd" runat="server" style="color: #00FFCC" Text=''></asp:Label></td>
               </tr>
               <tr>
                   <td>
                       <h4 style="color: #00FFCC">Ödev Konusu</h4>
                        <asp:Label ID="lbl_odevKonu" runat="server" Text=''></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="Label7" runat="server" Style="color:#00FFCC" Text="Teslim Tarihi : "></asp:Label>
                            <asp:Label ID="lbl_teslimTarih" runat="server" Text=''></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>
                        <asp:Label ID="Label2" runat="server" Style="color:#00FFCC" Text="Ödev Teslim Durumu : "></asp:Label>
                            <asp:Label ID="lbl_teslimDurum" runat="server" Text=''></asp:Label>
                       &nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" Style="color:#00FFCC" Text="Zamanında Teslim : "></asp:Label>
                            <asp:Label ID="lbl_zamanındaTeslim" runat="server" Text=''></asp:Label>
                   </td>
               </tr>
                <tr>
                   <td>
                       <asp:Label ID="Label9" runat="server" Style="color:#00FFCC" Text="Puan : "></asp:Label>
                            <asp:Label ID="lbl_Puan" runat="server" Text=''></asp:Label>
                   </td>
               </tr>
                <tr>
                   <td>
                      
                       <asp:FileUpload ID="dosyaYukle" runat="server" />
                       <asp:Label ID="lbl_Uzanti" runat="server" Text="İzin verilen uzantılar : "></asp:Label>
                      
                   </td>
               </tr>
               <tr>
                   <td>
                    
                    <asp:Button ID="btn_odevTeslim" runat="server" Text="Ödev Yükle" OnClick="btn_odevTeslim_Click" Height="49px" />
                      
                   </td>
               </tr>
                <tr>
                   <td>
                    
                       <asp:Label ID="lbl_hata" runat="server" Text=""></asp:Label>
                      
                   </td>
               </tr>
           </table>
           
       </div>
       </form>
</asp:Content>
