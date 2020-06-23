using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dllArendaDictonary.jDiscount
{
    public partial class frmAdd : Form
    {
        public DataRowView row { set; private get; }

        private bool isEditData = false;
        private string oldName;
        private int id = 0;
        private int id_DiscountValue = 0;
        private int id_DiscountObject = 0;

        public frmAdd()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            init_combobox();
            if (row != null)
            {
                id = (int)row["id"];

                dtpStart.Value = (DateTime)row["DateStart"];

                if (row["DateEnd"] == DBNull.Value) { rbStab.Checked = true; rbTime_Click(rbStab, null); }
                else { rbTime.Checked = true; rbTime_Click(rbTime, null); dtpEnd.Value = (DateTime)row["DateEnd"]; }

                cmbTypeDicount.SelectedValue = row["id_TypeDiscount"];
                cmbTypeTenant.SelectedValue = row["id_TypeTenant"];
                cmbTypeAgreements.SelectedValue = row["id_TypeAgreements"];


                #region ""

                Task<DataTable> task = Config.hCntMain.getDiscountValue(id);
                task.Wait();
                if (task.Result != null && task.Result.Rows.Count > 0)
                {
                    id_DiscountValue = (int)task.Result.Rows[0]["id"];
                    
                    if (task.Result.Rows[0]["DiscountPrice"]!=DBNull.Value)
                    tbDiscountPrice.Text = ((decimal)task.Result.Rows[0]["DiscountPrice"]).ToString("0.00");

                    if (task.Result.Rows[0]["PercentDiscount"] != DBNull.Value)
                        tbPercentDiscount.Text = ((decimal)task.Result.Rows[0]["PercentDiscount"]).ToString("0.00");

                    if (task.Result.Rows[0]["Price"] != DBNull.Value)
                        tbPrice.Text = ((decimal)task.Result.Rows[0]["Price"]).ToString("0.00");

                    if (task.Result.Rows[0]["TotalPrice"] != DBNull.Value)
                        tbTotalPrice.Text = ((decimal)task.Result.Rows[0]["TotalPrice"]).ToString("0.00");
                }

                #endregion


                #region ""
                
                task = Config.hCntMain.getDiscountObject(id);
                task.Wait();
                if (task.Result != null && task.Result.Rows.Count > 0)
                {
                    id_DiscountObject = (int)task.Result.Rows[0]["id"];

                    if (task.Result.Rows[0]["id_ObjectLease"] != DBNull.Value)
                        cmbObject.SelectedValue = task.Result.Rows[0]["id_ObjectLease"];

                    if (task.Result.Rows[0]["id_Buildings"] != DBNull.Value)
                        cmbBuilding.SelectedValue = task.Result.Rows[0]["id_Buildings"];

                    if (task.Result.Rows[0]["id_Floor"] != DBNull.Value)
                        cmbFloor.SelectedValue = task.Result.Rows[0]["id_Floor"];



                    if (task.Result.Rows[0]["id_Sections"] != DBNull.Value)
                    {
                        cmbObjectDiscount.SelectedValue = 1;
                        getObjectDicountData();
                        cmbComby.SelectedValue = task.Result.Rows[0]["id_Sections"];
                    }

                    if (task.Result.Rows[0]["id_ReclamaPlace"] != DBNull.Value)
                    {
                        cmbObjectDiscount.SelectedValue = 2;
                        getObjectDicountData();
                        cmbComby.SelectedValue = task.Result.Rows[0]["id_ReclamaPlace"];
                    }

                    if (task.Result.Rows[0]["id_LandPlot"] != DBNull.Value)
                    {
                        cmbObjectDiscount.SelectedValue = 3;
                        getObjectDicountData();
                        cmbComby.SelectedValue = task.Result.Rows[0]["id_LandPlot"];
                    }

                    chbIsException.Checked = (bool)task.Result.Rows[0]["isException"];
                }


                #endregion

                //tbNumber.Text = (string)row["NumberPlace"];
                //oldName = tbNumber.Text.Trim();

                //cmbObject.SelectedValue = row["id_ObjectLease"];
                //cmbBuilding.SelectedValue = row["id_Building"];

                //tbLength.Text = row["Length"].ToString();
                //tbWidth.Text = row["Width"].ToString();

            }

            isEditData = false;
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void init_combobox()
        {
            Task<DataTable> task = Config.hCntMain.getTypeDiscount(false);
            task.Wait();
            DataTable dtTypeDiscount = task.Result;

            cmbTypeDicount.DisplayMember = "cName";
            cmbTypeDicount.ValueMember = "id";
            cmbTypeDicount.DataSource = dtTypeDiscount;
            cmbTypeDicount.SelectedIndex = -1;

            task = Config.hCntMain.getTypeTenant(false);
            task.Wait();
            DataTable dtTypeTenant = task.Result;

            cmbTypeTenant.DisplayMember = "cName";
            cmbTypeTenant.ValueMember = "id";
            cmbTypeTenant.DataSource = dtTypeTenant;
            cmbTypeTenant.SelectedIndex = -1;

            task = Config.hCntMain.getTypeAgreements(false);
            task.Wait();
            DataTable dtTypeAgreements = task.Result;

            cmbTypeAgreements.DisplayMember = "cName";
            cmbTypeAgreements.ValueMember = "id";
            cmbTypeAgreements.DataSource = dtTypeAgreements;
            cmbTypeAgreements.SelectedIndex = -1;

            //

            task = Config.hCntMain.getBuilding(false);
            task.Wait();
            DataTable dtBuilding = task.Result;

            cmbBuilding.DisplayMember = "cName";
            cmbBuilding.ValueMember = "id";
            cmbBuilding.DataSource = dtBuilding;
            cmbBuilding.SelectedIndex = -1;

            task = Config.hCntMain.getObjectLease(false);
            task.Wait();
            DataTable dtObjectLease = task.Result;

            cmbObject.DisplayMember = "cName";
            cmbObject.ValueMember = "id";
            cmbObject.DataSource = dtObjectLease;
            cmbObject.SelectedIndex = -1;

            task = Config.hCntMain.getFloors(false);
            task.Wait();
            DataTable dtFloors = task.Result;

            cmbFloor.DisplayMember = "cName";
            cmbFloor.ValueMember = "id";
            cmbFloor.DataSource = dtFloors;
            cmbFloor.SelectedIndex = -1;


            task = Config.hCntMain.getObjectDiscount(false);
            task.Wait();
            DataTable dtObjectDiscount = task.Result;

            cmbObjectDiscount.DisplayMember = "cName";
            cmbObjectDiscount.ValueMember = "id";
            cmbObjectDiscount.DataSource = dtObjectDiscount;
            cmbObjectDiscount.SelectedIndex = -1;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            #region "Блок проверок для шапки"
            if (cmbTypeDicount.SelectedIndex == -1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{lTypeDiscont.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTypeDicount.Focus();
                return;
            }

            if (cmbTypeTenant.SelectedIndex == -1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{lTypeTenant.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTypeTenant.Focus();
                return;
            }

            if (cmbTypeAgreements.SelectedIndex == -1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{lTypeAgreements.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTypeAgreements.Focus();
                return;
            }
            #endregion

            #region "Блок проверок для таблицы журнал данных по скидкам"
            if (tbPercentDiscount.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{lPercentDiscount.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPercentDiscount.Focus();
                return;
            }

            if (tbDiscountPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{lDiscountPrice.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDiscountPrice.Focus();
                return;
            }

            if (tbPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{lPrice.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPrice.Focus();
                return;
            }
            
            if (tbTotalPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{lTotalPrice.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTotalPrice.Focus();
                return;
            }

            #endregion

            #region "Блок проверок для таблицы журнал объекта скидки "
            if (cmbObject.SelectedIndex == -1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{lObject.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbObject.Focus();
                return;
            }          
            
            if (cmbBuilding.SelectedIndex == -1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{lBuilding.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBuilding.Focus();
                return;
            }

            if (cmbFloor.SelectedIndex == -1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{lFloor.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFloor.Focus();
                return;
            }

            if (cmbObjectDiscount.SelectedIndex == -1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{lObjectDiscount.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbObjectDiscount.Focus();
                return;
            }

            if (cmbComby.SelectedIndex == -1)
            {
                MessageBox.Show(Config.centralText($"Необходимо выбрать\n \"{lComby.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbComby.Focus();
                return;
            }

            #endregion
            
            DateTime dateStart = dtpStart.Value;
            DateTime? dateEnd = null;
            if (rbTime.Checked)
                dateEnd = dtpEnd.Value;

            int id_TypeDiscount = (int)cmbTypeDicount.SelectedValue;
            int id_TypeTenant = (int)cmbTypeTenant.SelectedValue;
            int id_TypeAgreements = (int)cmbTypeAgreements.SelectedValue;
            int id_StatusDiscount = 1;

            Task<DataTable> task = Config.hCntMain.setTDiscount(id, dateStart, dateEnd, id_TypeDiscount, id_TypeTenant, id_TypeAgreements, id_StatusDiscount, true, false, 0);
            task.Wait();

            DataTable dtResult = task.Result;

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((int)dtResult.Rows[0]["id"] == -1)
            {
                MessageBox.Show("В справочнике уже присутствует должность с таким наименованием.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((int)dtResult.Rows[0]["id"] == -9999)
            {
                MessageBox.Show("Произошла неведомая хрень.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (id == 0)
            {
                id = (int)dtResult.Rows[0]["id"];
                Logging.StartFirstLevel(1);
                Logging.Comment("Добавить Тип документа");
                Logging.Comment($"ID: {id}");
                //Logging.Comment($"Наименование: {tbNumber.Text.Trim()}");
                Logging.StopFirstLevel();
            }
            else
            {
                Logging.StartFirstLevel(1);
                Logging.Comment("Редактировать Тип документа");
                Logging.Comment($"ID: {id}");
                //Logging.VariableChange("Наименование", tbNumber.Text.Trim(), oldName);
                Logging.StopFirstLevel();
            }

            task = Config.hCntMain.setDiscountValue(id_DiscountValue, id, decimal.Parse(tbPercentDiscount.Text), decimal.Parse(tbDiscountPrice.Text), decimal.Parse(tbPrice.Text), decimal.Parse(tbTotalPrice.Text), true, false, 0);
            task.Wait();
            
            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dtResult.Rows[0]["id"] == -9999)
            {
                MessageBox.Show("Произошла неведомая хрень.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int? id_ObjectLease=null;
            if (cmbObject.SelectedValue != null) id_ObjectLease = (int)cmbObject.SelectedValue;

            int? id_Buildings = null;
            if (cmbBuilding.SelectedValue != null) id_Buildings = (int)cmbBuilding.SelectedValue;
            
            int? id_Floor = null;
            if (cmbFloor.SelectedValue != null) id_Floor = (int)cmbFloor.SelectedValue;
            
            int? id_Sections = null;
            if ((int)cmbObjectDiscount.SelectedValue == 1) id_Sections = (int)cmbComby.SelectedValue;
                                    
            int? id_ReclamaPlace = null;
            if ((int)cmbObjectDiscount.SelectedValue == 2) id_ReclamaPlace = (int)cmbComby.SelectedValue;

            int? id_LandPlot = null;
            if ((int)cmbObjectDiscount.SelectedValue == 3) id_LandPlot = (int)cmbComby.SelectedValue;

            bool isException = chbIsException.Checked;

            task = Config.hCntMain.setDiscountObject(id_DiscountObject, id, id_ObjectLease, id_Buildings, id_Floor, id_Sections, id_LandPlot, id_ReclamaPlace, isException, true, false, 0);
            task.Wait();

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dtResult.Rows[0]["id"] == -9999)
            {
                MessageBox.Show("Произошла неведомая хрень.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void tbLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void rbTime_Click(object sender, EventArgs e)
        {
            lEnd.Visible = dtpEnd.Visible = (sender as RadioButton).Name.Equals(rbTime.Name);
        }

        private void tbDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.ToString().Contains(e.KeyChar) || (sender as TextBox).Text.ToString().Length == 0))
            {
                e.Handled = true;
            }
            else
                if ((!Char.IsNumber(e.KeyChar) && (e.KeyChar != ',')))
            {
                if (e.KeyChar != '\b')
                { e.Handled = true; }
            }
        }

        private void getObjectDicountData()
        {
            cmbComby.DataSource = null;
            lComby.Text = "";
            if (cmbObjectDiscount.SelectedValue == null) return;



            lComby.Text = cmbObjectDiscount.Text;
            switch ((int)cmbObjectDiscount.SelectedValue)
            {
                case 1: getSection(); break;
                case 2: getPlaceReclame(); break;
                case 3: getArea(); break;
                default: break;
            }           
        }

        private void getSection() {

            if (cmbObject.SelectedValue == null) return;
            if (cmbBuilding.SelectedValue == null) return;
            if (cmbFloor.SelectedValue == null) return;

            int id_object = (int)cmbObject.SelectedValue;
            int id_building = (int)cmbBuilding.SelectedValue;
            int id_floor = (int)cmbFloor.SelectedValue;

            Task<DataTable> task = Config.hCntMain.getSections();
            task.Wait();

            if (task.Result == null || task.Result.Rows.Count == 0) return;

            EnumerableRowCollection<DataRow> rowCollect = task.Result.AsEnumerable()
                .Where(r => r.Field<int>("id_Building") == id_building && r.Field<int>("id_ObjectLease") == id_object && r.Field<int>("id_Floor") == id_floor && r.Field<bool>("isActive"));
            if (rowCollect.Count() > 0)
            {
                cmbComby.DataSource = rowCollect.CopyToDataTable();
                cmbComby.DisplayMember = "cName";
                cmbComby.ValueMember= "id";
                cmbComby.SelectedIndex = -1;
            }
        }

        private void getPlaceReclame() {

            if (cmbObject.SelectedValue == null) return;
            if (cmbBuilding.SelectedValue == null) return;
            

            int id_object = (int)cmbObject.SelectedValue;
            int id_building = (int)cmbBuilding.SelectedValue;
            //int id_floor = (int)cmbFloor.SelectedValue;

            Task<DataTable> task = Config.hCntMain.getReclamaPlace();
            task.Wait();

            if (task.Result == null || task.Result.Rows.Count == 0) return;

            EnumerableRowCollection<DataRow> rowCollect = task.Result.AsEnumerable()
                .Where(r => r.Field<int>("id_Building") == id_building && r.Field<int>("id_ObjectLease") == id_object && r.Field<bool>("isActive"));
            if (rowCollect.Count() > 0)
            {
                cmbComby.DataSource = rowCollect.CopyToDataTable();
                cmbComby.DisplayMember = "NumberPlace";
                cmbComby.ValueMember = "id";
                cmbComby.SelectedIndex = -1;
            }
        }
    
        private void getArea() {

            if (cmbObject.SelectedValue == null) return;            

            int id_object = (int)cmbObject.SelectedValue;
            //int id_building = (int)cmbBuilding.SelectedValue;
            //int id_floor = (int)cmbFloor.SelectedValue;

            Task<DataTable> task = Config.hCntMain.getLandPlot();
            task.Wait();

            if (task.Result == null || task.Result.Rows.Count == 0) return;

            EnumerableRowCollection<DataRow> rowCollect = task.Result.AsEnumerable()
                .Where(r => r.Field<int>("id_ObjectLease") == id_object && r.Field<bool>("isActive"));

            if (rowCollect.Count() > 0)
            {
                cmbComby.DataSource = rowCollect.CopyToDataTable();
                cmbComby.DisplayMember = "NumberPlot";
                cmbComby.ValueMember = "id";
                cmbComby.SelectedIndex = -1;
            }
        }

        private void cmbObjectDiscount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getObjectDicountData();
        }

        private void cmbObject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getObjectDicountData();
        }

        private void tbPercentDiscount_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
            {
                (sender as TextBox).Text = decimal.Parse((sender as TextBox).Text).ToString("0.00");
            }
            else
                (sender as TextBox).Text = "0,00";
        }
    }
}
