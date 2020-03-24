using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls; 

namespace AppFactory
{
    public class AccessData
    {
		public AccessData(string connectionString)
		{
			this.connectionstring = connectionString;
		}
		private string row;

		public string Row
		{
			get { return row; }
			set { row = value; }
		}

		private string connectionstring; 

		private string ConnectionString
		{
			get { return connectionstring; }
			set { connectionstring = value; }
		}
		private SqlConnection sqlConnection;

		public SqlConnection SqlConnection
		{
			get { return sqlConnection; }
			set { sqlConnection = value; }
		}
		private SqlCommand sqlCommand;

		public SqlCommand SqlCommand
		{
			get { return sqlCommand; }
			set { sqlCommand = value; }
		}
		private SqlDataReader reader;

		public SqlDataReader SqlDataReader
		{
			get { return reader; }
			set { reader = value; }
		}
		public void UpdateData(string query,int Row, string firstName, string lastName, string dob, string contacts, string mail, bool primary, bool business, string roles)
		{ 

			using (sqlConnection = new SqlConnection(connectionstring))
			{
				try
				{
					sqlConnection.Open();
					System.Diagnostics.Debug.WriteLine($"Connection established...");
					sqlCommand = new SqlCommand(query, sqlConnection);
					sqlCommand.Parameters.AddWithValue("@Row", Row);
					sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
					sqlCommand.Parameters.AddWithValue("@LastName", lastName);
					sqlCommand.Parameters.AddWithValue("@Date", dob);
					sqlCommand.Parameters.AddWithValue("@Email", mail);
					sqlCommand.Parameters.AddWithValue("@Business", business);
					sqlCommand.Parameters.AddWithValue("@Contacts", contacts);
					sqlCommand.Parameters.AddWithValue("@Primary", primary);
					sqlCommand.ExecuteNonQuery();

				}
				catch (SqlException sqlEx)
				{
					System.Diagnostics.Debug.WriteLine(sqlEx);
				}
			}
		}
		public void StoreData(string query, string firstName, string lastName, string dob, string contacts, string mail, bool primary, bool business, string roles) { 

			using (sqlConnection = new SqlConnection(connectionstring))
			{
				try
				{
					sqlConnection.Open();
					System.Diagnostics.Debug.WriteLine($"Connection established...");
					sqlCommand = new SqlCommand(query, sqlConnection);
					sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
					sqlCommand.Parameters.AddWithValue("@LastName", lastName);
					sqlCommand.Parameters.AddWithValue("@Date", dob);
					sqlCommand.Parameters.AddWithValue("@Email", mail);
					sqlCommand.Parameters.AddWithValue("@Business", business);
					sqlCommand.Parameters.AddWithValue("@Contacts", contacts);
					sqlCommand.Parameters.AddWithValue("@Primary", primary);
					sqlCommand.Parameters.AddWithValue("@roles", roles);
					sqlCommand.ExecuteNonQuery();
					
				}
				catch (SqlException sqlEx)
				{
					System.Diagnostics.Debug.WriteLine(sqlEx);
				}
			}
		}
		public void EditData(string query,int row, TextBox FirstName,TextBox LastName,Calendar calendar,TextBox contacts,TextBox email, CheckBox primary, CheckBox business) {
			using (sqlConnection = new SqlConnection(connectionstring))
			{
				try
				{
					sqlConnection.Open();
					System.Diagnostics.Debug.WriteLine($"Connection established...");
					sqlCommand = new SqlCommand(query, sqlConnection);
					sqlCommand.Parameters.AddWithValue("@SelectedPerson", row);
					reader = sqlCommand.ExecuteReader();
					while (reader.Read())
					{
						FirstName.Text = reader[0].ToString();
						LastName.Text = reader[1].ToString();
						calendar.SelectedDate = Convert.ToDateTime(reader[3].ToString());
						
						contacts.Text = reader[6].ToString();
						email.Text = reader[5].ToString();
						primary.Checked = Convert.ToBoolean(reader[8].ToString());
						business.Checked = Convert.ToBoolean(reader[9].ToString());
						System.Diagnostics.Debug.WriteLine($"{reader[0]} {reader[1]} {reader[2]} {reader[3]} {reader[4]} {reader[5]} {reader[6]} {reader[7]} {reader[8]} {reader[9]}");
					}

				}
				catch (SqlException sqlEx)
				{
					System.Diagnostics.Debug.WriteLine(sqlEx);
				}
			}
		}
		public void ExtractData(string query, ref Table Interns)
		{
			using (sqlConnection = new SqlConnection(connectionstring))
			{
				try
				{ 
					sqlConnection.Open();
					System.Diagnostics.Debug.WriteLine($"Connection established...");
					sqlCommand = new SqlCommand(query, sqlConnection);
					reader = sqlCommand.ExecuteReader(); 
					
					while (reader.Read())
					{
						Button button = new Button();
						button.Text = "Edit";
						button.CssClass = "Button4";
						button.ID = reader[7].ToString();
						this.row = reader[7].ToString(); 
						button.Click += (s, e) => {
							HttpContext.Current.Response.Redirect($"Edit.aspx?{button.ID}"); 
						};
						TableRow row = new TableRow();
						TableCell FirstName = new TableCell();
						TableCell LastName = new TableCell();
						TableCell FullName = new TableCell();
						TableCell DateOfBirth = new TableCell();
						TableCell StartDate = new TableCell();
						TableCell Email = new TableCell();
						TableCell Contacts = new TableCell();
						TableCell Actions = new TableCell();
						FirstName.Text = reader[0].ToString();
						LastName.Text = reader[1].ToString();
						FullName.Text = reader[2].ToString();
						DateOfBirth.Text = Convert.ToDateTime(reader[3]).ToString("dd-MMM-yyyy");
						StartDate.Text = Convert.ToDateTime(reader[4]).ToString("dd-MMM-yyyy");
						Email.Text = reader[5].ToString();
						Contacts.Text = reader[6].ToString();
						Actions.Controls.Add(button);

						row.Cells.Add(FirstName);
						row.Cells.Add(LastName);
						row.Cells.Add(FullName);
						row.Cells.Add(DateOfBirth);
						row.Cells.Add(StartDate);
						row.Cells.Add(Email);
						row.Cells.Add(Contacts);
						row.Cells.Add(Actions);
						Interns.Rows.Add(row);
						System.Diagnostics.Debug.WriteLine($"{reader[0]} {reader[1]} {reader[2]} {reader[3]} {reader[4]} {reader[5]} {reader[6]} {reader[7]}"); 
					}
				}
				catch (SqlException sqlEx)
				{
					Console.WriteLine(sqlEx); 
				}
			}
		} 
	}
}