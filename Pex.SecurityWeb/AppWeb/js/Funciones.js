
var strNombreCarpetaVirtual = 'AppWeb'

/****************************************************************************************************
SCRIPT PARA EL CALENDARIO
*****************************************************************************************************/
	var	fixedX = -1			// x position (-1 if to appear below control)
	var	fixedY = -1			// y position (-1 if to appear below control)
	var startAt = 1			// 0 - sunday ; 1 - monday
	var showWeekNumber = 1	// 0 - don't show; 1 - show
	var showToday = 1		// 0 - don't show; 1 - show
	//var imgDir = "/" + strNombreCarpetaVirtual + "/images/"			// directory for images ... e.g. var imgDir="/img/"
    var imgDir = "/images/"			// directory for images ... e.g. var imgDir="/img/"
    
	var gotoString = "Go To Current Month"
	var todayString = "Hoy es"
	var weekString = "Sem"
	var scrollLeftMessage = "Click to scroll to previous month. Hold mouse button to scroll automatically."
	var scrollRightMessage = "Click to scroll to next month. Hold mouse button to scroll automatically."
	var selectMonthMessage = "Click to select a month."
	var selectYearMessage = "Click to select a year."
	var selectDateMessage = "Select [date] as date." // do not replace [date], it will be replaced by date.

	var	crossobj, crossMonthObj, crossYearObj, monthSelected, yearSelected, dateSelected, omonthSelected, oyearSelected, odateSelected, monthConstructed, yearConstructed, intervalID1, intervalID2, timeoutID1, timeoutID2, ctlToPlaceValue, ctlNow, dateFormat, nStartingYear

	var	bPageLoaded=false
	var	ie=document.all
	var	dom=document.getElementById

	var	ns4=document.layers
	var	today =	new	Date()
	var	dateNow	 = today.getDate()
	var	monthNow = today.getMonth()
	var	yearNow	 = today.getYear()
	var	imgsrc = new Array("drop1.gif","drop2.gif","left1.gif","left2.gif","right1.gif","right2.gif")
	var	img	= new Array()

	var bShow = false;

    /* hides <select> and <applet> objects (for IE only) */
    function hideElement( elmID, overDiv )
    {
      if( ie )
      {
        for( i = 0; i < document.all.tags( elmID ).length; i++ )
        {
          obj = document.all.tags( elmID )[i];
          if( !obj || !obj.offsetParent )
          {
            continue;
          }
      
          // Find the element's offsetTop and offsetLeft relative to the BODY tag.
          objLeft   = obj.offsetLeft;
          objTop    = obj.offsetTop;
          objParent = obj.offsetParent;
          
          while( objParent.tagName.toUpperCase() != "BODY" )
          {
            objLeft  += objParent.offsetLeft;
            objTop   += objParent.offsetTop;
            objParent = objParent.offsetParent;
          }
      
          objHeight = obj.offsetHeight;
          objWidth = obj.offsetWidth;
      
          if(( overDiv.offsetLeft + overDiv.offsetWidth ) <= objLeft );
          else if(( overDiv.offsetTop + overDiv.offsetHeight ) <= objTop );
          else if( overDiv.offsetTop >= ( objTop + objHeight ));
          else if( overDiv.offsetLeft >= ( objLeft + objWidth ));
          else
          {
            obj.style.visibility = "hidden";
          }
        }
      }
    }
     
    /*
    * unhides <select> and <applet> objects (for IE only)
    */
    function showElement( elmID )
    {
      if( ie )
      {
        for( i = 0; i < document.all.tags( elmID ).length; i++ )
        {
          obj = document.all.tags( elmID )[i];
          
          if( !obj || !obj.offsetParent )
          {
            continue;
          }
        
          obj.style.visibility = "";
        }
      }
    }

	function HolidayRec (d, m, y, desc)
	{
		this.d = d
		this.m = m
		this.y = y
		this.desc = desc
	}

	var HolidaysCounter = 0
	var Holidays = new Array()

	function addHoliday (d, m, y, desc)
	{
		Holidays[HolidaysCounter++] = new HolidayRec ( d, m, y, desc )
	}

	if (dom)
	{
		for	(i=0;i<imgsrc.length;i++)
		{
			img[i] = new Image
			img[i].src = imgDir + imgsrc[i]
		}
		document.write ("<div onclick='bShow=true' id='calendar'	style='z-index:+999;position:absolute;visibility:hidden;'><table	width="+((showWeekNumber==1)?250:220)+" style='font-family:arial;font-size:11px;border-width:1;border-style:solid;border-color:#a0a0a0;font-family:arial; font-size:11px}' bgcolor='#ffffff'><tr bgcolor='#0000aa'><td><table width='"+((showWeekNumber==1)?248:218)+"'><tr><td style='padding:2px;font-family:arial; font-size:11px;'><font color='#ffffff'><B><span id='caption'></span></B></font></td><td align=right><a href='javascript:hideCalendar()'><IMG SRC='"+imgDir+"close.gif' WIDTH='15' HEIGHT='13' BORDER='0' ALT='Close the Calendar'></a></td></tr></table></td></tr><tr><td style='padding:5px' bgcolor=#ffffff><span id='content'></span></td></tr>")
			
		if (showToday==1)
		{
			document.write ("<tr bgcolor=#f0f0f0><td style='padding:5px' align=center><span id='lblToday'></span></td></tr>")
		}
			
		document.write ("</table></div><div id='selectMonth' style='z-index:+999;position:absolute;visibility:hidden;'></div><div id='selectYear' style='z-index:+999;position:absolute;visibility:hidden;'></div>");
	}

	var	monthName =	new	Array("Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre")
	var	monthName2 = new Array("Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre")
	if (startAt==0)
	{
		dayName = new Array("Dom","Lun","Mar","Mie","Jue","Vie","Sab")
	}
	else
	{
		dayName = new Array	("Lun","Mar","Mie","Jue","Vie","Sab","Dom")
	}
	var	styleAnchor="text-decoration:none;color:black;"
	var	styleLightBorder="border-style:solid;border-width:1px;border-color:#a0a0a0;"

	function swapImage(srcImg, destImg){
		if (ie)	{ document.getElementById(srcImg).setAttribute("src",imgDir + destImg) }
	}

	function init()	{
		if (!ns4)
		{
			if (!ie) { yearNow += 1900	}

			crossobj=(dom)?document.getElementById("calendar").style : ie? document.all.calendar : document.calendar
			hideCalendar()

			crossMonthObj=(dom)?document.getElementById("selectMonth").style : ie? document.all.selectMonth	: document.selectMonth

			crossYearObj=(dom)?document.getElementById("selectYear").style : ie? document.all.selectYear : document.selectYear

			monthConstructed=false;
			yearConstructed=false;

			if (showToday==1)
			{
				document.getElementById("lblToday").innerHTML =	todayString + " <a onmousemove='window.status=\""+gotoString+"\"' onmouseout='window.status=\"\"' title='"+gotoString+"' style='"+styleAnchor+"' href='javascript:monthSelected=monthNow;yearSelected=yearNow;constructCalendar();'>"+dayName[(today.getDay()-startAt==-1)?6:(today.getDay()-startAt)]+", " + dateNow + " " + monthName[monthNow].substring(0,3)	+ "	" +	yearNow	+ "</a>"
			}

			sHTML1="<span id='spanLeft'	style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer' onmouseover='swapImage(\"changeLeft\",\"left2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+scrollLeftMessage+"\"' onclick='javascript:decMonth()' onmouseout='clearInterval(intervalID1);swapImage(\"changeLeft\",\"left1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartDecMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeLeft' SRC='"+imgDir+"left1.gif' width=10 height=11 BORDER=0>&nbsp</span>&nbsp;"
			sHTML1+="<span id='spanRight' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer'	onmouseover='swapImage(\"changeRight\",\"right2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+scrollRightMessage+"\"' onmouseout='clearInterval(intervalID1);swapImage(\"changeRight\",\"right1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onclick='incMonth()' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartIncMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'>&nbsp<IMG id='changeRight' SRC='"+imgDir+"right1.gif'	width=10 height=11 BORDER=0>&nbsp</span>&nbsp"
			sHTML1+="<span id='spanMonth' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer'	onmouseover='swapImage(\"changeMonth\",\"drop2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+selectMonthMessage+"\"' onmouseout='swapImage(\"changeMonth\",\"drop1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"' onclick='popUpMonth()'></span>&nbsp;"
			sHTML1+="<span id='spanYear' style='border-style:solid;border-width:1;border-color:#3366FF;cursor:pointer' onmouseover='swapImage(\"changeYear\",\"drop2.gif\");this.style.borderColor=\"#88AAFF\";window.status=\""+selectYearMessage+"\"'	onmouseout='swapImage(\"changeYear\",\"drop1.gif\");this.style.borderColor=\"#3366FF\";window.status=\"\"'	onclick='popUpYear()'></span>&nbsp;"
			
			document.getElementById("caption").innerHTML  =	sHTML1

			bPageLoaded=true
		}
	}

	function hideCalendar()	{
		crossobj.visibility="hidden"
		if (crossMonthObj != null){crossMonthObj.visibility="hidden"}
		if (crossYearObj !=	null){crossYearObj.visibility="hidden"}

	    showElement( 'SELECT' );
		showElement( 'APPLET' );
	}

	function padZero(num) {
		return (num	< 10)? '0' + num : num ;
	}

	function constructDate(d,m,y)
	{
		sTmp = dateFormat
		sTmp = sTmp.replace	("dd","<e>")
		sTmp = sTmp.replace	("d","<d>")
		sTmp = sTmp.replace	("<e>",padZero(d))
		sTmp = sTmp.replace	("<d>",d)
		sTmp = sTmp.replace	("mmmm","<p>")
		sTmp = sTmp.replace	("mmm","<o>")
		sTmp = sTmp.replace	("mm","<n>")
		sTmp = sTmp.replace	("m","<m>")
		sTmp = sTmp.replace	("<m>",m+1)
		sTmp = sTmp.replace	("<n>",padZero(m+1))
		sTmp = sTmp.replace	("<o>",monthName[m])
		sTmp = sTmp.replace	("<p>",monthName2[m])
		sTmp = sTmp.replace	("yyyy",y)
		return sTmp.replace ("yy",padZero(y%100))
	}

	function closeCalendar() {
		var	sTmp
	   
		hideCalendar();

		ctlToPlaceValue.value =	constructDate(dateSelected,monthSelected,yearSelected)

		if (document.getElementById('hdnTipoCambio') != undefined)
		{
			TipoCambio();
		}
	}

	/*** Month Pulldown	***/

	function StartDecMonth()
	{
		intervalID1=setInterval("decMonth()",80)
	}

	function StartIncMonth()
	{
		intervalID1=setInterval("incMonth()",80)
	}

	function incMonth () {
		monthSelected++
		if (monthSelected>11) {
			monthSelected=0
			yearSelected++
		}
		constructCalendar()
	}

	function decMonth () {
		monthSelected--
		if (monthSelected<0) {
			monthSelected=11
			yearSelected--
		}
		constructCalendar()
	}

	function constructMonth() {
		popDownYear()
		if (!monthConstructed) {
			sHTML =	""
			for	(i=0; i<12;	i++) {
				sName =	monthName[i];
				if (i==monthSelected){
					sName =	"<B>" +	sName +	"</B>"
				}
				sHTML += "<tr><td id='m" + i + "' onmouseover='this.style.backgroundColor=\"#FFCC99\"' onmouseout='this.style.backgroundColor=\"\"' style='cursor:pointer' onclick='monthConstructed=false;monthSelected=" + i + ";constructCalendar();popDownMonth();event.cancelBubble=true'>&nbsp;" + sName + "&nbsp;</td></tr>"
			}

			document.getElementById("selectMonth").innerHTML = "<table width=70	style='font-family:arial; font-size:11px; border-width:1; border-style:solid; border-color:#a0a0a0;' bgcolor='#FFFFDD' cellspacing=0 onmouseover='clearTimeout(timeoutID1)'	onmouseout='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"popDownMonth()\",100);event.cancelBubble=true'>" +	sHTML +	"</table>"

			monthConstructed=true
		}
	}

	function popUpMonth() {
		constructMonth()
		crossMonthObj.visibility = (dom||ie)? "visible"	: "show"
		crossMonthObj.left = parseInt(crossobj.left) + 50
		crossMonthObj.top =	parseInt(crossobj.top) + 26

		hideElement( 'SELECT', document.getElementById("selectMonth") );
		hideElement( 'APPLET', document.getElementById("selectMonth") );			
	}

	function popDownMonth()	{
		crossMonthObj.visibility= "hidden"
	}

	/*** Year Pulldown ***/

	function incYear() {
		for	(i=0; i<7; i++){
			newYear	= (i+nStartingYear)+1
			if (newYear==yearSelected)
			{ txtYear =	"&nbsp;<B>"	+ newYear +	"</B>&nbsp;" }
			else
			{ txtYear =	"&nbsp;" + newYear + "&nbsp;" }
			document.getElementById("y"+i).innerHTML = txtYear
		}
		nStartingYear ++;
		bShow=true
	}

	function decYear() {
		for	(i=0; i<7; i++){
			newYear	= (i+nStartingYear)-1
			if (newYear==yearSelected)
			{ txtYear =	"&nbsp;<B>"	+ newYear +	"</B>&nbsp;" }
			else
			{ txtYear =	"&nbsp;" + newYear + "&nbsp;" }
			document.getElementById("y"+i).innerHTML = txtYear
		}
		nStartingYear --;
		bShow=true
	}

	function selectYear(nYear) {
		yearSelected=parseInt(nYear+nStartingYear);
		yearConstructed=false;
		constructCalendar();
		popDownYear();
	}

	function constructYear() {
		popDownMonth()
		sHTML =	""
		if (!yearConstructed) {

			sHTML =	"<tr><td align='center'	onmouseover='this.style.backgroundColor=\"#FFCC99\"' onmouseout='clearInterval(intervalID1);this.style.backgroundColor=\"\"' style='cursor:pointer'	onmousedown='clearInterval(intervalID1);intervalID1=setInterval(\"decYear()\",30)' onmouseup='clearInterval(intervalID1)'>-</td></tr>"

			j =	0
			nStartingYear =	yearSelected-3
			for	(i=(yearSelected-3); i<=(yearSelected+3); i++) {
				sName =	i;
				if (i==yearSelected){
					sName =	"<B>" +	sName +	"</B>"
				}

				sHTML += "<tr><td id='y" + j + "' onmouseover='this.style.backgroundColor=\"#FFCC99\"' onmouseout='this.style.backgroundColor=\"\"' style='cursor:pointer' onclick='selectYear("+j+");event.cancelBubble=true'>&nbsp;" + sName + "&nbsp;</td></tr>"
				j ++;
			}

			sHTML += "<tr><td align='center' onmouseover='this.style.backgroundColor=\"#FFCC99\"' onmouseout='clearInterval(intervalID2);this.style.backgroundColor=\"\"' style='cursor:pointer' onmousedown='clearInterval(intervalID2);intervalID2=setInterval(\"incYear()\",30)'	onmouseup='clearInterval(intervalID2)'>+</td></tr>"

			document.getElementById("selectYear").innerHTML	= "<table width=44 style='font-family:arial; font-size:11px; border-width:1; border-style:solid; border-color:#a0a0a0;'	bgcolor='#FFFFDD' onmouseover='clearTimeout(timeoutID2)' onmouseout='clearTimeout(timeoutID2);timeoutID2=setTimeout(\"popDownYear()\",100)' cellspacing=0>"	+ sHTML	+ "</table>"

			yearConstructed	= true
		}
	}

	function popDownYear() {
		clearInterval(intervalID1)
		clearTimeout(timeoutID1)
		clearInterval(intervalID2)
		clearTimeout(timeoutID2)
		crossYearObj.visibility= "hidden"
	}

	function popUpYear() {
		var	leftOffset

		constructYear()
		crossYearObj.visibility	= (dom||ie)? "visible" : "show"
		leftOffset = parseInt(crossobj.left) + document.getElementById("spanYear").offsetLeft
		if (ie)
		{
			leftOffset += 6
		}
		crossYearObj.left =	leftOffset
		crossYearObj.top = parseInt(crossobj.top) +	26
	}

	/*** calendar ***/
   function WeekNbr(n) {
      // Algorithm used:
      // From Klaus Tondering's Calendar document (The Authority/Guru)
      // hhtp://www.tondering.dk/claus/calendar.html
      // a = (14-month) / 12
      // y = year + 4800 - a
      // m = month + 12a - 3
      // J = day + (153m + 2) / 5 + 365y + y / 4 - y / 100 + y / 400 - 32045
      // d4 = (J + 31741 - (J mod 7)) mod 146097 mod 36524 mod 1461
      // L = d4 / 1460
      // d1 = ((d4 - L) mod 365) + L
      // WeekNumber = d1 / 7 + 1
 
      year = n.getFullYear();
      month = n.getMonth() + 1;
      if (startAt == 0) {
         day = n.getDate() + 1;
      }
      else {
         day = n.getDate();
      }
 
      a = Math.floor((14-month) / 12);
      y = year + 4800 - a;
      m = month + 12 * a - 3;
      b = Math.floor(y/4) - Math.floor(y/100) + Math.floor(y/400);
      J = day + Math.floor((153 * m + 2) / 5) + 365 * y + b - 32045;
      d4 = (((J + 31741 - (J % 7)) % 146097) % 36524) % 1461;
      L = Math.floor(d4 / 1460);
      d1 = ((d4 - L) % 365) + L;
      week = Math.floor(d1/7) + 1;
 
      return week;
   }

	function constructCalendar () {
		var aNumDays = Array (31,0,31,30,31,30,31,31,30,31,30,31)

		var dateMessage
		var	startDate =	new	Date (yearSelected,monthSelected,1)
		var endDate

		if (monthSelected==1)
		{
			endDate	= new Date (yearSelected,monthSelected+1,1);
			endDate	= new Date (endDate	- (24*60*60*1000));
			numDaysInMonth = endDate.getDate()
		}
		else
		{
			numDaysInMonth = aNumDays[monthSelected];
		}

		datePointer	= 0
		dayPointer = startDate.getDay() - startAt
		
		if (dayPointer<0)
		{
			dayPointer = 6
		}

		sHTML =	"<table	 border=0 style='font-family:verdana;font-size:10px;'><tr>"

		if (showWeekNumber==1)
		{
			sHTML += "<td width=27><b>" + weekString + "</b></td><td width=1 rowspan=7 bgcolor='#d0d0d0' style='padding:0px'><img src='"+imgDir+"divider.gif' width=1></td>"
		}

		for	(i=0; i<7; i++)	{
			sHTML += "<td width='27' align='right'><B>"+ dayName[i]+"</B></td>"
		}
		sHTML +="</tr><tr>"
		
		if (showWeekNumber==1)
		{
			sHTML += "<td align=right>" + WeekNbr(startDate) + "&nbsp;</td>"
		}

		for	( var i=1; i<=dayPointer;i++ )
		{
			sHTML += "<td>&nbsp;</td>"
		}
	
		for	( datePointer=1; datePointer<=numDaysInMonth; datePointer++ )
		{
			dayPointer++;
			sHTML += "<td align=right>"
			sStyle=styleAnchor
			if ((datePointer==odateSelected) &&	(monthSelected==omonthSelected)	&& (yearSelected==oyearSelected))
			{ sStyle+=styleLightBorder }

			sHint = ""
			for (k=0;k<HolidaysCounter;k++)
			{
				if ((parseInt(Holidays[k].d)==datePointer)&&(parseInt(Holidays[k].m)==(monthSelected+1)))
				{
					if ((parseInt(Holidays[k].y)==0)||((parseInt(Holidays[k].y)==yearSelected)&&(parseInt(Holidays[k].y)!=0)))
					{
						sStyle+="background-color:#FFDDDD;"
						sHint+=sHint==""?Holidays[k].desc:"\n"+Holidays[k].desc
					}
				}
			}

			var regexp= /\"/g
			sHint=sHint.replace(regexp,"&quot;")

			dateMessage = "onmousemove='window.status=\""+selectDateMessage.replace("[date]",constructDate(datePointer,monthSelected,yearSelected))+"\"' onmouseout='window.status=\"\"' "

			if ((datePointer==dateNow)&&(monthSelected==monthNow)&&(yearSelected==yearNow))
			{ sHTML += "<b><a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' href='javascript:dateSelected="+datePointer+";closeCalendar();'><font color=#ff0000>&nbsp;" + datePointer + "</font>&nbsp;</a></b>"}
			else if	(dayPointer % 7 == (startAt * -1)+1)
			{ sHTML += "<a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' href='javascript:dateSelected="+datePointer + ";closeCalendar();'>&nbsp;<font color=#909090>" + datePointer + "</font>&nbsp;</a>" }
			else
			{ sHTML += "<a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' href='javascript:dateSelected="+datePointer + ";closeCalendar();'>&nbsp;" + datePointer + "&nbsp;</a>" }

			sHTML += ""
			if ((dayPointer+startAt) % 7 == startAt) { 
				sHTML += "</tr><tr>" 
				if ((showWeekNumber==1)&&(datePointer<numDaysInMonth))
				{
					sHTML += "<td align=right>" + (WeekNbr(new Date(yearSelected,monthSelected,datePointer+1))) + "&nbsp;</td>"
				}
			}
		}

		document.getElementById("content").innerHTML   = sHTML
		document.getElementById("spanMonth").innerHTML = "&nbsp;" +	monthName[monthSelected] + "&nbsp;<IMG id='changeMonth' SRC='"+imgDir+"drop1.gif' WIDTH='12' HEIGHT='10' BORDER=0>"
		document.getElementById("spanYear").innerHTML =	"&nbsp;" + yearSelected	+ "&nbsp;<IMG id='changeYear' SRC='"+imgDir+"drop1.gif' WIDTH='12' HEIGHT='10' BORDER=0>"
	}

    function popUpCalendar(ctl,	ctl2, format) {
		var	leftpos=0
		var	toppos=0

		if (bPageLoaded)
		{
			if ( crossobj.visibility ==	"hidden" ) {
				ctlToPlaceValue	= ctl2
				dateFormat=format;

				formatChar = " "
				aFormat	= dateFormat.split(formatChar)
				if (aFormat.length<3)
				{
					formatChar = "/"
					aFormat	= dateFormat.split(formatChar)
					if (aFormat.length<3)
					{
						formatChar = "."
						aFormat	= dateFormat.split(formatChar)
						if (aFormat.length<3)
						{
							formatChar = "-"
							aFormat	= dateFormat.split(formatChar)
							if (aFormat.length<3)
							{
								// invalid date	format
								formatChar=""
							}
						}
					}
				}

				tokensChanged =	0
				if ( formatChar	!= "" )
				{
					// use user's date
					aData =	ctl2.value.split(formatChar)

					for	(i=0;i<3;i++)
					{
						if ((aFormat[i]=="d") || (aFormat[i]=="dd"))
						{
							dateSelected = parseInt(aData[i], 10)
							tokensChanged ++
						}
						else if	((aFormat[i]=="m") || (aFormat[i]=="mm"))
						{
							monthSelected =	parseInt(aData[i], 10) - 1
							tokensChanged ++
						}
						else if	(aFormat[i]=="yyyy")
						{
						    var d=new Date();//fecha del sistema operativo
                            var dan=d.getFullYear();//año de la fecha
                                                  
							//yearSelected = parseInt(aData[i], 10)
							yearSelected = parseInt(dan, 10)
							tokensChanged ++
						}
						else if	(aFormat[i]=="mmm")
						{
							for	(j=0; j<12;	j++)
							{
								if (aData[i]==monthName[j])
								{
									monthSelected=j
									tokensChanged ++
								}
							}
						}
						else if	(aFormat[i]=="mmmm")
						{
							for	(j=0; j<12;	j++)
							{
								if (aData[i]==monthName2[j])
								{
									monthSelected=j
									tokensChanged ++
								}
							}
						}
					}
				}

				if ((tokensChanged!=3)||isNaN(dateSelected)||isNaN(monthSelected)||isNaN(yearSelected))
				{
					dateSelected = dateNow
					monthSelected =	monthNow
					yearSelected = yearNow
				}

				odateSelected=dateSelected
				omonthSelected=monthSelected
				oyearSelected=yearSelected

				aTag = ctl
				do {
					aTag = aTag.offsetParent;
					leftpos	+= aTag.offsetLeft;
					toppos += aTag.offsetTop;
				} while(aTag.tagName!="BODY");
				//ctl.offsetLeft es el width del control texto fecha
				//leftpos posicion inicial horizontal del control texto fecha
				//toppos posicion inicial vertical del control texto fecha
				var posh
				var posv
				var alto
				var ancho
				if (window.dialogWidth == undefined)
				{
					alto = window.screen.height
					ancho = window.screen.width
				}
				else
				{
					alto = window.dialogHeigth
					ancho = window.dialogWidth
				}
				if (ctl.offsetLeft + leftpos + 280 <= ancho)
				{
					posh = ctl.offsetLeft + leftpos
				}
				else
				{
					posh = ctl.offsetLeft+ leftpos - 180
				}
				if (ctl.offsetTop +	toppos + ctl.offsetHeight + 294 <= alto)
				{
					posv = ctl.offsetTop +	toppos + ctl.offsetHeight + 2
				}
				else
				{
					posv = ctl.offsetTop +	toppos + ctl.offsetHeight - 80
				}
				crossobj.left =	fixedX==-1 ? posh :	fixedX
				//crossobj.left =	fixedX==-1 ? ctl.offsetLeft	+ leftpos - 250 :	fixedX
				crossobj.top = fixedY==-1 ?	posv :	fixedY
				//crossobj.top = fixedY==-1 ?	ctl.offsetTop +	toppos + ctl.offsetHeight -	150 :	fixedY
				constructCalendar (1, monthSelected, yearSelected);
				crossobj.visibility=(dom||ie)? "visible" : "show"

				hideElement( 'SELECT', document.getElementById("calendar") );
				hideElement( 'APPLET', document.getElementById("calendar") );			

				bShow = true;
			}
			else
			{
				hideCalendar()
				if (ctlNow!=ctl) {popUpCalendar(ctl, ctl2, format)}
			}
			ctlNow = ctl
		}
	}

	document.onkeypress = function hidecal1 () { 
		if (event.keyCode==27) 
		{
			hideCalendar()
		}
	}
	document.onclick = function hidecal2 () { 		
		if (!bShow)
		{
			hideCalendar()
		}
		bShow = false
	}

	if(ie)
	{
		init()
	}
	else
	{
		window.onload=init
	}

