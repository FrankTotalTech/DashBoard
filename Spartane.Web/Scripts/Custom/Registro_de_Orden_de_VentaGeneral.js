

//Begin Declarations for Foreigns fields for Detalle_Variables_de_Venta MultiRow
var Detalle_Variables_de_VentacountRowsChecked = 0;
function GetDetalle_Variables_de_Venta_VariableName(Id) {
    for (var i = 0; i < Detalle_Variables_de_Venta_VariableItems.length; i++) {
        if (Detalle_Variables_de_Venta_VariableItems[i].Clave == Id) {
            return Detalle_Variables_de_Venta_VariableItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Variables_de_Venta_VariableDropDown() {
    var Detalle_Variables_de_Venta_VariableDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Detalle_Variables_de_Venta_VariableDropdown);
    if(Detalle_Variables_de_Venta_VariableItems != null)
    {
       for (var i = 0; i < Detalle_Variables_de_Venta_VariableItems.length; i++) {
           $('<option />', { value: Detalle_Variables_de_Venta_VariableItems[i].Clave, text:    Detalle_Variables_de_Venta_VariableItems[i].Descripcion }).appendTo(Detalle_Variables_de_Venta_VariableDropdown);
       }
    }
    return Detalle_Variables_de_Venta_VariableDropdown;
}
function GetDetalle_Variables_de_Venta_Detalle_Valor_de_VariableName(Id) {
    for (var i = 0; i < Detalle_Variables_de_Venta_Detalle_Valor_de_VariableItems.length; i++) {
        if (Detalle_Variables_de_Venta_Detalle_Valor_de_VariableItems[i].Folio == Id) {
            return Detalle_Variables_de_Venta_Detalle_Valor_de_VariableItems[i].Valor;
        }
    }
    return "";
}

function GetDetalle_Variables_de_Venta_Detalle_Valor_de_VariableDropDown() {
    var Detalle_Variables_de_Venta_Detalle_Valor_de_VariableDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Detalle_Variables_de_Venta_Detalle_Valor_de_VariableDropdown);
    if(Detalle_Variables_de_Venta_Detalle_Valor_de_VariableItems != null)
    {
       for (var i = 0; i < Detalle_Variables_de_Venta_Detalle_Valor_de_VariableItems.length; i++) {
           $('<option />', { value: Detalle_Variables_de_Venta_Detalle_Valor_de_VariableItems[i].Folio, text:    Detalle_Variables_de_Venta_Detalle_Valor_de_VariableItems[i].Valor }).appendTo(Detalle_Variables_de_Venta_Detalle_Valor_de_VariableDropdown);
       }
    }
    return Detalle_Variables_de_Venta_Detalle_Valor_de_VariableDropdown;
}


function GetInsertDetalle_Variables_de_VentaRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetDetalle_Variables_de_Venta_VariableDropDown()).addClass('Detalle_Variables_de_Venta_Variable Variable').attr('id', 'Detalle_Variables_de_Venta_Variable_' + index).attr('data-field', 'Variable').after($.parseHTML(addNew('Detalle_Variables_de_Venta', 'Variable', 'Variable')));
    columnData[1] = $(GetDetalle_Variables_de_Venta_Detalle_Valor_de_VariableDropDown()).addClass('Detalle_Variables_de_Venta_Valor Valor').attr('id', 'Detalle_Variables_de_Venta_Valor_' + index).attr('data-field', 'Valor').after($.parseHTML(addNew('Detalle_Variables_de_Venta', 'Detalle_Valor_de_Variable', 'Valor')));


    initiateUIControls();
    return columnData;
}

function Detalle_Variables_de_VentaInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Variables_de_Venta("Detalle_Variables_de_Venta_", "_" + rowIndex)) {
    var iPage = Detalle_Variables_de_VentaTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Variables_de_Venta';
    var prevData = Detalle_Variables_de_VentaTable.fnGetData(rowIndex);
    var data = Detalle_Variables_de_VentaTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false
        ,Variable:  data.childNodes[counter++].childNodes[0].value
        ,Valor:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Variables_de_VentaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Variables_de_VentarowCreationGrid(data, newData, rowIndex);
    Detalle_Variables_de_VentaTable.fnPageChange(iPage);
    Detalle_Variables_de_VentacountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Variables_de_Venta("Detalle_Variables_de_Venta_", "_" + rowIndex);
  }
}

