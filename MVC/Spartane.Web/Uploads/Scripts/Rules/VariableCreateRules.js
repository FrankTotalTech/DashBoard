var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
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

function EjecutarValidacionesAntesDeGuardarMRDetalle_Valor_de_Variable(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Valor_de_Variable//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Valor_de_Variable(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Valor_de_Variable//
}
function EjecutarValidacionesAlEliminarMRDetalle_Valor_de_Variable(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Valor_de_Variable//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Valor_de_Variable(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Valor_de_Variable//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Valor_de_Variable(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Valor_de_Variable//
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
