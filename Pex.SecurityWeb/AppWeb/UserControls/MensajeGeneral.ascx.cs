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
    public partial class MensajeGeneral : System.Web.UI.UserControl
    {
        protected string validationGroup;
        protected string headerText;
        //protected HtmlGenericControl divMjeExito;
        //protected HtmlGenericControl divMjeInfo;
        //protected HtmlGenericControl divMjeError;

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
        //public void SetCustomMessage(string cstmMessage)
        //{
        //    lblCstmMessage.Text = cstmMessage;
        //    lblCstmMessage.Style["display"] = "block";
        //}

        /// <summary>
        /// Limpia el mensaje manual del control. Debe utilizar un UpdatePanel para que funcione.
        /// </summary>
        //public void ClearCustomMessage()
        //{
        //    lblCstmMessage.Style["display"] = "none";
        //    lblCstmMessage.Text = " ";
        //}

        //public Label LabelCustomMessage
        //{
        //    get { return lblCstmMessage; }
        //}



        public string TextoError
        {
           get { return lblCstmMessage.Text; }        
           set
           {
                
                if (value.Length > 0)
                {
                    divMjeExito.Style["display"] = "block";
                }
                else
                {
                    divMjeError.Style["display"] = "none";
                }

                lblCstmMessage.Text = value;

           }
        }


        public string TextoExito
        {
            get { return lblMjeExito.Text; }
            set
            {
                lblMjeExito.Text = value;
                if (value.Length > 0)
                {
                    divMjeExito.Style["display"] = "block";
                }
                else
                {
                    divMjeExito.Style["display"] = "none";
                }
            }
        }


        public string TextoInformacion
        {
            get { return lblMjeInformacion.Text; }
            set
            {
                lblMjeInformacion.Text = value;
                divMjeInfo.Style["display"] = "none";
                if (value.Length > 0)
                    divMjeInfo.Style["display"] = "block";
            }
        }


        //        function mostrarProcesando() {
        //            if (!Page_ClientValidate('vgrConfigurarGrupos')) {
        //                document.getElementById('lblMjeBusqueda').style.display = 'block';
        //                return;
        //            }
        //            document.getElementById('lblMjeBusqueda').style.display = 'none';
        //            document.getElementById('<%= btnProcesar.ClientID %>').click();
        //        }

        //public string TextoError
        //{
        //    get { return lblCstmMessage.Text; }
        //    set
        //    {
        //        lblCstmMessage.Text = value;
        //        divMjeError.Style["display"] = "none";
        //        if (value.Length > 0)
        //            divMjeError.Style["display"] = "block";
        //    }
        //}

        public bool ValidarDatos()
        {
            bool valido; 
            this.Page.Validate(this.ValidationGroup);
            valido = this.Page.IsValid;
            if (valido)
            {

                    divMjeError.Style["display"] = "none";
            }
            else 
            {
                    divMjeError.Style["display"] = "block";
            }

            return valido;
        }

    }
}