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
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
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

            //if (tbNumber.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{lNumber.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tbNumber.Focus();
            //    return;
            //}

            //if (tbWidth.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{gbSizePlace.Text}: {lLength.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tbWidth.Focus();
            //    return;
            //}

            //if (tbLength.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{gbSizePlace.Text}: {lWidth.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tbLength.Focus();
            //    return;
            //}

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
    }
}