function Detalle_Variables_de_VentaCancelRow(rowIndex) {
    var prevData = Detalle_Variables_de_VentaTable.fnGetData(rowIndex);
    var data = Detalle_Variables_de_VentaTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Variables_de_VentaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Variables_de_VentarowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Variables_de_VentaGrid(Detalle_Variables_de_VentaTable.fnGetData());
    Detalle_Variables_de_VentacountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Variables_de_VentaFromDataTable() {
    var Detalle_Variables_de_VentaData = [];
    var gridData = Detalle_Variables_de_VentaTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Variables_de_VentaData.push({
                Folio: gridData[i].Folio
                ,Variable: gridData[i].Variable
                ,Valor: gridData[i].Valor

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Variables_de_VentaData.length; i++) {
        if (removedDetalle_Variables_de_VentaData[i] != null && removedDetalle_Variables_de_VentaData[i].Folio > 0)
            Detalle_Variables_de_VentaData.push({
                Folio: removedDetalle_Variables_de_VentaData[i].Folio
                ,Variable: removedDetalle_Variables_de_VentaData[i].Variable
                ,Valor: removedDetalle_Variables_de_VentaData[i].Valor

                , Removed: true
            });
    }	

    return Detalle_Variables_de_VentaData;
}

function Detalle_Variables_de_VentaEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Variables_de_VentaTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Variables_de_VentacountRowsChecked++;
    var Detalle_Variables_de_VentaRowElement = "Detalle_Variables_de_Venta_" + rowIndex.toString();
    var prevData = Detalle_Variables_de_VentaTable.fnGetData(rowIndexTable );
    var row = Detalle_Variables_de_VentaTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Variables_de_Venta_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Variables_de_VentaGetUpdateRowControls(prevData, "Detalle_Variables_de_Venta_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Variables_de_VentaRowElement + "')){ Detalle_Variables_de_VentaInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Detalle_Variables_de_VentaCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Variables_de_VentaGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Variables_de_VentaGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    $('.Detalle_Variables_de_Venta' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setDetalle_Variables_de_VentaValidation();
    initiateUIControls();
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Variables_de_Venta(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Variables_de_VentafnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Variables_de_VentaTable.fnGetData().length;
    Detalle_Variables_de_VentafnClickAddRow();
    GetAddDetalle_Variables_de_VentaPopup(currentRowIndex, 0);
}

function Detalle_Variables_de_VentaEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Variables_de_VentaTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Variables_de_VentaRowElement = "Detalle_Variables_de_Venta_" + rowIndex.toString();
    var prevData = Detalle_Variables_de_VentaTable.fnGetData(rowIndexTable);
    GetAddDetalle_Variables_de_VentaPopup(rowIndex, 1, prevData.Folio);
    $('#Detalle_Variables_de_VentaVariable').val(prevData.Variable);
    $('#Detalle_Variables_de_VentaValor').val(prevData.Valor);

    initiateUIControls();

}

function Detalle_Variables_de_VentaAddInsertRow() {
    if (Detalle_Variables_de_VentainsertRowCurrentIndex < 1)
    {
        Detalle_Variables_de_VentainsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true
        ,Variable: ""
        ,Valor: ""

    }
}

function Detalle_Variables_de_VentafnClickAddRow() {
    Detalle_Variables_de_VentacountRowsChecked++;
    Detalle_Variables_de_VentaTable.fnAddData(Detalle_Variables_de_VentaAddInsertRow(), true);
    Detalle_Variables_de_VentaTable.fnPageChange('last');
    initiateUIControls();
	 var tag = $('#Detalle_Variables_de_VentaGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    $('#Detalle_Variables_de_VentaGrid tbody tr:nth-of-type(' + (Detalle_Variables_de_VentainsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Variables_de_Venta("Detalle_Variables_de_Venta_", "_" + Detalle_Variables_de_VentainsertRowCurrentIndex);
}

function Detalle_Variables_de_VentaClearGridData() {
    Detalle_Variables_de_VentaData = [];
    Detalle_Variables_de_VentadeletedItem = [];
    Detalle_Variables_de_VentaDataMain = [];
    Detalle_Variables_de_VentaDataMainPages = [];
    Detalle_Variables_de_VentanewItemCount = 0;
    Detalle_Variables_de_VentamaxItemIndex = 0;
    $("#Detalle_Variables_de_VentaGrid").DataTable().clear();
    $("#Detalle_Variables_de_VentaGrid").DataTable().destroy();
}

//Used to Get Registro de Orden de Venta Information
function GetDetalle_Variables_de_Venta() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Variables_de_VentaData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Variables_de_VentaData[i].Folio);
        form_data.append('[' + i + '].Variable', Detalle_Variables_de_VentaData[i].Variable);
        form_data.append('[' + i + '].Valor', Detalle_Variables_de_VentaData[i].Valor);

        form_data.append('[' + i + '].Removed', Detalle_Variables_de_VentaData[i].Removed);
    }
    return form_data;
}
function Detalle_Variables_de_VentaInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Variables_de_Venta("Detalle_Variables_de_VentaTable", rowIndex)) {
    var prevData = Detalle_Variables_de_VentaTable.fnGetData(rowIndex);
    var data = Detalle_Variables_de_VentaTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false
        ,Variable: $('#Detalle_Variables_de_VentaVariable').val()
        ,Valor: $('#Detalle_Variables_de_VentaValor').val()

    }

    Detalle_Variables_de_VentaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Variables_de_VentarowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Variables_de_Venta-form').modal({ show: false });
    $('#AddDetalle_Variables_de_Venta-form').modal('hide');
    Detalle_Variables_de_VentaEditRow(rowIndex);
    Detalle_Variables_de_VentaInsertRow(rowIndex);
    //}
}
function Detalle_Variables_de_VentaRemoveAddRow(rowIndex) {
    Detalle_Variables_de_VentaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Variables_de_Venta MultiRow


$(function () {
    function Detalle_Variables_de_VentainitializeMainArray(totalCount) {
        if (Detalle_Variables_de_VentaDataMain.length != totalCount && !Detalle_Variables_de_VentaDataMainInitialized) {
            Detalle_Variables_de_VentaDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Variables_de_VentaDataMain[i] = null;
            }
        }
    }
    function Detalle_Variables_de_VentaremoveFromMainArray() {
        for (var j = 0; j < Detalle_Variables_de_VentadeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Variables_de_VentaDataMain.length; i++) {
                if (Detalle_Variables_de_VentaDataMain[i] != null && Detalle_Variables_de_VentaDataMain[i].Id == Detalle_Variables_de_VentadeletedItem[j]) {
                    hDetalle_Variables_de_VentaDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Variables_de_VentacopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Variables_de_VentaDataMain.length; i++) {
            data[i] = Detalle_Variables_de_VentaDataMain[i];

        }
        return data;
    }
    function Detalle_Variables_de_VentagetNewResult() {
        var newData = copyMainDetalle_Variables_de_VentaArray();

        for (var i = 0; i < Detalle_Variables_de_VentaData.length; i++) {
            if (Detalle_Variables_de_VentaData[i].Removed == null || Detalle_Variables_de_VentaData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Variables_de_VentaData[i]);
            }
        }
        return newData;
    }
    function Detalle_Variables_de_VentapushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Variables_de_VentaDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Variables_de_VentaDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">--Select--</option></select>';
    return dropDown;
}

function GetGridDatePicker() {
    return "<input type='text' class='fullWidth gridDatePicker xyz form-control' >";
}
function GetGridTimePicker() {
    return "<input type='text' class='fullWidth gridTimePicker form-control'  data-autoclose='true'>";
}
function GetGridTextArea() {
    return "<textarea rows='2'></textarea>";
}
function GetGridCheckBox() {
    return " <input type='checkbox' class='fullWidth'> ";
}
function GetFileUploader() {
    return "<input type='file' class='fullWidth'>";
}

function GetGridAutoComplete(data,field, id) {
    
    var dataMain = data == null ? "Select" : data;
    id ==  (id==null   || id==undefined)? "":id;
    
     return "<select class='AutoComplete fullWidth select2-dropDown " + field + " form-control' data-val='true'  ><option value='" + id +"'>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceFolio").val("0");
    $('#CreateRegistro_de_Orden_de_Venta')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Variables_de_VentaClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateRegistro_de_Orden_de_Venta').trigger('reset');
    $('#CreateRegistro_de_Orden_de_Venta').find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'number':
            case 'select-multiple':
            case 'select-one':
            case 'select':
            case 'text':
            case 'textarea':
                $(this).val('');
				for (instance in CKEDITOR.instances) {
                    CKEDITOR.instances[instance].updateElement();
                    CKEDITOR.instances[instance].setData('');
                }
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}
function CheckValidation() {
    var $myForm = $('#CreateRegistro_de_Orden_de_Venta');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Variables_de_VentacountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Variables_de_Venta();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateRegistro_de_Orden_de_Venta").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateRegistro_de_Orden_de_Venta").on('click', '#Registro_de_Orden_de_VentaCancelar', function () {
        Registro_de_Orden_de_VentaBackToGrid();
    });
	$("form#CreateRegistro_de_Orden_de_Venta").on('click', '#Registro_de_Orden_de_VentaGuardar', function () {
		$('#Registro_de_Orden_de_VentaGuardar').off('click');
        if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendRegistro_de_Orden_de_VentaData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Registro_de_Orden_de_VentaBackToGrid();
					else {
						
					    if (!isMR)
					        window.opener.RefreshCatalog('Registro_de_Orden_de_Venta', nameAttribute);
					    else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
								    eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Registro_de_Orden_de_VentaItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Registro_de_Orden_de_VentaDropDown().get(0)').innerHTML);  
								}								
							}
					    }
						window.close();						
						}
				});
		}
		$('#Registro_de_Orden_de_VentaGuardar').on('click');
    });
	$("form#CreateRegistro_de_Orden_de_Venta").on('click', '#Registro_de_Orden_de_VentaGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendRegistro_de_Orden_de_VentaData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Variables_de_VentaData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Registro_de_Orden_de_Venta', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Registro_de_Orden_de_VentaItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Registro_de_Orden_de_VentaDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateRegistro_de_Orden_de_Venta").on('click', '#Registro_de_Orden_de_VentaGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendRegistro_de_Orden_de_VentaData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Variables_de_VentaClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Variables_de_VentaData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Registro_de_Orden_de_Venta',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Registro_de_Orden_de_VentaItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Registro_de_Orden_de_VentaDropDown().get(0)').innerHTML);                          
					    }	
					}						
			setIsNew();
				});
		}
    });
});

