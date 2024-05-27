using Microsoft.AspNet.SignalR;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public class MyHub : Hub
{
    public void SendDataToClients()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        // Example of retrieving a local resource for the current page


        {
            con.Open();
            string query = "SELECT DISTINCT Location FROM dbo.TagMapping";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    string data = reader["Location"].ToString();

                    Clients.All.receiveData(data);


                    // DropDownList1.Items.Insert(0, new ListItem(Text = "SelectedFactory" meta: resourceKey = "SelectedFactory", ""));
                }
            }
        }
    }
}
