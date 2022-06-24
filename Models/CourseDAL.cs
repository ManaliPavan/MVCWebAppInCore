using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models
{
    public class CourseDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CourseDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Course> GetAllCourses()
        {
            List<Course> list = new List<Course>();
            string str = "select * from Course";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Course c = new Course();
                    c.Cid = Convert.ToInt32(dr["Cid"]);
                    c.Cname = dr["Cname"].ToString();
                    c.Fees = Convert.ToDecimal(dr["Fees"]);
                    list.Add(c);
                }
                con.Close();
                return list;
            }
            else
            {
                return list;
            }

        }
        public Course GetCourseById(int cid)
        {
            Course c = new Course();
            string str = "select * from Course where Cid=@cid";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@cid", cid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    c.Cid = Convert.ToInt32(dr["Cid"]);
                    c.Cname = dr["Cname"].ToString();
                    c.Fees = Convert.ToDecimal(dr["Fees"]);

                }
                con.Close();
                return c;
            }
            else
            {
                con.Close();
                return c;
            }
        }
        public int Save(Course course)
        {
            string str = "insert into Course values(@cname,@fees)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@cname", course.Cname);
            cmd.Parameters.AddWithValue("@fees", course.Fees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Update(Course course)
        {
            string str = "update Course set Cname=@cname,Fees=@fees where Cid=@cid";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@cid", course.Cid);
            cmd.Parameters.AddWithValue("@cname", course.Cname);
            cmd.Parameters.AddWithValue("@fees", course.Fees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int cid)
        {
            string str = "delete from Course where Cid=@cid";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@cid", cid);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}