function setIsNew() {
    $('#hdnIsNew').val("True");
	$('#Operation').val("New");
	operation = "New";
}



var mainElementObject;
var childElementObject;
function DisplayElementAttributes(data) {
}

function getElementTable(elementNumber, table) {

    for (var j = 0; j < childElementObject.length; j++) {
        if (childElementObject[j].table == table) {
            return childElementObject[j].elements[elementNumber];
            break;
        }
    }
}

function setRequired(elementNumber, element, elementType, table) {
    //debugger;
    if (elementType == "1") {
        mainElementObject[elementNumber].IsRequired = (mainElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
        if (!mainElementObject[elementNumber].IsVisible && mainElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (mainElementObject[elementNumber].IsReadOnly && mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    } else {
        getElementTable(elementNumber, table).IsRequired = (getElementTable(elementNumber, table).IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
        if (!getElementTable(elementNumber, table).IsVisible && getElementTable(elementNumber, table).IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (getElementTable(elementNumber, table).IsReadOnly && getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    }
}
function setVisible(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && mainElementObject[elementNumber].IsVisible) {
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && getElementTable(elementNumber, table).IsVisible) {
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsVisible = (getElementTable(elementNumber, table).IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    }
}
function setReadOnly(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ?GetTraduction('Disabled') : GetTraduction('Enabled')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && !getElementTable(elementNumber, table).IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsReadOnly = (getElementTable(elementNumber, table).IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsReadOnly == true ? GetTraduction('Disabled') : GetTraduction('Enabled')));
    }
}
function setDefaultValue(elementNumber, element, elementType, table) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text(GetTraduction('DefaultValue'));
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).DefaultValue);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
}
function setHelpText(elementNumber, element, elementType, table) {
    $('#hdnAttributType').val('2');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text(GetTraduction('HelpText'));
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).HelpText);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
    //$(element).children().attr("src", "" + (mainElementObject[elementNumber].HelpText == '' ? "Images/red-help.png" : "Images/green-help.png") + "");
}
function SaveValue(table) {
    debugger;
    if ($('#hdnElementType').val() == "1") {
        if ($('#hdnAttributType').val() == "1") {
            mainElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue));
        } else if ($('#hdnAttributType').val() == "2") {
            mainElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    } else {
        if ($('#hdnAttributType').val() == "1") {
            getElementTable($('#hdnAttributNumber').val(), table).DefaultValue = $('#txtAttributeValue').val();
            console.log(childElementObject[$('#hdnAttributNumber').val()].DefaultValue);
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue));
            console.log($('#hdnAttributNumber').val());
        } else if ($('#hdnAttributType').val() == "2") {
            getElementTable($('#hdnAttributNumber').val(), table).HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).HelpText));
        }
    }
    $('#txtAttributeValue').val('');
    $('#dvAttributeValue').hide();
}
function returnAttributeHTML(element, table, number) {
    var mainElementAttributes = '<div class="col-ld-12" style="display:inline-flex;">';
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (element.IsRequired == true ? GetTraduction("Required") : GetTraduction("NotRequired")) + '" onclick="setRequired(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (element.IsVisible == true ? GetTraduction("Visible") : GetTraduction("InVisible")) + '" onclick="setVisible(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (element.IsReadOnly == true ?GetTraduction("Disabled") :GetTraduction("Enabled")) + '" onclick="setReadOnly(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + number.toString() + '" class="defaultValueClick" title="' + (element.DefaultValue) + '" onclick="setDefaultValue(' + number.toString() + ', this, 2,  "' + table + '")"><img src="' + $('#hdnApplicationDirectory').val() + (element.DefaultValue != '' && element.DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + number.toString() + '" class="helpTextClick" title="' + (element.HelpText) + '" onclick="setHelpText(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.HelpText != '' && element.HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;
}



var Registro_de_Orden_de_VentaisdisplayBusinessPropery = false;
Registro_de_Orden_de_VentaDisplayBusinessRuleButtons(Registro_de_Orden_de_VentaisdisplayBusinessPropery);
function Registro_de_Orden_de_VentaDisplayBusinessRule() {
    if (!Registro_de_Orden_de_VentaisdisplayBusinessPropery) {
        $('#CreateRegistro_de_Orden_de_Venta').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Registro_de_Orden_de_VentadisplayBusinessPropery"><button onclick="Registro_de_Orden_de_VentaGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Registro_de_Orden_de_VentaBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Registro_de_Orden_de_VentadisplayBusinessPropery').remove();
    }
    Registro_de_Orden_de_VentaDisplayBusinessRuleButtons(!Registro_de_Orden_de_VentaisdisplayBusinessPropery);
    Registro_de_Orden_de_VentaisdisplayBusinessPropery = (Registro_de_Orden_de_VentaisdisplayBusinessPropery ? false : true);
}
function Registro_de_Orden_de_VentaDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

