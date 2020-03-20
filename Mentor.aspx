<%@ Page Language="C#" MasterPageFile="~/Nav.Master" AutoEventWireup="true" CodeBehind="Mentor.aspx.cs" Inherits="AppFactory.Mentor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
         <div class="Interns"> 
         <h1 style="color:#4FC3F7;padding:0">Mentors Information</h1>
    <asp:Table  ID="Mentors" runat="server" Width="100%"> 
    <asp:TableRow BackColor="#4FC3F7" BorderColor="#82E0AA" >
        <asp:TableCell CssClass="Cell" Font-Bold="true">First Name</asp:TableCell>
        <asp:TableCell CssClass="Cell" Font-Bold="true">Last Name</asp:TableCell>
        <asp:TableCell CssClass="Cell" Font-Bold="true">Full Name</asp:TableCell>
        <asp:TableCell CssClass="Cell" Font-Bold="true">Date Of Birth</asp:TableCell>
        <asp:TableCell CssClass="Cell" Font-Bold="true">Start Date</asp:TableCell>
        <asp:TableCell CssClass="Cell" Font-Bold="true">Email</asp:TableCell>
        <asp:TableCell CssClass="Cell" Font-Bold="true">Contacts</asp:TableCell>
    </asp:TableRow>
</asp:Table> 
    </div>
</asp:Content>
