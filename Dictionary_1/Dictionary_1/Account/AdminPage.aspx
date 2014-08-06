<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Dictionary_1.Account.AdminPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     
    <hgroup class="title">

        <h1>&nbsp;

        </h1>

        <h2>Administrator Page<br />
           
          
            <asp:TextBox ID="TextBoxFindword" runat="server" Width="470px"></asp:TextBox>
            &nbsp;&nbsp;<asp:Button ID="ButtonSearch1" runat="server" OnClick="ButtonSearch1_Click" Text="Search" Width="110px" />
            <br />
            <br />
            <table style="width: 100%">
                <tr>
                    <td style="text-align: right; width: 204px">Word</td>
                    <td>
                        <asp:TextBox ID="TextBoxW" runat="server" Enabled="False" Width="388px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;<br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 204px; height: 68px;">Synonyms</td>
                    <td>
                        <asp:TextBox ID="TextBoxSyn" runat="server" Enabled="False" Width="388px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 204px">Russian meaning</td>
                    <td>
                        <asp:TextBox ID="TextBoxRus" runat="server" Enabled="False" Width="388px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 204px; text-align: justify;">
                        <br />
                    </td>
                    <td>
                        <asp:Button ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" Text="Edit" Width="100px" />
                        <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" Width="100px" />
                        <asp:Button ID="ButtonAdd" runat="server" Text="Add" Width="100px" OnClick="ButtonAdd_Click" />
                        <asp:Button ID="ButtonDel" runat="server" Text="Delete" Width="100px" OnClick="ButtonDel_Click" />
                        <br />
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Plesae prees Edit button, if you want to Update &amp; Add data into Database!" Font-Italic="True" Font-Size="Medium" style="text-align: right"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </h2>
    </hgroup>

  
    
    
                           
                       
           

  
    
</asp:Content>
