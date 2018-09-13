using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Valor_de_Variable
{
    public interface IDetalle_Valor_de_VariableApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_VariablePagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Valor_de_VariableInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity, Spartane.Core.Domain.User.GlobalData Detalle_Valor_de_VariableInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity, Spartane.Core.Domain.User.GlobalData Detalle_Valor_de_VariableInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_VariablePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

