using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFactory
{
    public partial class Capture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 

        } 

        protected void Button1_Click(object sender, EventArgs e)
        {
            AccessData accessData = new AccessData("Data Source=LAPTOP-J5RU88CT;Initial Catalog=AppFactory;User ID=Frans911;Password=Sushi_boy93"); 

            Page.Validate();
            
            if (Page.IsValid && Calendar1.SelectedDate.ToString() != "01 Jan 0001 00:00:00")
            {
               
                string firstName = fname.Text;
                string lastName = lname.Text; 
                string dob = Calendar1.SelectedDate.ToShortDateString();
                string contacts = cell.Text;
                string mail = email.Text;
                bool primary = Primary.Checked;
                bool business = Business.Checked;
                string roles = Roles.Text; 
                string query = @"INSERT INTO Person(FirstName,Surname,DateOfBirth,PersonTypeId,IsActive) VALUES(@FirstName,@LastName,@Date,(SELECT PersonType.PersonTypeId FROM PersonType WHERE PersonType.Description = @roles),1);
                                 INSERT INTO Email(EmailAddress, IsBusiness, PersonId, IsActive) VALUES(@Email, @Business, IDENT_CURRENT ('Person'),1);
                                 INSERT INTO CellPhone(CellPhoneNo, PersonId, IsPrimary, IsActive) VALUES(@Contacts, IDENT_CURRENT ('Person'),@Primary,1); ";
                accessData.StoreData(query,firstName,lastName,dob,contacts,mail,primary,business,roles);
                ClearInputs();
                pnlFormFields.Visible = false;
                pnlThankYouMessage.Visible = true;
            }
            else
            {
                ErrorCalender.Visible = true;
            }




        }

        private void ClearInputs()
        {
            fname.Text = string.Empty;
            lname.Text = string.Empty;
            //dob.Text = string.Empty;
            cell.Text = string.Empty;
            email.Text = string.Empty;
            Primary.Checked = false;
            Business.Checked = false;
            Calendar1.SelectedDates.Clear();
            Roles.SelectedIndex = 0;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            pnlFormFields.Visible = true;
            pnlThankYouMessage.Visible = false;
        }
    }
}