using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Syllabus_PL.UserControls
{
    public partial class MensajeExito : System.Web.UI.UserControl
    {
        protected string text;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Text
        {
            get { return lblMjeExito.Text; }
            set
            {
                lblMjeExito.Text = value;

                divMjeExito.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                divMjeExito.Style["display"] = "none";
                if (value.Length > 0)
                {
                    divMjeExito.Style["display"] = "block";
                    divMjeExito.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                }
            }
        }

        public Label LabelMensaje
        {
            get { return lblMjeExito; }
        }

        public HtmlGenericControl DivControl
        {
            get { return divMjeExito; }
        }

    }
}