using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Lending_Management_System.Modules
{
    public class Settings:db_connect

    {
        String query;

        //LOAD AREA
        public DataTable loadArea()
        {
            DataTable dt = new DataTable();
            try
            {
                query = "SELECT DISTINCT m.citymunCode, refcitymun.citymunDesc FROM tbl_member AS m INNER JOIN refcitymun ON refcitymun.citymunCode = m.citymunCode";
                connect();
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "LoadArea()");
            } finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return dt;
        }

        public void deleteArea(int areaID)
        {
            try
            {
                query = "UPDATE tbl_area SET isdelete = true where areaID = '"+ areaID +"' ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "deleteArea()");
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        public Boolean updateArea(int areaID,string area)
        {
            try
            {
                query = "UPDATE tbl_area SET area ='"+ area +"' where areaID = '" + areaID + "' ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "deleteArea()");
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }
        public Boolean addArea(string area)
        {
            try
            {
                query = "INSERT INTO tbl_area (area) VALUES ('" + area + "') ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "addrea()");
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        //END LOAD AREA  

        //CRUD TERM
        public DataTable loadTerm()
        {
            DataTable dt = new DataTable();
            try
            {
                query = "SELECT * FROM tbl_terms where isdelete = false ORDER BY terms ASC";
                connect();
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();
                dt.Load(reader);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "LoadTerms");
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return dt;
        }


        public void deleteTerm(int termsID)
        {
            try
            {
                query = "UPDATE tbl_terms SET isdelete = true where termsID = '" + termsID + "' ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "deleteTerm");
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        public Boolean updateTerm(int termsID, string term, string duration)
        {
            try
            {
                query = "UPDATE tbl_terms SET terms = '"+ term +"', durations = '"+ duration +"' WHERE termsID = "+termsID+" ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "updateTerm");
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }
        public Boolean addTerm(string terms, string duration)
        {
            try
            {
                query = "INSERT INTO tbl_terms (terms, durations) VALUES ('" + terms + "','"+ duration +"') ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "addTerm");
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }
        //END TERM
        public Boolean validate(string qry)
        {
            try
            {
                connect();
                cmd.CommandText = qry;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "validation");
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        //LIMITATION OF ACCOUNTS TO BE CREATED
        public int LimitAcct()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT limits FROM tbl_acc_limits";
                reader = cmd.ExecuteReader();
                return  (reader.Read())? (int)reader["limits"] : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            } finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        public Boolean updateLimits(int no)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_acc_limits SET limits ="+no+" ";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }
        //END-LIMITATION OF ACCOUNTS TO BE CREATED

        //START-LOANABLE AMOUNTS
        public double[] amountsLoanable()
        {
            double[] amount = new double[2];
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_amount_loanable";
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    amount[0] = (double)reader["minAmount"];
                    amount[1] = (double)reader["maxAmount"];
                }

                return amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            } finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        public Boolean saveLoanAmounts(double min, double max)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_amount_loanable SET minAmount = " + min + ", maxAmount=" + max + "";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //END-LOANABLE AMOUNTS


        //START--INTEREST RATE
          public DataTable loadInterest()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_interest WHERE isdelete = false";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return dt;
        }

        public void deleteInterest(int intID)
        {
            try
            {
                query = "UPDATE tbl_interest SET isdelete = true where intID = '" + intID + "' ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "deleteTerm");
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        public Boolean updateInterest(int intID, double interest)
        {
            try
            {
                query = "UPDATE tbl_interest SET interest = '" + interest + "' WHERE intID = " + intID + " ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "updateInterest");
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }
        public Boolean addInterest(double interest)
        {
            try
            {
                query = "INSERT INTO tbl_interest (interest) VALUES ('" + interest + "') ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "addTerm");
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }


        //END--INTEREST RATE

        //START POSITION
        public Boolean addPosition(string position, DataTable modules)
        {
            string columns = "";
            string data = "";
            try
            {
                
                foreach (DataRow row in modules.Rows)
                {
                    columns += ", " + row["modules"];
                    data += ", " + row["permission"].ToString();

                }
                query = "INSERT INTO tbl_position (position"+columns+") VALUES ('"+position+"'" + data + ")";
                connect();
                cmd.CommandText =query ;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + query + " " + data);
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }

        }

        public DataTable loadModules()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_modules ORDER BY modules ASC";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return dt;
        }

        public DataTable loadPosition()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_position WHERE isdelete = false";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                disconnect_db();
            }
            return dt;

        }

        public Boolean updatePosition(string qry)
        {
            try
            {
                connect();
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            } finally
            {
                cmd.Dispose();
                disconnect_db();
            }
                        
        }

        public void deletePosition(int posID)
        {
            try
            {
                query = "UPDATE tbl_position SET isdelete = true where posID = '" + posID + "' ";
                connect();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "deletePosition");
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }
        //END POSITION



    }
    //END CLASS SETTINGS

    //START USER

    #region User
    public class user : db_connect
    {
        public string memID { get; set; }
        public string fname { get; set; }
        public string mi { get; set; }
        public string lname { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public string dob { get; set; }
        public string uname { get; set; }
        public string pass { get; set; }
        public Byte[] arrayImage { get; set; }
        public string gender { get; set; }
        public int posID { get; set; }
        public int areaID { get; set; }
        public String getMemID()
        {

            try
            {
                connect();
                cmd.CommandText = "SELECT memID AS memID FROM tbl_member order by memID DESC limit 1";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToString(Convert.ToInt32(reader.GetString("memID")) + 1) : "10000001";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "null";
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                disconnect_db();
            }
        }

        public bool isDuplicateUser()
        {
        
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_user WHERE isdelete = FALSE AND uname = @UserName AND memID != @MemID";
                cmd.Parameters.AddWithValue("@UserName", uname);
                cmd.Parameters.AddWithValue("@MemID", memID);
                reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    MessageBox.Show($"The {uname} is already registered.");
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }
        public Boolean AddUser()
        {
            try
            {
                connect();
                transact = con.BeginTransaction();
                cmd.Transaction = transact;
                cmd.CommandText = "INSERT INTO tbl_member (memID, fname, mi, lname,dob, contact, address,gender) VALUES (@memID, @fname, @mi, @lname, @dob, @contact, @address, @gender)";
                cmd.Parameters.AddWithValue("@memID", memID);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@mi", mi);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO tbl_user (uname, pass, memID, posID) VALUES(@uname,md5(@pass), @ID, @posID)";
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@ID", memID);
                cmd.Parameters.AddWithValue("@posID", posID);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO tbl_photo (image, memID) VALUES (@img,@memberID)";
                cmd.Parameters.AddWithValue("@img", arrayImage);
                cmd.Parameters.AddWithValue("@memberID", memID);
                cmd.ExecuteNonQuery();
                transact.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }

        public Boolean addUserAcc()
        {
            try
            {
                connect();
                cmd.CommandText = "INSERT INTO tbl_user (uname, pass, memID, posID) VALUES(@uname,md5(@pass), @ID, @posID)";
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@ID", memID);
                cmd.Parameters.AddWithValue("@posID", posID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
                throw;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

     


        public Boolean addUserImage()
        {

            try
            {
                connect();
                cmd.CommandText = "INSERT INTO tbl_photo (image, memID) VALUES (@img,@memberID)";
                cmd.Parameters.AddWithValue("@img", arrayImage);
                cmd.Parameters.AddWithValue("@memberID", memID);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
           

        }

        public DataTable loadUserList(string search = null)
        {
            DataTable dt = new DataTable();
            string qry = "";
            try
            {
                if (search == null)
                {
                    qry = "SELECT CONCAT(member.lname,', ',member.fname,' ', member.mi) AS name, member.contact, user.uname, pos.position, member.memID FROM tbl_member AS member INNER JOIN tbl_user AS user ON user.memID = member.memID INNER JOIN tbl_position AS pos ON pos.posID = user.posID where member.isdelete = false AND user.isdelete = false ";
                }
                else
                {
                    qry = "SELECT CONCAT(member.lname,', ',member.fname,' ', member.mi) AS name, member.contact, user.uname, pos.position, member.memID FROM tbl_member AS member INNER JOIN tbl_user AS user ON user.memID = member.memID INNER JOIN tbl_position AS pos ON pos.posID = user.posID where member.isdelete = false AND user.isdelete = false AND (member.lname LIKE '%" + search + "%' OR member.fname LIKE '%" + search + "%')";

                }
                connect();
                cmd.CommandText = qry;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return dt;
        }


        public DataTable loadPosition()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT position, posID FROM tbl_position WHERE isdelete = false";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return dt;
        }


        public Boolean updateUser()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_member AS member INNER JOIN tbl_user AS u on u.memID = member.memID  SET member.lname = @Lastname, member.fname = @FirstName,member.mi =@Mi, member.contact = @ContactNo,member.gender = @Gender, member.address = @Address,member.dob = @DateOfBirth, u.posID = @PosID WHERE member.memID = @MemID ";
                cmd.Parameters.AddWithValue("@LastName", lname);
                cmd.Parameters.AddWithValue("@FirstName",fname);
                cmd.Parameters.AddWithValue("@Mi",mi);
                cmd.Parameters.AddWithValue("@Address",address);
                cmd.Parameters.AddWithValue("@DateOfBirth",dob);
                cmd.Parameters.AddWithValue("@Gender",gender);
                cmd.Parameters.AddWithValue("@ContactNo",contact);
                cmd.Parameters.AddWithValue("@MemID",memID);
                cmd.Parameters.AddWithValue("@PosID",posID);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public Boolean updateUserAcc()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_user SET uname = @uname, pass= md5(@pass), posID = @pos WHERE memID = @ID";
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@pos", posID);
                cmd.Parameters.AddWithValue("@ID", memID);
                cmd.ExecuteNonQuery();
                success = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public Boolean updateUserImage()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_photo SET image = @img WHERE memID = @memID";
                cmd.Parameters.AddWithValue("@img", arrayImage);
                cmd.Parameters.AddWithValue("@memID", memID);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public DataTable loadUserInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT pos.position, member.fname, member.lname, member.mi, member.contact, member.address, member.gender, member.dob, user.posID, user.uname, tbl_photo.image FROM tbl_member AS member INNER JOIN tbl_user AS user ON user.memID = member.memID INNER JOIN tbl_photo ON tbl_photo.memID = member.memID INNER JOIN tbl_position AS pos ON pos.posID = user.posID WHERE member.memID = '" + memID + "' ";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                disconnect_db();
            }
            return dt;
        }
        
        //CheckUserAccount
        public bool CheckUser(string uname, string pass)
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_user WHERE uname = @Username AND pass = md5(@Password) AND isdelete = false";
                cmd.Parameters.AddWithValue("@Username", uname);
                cmd.Parameters.AddWithValue("@Password", pass);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        memID = reader.GetString("memID");
                    }
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Check User");
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }

        public string getUserID()
        {
            return memID;
        }

        
        public Boolean DeleteUser()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_member INNER JOIN tbl_user ON tbl_user.memID  = tbl_member.memID SET tbl_member.isdelete = true, tbl_user.isdelete = true WHERE tbl_member.memID ='" + memID + "'";
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "DeleteUser");
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public Boolean deleteCollector()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_member INNER JOIN tbl_collector ON tbl_collector.memID  = tbl_member.memID SET tbl_member.isdelete = true, tbl_collector.isdelete = true WHERE tbl_member.memID ='" + memID + "'";
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "DeleteCollector");
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public Boolean addCollector()
        {
            Boolean success = false;
            try
            {
                connect();
                transact = con.BeginTransaction();
                cmd.CommandText = "INSERT INTO tbl_member (memID, fname, mi, lname,dob, contact, address,gender) VALUES (@memID, @fname, @mi, @lname, @dob, @contact, @address, @gender)";
                //Insert collector information
                cmd.Parameters.AddWithValue("@memID", memID);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@mi", mi);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.ExecuteNonQuery();

                //Insert collector Image
                cmd.CommandText = "INSERT INTO tbl_photo (image, memID) VALUES (@img,@mID)";
                cmd.Parameters.AddWithValue("@img", arrayImage);
                cmd.Parameters.AddWithValue("@mID", memID);
                cmd.ExecuteNonQuery();
                //Insert collector
                cmd.Transaction = transact;
                cmd.CommandText = "INSERT INTO tbl_collector (memID) VALUES (@MemberID)";
                cmd.Parameters.AddWithValue("@MemberID", memID);
                cmd.ExecuteNonQuery();

                cmd.Transaction.Commit();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,$"collector {memID}");
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }

            return success;
        }

        public UserPermissions GetUserPermission(string UserID)
        {
            var UserP = new UserPermissions();
            try
            {
                connect();
                cmd.CommandTimeout = 0;
                cmd.CommandText = "SELECT photo.image, CONCAT(m.`lname`,', ',m.`fname`,' ', m.`mi`)AS name, p.* FROM tbl_position  AS p INNER JOIN tbl_user AS u ON u.`posID` = p.`posID` INNER JOIN tbl_member AS m ON m.`memID` = u.`memID` INNER JOIN tbl_photo AS photo ON photo.`memID` = u.`memID` WHERE u.memID = @UserID";
                cmd.Parameters.AddWithValue("@UserID", UserID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserP.UserImage = (byte[])reader["image"];
                    UserP.Name = reader.GetString("name");
                    UserP.Position = reader.GetString("position");
                    UserP.Dashboard = reader.GetBoolean("dashboard");
                    UserP.Borrower = reader.GetBoolean("borrowers");
                    UserP.Accounts = reader.GetBoolean("accounts");
                    UserP.Collectibles = reader.GetBoolean("collectibles");
                    UserP.Pastdue = reader.GetBoolean("pastdue");
                    UserP.Loans = reader.GetBoolean("loans");
                    UserP.Posting = reader.GetBoolean("posting");
                    UserP.Remittance = reader.GetBoolean("remittances");
                    UserP.Settings = reader.GetBoolean("settings");

                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return UserP;

        }
        public Boolean updateCollector()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_member AS member INNER JOIN tbl_collector AS col ON col.memID = member.memID SET member.fname = @fname, member.mi = @mi, member.lname = @lname, member.gender = @gender, member.dob = @dob, member.contact = @contact, member.address = @address,  WHERE member.memId = @memID";
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@mi", mi);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@contact",contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@memID", memID);
                cmd.ExecuteNonQuery();
                success = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public DataTable loadCollectorList(string search = null)
        {
            DataTable dt = new DataTable();
            string qry;
            try
            {
                if (search == null)
                {
                    qry = "SELECT CONCAT(member.lname,', ',member.fname,' ', member.mi) AS name, member.contact, member.memID , col.collectorID FROM tbl_member AS member INNER JOIN tbl_collector AS col ON col.memID = member.memID WHERE  col.isdelete = false ";
                }
                else
                {
                    qry = "SELECT CONCAT(member.lname,', ',member.fname,' ', member.mi) AS name, member.contact, member.memID FROM tbl_member AS member INNER JOIN tbl_collector AS col ON col.memID = member.memID where  col.isdelete = false AND (member.lname LIKE '%" + search + "%' OR member.fname LIKE '%" + search + "%')";

                }
                connect();
                cmd.CommandText = qry;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return dt;
        }

        public DataTable loadCollectorInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT  member.fname, member.lname, member.mi, member.contact, member.address, member.gender, member.dob, tbl_photo.image FROM tbl_member AS member INNER JOIN tbl_collector AS col ON col.memID = member.memID INNER JOIN tbl_photo ON tbl_photo.memID = member.memID WHERE member.memID = '" + memID + "' ";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                disconnect_db();
            }
            return dt;
        }

       

    }
    #endregion

    //END USER
    public class UserPermissions
    {
        public string UserID { get; set; }
        public byte[] UserImage { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public bool Borrower { get; set; }
        public bool Accounts { get; set; }
        public bool Collectibles { get; set; }
        public bool Dashboard { get; set; }
        public bool Loans { get; set; }
        public bool Pastdue { get; set; }
        public bool Posting { get; set; }
        public bool Remittance { get; set; }
        public bool Settings { get; set; }
    }




}
