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
                                     INNER JOIN CellPhone ON Person.PersonId = CellPhone.PersonId WHERE Person.PersonTypeId = 1", ref Interns);
 
        } 
    }
}