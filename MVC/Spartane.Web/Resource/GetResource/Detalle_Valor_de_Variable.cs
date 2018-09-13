using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Valor_de_VariableResources
    {
        //private static IResourceProvider resourceProviderDetalle_Valor_de_Variable = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Valor_de_VariableResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Valor_de_Variable = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Valor_de_VariableResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Valor_de_Variable = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Valor_de_VariableResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Valor_de_Variable</summary>
        public static string Detalle_Valor_de_Variable
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Valor_de_Variable.GetResource("Detalle_Valor_de_Variable", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Valor_de_Variable.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Valor</summary>
        public static string Valor
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Valor_de_Variable.GetResource("Valor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Peso</summary>
        public static string Peso
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Valor_de_Variable.GetResource("Peso", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Valor_de_Variable.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
