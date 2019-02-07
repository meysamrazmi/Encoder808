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
    public partial class Publishfrm : Form
    {
        bool? type;
        string version;
        int id = 0;
        public Publishfrm(bool? type, string version)
        {
            this.type = type;
            this.version = version;
            InitializeComponent();
        }

        private void Publishfrm_Load(object sender, EventArgs e)
        {
            Classes.Version versionItem = null;
            try
            {
                switch (type)
                {
                    case true://new
                        var result = Encoder808.Classes.WebService.getAllVersion();
                        lblLastVersion.Text = string.Format("آخرین ورژن {0} میباشد", result.versions.LastOrDefault()?.vid);
                        break;
                    case false://edit
                        versionItem = Encoder808.Classes.WebService.getVersion(version);
                        break;
                    default://detail   
                        versionItem = Encoder808.Classes.WebService.getVersion(version);
                        btnAction.Enabled = false;
                        break;
                }
                if (versionItem != null)
                {
                    txtDescription.Text = versionItem.description;
                    txtLink.Text = versionItem.update_link;
                    mstxtVersion.Text = versionItem.vid;
                    id = versionItem.id;
                    chkRequire.Checked = versionItem.force_update == "1";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text) ||
                string.IsNullOrEmpty(txtLink.Text) ||
                string.IsNullOrEmpty(mstxtVersion.Text)
                )
            {
                MessageBox.Show("تمام فیلدها اجباری می باشد");
                return;
            }

            var force_update = chkRequire.Checked ? "1" : "0";
            try
            {
                bool result = false;
                if (id > 0)
                {
                    result = Encoder808.Classes.WebService.editPublish(id, mstxtVersion.Text, txtDescription.Text, force_update, txtLink.Text, Mainfrm.userLogin.session_name + "=" + Mainfrm.userLogin.sessid, Mainfrm.userLogin.token);
                }
                else
                {
                    result = Encoder808.Classes.WebService.newPublish(mstxtVersion.Text, txtDescription.Text, force_update, txtLink.Text, Mainfrm.userLogin.session_name + "=" + Mainfrm.userLogin.sessid, Mainfrm.userLogin.token);
                }

                if (result)
                {
                    txtDescription.Text =
                    txtLink.Text =
                    mstxtVersion.Text = string.Empty;
                    chkRequire.Checked = false;
                    id = 0;
                    MessageBox.Show("عملیات با موفقیت انجام شد");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
