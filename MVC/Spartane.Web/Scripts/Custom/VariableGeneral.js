

//Begin Declarations for Foreigns fields for Detalle_Valor_de_Variable MultiRow
var Detalle_Valor_de_VariablecountRowsChecked = 0;


function GetInsertDetalle_Valor_de_VariableRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_Valor_de_Variable_Valor Valor').attr('id', 'Detalle_Valor_de_Variable_Valor_' + index).attr('data-field', 'Valor');
    columnData[1] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Valor_de_Variable_Peso Peso').attr('id', 'Detalle_Valor_de_Variable_Peso_' + index).attr('data-field', 'Peso');


    initiateUIControls();
    return columnData;
}

function Detalle_Valor_de_VariableInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Valor_de_Variable("Detalle_Valor_de_Variable_", "_" + rowIndex)) {
    var iPage = Detalle_Valor_de_VariableTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Valor_de_Variable';
    var prevData = Detalle_Valor_de_VariableTable.fnGetData(rowIndex);
    var data = Detalle_Valor_de_VariableTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false
        ,Valor:  data.childNodes[counter++].childNodes[0].value
        ,Peso: data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Valor_de_VariableTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Valor_de_VariablerowCreationGrid(data, newData, rowIndex);
    Detalle_Valor_de_VariableTable.fnPageChange(iPage);
    Detalle_Valor_de_VariablecountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Valor_de_Variable("Detalle_Valor_de_Variable_", "_" + rowIndex);
  }
}

