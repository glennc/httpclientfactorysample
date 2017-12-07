<%@ Page Async="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebUI.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Values:</h2>

    <ul>
        <asp:Repeater ID="repeater" runat="server">
            <ItemTemplate>
                <%# Container.DataItem?.ToString() %>
            </ItemTemplate>
        </asp:Repeater>
        </ul>

</asp:Content>
