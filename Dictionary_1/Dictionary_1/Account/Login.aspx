<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dictionary_1.Account.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Entry-level system Administrator<br />
            <br />
            <br />
        </h2>
        <table style="width: 100%">
            <tr>
                <td style="width: 368px; text-align: right">Username</td>
                <td style="width: 168px">
                    </hgroup>
                    <asp:TextBox ID="TextBoxUser" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td style="width: 538px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUser" ErrorMessage="Please insert user name" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 368px; text-align: right">Password</td>
                <td style="width: 168px">
                    <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
                <td style="width: 538px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="Please insert password" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 368px">&nbsp;</td>
                <td style="width: 168px">
                    <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Log in" />
                </td>
                <td style="width: 538px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 368px">&nbsp;</td>
                <td style="width: 168px">&nbsp;</td>
                <td style="width: 538px">&nbsp;</td>
            </tr>
        </table>
    <hgroup>
    </hgroup>

     
</asp:Content>