/*****************************************************************************************************************************
SCRIPT PARA EL CALENDARIO
******************************************************************************************************************************/

function IsNumeric(valor)
{
	var log=valor.length; var sw="S";
	for (x=0; x<log; x++)
	{ 
		v1=valor.substr(x,1);
		v2 = parseInt(v1);
		//Compruebo si es un valor numérico
		if (isNaN(v2)) { sw= "N";}
	}
	if (sw=="S") {return true;} else {return false; }
}

var primerslap=false;
var segundoslap=false;

function formateafecha(fecha)
{
	var long = fecha.length;
	var dia;
	var mes;
	var ano;

	if ((long>=2) && (primerslap==false)) 
	{ 
		dia=fecha.substr(0,2);
		if ((IsNumeric(dia)==true) && (dia<=31) && (dia!="00")) 
		{ 
			fecha=fecha.substr(0,2)+"/"+fecha.substr(3,7); 
			primerslap=true; 
		}
		else 
		{ 
			fecha=""; 
			primerslap=false;
		}
	}
	else
	{ 
		dia=fecha.substr(0,1);
		if (IsNumeric(dia)==false)
		{
			fecha="";
		}
		if ((long<=2) && (primerslap=true)) 
		{
			fecha=fecha.substr(0,1); 
			primerslap=false; 
		}
	}
	if ((long>=5) && (segundoslap==false))
	{ 
		mes=fecha.substr(3,2);
		if ((IsNumeric(mes)==true) &&(mes<=12) && (mes!="00")) 
		{ 
			fecha=fecha.substr(0,5)+"/"+fecha.substr(6,4); segundoslap=true; 
		}
		else 
		{ 
			fecha=fecha.substr(0,3);; segundoslap=false;
		}
	}
	else 
	{ 
		if ((long<=5) && (segundoslap=true)) 
		{ 
			fecha=fecha.substr(0,4); segundoslap=false; 
		} 
	}
	if (long>=7)
	{ 
		ano=fecha.substr(6,4);
		if (IsNumeric(ano)==false) 
		{ 
			fecha=fecha.substr(0,6); 
		}
		else 
		{ 
			if (long==10)
			{ 
				if ((ano==0) || (ano<1900) || (ano>2100)) 
				{ 
					fecha=fecha.substr(0,6); 
				} 
			} 
		}
	}

	if (long>=10)
	{
		fecha=fecha.substr(0,10);
		dia=fecha.substr(0,2);
		mes=fecha.substr(3,2);
		ano=fecha.substr(6,4);
		// Año no viciesto y es febrero y el dia es mayor a 28
		if ( (ano%4 != 0) && (mes ==02) && (dia > 28) ) 
		{ 
			fecha=fecha.substr(0,2)+"/"; 
		}
	}
	return (fecha);
}

