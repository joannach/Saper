using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class HighscoreForm : Form
    {

        public HighscoreForm(Highscore h)
        {
            InitializeComponent();
            for (int i = 0; i < Highscore.SIZE; i++)
            {
                ListViewItem item = m_listView.Items.Add(h.get_time(i).ToString());
                item.SubItems.Add(h.get_name(i));
            }
         
        }

        private void HighscoreForm_Load(object sender, EventArgs e)
        {

        }

        private void m_button_ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
