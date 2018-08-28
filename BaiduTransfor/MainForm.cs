using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiduTransfor
{
    public partial class MainForm : Form
    {

        // 在平台申请的APP_ID 详见 http://api.fanyi.baidu.com/api/trans/product/desktop?req=developer
        private static readonly String APP_ID = "20170807000071140";
        private static readonly String SECURITY_KEY = "uGLl38wagCGsX2eapwJB";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Transfor(object sender, EventArgs e)
        {
            if (sender != null)
            {
                TransApi api = new TransApi(APP_ID, SECURITY_KEY);
                string dest = (sender as Button).Text;
                String query = tb_input.Text;
                if (!string.IsNullOrWhiteSpace(query))
                {
                    String result = api.getTransResult(query, "auto", dest);

                    int site = 0;
                    String[] output = new String[9];
                    for (int i = 0; i <= 8; i++)
                    {
                        int start = result.IndexOf("\"", site);
                        site = start + 1;
                        int end = result.IndexOf("\"", site);
                        site = end + 1;
                        output[i] = result.Substring(start + 1, end);
                    }
                    tb_output.Text = output[8];
                }
            }
        }
    }
}