function AbreModal(pstrPagina,pwidth,pheight)
{
	var Argumento;
	var ConfiguracionPagina = 'center:yes;resizable:no;help:no;status:no;dialogWidth:' + pwidth + ';dialogHeight:' + pheight + ';scroll:yes;modal:yes';
	Argumento = window.showModalDialog(pstrPagina, Argumento, ConfiguracionPagina);
	
	//Modificacion Hecha Por CVV -  Compatibilidad con Master Page y Modal
	if (document.getElementById("ctl00_ContentPlaceHolder1_hdnRespuesta")!=undefined)
	{
	    document.getElementById("ctl00_ContentPlaceHolder1_hdnRespuesta").innerText = Argumento;
    }
	
	
	//Modificacion Hecha Por CVV - Modal de Modal
	if (document.getElementById("hdnRespuesta")!=undefined)
	{
	    document.getElementById("hdnRespuesta").innerText = Argumento;
	    document.getElementById("form1").submit();
	    return;
    }
    else
    {
        if (Argumento == 'True')
		{
			//document.getElementById("form1").submit();
		}
    }
	
	//Llamadas a Modales de Paginas Simples
	/*if (Form1.hdnRespuesta!=undefined)
	{	    
		Form1.hdnRespuesta.value = Argumento;		
	}
	else
	{
		if (Argumento == 'True')
		{
			Form1.submit();
		}
	}*/

}

