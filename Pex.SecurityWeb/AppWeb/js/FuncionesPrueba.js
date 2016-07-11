    function validarDatos()
    {   
        var strMensaje;   
        strMensaje = "";
        txtLogin=document.getElementById("txtLogin");
        txtDescripcion=document.getElementById("txtDescripcion");
        ddlUO=document.getElementById("ddlUO");
        txtPassword=document.getElementById("txtPassword");
        txtRepitPassword=document.getElementById("txtRepitPassword");
          
        if(txtLogin.value=="")
         {
            strMensaje = strMensaje + "Ingrese un nombre.\n";
         }
        
          if(txtDescripcion.value=="")
         {
            strMensaje = strMensaje + "Ingrese el nombre y/o apellido del usuario.\n";
         }
         
         if(ddlUO.value=="")
         {
            strMensaje = strMensaje + "Ingrese una Unidad Organica.\n";
         }
                 
         if (txtPassword.value.length<6)
         {
            strMensaje = strMensaje + "La contraseña debe tener al menos 6 caracteres.\n";
         } 
                 
         if (!(txtPassword.value==txtRepitPassword.value))
         {
            strMensaje = strMensaje + "La contraseña no coindice con su confirmación.\n";
         }
       
         if(strMensaje == "")
         {
            strMensaje = "Los datos son correctos!";
         }                
         alert(strMensaje)         
       
      return false; 
    }
    
    
function IsNumeric(sText)

    {
       var ValidChars = "0123456789.";
       var IsNumber=true;
       var Char;

     
       for (i = 0; i < sText.length && IsNumber == true; i++) 
          { 
          Char = sText.charAt(i); 
          if (ValidChars.indexOf(Char) == -1) 
             {
             IsNumber = false;
             }
          }
       return IsNumber;   
    }
    
    
        function CancelarAjax() {
            //Obtenemos una referncia a la instancia del gestor de peticiones de la página
            var rm = Sys.WebForms.PageRequestManager.getInstance();
            if (rm.get_isInAsyncPostBack()) {
                rm.abortPostBack();
            }
            //Devolvemos siempre false para cancelar el efecto de pulsar el enlace
            return false;
        }  
        
        
              function Error(sender, args)
                 {
                     switch (args.get_reason()) 
                     {
                         case Telerik.Web.UI.InputErrorReason.ParseError:
                             //HandleDateParseError(sender, args.get_inputText().toUpperCase(), args);                             
                             alert('La hora de entrada no tiene el formato correcto')
                             //sender.set_selectedDate(null);
                             sender.focus();
                             break;
                         case Telerik.Web.UI.InputErrorReason.OutOfRange:
                             //HandleDateOutOfRange(sender, args);
                             alert('La hora de entrada ha sobrepasado el limite de rango')
                             //sender.set_selectedDate(null); 
                             sender.focus();                            
                             break;
                     }
                 } 
