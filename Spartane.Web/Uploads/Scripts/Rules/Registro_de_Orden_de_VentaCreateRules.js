var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//BusinessRuleId:1, Attribute:223002, Operation:Field, Event:None
$("form#CreateRegistro_de_Orden_de_Venta").on('change', '#Estatus', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divObservaciones').css('display', 'block');} else { $('#divObservaciones').css('display', 'none');}
});

//BusinessRuleId:1, Attribute:223002, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_Variables_de_Venta(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Variables_de_Venta//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Variables_de_Venta(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Variables_de_Venta//
}
function EjecutarValidacionesAlEliminarMRDetalle_Variables_de_Venta(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Variables_de_Venta//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Variables_de_Venta(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Variables_de_Venta//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Variables_de_Venta(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Variables_de_Venta//
    return result;
}


function EjecutarValidacionesAntesDeGuardarMRValores(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Valores// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRValores(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Valores// 
} 

function EjecutarValidacionesAlEliminarMRValores(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Valores// 
 return result; 
} 

function EjecutarValidacionesNewRowMRValores(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Valores// 
  return result; 
} 

function EjecutarValidacionesEditRowMRValores(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Valores// 
 return result; 
} 