var RAltas = 'El registro se ingres\xF3 satisfactoriamente';
var RBajas = 'El registro se elimin\xF3 satisfactoriamente';
var RCambios = 'Los cambios fueron actualizados satisfactoriamente';

function MsgRespuesta(strOpcion)
{
	switch (strOpcion)
	{
		case 'I':
			alert(RAltas);
		break;
		case 'E':
			alert(RCambios);
		break;
		case 'D':
			alert(RBajas);
		break;			
	}
}

function CerrarVentana()
{
	window.close();
}


function AbreModalPanel(pstrPagina,pwidth,pheight)
{
	var Argumento;
	var ConfiguracionPagina = 'center:yes;resizable:no;help:no;status:no;dialogWidth:' + pwidth + ';dialogHeight:' + pheight + ';scroll:yes;modal:yes';
	Argumento = window.showModalDialog(pstrPagina, Argumento, ConfiguracionPagina);
	if (aspnetForm.hdnRespuesta != undefined)
	{
		aspnetForm.hdnRespuesta.value = Argumento;
	}
	else
	{
		if (Argumento == 'True')
		{
			aspnetForm.submit();
		}
	}

}

/*
--------------------- BtnCancelar - X_Salir ----------------------
*/

  function Cancelar()
        {
            if (confirm("Cerrando formulario"))
            {
                self.window.close();
            return true;
            }          
            return false;
            
        } 
        
 
 function salir() {
    if((event.clientX < 100)||(event.clientY > -25)) {
    return "You are not supposed to close this window";
    }
    if((event.clientX > 500)||(event.clientY > -25)) {
    return "You are not supposed to close this window";
    }
    }
     
  /*  Solo Numero - Solo Letra*/
  //if x="2" then : xx="3" : else : end if
  function SoloNumerosKP(e) {
           e = (e) ? e : window.event;
           var charCode = (e.which) ? e.which : e.keyCode; 
           if (charCode == 13){e.keyCode = 9;return true;}
           if ((charCode >= 48 && charCode <= 57) || charCode == 9 || charCode == 8  ) {return true;}
           else {return false;}
           } 
  
