using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encoder808
{
    public partial class ManagePublishfrm : Form
    {
        public ManagePublishfrm()
        {
            InitializeComponent();
        }

        private void ManagePublishfrm_Load(object sender, EventArgs e)
        {
            fillGridView();
        }

        void fillGridView()
        {
            try
            {
                var result = Encoder808.Classes.WebService.getAllVersion();
                //listPublish.DisplayMember = "vid - description";
                //listPublish.ValueMember = "id";
                //listPublish.DataSource = result.versions;
                foreach (Classes.Version item in result.versions)
                {
                    listPublish.Items.Add(item.vid + "_" + item.description);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new Publishfrm(true, string.Empty);
            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var version = getVersionOfPublishList();
            if (version  == null)
            {
                MessageBox.Show("لطفا نسخه مورد نظر را انتخاب کنید");
                return;
            }
            var frm = new Publishfrm(false, version);
            frm.ShowDialog();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            var version = getVersionOfPublishList();
            if (version == null)
            {
                MessageBox.Show("لطفا نسخه مورد نظر را انتخاب کنید");
                return;
            }
            var frm = new Publishfrm(null, version);
            frm.ShowDialog();
        }

        string getVersionOfPublishList()
        {
            if (listPublish.SelectedIndex > -1)
            {
                var text = listPublish.SelectedItem.ToString();
                return text.Split('_').FirstOrDefault();
            }
            return null;
        }
    }
}
