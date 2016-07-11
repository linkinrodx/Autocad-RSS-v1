/*
* Load() - Maneja el evento onload del tag BODY
*/
function Load()
{
	ShowMessage();
}
	
/*
* ShowMessage() - Muestra un cuadro de diálogo (frmMensaje) con el 
* mensaje contenido en el tag hidden con id "_MessageError"
*/
function ShowMessage()
{
	var hidMsg = document.getElementById("_MessageError");
	if (hidMsg.value.length > 0) { MensajeResultado(hidMsg.value); }
	hidMsg.value = "";
}
	
function MensajeResultado(str){	
		var resul = window.showModalDialog("mensaje.aspx?message="+ str,str,"dialogWidth=310px;dialogHeight=158px;status=0");
}
function EventoEnter()
{
	if (window.event.keyCode == 13)
	{
    	var btn = document.getElementById("_filtros__search");
		if (btn) btn.click();
		window.focus();	
    }
}
			
/*** Abrir cuadro de diálogo modal (cualquier navegador) ***/
function ShowModalDialog(url, name, width, height)
{
	var res;
	if (window.showModalDialog)
	{
		res = window.showModalDialog(url, name, "dialogWidth:" + width + "px;dialogHeight:" + height + "px;status=0");
	}
	else
	{ 
		//netscape.security.PrivilegeManager.enablePrivilege("UniversalBrowserWrite");
		res = window.open(url, name, 'height=' + height + ',width=' + width + ',toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,modal=yes');
		res.focus();
		//netscape.security.PrivilegeManager.disablePrivilege("UniversalBrowserWrite");
	}	
	return res;		
}

/*** Elimina todos los elementos de una lista (Tag SELECT) ***/
function LimpiarLista(pstrNombreControl)
{
	var lobjControl = document.getElementById(pstrNombreControl);
	for (var i = lobjControl.length - 1; i >= 0; i--)
		lobjControl.remove(i);	
}

// Validaciones de ingreso
function solonumeros(e)
{
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || (key >= 48 && key <= 57));
}

function solonumerosypunto(e)
{
	var target = (e.target ? e.target : e.srcElement);
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	if (key == 46) return (target.value.length > 0 && target.value.indexOf(".") == -1);
	return (key <= 12 || (key >= 48 && key <= 57));
}

function sololetrasynumeros(e)
{
	var target = (e.target ? e.target : e.srcElement);
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || (key>=48 && key <=57) || (key>=65 && key <=90) || (key>=97 && key<=122) || (key==32) || (key>=164 && key <=165));
}
function sololetras(e)
{	 
	var target = (e.target ? e.target : e.srcElement);
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || (key>=65 && key <=90) || (key>=97 && key<=122) || (key==32) || (key>=164 && key <=165)); 
}
function soloalfanumericos(e)
{	 
    var cadena="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789 ";
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	var letra=String.fromCharCode(key);
	var idx=cadena.indexOf(letra)
	if(idx!=-1){
	 	return true;	
	}else{
		return false;
			
	}
	
	//return (key <= 12 || (key>=65 && key <=90) || (key>=97 && key<=122) || (key==32) || (key>=164 && key <=165) || (key>=48 && key <=57) );
}

function solonumerosyguion(e)
{
	var key = (e ? e.keyCode || e.which : window.event.keyCode);
	return (key <= 12 || key == 45 ||(key >= 48 && key <= 57));
}
 
/*FUNCION QUE VALIDA LA CANTIDAD DE CARACTERES DE UN TEXTAREA*/
function Maximo_TextArea(total,dato){   
	aux = dato;
	if (aux.length>=total){
		if (event.keyCode == 8){
			event.returnValue = true; 
		}else{
			alert("Maximo " + total + " caracteres"); 
			event.returnValue = false;
		}
	}	
}//End Function Maximo_textarea


// Remover los espacios en blanco a la izquierda
function LTrim( value ) {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Remover los espacios en blanco al final
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Remover los espacios en ambos lados
function trim( value ) {
	
	return LTrim(RTrim(value));
	
}

 function cambia(obj, ImgC) {
	var v = document.all(obj.id);
	obj.src=ImgC; 				
} 