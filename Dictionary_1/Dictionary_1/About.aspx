<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Dictionary_1.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>App description page.</h2>
    </hgroup>

    <article>
        <p>        
            Online free thesaurus dictionary for Korean.
        </p>

        <p>        
            Dictionary is free for search synonyms and always update words by Administrator.
        </p>

        <p>        
            More informations, visit page Korean Dictionaries: <span><a  href="http://www.wordnet.co.kr/">www.wordnet.co.kr</a> </span>
        </p>
    </article>

    <aside>
        <h3>Aside Title</h3>
        <p>        
            Use this area to provide additional information.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>
</asp:Content>