using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Lending_Management_System.Modules
{
    class BorrowerModel : db_connect
    {
        public string fname { get; set; }
        public string mi { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public string contact { get; set; }
        public string occupation { get; set; }
        public string address { get; set; }
        public string dob { get; set; }
        public string memID { get; set; }
        public string borID { get; set; }
        public int colID { get; set; }
        public string brgyCode { get; set; }
        public string citymunCode { get; set; }
        public string provCode { get; set; }
        public Byte[] arrayImage { get; set; }


        private int start = 0;
        private int limit = 100;
        private string search = "";

        public DataTable LoadProvince()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandTimeout = 0;
                cmd.CommandText = "SELECT DISTINCT refprovince.`provCode`, refprovince.`provDesc` FROM tbl_member AS m  INNER JOIN refprovince ON refprovince.`provCode` = m.provCode";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            cmd.Dispose();
            reader.Close();
            return dt;
        }

        public DataTable LoadCityMunicipality(string pCode = null , List<string> provCode = null)
        {
            DataTable dt = new DataTable();
            
            string ProvCode ="";
            if (pCode != null)
                ProvCode = $"where m.provCode = '{pCode}'";
            else if(provCode != null)
                ProvCode = $"where m.provCode IN ({string.Join(",",provCode)})";

            try
            {
                connect();
                cmd.CommandText = $"SELECT DISTINCT refcitymun.`citymunCode`, refcitymun.`citymunDesc` FROM tbl_member AS m INNER JOIN refcitymun ON refcitymun.`citymunCode` = m.`citymunCode` {ProvCode} ORDER BY refcitymun.`citymunDesc` ASC";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Zeustech Lending System");
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }


        public DataTable LoadBarangay(string citymunCode = null, List<string> citymunListCode = null)
        {
            string code = "";
            if (citymunCode != null)
                code = $"where m.citymunCode = '{citymunCode}'";
            else if (citymunListCode != null)
                code = $"where m.citymunCode IN ({string.Join(",", citymunListCode)})";
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = $"SELECT DISTINCT refbrgy.`brgyCode`, refbrgy.`brgyDesc` FROM  tbl_member AS m INNER JOIN refbrgy  ON refbrgy.`brgyCode` = m.`brgyCode` {code}";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }



        public int totalRows()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT COUNT(*) AS total FROM tbl_borrower AS b INNER JOIN tbl_member AS mem ON mem.memID = b.memID  WHERE b.isdelete = false";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }

        public int filtered_rows()
        {
            try
            {
                connect();
                cmd.CommandText = $"SELECT COUNT(*) AS total FROM tbl_borrower AS b INNER JOIN tbl_member AS mem ON mem.memID = b.memID  WHERE b.isdelete = false AND (mem.lname LIKE  '%{search}%' OR mem.fname LIKE '%{search}%' OR b.borrowerID LIKE '{search}%') LIMIT {start},{limit}";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }
        public DataTable loadBorrowerList(int _start, int _limit, string _search = null)
        {
            start = _start;
            limit = _limit;
            search = _search;
            string qry = "";
            DataTable dt = new DataTable();
            try
            {
                connect();
                if (search == null)
                {
                    qry = "SELECT b.borrowerID, b.memID,CONCAT(mem.lname, ', ', mem.fname,' ', mem.mi) AS bname, mem.contact, mem.occupation, DATE_FORMAT(mem.dob,'%M %d, %Y') AS dob, b.date_reg FROM tbl_borrower AS b INNER JOIN tbl_member AS mem ON mem.memID = b.memID  WHERE b.isdelete = false ORDER BY mem.lname ASC, mem.fname ASC";
                }
                else
                {
                    qry = $"SELECT b.borrowerID, b.memID,CONCAT(mem.lname, ', ', mem.fname,' ', mem.mi) AS bname, mem.contact, mem.occupation, DATE_FORMAT(mem.dob,'%M %d, %Y') AS dob, b.date_reg FROM tbl_borrower AS b INNER JOIN tbl_member AS mem ON mem.memID = b.memID  WHERE b.isdelete = false AND (mem.lname LIKE  '%{search}%' OR mem.fname LIKE '%{search}%' OR b.borrowerID LIKE '{search}%') ORDER BY mem.lname ASC, mem.fname ASC LIMIT {start},{limit}";

                }
                cmd.CommandText = qry;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }

        public IList<address> getProvince()
        {
            var addr = new List<address>();
            try
            {
                connect();
                cmd.CommandText = "SELECT provCode,provDesc FROM refprovince ORDER BY provDesc ASC";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    address adr = new address();
                    adr.code = reader.GetString("provCode");
                    adr.Description = reader.GetString("provDesc").ToUpper();
                    addr.Add(adr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");

            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return addr;
        }

        public IList<address> getCityMun(string code)
        {
            var addr = new List<address>();
            try
            {
                connect();
                cmd.CommandText = "SELECT citymunCode,citymunDesc FROM refcitymun WHERE provCode = @provCode ORDER BY citymunDesc ASC";
                cmd.Parameters.AddWithValue("@provCode", code);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    address adr = new address();
                    adr.code = reader.GetString("citymunCode");
                    adr.Description = reader.GetString("citymunDesc").ToUpper();
                    addr.Add(adr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");

            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return addr;
        }
        public IList<address> getBrgy(string code)
        {
            var addr = new List<address>();
            try
            {
                connect();
                cmd.CommandText = "SELECT brgyCode,brgyDesc FROM refbrgy WHERE citymunCode = @citymunCode ORDER BY brgyDesc ASC";
                cmd.Parameters.AddWithValue("@citymunCode", code);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    address adr = new address();
                    adr.code = reader.GetString("brgyCode");
                    adr.Description = reader.GetString("brgyDesc").ToUpper();
                    addr.Add(adr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");

            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return addr;
        }
        public Borrower getBorrowerInfoViaLoan(string LoanNo)
        {
            var borrowerInfo = new Borrower();
            try
            {
                connect();
                cmd.CommandText = "SELECT CONCAT(m.lname,', ', m.fname,' ', m.mi) AS name,CONCAT(br.brgyDesc, ', ', ci.citymunDesc,', ',p.provDesc) as address ,m.contact, l.loanNO FROM tbl_member AS m  INNER JOIN tbl_borrower AS b ON b.memID = m.memID INNER JOIN tbl_borrower_acc AS a ON a.borrowerID  = b.borrowerID  INNER JOIN tbl_loan AS l ON l.accID = a.accID INNER JOIN refbrgy br ON br.brgyCode = m.brgyCode inner join refcitymun AS ci ON ci.citymunCode = m.citymunCode INNER JOIN refprovince AS p on p.provCode = m.provCode WHERE l.loanNO = @LoanNo";
                cmd.Parameters.AddWithValue("@LoanNo", LoanNo);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    borrowerInfo.LoanNo = reader.GetString("loanNO");
                    borrowerInfo.Name = reader.GetString("name");
                    borrowerInfo.ContactNo = reader.GetString("contact");
                    borrowerInfo.Address = reader.GetString("address");
                    
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
            return borrowerInfo;
        }
        public String getBorrowerID()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT borrowerID FROM tbl_borrower ORDER BY borrowerID DESC LIMIT 1";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToString(Convert.ToInt32(reader["borrowerID"].ToString()) + 1) : "100010001";
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
     
        public Boolean addBorrowerInfo()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "INSERT INTO tbl_member (memID, lname, fname, mi, gender, dob, contact, occupation, address,brgyCode,citymunCode,provCode) VALUES (@mID, @lname, @fname, @mi, @gender, @dob, @contact, @occupation, @address,@BrgyCode,@CityMunCode,@ProvCode)";
                cmd.Parameters.AddWithValue("@mID", memID);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("mi", mi);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@occupation", occupation);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@BrgyCode", brgyCode);
                cmd.Parameters.AddWithValue("@CityMunCode", citymunCode);
                cmd.Parameters.AddWithValue("@ProvCode", provCode);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System!");

            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public Boolean addBorrower()
        {
            Boolean success = false;
            try
            {
                connect();
                transact = con.BeginTransaction();
                cmd.Transaction = transact; 
                cmd.CommandText = "INSERT INTO tbl_borrower (borrowerID, memID) VALUES (@bID, @memID)";
                cmd.Parameters.AddWithValue("@bID", borID);
                cmd.Parameters.AddWithValue("@memID", memID);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO tbl_member (memID, lname, fname, mi, gender, dob, contact, occupation, address,brgyCode,citymunCode,provCode) VALUES (@mID, @lname, @fname, @mi, @gender, @dob, @contact, @occupation, @address,@BrgyCode,@CityMunCode,@ProvCode)";
                cmd.Parameters.AddWithValue("@mID", memID);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("mi", mi);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@occupation", occupation);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@BrgyCode", brgyCode);
                cmd.Parameters.AddWithValue("@CityMunCode", citymunCode);
                cmd.Parameters.AddWithValue("@ProvCode", provCode);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO tbl_photo (image, memID) VALUES (@img,@memberID)";
                cmd.Parameters.AddWithValue("@img", arrayImage);
                cmd.Parameters.AddWithValue("@memberID", memID);
                cmd.ExecuteNonQuery();
                transact.Commit();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public Boolean deleteBorrower()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_borrower AS b INNER JOIN tbl_member AS m ON m.memID = b.memID SET m.isdelete = true, b.isdelete = true WHERE b.borrowerID = @bID";
                cmd.Parameters.AddWithValue("@bID", borID);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            } finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public DataTable loadBorrowerInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT b.collectorID, member.occupation, member.*,refbrgy.brgyDesc, refcitymun.citymunDesc, refprovince.provDesc, tbl_photo.image FROM tbl_member AS member INNER JOIN tbl_photo ON tbl_photo.memID = member.memID INNER JOIN tbl_borrower AS b ON b.memID = member.memID INNER JOIN refbrgy ON refbrgy.brgyCode = member.brgyCode INNER JOIN refcitymun ON refcitymun.citymunCode = member.citymunCode INNER JOIN refprovince ON refprovince.provCode = member.provCode WHERE b.borrowerID = '" + borID + "' ";
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

        
        public string getBorrowerName()
        {
            return $"{lname}, {fname} {mi}";
        }

        public Boolean updateBorrowerInfo()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_member AS member INNER JOIN tbl_borrower AS b ON b.memID = member.memID SET  member.occupation = @occupation, member.fname = @fname, member.mi = @mi, member.lname = @lname, member.gender = @gender, member.dob = @dob, member.contact = @contact, member.address = @address, member.brgyCode = @BrgyCode, member.citymunCode = @CityMunCode, member.provCode = @ProvCode WHERE b.borrowerID = @bID";
                cmd.Parameters.AddWithValue("@occupation", occupation);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@mi", mi);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@bID", borID);
                cmd.Parameters.AddWithValue("@BrgyCode",brgyCode);
                cmd.Parameters.AddWithValue("@CityMunCode",citymunCode);
                cmd.Parameters.AddWithValue("@ProvCode",provCode);
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
    }
    //
    //
    //Borrower Account Modules
    //
    //
    class borrowerAcc:db_connect
    {
        public string accID { get; set; }
        public string borrowerID { get; set; }


        private int start = 0;
        private int limit = 100;
        private string search = "";

        public int totalRows()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT COUNT(*) AS total FROM tbl_borrower_acc AS a INNER JOIN tbl_borrower AS b ON b.borrowerID = a.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID where a.isdelete = false";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }

        public int filtered_rows()
        {
            string qry = null;
            try
            {
                connect();
                qry = $"SELECT COUNT(*) AS total FROM tbl_borrower_acc AS a INNER JOIN tbl_borrower AS b ON b.borrowerID = a.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID where a.isdelete = false AND (m.lname LIKE @LastName OR m.fname LIKE @FirstName OR a.accID LIKE @AccountID) LIMIT {start},{limit}";
                cmd.CommandText = qry;
                cmd.Parameters.AddWithValue("@LastName", $"%{search}%");
                cmd.Parameters.AddWithValue("@FirstName", $"%{ search}%");
                cmd.Parameters.AddWithValue("@AccountID", $"%{search}%");
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }
        public String getAccID()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT accID FROM tbl_borrower_acc   ORDER BY accID DESC LIMIT 1";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToString(Convert.ToInt32(reader["accID"].ToString()) + 1) : "100020001";
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

        public DataTable loadAccountsForLoan(string search)
        {
            DataTable dt = new DataTable();
            try
            {
                connect();

                cmd.CommandText = "SELECT CONCAT(m.lname,', ', m.fname,' ', m.mi) AS name,m.address,m.contact, a.accID, a.date_reg FROM tbl_borrower_acc AS a INNER JOIN tbl_borrower AS b ON b.borrowerID = a.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID where a.isdelete = false AND a.isPendingLoan = false AND (m.lname LIKE @LastName OR m.fname LIKE @FirstName OR a.accID LIKE @AccountID) ORDER BY name ASC";
                cmd.Parameters.AddWithValue("@LastName", $"%{search}%");
                cmd.Parameters.AddWithValue("@FirstName", $"%{ search}%");
                cmd.Parameters.AddWithValue("@AccountID", $"%{search}%");
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");

            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }

        public DataTable loadBorrowersAccounts(string BorrowerID)
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT a.`accID`, CONCAT(m.lname,', ', m.fname,' ', m.mi) AS NAME,a.date_reg FROM tbl_borrower_acc AS a INNER JOIN tbl_borrower AS b ON b.borrowerID = a.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID  WHERE a.isdelete = FALSE AND a.borrowerID = @BorrowerID ORDER BY date_reg ASC";
                cmd.Parameters.AddWithValue("@BorrowerID",BorrowerID);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }
        public DataTable loadAccounts(string _search,int _start, int _limit)
        {
            string qry = "";
            search = _search;
            start = _start;
            limit = _limit;
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandTimeout = 0;
                qry = $"SELECT a.`borrowerID`, CONCAT(m.lname,', ', m.fname,' ', m.mi) AS name,CONCAT(brgy.`brgyDesc`,', ',c.`citymunDesc`,', ',p.`provDesc` ) AS address, m.contact, COUNT(a.accID) accounts FROM tbl_borrower_acc AS a INNER JOIN tbl_borrower AS b ON b.borrowerID = a.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID INNER JOIN refprovince p ON p.`provCode` = m.`provCode` INNER JOIN refcitymun AS c ON c.`citymunCode` = m.`citymunCode` INNER JOIN refbrgy brgy ON brgy.`brgyCode` = m.`brgyCode` where a.isdelete = false AND (m.lname LIKE @LastName OR m.fname LIKE @FirstName OR a.accID LIKE @AccountID) GROUP BY a.`borrowerID`  ORDER BY m.lname ASC,m.fname LIMIT {start},{limit}";
                cmd.CommandText = qry;
                cmd.Parameters.AddWithValue("@LastName",$"%{search}%");
                cmd.Parameters.AddWithValue("@FirstName",$"%{ search}%");
                cmd.Parameters.AddWithValue("@AccountID", $"%{search}%");
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");

            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }

        public Boolean addAccount()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "INSERT INTO tbl_borrower_acc (accID, borrowerID ) VALUES (@accID, @bID)";
                cmd.Parameters.AddWithValue("@accID", accID);
                cmd.Parameters.AddWithValue("@bID", borrowerID);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public bool delete_batch(List<string> AccountIDs)
        {
            string qry = "UPDATE `tbl_borrower_acc` SET ";
            string idlist = "";
            foreach (var id in AccountIDs)
            {
                qry += $"`isdelete` = CASE WHEN `borrowerID` = '{id}' THEN true ELSE isdelete END,";
                idlist += $"'{id}',";
            }
            idlist = idlist.Remove(idlist.Length - 1, 1);
            qry = qry.Remove(qry.Length - 1, 1);
            qry += $" WHERE borrowerID IN({idlist})";
            try
            {
                connect();
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        public bool deleteBorrowerAccList(string BorrowerID)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_borrower_acc SET isdelete = true WHERE borrowerID = @BorrowerID";
                cmd.Parameters.AddWithValue("@BorrowerID", BorrowerID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
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

        public bool deleteBorrowerAcc(string AccountID)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_borrower_acc SET isdelete = true WHERE accID = @AccountID";
                cmd.Parameters.AddWithValue("@AccountID", AccountID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
                return false;
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }

        public int countBorrowerAcc()
        {
            int no = 0;
            try
            {
                connect();
                cmd.CommandText = "SELECT COUNT(*) AS n FROM tbl_borrower_acc WHERE borrowerID = @borrowerID AND isdelete = FALSE AND active = TRUE";
                cmd.Parameters.AddWithValue("@borrowerID", borrowerID);
                reader = cmd.ExecuteReader();
                no = (reader.Read()) ? Convert.ToInt32(reader["n"].ToString()) :0;
                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            } finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return no;
        }

    }

    class address
    {
        public string code { get; set; }
        public string Description { get; set; }
    }
}
