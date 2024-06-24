using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace webApi.Models
{
    public class DAL
    {
        public Response GetAllUser(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM userInfo",connection);
            DataTable dt=new DataTable();
            List<userModel> users= new List<userModel>();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    userModel userModel = new userModel();
                    userModel.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    userModel.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    userModel.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    

                    
                    users.Add(userModel);

                }
            }
            if (users.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "OK";
                response.users = users;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.users = null;
            }
            return response;

        }

        public Response AddUser(SqlConnection connection,userModel user)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO userInfo(Name,Password) VALUES('"+ user.Name +"','"+user.Password+"')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "1 data inserted";
                
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data inserted";
              
            }
            return response;

        }

        public Response GetUserById(SqlConnection connection,int id)
        {
            Response response = new Response();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM userInfo WHERE ID='"+id+"'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                
                    userModel userModel = new userModel();
                    userModel.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
                    userModel.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    userModel.Password = Convert.ToString(dt.Rows[0]["Password"]);
                    response.StatusCode = 200;
                    response.StatusMessage = "OK";
                    response.userModel= userModel;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.users = null;
            }
            return response;

        }

        public Response UserDelete(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM userInfo WHERE ID='" + id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "1 Data Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
            }
            return response;

        }

        public Response UserUpdate(SqlConnection connection, userModel user)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE userInfo SET Name='" + user.Name + "',Password='" + user.Password + "'WHERE ID='"+user.Id+"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "1 data updated";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data inserted";

            }
            return response;

        }

        public Response UserLogin(SqlConnection connection, userModel user)
        {
            Response response = new Response();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM userInfo WHERE Name='" + user.Name + "' AND Password='" + user.Password + "'", connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login Succes";
              
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
            }
            return response;

        }

    }
}
