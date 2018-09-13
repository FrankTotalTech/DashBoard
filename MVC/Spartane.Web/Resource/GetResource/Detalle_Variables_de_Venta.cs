using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Variables_de_VentaResources
    {
        //private static IResourceProvider resourceProviderDetalle_Variables_de_Venta = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Variables_de_VentaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Variables_de_Venta = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Variables_de_VentaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Variables_de_Venta = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Variables_de_VentaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Variables_de_Venta</summary>
        public static string Detalle_Variables_de_Venta
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Variables_de_Venta.GetResource("Detalle_Variables_de_Venta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Variables_de_Venta.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Variable</summary>
        public static string Variable
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Variables_de_Venta.GetResource("Variable", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Valor</summary>
        public static string Valor
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Variables_de_Venta.GetResource("Valor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Variables_de_Venta.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
