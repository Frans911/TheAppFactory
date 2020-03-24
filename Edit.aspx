<%@ Page Language="C#" MasterPageFile="~/Nav.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="AppFactory.Edit" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    <asp:Panel ID="pnlInternsEdit" runat="server" Visible="True">
            <div class="CaptureForm" runat="server">
              <h1>Edit Information</h1>
              <form id="CaptureForm" method="post" runat="server">  
              <asp:Textbox placeholder="First Name :" runat="server" type="text" id="FirstName" name="FirstName"></asp:Textbox> <br> 
                  <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fname" ErrorMessage="Please enter first name" Font-Names="Bahnschrift" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  <br /> 
              <asp:Textbox placeholder="Last Name :" runat="server" type="text" id="LastName" name="LastName"></asp:Textbox> <br> 
                  <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lname" ErrorMessage="Please enter last name" Font-Names="Bahnschrift" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  <br />
                  
                  <asp:Label style="margin:0 45% 0 0" ID="Label1" runat="server" Font-Size="Smaller" ForeColor="#999999" Text="Role"></asp:Label>
                  
                  <br />
                  <asp:DropDownList ID="Roles" runat="server" Font-Names="Bahnschrift" Font-Size="Smaller" Width="50%" ForeColor="Black" Height="25px">
                      <asp:ListItem>Intern</asp:ListItem>
                      <asp:ListItem>Mentor</asp:ListItem>
                      <asp:ListItem>Manager</asp:ListItem>
                  </asp:DropDownList><br />
              <%--    <br /> --%>
            <%--  <asp:Textbox placeholder="Date of birth :" runat="server" id="dob" name="dob"></asp:Textbox> <br> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dob" ErrorMessage="Please enter date of birth" Font-Names="Bahnschrift" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  <br /> 
                  <asp:Calendar Width="50%" style="margin:0 0 0 25%;font-weight:lighter;" ID="Calendar1" runat="server" Caption="Date of birth"></asp:Calendar>
                  <br />
                  <asp:Label ID="ErrorCalender" runat="server" Font-Names="Bahnschrift" Font-Size="Smaller" ForeColor="Red" Text="Please choose your date of birth" Visible="False"></asp:Label>
                  <br />
              <asp:Textbox style="margin:0 0 0 5%"  placeholder="Contact :" runat="server" type="tel" id="cell" name="cell"></asp:Textbox>
                  <asp:CheckBox style="transform:translateY(30px)" Text="Primary" ID="Primary" runat="server" Font-Size="Smaller" Height="14pt" Width="21pt" />
                  <br> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cell" ErrorMessage="Please enter contacts" Font-Names="Bahnschrift" ForeColor="Red" Font-Size="Smaller"></asp:RequiredFieldValidator>
                  <br />  
              <asp:Textbox style="margin:0 0 0 5%" placeholder="Email :" runat="server" type="text" id="email" name="email"></asp:Textbox>
                  <asp:CheckBox style="transform:translateY(30px)" Text="Business" ID="Business" runat="server" Font-Size="Smaller" Height="14pt" Width="21pt" /><br> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="email" ErrorMessage="Please enter email" Font-Names="Bahnschrift" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                  <br /> 
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Type correct email" Font-Names="Nunito" Font-Size="Smaller" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  <br />
              <asp:button CssClass="Button5" runat="server" type="submit" id="Cancel" name="Submit" Text="CANCEL" OnClick="Cancel_Click" ></asp:button>
                  <asp:button CssClass="Button6" runat="server" type="submit" id="Update" name="Submit" Text="UPDATE" OnClick="Update_Click" ></asp:button>
              <br />
                  <asp:Label ID="Label2" runat="server" Font-Size="Smaller" Text="Label" Visible="False"></asp:Label>
                </form>
    </div>
</asp:Panel>
        <asp:Panel ID="pnlThankYouMessage" runat="server" Visible="False">
         <div class="Feedback" runat="server">
             <form id="Form1" method="post" runat="server"> 
                             <h4>You've successfully updated the information</h4>
             <asp:Button CssClass="Button2" ID="OK" runat="server" Text="OK" OnClick="OK_Click"  />
             <br />
             </form>


         </div>
    
    </asp:Panel>
 </asp:Content>
