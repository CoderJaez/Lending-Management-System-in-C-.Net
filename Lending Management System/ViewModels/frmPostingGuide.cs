using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lending_Management_System.Modules;

namespace Lending_Management_System
{
    public partial class frmPostingGuide : Form
    {
        BorrowerModel b = new BorrowerModel();
        private List<string> pCode = new List<string>();
        private List<string> cCode = new List<string>();
        private List<string> bCode = new List<string>();
        private int NoOfProvinceCheck = 0;
        private int NoOfCitMunCheck = 0;
        public frmPostingGuide()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTo.Text = dpDate.Value.AddDays(6).ToLongDateString();
        }

        public void loadSelectedArea()
        {
            cbArea.DisplayMember = "Text";
            cbArea.ValueMember = "Value";
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");

            dt.Rows.Add("","");
            dt.Rows.Add("PROVINCE","1");
            dt.Rows.Add("CITY/MUNICIPALITY AND PROVINCE","2");
            dt.Rows.Add("BARANGAY AND CITY/MUNICIPALITY","3");
            cbArea.DataSource = dt;

        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbArea.SelectedValue.ToString() != "")
            {
                if (cbArea.SelectedValue.ToString() == "1")
                {
                    NoOfProvinceCheck = 0;
                    dgProvince.Visible = true;
                    dgCityMuncipality.Visible = false;
                    dgBarangay.Visible = false;
                    LoadProvince();
                }
                else if (cbArea.SelectedValue.ToString() == "2")
                {
                    NoOfProvinceCheck = 0;
                    cCode.Clear();
                    pCode.Clear();
                    dgProvince.Visible = true;
                    dgCityMuncipality.Visible = true;
                    dgBarangay.Visible = false;
                    LoadProvince();
                    LoadCityMun();
                }
                else if (cbArea.SelectedValue.ToString() == "3")
                {
                    cCode.Clear();
                    bCode.Clear();
                    NoOfCitMunCheck = 0;
                    dgProvince.Visible = false;
                    dgCityMuncipality.Visible = true;
                    dgBarangay.Visible = true;
                    LoadCityMun();
                    LoadBarangay();
                }
            } else
            {
                dgProvince.Visible = false;
                dgCityMuncipality.Visible = false;
                dgBarangay.Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPostingGuide_Load(object sender, EventArgs e)
        {
            loadSelectedArea();
        }

        private void LoadProvince()
        {
            dgProvince.Rows.Clear();
                foreach (DataRow row in b.LoadProvince().Rows)
                    dgProvince.Rows.Add(false, row["provCode"].ToString(), row["provDesc"].ToString());
        }

        private void LoadCityMun()
        {
            dgCityMuncipality.Rows.Clear();
            if (cbArea.SelectedValue.ToString() == "2")
            {
                if (NoOfProvinceCheck > 0)
                    foreach (DataRow row in b.LoadCityMunicipality(null, pCode).Rows)
                        dgCityMuncipality.Rows.Add(false, row["citymunCode"].ToString(), row["citymunDesc"].ToString());
            }
            else if(cbArea.SelectedValue.ToString() == "3")
            {
                foreach (DataRow row in b.LoadCityMunicipality().Rows)
                    dgCityMuncipality.Rows.Add(false, row["citymunCode"].ToString(), row["citymunDesc"].ToString());
            }
        }

        private void LoadBarangay()
        {
            dgBarangay.Rows.Clear();
            if(NoOfCitMunCheck > 0)
                foreach (DataRow row in b.LoadBarangay(null,cCode).Rows)
                    dgBarangay.Rows.Add(false, row["brgyCode"].ToString(), row["brgyDesc"].ToString());
        }

        private void dgProvince_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(dgProvince.Columns[e.ColumnIndex].Name == "checkbox")
                {
                    if((bool)dgProvince.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                    {
                        dgProvince.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        pCode.Remove(dgProvince.Rows[e.RowIndex].Cells[1].Value.ToString());
                        NoOfProvinceCheck -= 1;
                    } else
                    {
                        dgProvince.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        pCode.Add(dgProvince.Rows[e.RowIndex].Cells[1].Value.ToString());
                        NoOfProvinceCheck += 1;
                    }
                    LoadCityMun();
                }
                
            }
        }

        private void dgCityMuncipality_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgCityMuncipality.Columns[e.ColumnIndex].Name == "CityMunCheckbox")
                {
                    if ((bool)dgCityMuncipality.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                    {
                        dgCityMuncipality.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        cCode.Remove(dgCityMuncipality.Rows[e.RowIndex].Cells[1].Value.ToString());
                        NoOfCitMunCheck -= 1;
                    }
                    else
                    {
                        dgCityMuncipality.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        cCode.Add(dgCityMuncipality.Rows[e.RowIndex].Cells[1].Value.ToString());
                        NoOfCitMunCheck += 1;
                    }
                    LoadBarangay();
                }

            }
        }

        private void dgBarangay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgBarangay.Columns[e.ColumnIndex].Name == "BrgyCheckbox")
                {
                    if ((bool)dgBarangay.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                    {
                        dgBarangay.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        bCode.Remove(dgBarangay.Rows[e.RowIndex].Cells[1].Value.ToString());
                    }
                    else
                    {
                        dgBarangay.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        bCode.Add(dgBarangay.Rows[e.RowIndex].Cells[1].Value.ToString());
                    }
                }

            }
        }

        private bool validate()
        {
            if (cbArea.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Area Field is Required");
                return false;
            } else
            {
                if (pCode.Count <= 0 && cbArea.SelectedValue.ToString() == "1")
                {
                    MessageBox.Show($"Please check the desired list of provinces.");
                    return false;
                }
                else if ((pCode.Count <= 0 || cCode.Count <= 0) && cbArea.SelectedValue.ToString() == "2")
                {
                    MessageBox.Show($"Please check the desired list of provinces and cities/municipalities.");
                    return false;
                }
                else if ((bCode.Count <= 0 || cCode.Count <= 0) && cbArea.SelectedValue.ToString() == "3")
                {
                    MessageBox.Show($"Please check the desired list of  cities/municipalities and barangays.");
                    return false;
                }
            }
            return true;
        }
        private void btnPosting_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                frmLedger ledger = new frmLedger(Convert.ToInt32(cbArea.SelectedValue.ToString()), pCode, cCode, bCode, dpDate.Value.ToString("yyyy-MM-dd"));
                ledger.ShowDialog();
            }
        }
    }
}
