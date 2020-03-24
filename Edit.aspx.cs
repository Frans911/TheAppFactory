using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFactory
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!IsPostBack)
            {
                int row = Convert.ToInt32(Request.QueryString.ToString());

                AccessData accessData = new AccessData("Data Source=LAPTOP-J5RU88CT;Initial Catalog=AppFactory;User ID=Frans911;Password=Sushi_boy93");
                accessData.EditData(@"SELECT FirstName,Surname,FullName,DateOfBirth,StartDate,EmailAddress,CellPhoneNo,Person.PersonId,CellPhone.IsPrimary,Email.IsBusiness FROM Person 
                                     INNER JOIN Email ON Person.PersonId = Email.PersonId 
                                     INNER JOIN CellPhone ON Person.PersonId = CellPhone.PersonId WHERE Person.PersonTypeId = 1 AND Person.PersonId = @SelectedPerson", row, FirstName, LastName, Calendar1, cell, email, Primary, Business);
            }

        } 
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Intern.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        { 
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string dob = Calendar1.SelectedDate.ToShortDateString();
            string contacts = cell.Text;
            string mail = email.Text;
            bool primary = Primary.Checked;
            bool business = Business.Checked;
            string roles = Roles.Text;
            int row = Convert.ToInt32(Request.QueryString.ToString());
            System.Diagnostics.Debug.WriteLine($"Row update{firstName} {lastName} {dob} {contacts} {mail} {primary} {business} {row}");
            AccessData accessData = new AccessData("Data Source=LAPTOP-J5RU88CT;Initial Catalog=AppFactory;User ID=Frans911;Password=Sushi_boy93");
            accessData.UpdateData(@" UPDATE Person SET FirstName = @FirstName,Surname = @LastName,DateOfBirth = @Date WHERE Person.PersonId = @Row;
                                     UPDATE Email SET EmailAddress = @Email,IsBusiness = @Business WHERE EmailId = @Row;
                                     UPDATE CellPhone SET CellPhoneNo = @Contacts,IsPrimary = @Primary WHERE CellPhoneId = @Row;", row, firstName, lastName, dob, contacts, mail, primary, business, roles);
            pnlThankYouMessage.Visible = true;
            pnlInternsEdit.Visible = false;
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            Response.Redirect("Intern.aspx");
        }
    }
}