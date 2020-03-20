using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFactory
{
    public partial class Intern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AccessData accessData = new AccessData("Data Source=LAPTOP-J5RU88CT;Initial Catalog=AppFactory;User ID=Frans911;Password=Sushi_boy93"); 
            accessData.ExtractData(@"SELECT FirstName,Surname,FullName,DateOfBirth,StartDate,EmailAddress,CellPhoneNo,Person.PersonId FROM Person 
                                     INNER JOIN Email ON Person.PersonId = Email.PersonId 
                                     INNER JOIN CellPhone ON Person.PersonId = CellPhone.PersonId WHERE Person.PersonTypeId = 1", ref Interns, pnlInternsEdit, pnlFormInternsTable,FirstName,LastName,Calendar1,cell,email,Primary,Business,Roles,Label2);
 
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            pnlInternsEdit.Visible = false;
            pnlFormInternsTable.Visible = true; 
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string dob = Calendar1.SelectedDate.ToShortDateString();
            string contacts = cell.Text;
            string mail = email.Text;
            bool primary = Primary.Checked;
            bool business = Business.Checked;
            string roles = Roles.Text;
            int Row = 0;
            Row = Convert.ToInt32(Label2.Text);
            AccessData accessData = new AccessData("Data Source=LAPTOP-J5RU88CT;Initial Catalog=AppFactory;User ID=Frans911;Password=Sushi_boy93");
            
            accessData.UpdateData(@" UPDATE Person SET FirstName = @FirstName,Surname = @LastName,DateOfBirth = @Date WHERE Person.PersonId = @Row;
                                     UPDATE Email SET EmailAddress = @Email,IsBusiness = @Business WHERE EmailId = @Row;
                                     UPDATE CellPhone SET CellPhoneNo = @Contacts,IsPrimary = @Primary WHERE CellPhoneId = @Row;", Row,firstName,lastName,dob,contacts,mail,primary,business,roles);
            pnlThankYouMessage.Visible = true;
            pnlInternsEdit.Visible = false;
            pnlFormInternsTable.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            pnlInternsEdit.Visible = false;
            pnlFormInternsTable.Visible = true;
            pnlThankYouMessage.Visible = false;
        }
    }
}