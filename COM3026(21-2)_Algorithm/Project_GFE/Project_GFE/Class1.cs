using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace FinalSubject
{
    public partial class MyTextBox : TextBox
    {
        [DefaultValue(false)]
        [Browsable(true)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        public MyTextBox()
        {
            this.AutoSize = false;
        }
    }
}
