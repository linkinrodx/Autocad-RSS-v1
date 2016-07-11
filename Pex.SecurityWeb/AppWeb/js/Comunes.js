
function ObtieneIDSel(Grilla,HidCodigo,ControlValidar){
/*
obtiene el codigo que se encuentra en un campo oculto y asociado al checkbox
que se activa en un datagrid

*/
        var strcodigo="";
		var num=document.forms[0].length; 
		var n=3;
			 for(i=0;i<num;i++,n++){
			    if(parseInt(n)<10){
		   	   	     nombre=Grilla+"_ctl0"+n+"_"+HidCodigo;
				     cheksel=Grilla+"_ctl0"+n+"_"+ControlValidar;	
				 }else{
				     nombre=Grilla+"_ctl"+n+"_"+HidCodigo;
				     cheksel=Grilla+"_ctl"+n+"_"+ControlValidar;	
				 }
	              	if(document.getElementById(cheksel)!=null){
							if(document.getElementById(cheksel).checked==true){
							strcodigo=document.getElementById(nombre).value;
							break;
							}
						} 
			 }
		return strcodigo;
}
function getRadioButton(objeto,grilla,radio) {
		var num=document.forms[0].length; 
		var n=2;
			 for(i=0;i<num;i++,n++){
				 	 cheksel=grilla+"_ctl"+n+"_"+radio;  
				 	 if( document.getElementById(cheksel)!=null){
				 				if(document.getElementById(cheksel).name==objeto.name){
				 					document.getElementById(cheksel).checked=true;
				 				}else{
				 					document.getElementById(cheksel).checked=false;
				 				}	
				 	 }
			 }
}

function CuentaSeleccionChk(Grilla,ControlValidar) {
		var num=document.forms[0].length; 
		var n=2;
		var cuenta=0;
			  for(i=0;i<num;i++,n++){
		   	   	 if (parseInt(n)<10){															//campo  oculto hidden  
				    cheksel=Grilla+"_ctl0"+n+"_"+ControlValidar;				// checkbox o radiobutton
				 }else{
				    cheksel=Grilla+"_ctl"+n+"_"+ControlValidar;
				 }
				 	if(document.getElementById(cheksel)!=null){
							if(document.getElementById(cheksel).checked==true){
									  cuenta++;
							}
						} 
			 }
			 return cuenta;
}
function SeleccionaChecks(Grilla,obj_chk,obj_chk_all){
/*
selecciona o deselecciona los checks de un datagrid
parametros 
-grilla,
-nombre del check,
-nombre del check que seleccion todos
*/
        var strcodigo="";
		var num=document.forms[0].length; 
		var n=3;
		var chkAllNombre=cheksel=Grilla+"_ctl2_"+obj_chk_all;				// checkbox o radiobutton
			 for(i=0;i<num;i++,n++){
				 cheksel=Grilla+"_ctl"+n+"_"+obj_chk;						// checkbox o radiobutton
	 			 if(document.getElementById(chkAllNombre)!=null){
				 	if(document.getElementById(cheksel)!=null){
	 						document.getElementById(cheksel).checked=document.getElementById(chkAllNombre).checked;
							}
						} 
			 }
}
function MensajeResultado(str){	
		var resul = window.showModalDialog("mensaje.aspx?message="+ str,str,"dialogWidth=367px;dialogHeight=237px;status=0");
}


// selecciona items de listas y los pasa a la lista destino ... eliminando los seleccionados.
// from= Lista de Origen
// to = Lista Destino

function Copiar_Lista(from,to)
{
  var sel = false;
  fromList =document.getElementById(from);
  toList = document.getElementById(to);
  
   for (i=0;i<fromList.options.length;i++)
  {
				var current = fromList.options[i];
				if (current.selected)
				{
					sel = true;
					txt = current.text;
					val = current.value;
					toList.options[toList.length] = new Option(txt,val);
					fromList.options[i] = null;
					i--;
				}
  }
  if (!sel) alert ('Seleccione Centros de Costos!');
}
function SeleccionTotal(listBox)
{
  List = document.getElementById(listBox);
  for (i=0;i<List.length;i++)
  {
     List.options[i].selected = true;
  }
}
///////
function caracteresvalidos() 
        {	var tecla = window.event.keyCode; 
			if (tecla == 13) 
			{ window.event.keyCode=9; 
					event.cancelBubble = true; 
					Form1.submit(); 
			} 
			else                 
				if (!( (tecla >39 && tecla < 58) || (tecla >63 && tecla < 94) || (tecla >94 && tecla < 123)))
					if (!((tecla == 8) || (tecla == 32)))
					window.event.keyCode=0;         
        }
			
// ***** FUNCTION ltrim()
function ltrim(lstr) {	
			while (lstr.substr(0, 1) == " ")  {
				lstr = lstr.substr(1, lstr.length)
			  }
			return (lstr);
}
// ***** FUNCTION rtrim()
function rtrim(rstr) {	
	while (rstr.substr(rstr.length-1, 1) == " ") 
			  {	rstr = rstr.substr(0, rstr.length-1)
			  }
			return (rstr);
}
// ***** FUNCTION alltrim()
function alltrim(tstr){	
	return (ltrim(rtrim(tstr)))
}	
/// Mensajes Constantes DBS
var MENSAJE_ELIMINACION="Seleccione uno o varios Registros para Eliminarlos.";
var MENSAJE_MODIFICACION="Para Modificar Seleccione un Registro.";
var MENSAJE_PERMISO_DENEGADO="Su Perfil No tiene Permisos para realizar la Operacion."