function Detalle_Valor_de_VariableCancelRow(rowIndex) {
    var prevData = Detalle_Valor_de_VariableTable.fnGetData(rowIndex);
    var data = Detalle_Valor_de_VariableTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Valor_de_VariableTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Valor_de_VariablerowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Valor_de_VariableGrid(Detalle_Valor_de_VariableTable.fnGetData());
    Detalle_Valor_de_VariablecountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Valor_de_VariableFromDataTable() {
    var Detalle_Valor_de_VariableData = [];
    var gridData = Detalle_Valor_de_VariableTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Valor_de_VariableData.push({
                Folio: gridData[i].Folio
                ,Valor: gridData[i].Valor
                ,Peso: gridData[i].Peso

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Valor_de_VariableData.length; i++) {
        if (removedDetalle_Valor_de_VariableData[i] != null && removedDetalle_Valor_de_VariableData[i].Folio > 0)
            Detalle_Valor_de_VariableData.push({
                Folio: removedDetalle_Valor_de_VariableData[i].Folio
                ,Valor: removedDetalle_Valor_de_VariableData[i].Valor
                ,Peso: removedDetalle_Valor_de_VariableData[i].Peso

                , Removed: true
            });
    }	

    return Detalle_Valor_de_VariableData;
}

function Detalle_Valor_de_VariableEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Valor_de_VariableTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Valor_de_VariablecountRowsChecked++;
    var Detalle_Valor_de_VariableRowElement = "Detalle_Valor_de_Variable_" + rowIndex.toString();
    var prevData = Detalle_Valor_de_VariableTable.fnGetData(rowIndexTable );
    var row = Detalle_Valor_de_VariableTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Valor_de_Variable_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Valor_de_VariableGetUpdateRowControls(prevData, "Detalle_Valor_de_Variable_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Valor_de_VariableRowElement + "')){ Detalle_Valor_de_VariableInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Detalle_Valor_de_VariableCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Valor_de_VariableGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Valor_de_VariableGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    $('.Detalle_Valor_de_Variable' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setDetalle_Valor_de_VariableValidation();
    initiateUIControls();
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Valor_de_Variable(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Valor_de_VariablefnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Valor_de_VariableTable.fnGetData().length;
    Detalle_Valor_de_VariablefnClickAddRow();
    GetAddDetalle_Valor_de_VariablePopup(currentRowIndex, 0);
}

function Detalle_Valor_de_VariableEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Valor_de_VariableTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Valor_de_VariableRowElement = "Detalle_Valor_de_Variable_" + rowIndex.toString();
    var prevData = Detalle_Valor_de_VariableTable.fnGetData(rowIndexTable);
    GetAddDetalle_Valor_de_VariablePopup(rowIndex, 1, prevData.Folio);
    $('#Detalle_Valor_de_VariableValor').val(prevData.Valor);
    $('#Detalle_Valor_de_VariablePeso').val(prevData.Peso);

    initiateUIControls();

}

function Detalle_Valor_de_VariableAddInsertRow() {
    if (Detalle_Valor_de_VariableinsertRowCurrentIndex < 1)
    {
        Detalle_Valor_de_VariableinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true
        ,Valor: ""
        ,Peso: ""

    }
}

function Detalle_Valor_de_VariablefnClickAddRow() {
    Detalle_Valor_de_VariablecountRowsChecked++;
    Detalle_Valor_de_VariableTable.fnAddData(Detalle_Valor_de_VariableAddInsertRow(), true);
    Detalle_Valor_de_VariableTable.fnPageChange('last');
    initiateUIControls();
	 var tag = $('#Detalle_Valor_de_VariableGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    $('#Detalle_Valor_de_VariableGrid tbody tr:nth-of-type(' + (Detalle_Valor_de_VariableinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Valor_de_Variable("Detalle_Valor_de_Variable_", "_" + Detalle_Valor_de_VariableinsertRowCurrentIndex);
}

function Detalle_Valor_de_VariableClearGridData() {
    Detalle_Valor_de_VariableData = [];
    Detalle_Valor_de_VariabledeletedItem = [];
    Detalle_Valor_de_VariableDataMain = [];
    Detalle_Valor_de_VariableDataMainPages = [];
    Detalle_Valor_de_VariablenewItemCount = 0;
    Detalle_Valor_de_VariablemaxItemIndex = 0;
    $("#Detalle_Valor_de_VariableGrid").DataTable().clear();
    $("#Detalle_Valor_de_VariableGrid").DataTable().destroy();
}

//Used to Get Variable Information
function GetDetalle_Valor_de_Variable() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Valor_de_VariableData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Valor_de_VariableData[i].Folio);
        form_data.append('[' + i + '].Valor', Detalle_Valor_de_VariableData[i].Valor);
        form_data.append('[' + i + '].Peso', Detalle_Valor_de_VariableData[i].Peso);

        form_data.append('[' + i + '].Removed', Detalle_Valor_de_VariableData[i].Removed);
    }
    return form_data;
}
function Detalle_Valor_de_VariableInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Valor_de_Variable("Detalle_Valor_de_VariableTable", rowIndex)) {
    var prevData = Detalle_Valor_de_VariableTable.fnGetData(rowIndex);
    var data = Detalle_Valor_de_VariableTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false
        ,Valor: $('#Detalle_Valor_de_VariableValor').val()
        ,Peso: $('#Detalle_Valor_de_VariablePeso').val()


    }

    Detalle_Valor_de_VariableTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Valor_de_VariablerowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Valor_de_Variable-form').modal({ show: false });
    $('#AddDetalle_Valor_de_Variable-form').modal('hide');
    Detalle_Valor_de_VariableEditRow(rowIndex);
    Detalle_Valor_de_VariableInsertRow(rowIndex);
    //}
}
function Detalle_Valor_de_VariableRemoveAddRow(rowIndex) {
    Detalle_Valor_de_VariableTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Valor_de_Variable MultiRow


$(function () {
    function Detalle_Valor_de_VariableinitializeMainArray(totalCount) {
        if (Detalle_Valor_de_VariableDataMain.length != totalCount && !Detalle_Valor_de_VariableDataMainInitialized) {
            Detalle_Valor_de_VariableDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Valor_de_VariableDataMain[i] = null;
            }
        }
    }
    function Detalle_Valor_de_VariableremoveFromMainArray() {
        for (var j = 0; j < Detalle_Valor_de_VariabledeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Valor_de_VariableDataMain.length; i++) {
                if (Detalle_Valor_de_VariableDataMain[i] != null && Detalle_Valor_de_VariableDataMain[i].Id == Detalle_Valor_de_VariabledeletedItem[j]) {
                    hDetalle_Valor_de_VariableDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Valor_de_VariablecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Valor_de_VariableDataMain.length; i++) {
            data[i] = Detalle_Valor_de_VariableDataMain[i];

        }
        return data;
    }
    function Detalle_Valor_de_VariablegetNewResult() {
        var newData = copyMainDetalle_Valor_de_VariableArray();

        for (var i = 0; i < Detalle_Valor_de_VariableData.length; i++) {
            if (Detalle_Valor_de_VariableData[i].Removed == null || Detalle_Valor_de_VariableData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Valor_de_VariableData[i]);
            }
        }
        return newData;
    }
    function Detalle_Valor_de_VariablepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Valor_de_VariableDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Valor_de_VariableDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
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
    $("#ReferenceClave").val("0");
    $('#CreateVariable')[0].reset();
    ClearFormControls();
    $("#ClaveId").val("0");
                Detalle_Valor_de_VariableClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateVariable').trigger('reset');
    $('#CreateVariable').find(':input').each(function () {
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
    var $myForm = $('#CreateVariable');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Valor_de_VariablecountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Valor_de_Variable();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblClave").text("0");
}
$(document).ready(function () {
    $("form#CreateVariable").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateVariable").on('click', '#VariableCancelar', function () {
        VariableBackToGrid();
    });
	$("form#CreateVariable").on('click', '#VariableGuardar', function () {
		$('#VariableGuardar').off('click');
        if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendVariableData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						VariableBackToGrid();
					else {
						
					    if (!isMR)
					        window.opener.RefreshCatalog('Variable', nameAttribute);
					    else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
								    eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_VariableItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_VariableDropDown().get(0)').innerHTML);  
								}								
							}
					    }
						window.close();						
						}
				});
		}
		$('#VariableGuardar').on('click');
    });
	$("form#CreateVariable").on('click', '#VariableGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendVariableData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Valor_de_VariableData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Variable', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_VariableItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_VariableDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateVariable").on('click', '#VariableGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendVariableData(function (currentId) {
					$("#ClaveId").val("0");
	                Detalle_Valor_de_VariableClearGridData();

					ResetClaveLabel();
					$("#ReferenceClave").val(currentId);
	                getDetalle_Valor_de_VariableData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Variable',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_VariableItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_VariableDropDown().get(0)').innerHTML);                          
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



var VariableisdisplayBusinessPropery = false;
VariableDisplayBusinessRuleButtons(VariableisdisplayBusinessPropery);
function VariableDisplayBusinessRule() {
    if (!VariableisdisplayBusinessPropery) {
        $('#CreateVariable').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="VariabledisplayBusinessPropery"><button onclick="VariableGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#VariableBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.VariabledisplayBusinessPropery').remove();
    }
    VariableDisplayBusinessRuleButtons(!VariableisdisplayBusinessPropery);
    VariableisdisplayBusinessPropery = (VariableisdisplayBusinessPropery ? false : true);
}
function VariableDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

