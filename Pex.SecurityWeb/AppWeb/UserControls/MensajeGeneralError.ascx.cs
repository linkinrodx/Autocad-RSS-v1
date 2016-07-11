using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Syllabus_PL.UserControls
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected string validationGroup;
        protected string headerText;

        protected void Page_Load(object sender, EventArgs e)
        {

        }            

        public string ValidationGroup
        {
            get { return vsFiltros.ValidationGroup; }
            set { vsFiltros.ValidationGroup = value; }
        }

        public string HeaderText
        {
            get { return vsFiltros.HeaderText; }
            set { vsFiltros.HeaderText = value; }
        }

        /// <summary>
        /// Coloca un mensaje manual del control. Debe utilizar un UpdatePanel para que funcione.
        /// </summary>
        /// <param name="cstmMessage"></param>
        public void SetCustomMessage(string cstmMessage)
        {
            lblCstmMessage.Text = cstmMessage;
            lblCstmMessage.Style["visibility"] = "visible";
        }

        /// <summary>
        /// Limpia el mensaje manual del control. Debe utilizar un UpdatePanel para que funcione.
        /// </summary>
        public void ClearCustomMessage()
        {
            lblCstmMessage.Style["visibility"] = "hidden";
            lblCstmMessage.Text = string.Empty;
        }

        public Label LabelCustomMessage
        {
            get { return lblCstmMessage; }
        }

     }
   
}