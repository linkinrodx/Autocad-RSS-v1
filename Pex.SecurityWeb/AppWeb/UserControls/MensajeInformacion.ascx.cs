using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Syllabus_PL.UserControls
{
    public partial class MensajeInformacion : System.Web.UI.UserControl
    {
        protected string text;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Text
        {
            get { return lblMjeInformacion.Text; }
            set
            {
                lblMjeInformacion.Text = value;

                divMjeInfo.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                divMjeInfo.Style["display"] = "none";
                if (value.Length > 0)
                {
                    divMjeInfo.Style["display"] = "block";
                    divMjeInfo.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                }

            }
        }

        public Label LabelMensaje
        {
            get { return lblMjeInformacion; }
        }

        public HtmlGenericControl DivControl
        {
            get { return divMjeInfo; }
        }

    }
}