function SoloLetrasKP(e) {
       e = (e) ? e : window.event;     
       var charCode = (e.which) ? e.which : e.keyCode; 
       if (charCode == 13){e.keyCode = 9;return true;} // El enter no funciona
       if (charCode == 16) {return false;}       
       var bolResul=false;       
       if (charCode ==225 || charCode ==237 ||
           charCode ==243 || charCode ==250 ||
           charCode ==241 || charCode ==209 ||
           charCode ==220 || charCode ==233 ||
           charCode ==252 || charCode ==201 ||
           charCode ==246 || charCode ==214 ||
           charCode ==193 || charCode ==205 ||
           charCode ==211 || charCode ==218 ||
           charCode==8    || charCode ==9   ||
           charCode==32   || charCode ==209 ||  
          (charCode >= 65 && charCode<=90)  ||  
          (charCode >= 97 && charCode<=122)) {bolResul= true;}
       else{bolResul=false;}
       return bolResul;
       } 
       
       function SoloNumerosKP(e) {
           e = (e) ? e : window.event;
           var charCode = (e.which) ? e.which : e.keyCode; 
           if (charCode == 13){e.keyCode = 9;return true;}
           if ((charCode >= 48 && charCode <= 57) || charCode == 9 || charCode == 8  ) {return true;}
           else {return false;}
           } 
           
       function LetrasNumerosSimbolosEspecialesKP(e) {
       e = (e) ? e : window.event;     
       var charCode = (e.which) ? e.which : e.keyCode; 
       if (charCode == 13){e.keyCode = 9;return true;} // El enter no funciona
       if ((charCode >= 48 && charCode <= 57) || charCode == 9 || charCode == 8  ) {return true;}
       if (charCode == 16) {return false;}       
       var bolResul=false;   
       
       
       if (charCode ==225 || charCode ==237 ||
           charCode ==243 || charCode ==250 ||
           charCode ==241 || charCode ==209 ||
           charCode ==220 || charCode ==233 ||
           charCode ==201 ||
           charCode ==193 || charCode ==205 ||
           charCode ==211 || charCode ==218 ||
           charCode==8    || charCode ==9   ||
           charCode==32   || charCode ==209 ||  
           charCode==34   || charCode==39   ||
           charCode==45   || 
           charCode==196 || charCode ==228 || 
           charCode==203 || charCode==235 || 
           charCode==207 || charCode ==239 || 
           charCode==214 || charCode ==246 || 
           charCode==220 || charCode ==252 || 
           (charCode >= 65 && charCode<=90)  ||  
           (charCode >= 97 && charCode<=122)
           ) 
           {bolResul= true;}
       else{bolResul=false;}
       
       return bolResul;
       }
       
       function Nada(e) {
       e = (e) ? e : window.event
       var charCode = (e.which) ? e.which : e.keyCode
       if (charCode > 0){
          return false
        }
        //return true
              
       }    
       
        function ValidarIngreso(val) 
        {
            if(Trim(val) == 0)
            {
               // alert("Debe Ingresar " + campo);
                return false
            }
        }      
        
           
        function Trim(s)
        {
            var sw=0;
            var i=0
            for(i=0; i < s.length; i++)
            {
                    if(s.substring(i,i+1) != ' ')
                    {
                               sw=1;
                               break;
                    }
            }
            return sw
                       
        }
        
    function LTrim(s){
        var i=0;
        var j=0;
        for(i=0; i<=s.length-1; i++)
               if(s.substring(i,i+1) != ' '){
                       j=i;
                       break;
               }
        return s.substring(j, s.length);
    }
    function RTrim(s){
        var j=0;
        for(var i=s.length-1; i>-1; i--)
               if(s.substring(i,i+1) != ' '){
                       j=i;
                       break;
               }
        return s.substring(0, j+1);
    }
    function AllTrim(s){
        return LTrim(RTrim(s));
    }
      
      function mensajealert(sender, args)
        {
          var msg_id = document.getElementById('ctl00_ContentPlaceHolder1_hdnmensaje');
          if (msg_id.value!=""){
          alert(msg_id.value);
          }
          msg_id.value="";
        }
   var a, mes, dia, anyo, febrero;


