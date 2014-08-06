<%@ Page  Language="C#" UICulture="auto" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"  Inherits="Dictionary_1._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            
            <hgroup class="title">
                <h1><%: Title %>
            <asp:Image ID="Image1" runat="server" ImageAlign="left" ImageUrl="images/DictionaryImg.jpg" Height="59px" Width="61px" />
                    &nbsp; Korean Thesaurus Dictionary
                    <br />
                    <br />
                </h1>
            </hgroup>
            <p>
 
                
                <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="373px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="Synonyms"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Height="50px" Width="376px" Enabled="False" ></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Font-Size="Larger" Text="Russian mean"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox3" runat="server" Width="336px" Enabled="False"></asp:TextBox>
            </p>
            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Mai Trang</h3>
</asp:Content>
