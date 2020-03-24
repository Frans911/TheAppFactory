<%@ Page Language="C#" MasterPageFile="~/Nav.Master" AutoEventWireup="true" CodeBehind="Intern.aspx.cs" Inherits="AppFactory.Intern" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <asp:Panel  runat="server">
     <form id="InternsForm" runat="server">
      <div class="Interns"> 
         <h1 style="color:#4FC3F7;padding:0">Interns Information</h1>
    <asp:Table  ID="Interns" runat="server" Width="100%"> 
    <asp:TableRow BackColor="#343a40" BorderColor="#82E0AA" >
        <asp:TableCell CssClass="Cell" ForeColor="White" Font-Bold="true">First Name</asp:TableCell>
        <asp:TableCell CssClass="Cell" ForeColor="White" Font-Bold="true">Last Name</asp:TableCell>
        <asp:TableCell CssClass="Cell" ForeColor="White" Font-Bold="true">Full Name</asp:TableCell>
        <asp:TableCell CssClass="Cell" ForeColor="White" Font-Bold="true">Date Of Birth</asp:TableCell>
        <asp:TableCell CssClass="Cell" ForeColor="White" Font-Bold="true">Start Date</asp:TableCell>
        <asp:TableCell CssClass="Cell" ForeColor="White" Font-Bold="true">Email</asp:TableCell>
        <asp:TableCell CssClass="Cell" ForeColor="White" Font-Bold="true">Contacts</asp:TableCell>
        <asp:TableCell CssClass="Cell" ForeColor="White" Font-Bold="true">Action</asp:TableCell>
    </asp:TableRow>
</asp:Table> 
    </div>
 </form>
</asp:Panel>

</asp:Content>