function anyoBisiesto(anyo)
{
if (anyo < 100)
    var fin = anyo + 1900;
else
    var fin = anyo ;

    if (fin % 4 != 0)
        return false;
    else
    {
        if (fin % 100 == 0)
        {
            if (fin % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}


function validarFecha(a)
{
    
    var mensaje=""
    var valor=a.value
    if(Trim(valor)=="")
    {
        mensaje="Ingrese Fecha"
        return mensaje;
    }
    dia=valor.split("/")[0];
    mes=valor.split("/")[1];
    anyo=valor.split("/")[2];
    
        if( (isNaN(dia)==true) || (isNaN(mes)==true) || (isNaN(anyo)==true) )
        {
            mensaje="Debe Ingresar el siguiente formato 'DD/MM/YYYY'";
            a.focus();
            a.select();
            return mensaje;
        }
        if(anyo.length!=4)
        {
            mensaje="Año Incorrecto";
            a.focus();
            a.select();
            //return false;
        }
        
    if(anyoBisiesto(anyo))
        febrero=29;
    else
        febrero=28;
        
    if ((mes<1) || (mes>12))
    {
        mensaje="El mes introducido no es valido. Por favor, introduzca un mes correcto";
        a.focus();
        a.select();
        //return false;
    }
      if(anyo==yearNow && mes > monthNow+1)
    {
         mensaje="El mes introducido no es valido.";
         a.focus();
         a.select();
         //return false;
    }
    if ((mes==2) && ((dia<1) || (dia>febrero)))
    {
        mensaje="El dia introducido no es valido. Por favor, introduzca un dia correcto";
        a.focus();
        a.select();
        //return false;
    }

    if (((mes==1) || (mes==3) || (mes==5) || (mes==7) || (mes==8) || (mes==10) || (mes==12)) && ((dia<1) || (dia>31)))
    {
        mensaje="El dia introducido no es valido. Por favor, introduzca un dia correcto";
        a.focus();
        a.select();
        //return false;
    }
    if (((mes==4) || (mes==6) || (mes==9) || (mes==11)) && ((dia<1) || (dia>30)))
    {
        mensaje="El dia introducido no es valido. Por favor, introduzca un dia correcto";
        a.focus();
        a.select();
        //return false;
    }
    if (mes==monthNow+1 && anyo==yearNow && dia>dateNow)
    {
        mensaje="El dia introducido no es valido. Por favor, introduzca un dia correcto";
        a.focus();
        a.select();
       // return false;
    }
  
    if ((anyo<1900) || (anyo>yearNow))
    {
        mensaje="El año introducido no es valido";
        a.focus();
        a.select();
    } 
    return mensaje;
} 

function SoloFechas(e)
{
    e = (e) ? e : window.event;
     // alert(e.keyCode)  
    var charCode = (e.which) ? e.which : e.keyCode;
    if(charCode>=47 && charCode<=57) 
        return true
    else
        return false   
}  


        function oNumero(numero)
        {
        //Propiedades 
        this.valor = numero || 0
        this.dec = -1;
        //Métodos 
        this.formato = numFormat;
        var mynum
//        this.ponValor = ponValor;
        //Definición de los métodos 
//        function ponValor(cad)
//        {
//        if (cad =='-' || cad=='+') return
//        if (cad.length ==0) return
//        if (cad.indexOf('.') >=0)
//            this.valor = parseFloat(cad);
//        else 
//            this.valor = parseInt(cad);
//        } 
        
            function numFormat(dec, miles)
            {
            var num = this.valor, signo=3, expr;
            var cad = ""+this.valor;
            var ceros = "", pos, pdec, i;
            for (i=0; i < dec; i++)
            ceros += '0';
            pos = cad.indexOf('.')
            if (pos < 0)
                cad = cad+"."+ceros;
            else
                {
                pdec = cad.length - pos -1;
                if (pdec <= dec)
                    {
                    for (i=0; i< (dec-pdec); i++)
                        cad += '0';
                    }
                else
                    {
                    num = num*Math.pow(10, dec);
                    //num = Math.round(num);
                    num=parseInt(num)
                    num = num/Math.pow(10, dec);
                    cad = new String(num);
                    }
                }
            pos = cad.indexOf('.')
            if (pos < 0) pos = cad.lentgh
            if (cad.substr(0,1)=='-' || cad.substr(0,1) == '+') 
                   signo = 4;
            if (miles && pos > signo)
                do{
                    expr = /([+-]?\d)(\d{3}[\.\,]\d*)/
                    cad.match(expr)
                   // cad=cad.replace(expr, RegExp.$1+','+RegExp.$2)
                    cad=cad.replace(expr, RegExp.$1+''+RegExp.$2)
                    }
                while (cad.indexOf(',') > signo)
                if (dec<0) cad = cad.replace(/\./,'')
                    return cad;
            }
        }//Fin del objeto oNumero:  
        
        
        function LeftTrim(s){
        var i=0;
        var j=0;
        for(i=0; i<=s.length-1; i++)
               if(s.substring(i,i+1) != ' '){
                       j=i;
                       break;
               }
        return s.substring(j, s.length);
        }
        function RigthTrim(s){
        var j=0;
        var r= 0
        for(var i=s.length-1; i>-1; i--)
               if(s.substring(i,i+1) != ' '){
                       j=i;
                       r=1
                       break;
               }
          if(r==0)
            return ""     
          else  
            return s.substring(0, j+1);
    }
    function TrimAll(s){
        return LeftTrim(RigthTrim(s));
    } 