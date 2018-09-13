using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
//using Autofac.Integration.WebApi;
using System.Web.Mvc;
using Spartane.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Core.Domain;
using Spartane.Services.Security;
using Spartane.Services.Authentication;
using Spartane.Services.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFile;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Controllers;
using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Domain.User;
using Spartane.Services.Spartan_Format;
using Spartane.Core.Domain.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Services.Spartan_Format_Type;
using Spartane.Core.Domain.Spartan_Format_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Type;
using Spartane.Services.Spartan_Metadata;
using Spartane.Core.Domain.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Services.Spartan_Format_Configuration;
using Spartane.Core.Domain.Spartan_Format_Configuration;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Configuration;
using Spartane.Services.Spartan_Format_Field;
using Spartane.Core.Domain.Spartan_Format_Field;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Field;
using Spartane.Services.Spartan_Format_Permission_Type;
using Spartane.Core.Domain.Spartan_Format_Permission_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permission_Type;
using Spartane.Services.Spartan_Format_Permissions;
using Spartane.Core.Domain.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Services.Spartan_Report;
using Spartane.Core.Domain.Spartan_Report;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
using Spartane.Services.Spartan_Report_Field_Type;
using Spartane.Core.Domain.Spartan_Report_Field_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Field_Type;
using Spartane.Services.Spartan_Report_Fields_Detail;
using Spartane.Core.Domain.Spartan_Report_Fields_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Fields_Detail;
using Spartane.Services.Spartan_Report_Format;
using Spartane.Core.Domain.Spartan_Report_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Format;
using Spartane.Services.Spartan_Report_Function;
using Spartane.Core.Domain.Spartan_Report_Function;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Function;
using Spartane.Services.Spartan_Report_Order_Type;
using Spartane.Core.Domain.Spartan_Report_Order_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Order_Type;
using Spartane.Services.Spartan_Report_Permission_Type;
using Spartane.Core.Domain.Spartan_Report_Permission_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permission_Type;
using Spartane.Services.Spartan_Report_Permissions;
using Spartane.Core.Domain.Spartan_Report_Permissions;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permissions;
using Spartane.Services.Spartan_Report_Presentation_Type;
using Spartane.Core.Domain.Spartan_Report_Presentation_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_Type;
using Spartane.Services.Spartan_Report_Presentation_View;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_View;
using Spartane.Services.Spartan_Report_Status;
using Spartane.Core.Domain.Spartan_Report_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Status;
using Spartane.Core.Domain.Spartan_Report_Filter;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Filter;
using Spartane.Core.Domain.Spartan_Report_Advance_Filter;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Advance_Filter;

using Spartane.Services.Spartan_User;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Services.Spartan_User_Role;
using Spartane.Core.Domain.Spartan_User_Role;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;
using Spartane.Services.Spartan_User_Role_Status;
using Spartane.Core.Domain.Spartan_User_Role_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role_Status;
using Spartane.Services.Spartan_User_Status;
using Spartane.Core.Domain.Spartan_User_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Status;


using Spartane.Services.Spartan_Traduction_Concept_Type;
using Spartane.Core.Domain.Spartan_Traduction_Concept_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Concept_Type;
using Spartane.Services.Spartan_Traduction_Detail;
using Spartane.Core.Domain.Spartan_Traduction_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Detail;
using Spartane.Services.Spartan_Traduction_Language;
using Spartane.Core.Domain.Spartan_Traduction_Language;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Language;
using Spartane.Services.Spartan_Traduction_Object;
using Spartane.Core.Domain.Spartan_Traduction_Object;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object;
using Spartane.Services.Spartan_Traduction_Object_Type;
using Spartane.Core.Domain.Spartan_Traduction_Object_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object_Type;
using Spartane.Services.Spartan_Traduction_Process;
using Spartane.Core.Domain.Spartan_Traduction_Process;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process;
using Spartane.Services.Spartan_Traduction_Process_Data;
using Spartane.Core.Domain.Spartan_Traduction_Process_Data;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process_Data;
using Spartane.Services.Spartan_Traduction_Process_Workflow;
using Spartane.Core.Domain.Spartan_Traduction_Process_Workflow;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process_Workflow;

using Spartane.Services.Spartan_WorkFlow;
using Spartane.Core.Domain.Spartan_WorkFlow;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow;
using Spartane.Services.Spartan_WorkFlow_Condition;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Condition;
using Spartane.Services.Spartan_WorkFlow_Condition_Operator;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Condition_Operator;
using Spartane.Services.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Services.Spartan_WorkFlow_Information_by_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Information_by_State;
using Spartane.Services.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Services.Spartan_WorkFlow_Operator;
using Spartane.Core.Domain.Spartan_WorkFlow_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Operator;
using Spartane.Services.Spartan_WorkFlow_Phase_Status;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Status;
using Spartane.Services.Spartan_WorkFlow_Phase_Type;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Type;
using Spartane.Services.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Services.Spartan_WorkFlow_Roles_by_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Roles_by_State;
using Spartane.Services.Spartan_WorkFlow_State;
using Spartane.Core.Domain.Spartan_WorkFlow_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_State;
using Spartane.Services.Spartan_WorkFlow_Status;
using Spartane.Core.Domain.Spartan_WorkFlow_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Status;
using Spartane.Services.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Services.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Services.Spartan_Object;
using Spartane.Core.Domain.Spartan_Object;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Object;


using Spartane.Services.SpartanChangePasswordAutorizationEstatus;
using Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus;
using Spartane.Web.Areas.WebApiConsumer.SpartanChangePasswordAutorizationEstatus;
using Spartane.Services.Spartan_ChangePasswordAutorization;
using Spartane.Core.Domain.Spartan_ChangePasswordAutorization;
using Spartane.Web.Areas.WebApiConsumer.Spartan_ChangePasswordAutorization;
using Spartane.Services.Spartan_User_Historical_Password;
using Spartane.Core.Domain.Spartan_User_Historical_Password;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Historical_Password;
using Spartane.Services.Spartan_Settings;
using Spartane.Core.Domain.Spartan_Settings;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Settings;

using Spartane.Services.Estatus;
using Spartane.Core.Domain.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Services.Cliente;
using Spartane.Core.Domain.Cliente;
using Spartane.Web.Areas.WebApiConsumer.Cliente;
using Spartane.Services.Detalle_Valor_de_Variable;
using Spartane.Core.Domain.Detalle_Valor_de_Variable;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Valor_de_Variable;
using Spartane.Services.Detalle_Variables_de_Venta;
using Spartane.Core.Domain.Detalle_Variables_de_Venta;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Variables_de_Venta;
using Spartane.Services.Registro_de_Orden_de_Venta;
using Spartane.Core.Domain.Registro_de_Orden_de_Venta;
using Spartane.Web.Areas.WebApiConsumer.Registro_de_Orden_de_Venta;
using Spartane.Services.Variable;
using Spartane.Core.Domain.Variable;
using Spartane.Web.Areas.WebApiConsumer.Variable;
using Spartane.Services.Template_Dashboard_Editor;
using Spartane.Core.Domain.Template_Dashboard_Editor;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Editor;
using Spartane.Services.Dashboard_Status;
using Spartane.Core.Domain.Dashboard_Status;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Status;
using Spartane.Services.Dashboard_Editor;
using Spartane.Core.Domain.Dashboard_Editor;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Editor;
using Spartane.Services.Template_Dashboard_Detail;
using Spartane.Core.Domain.Template_Dashboard_Detail;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Detail;
using Spartane.Services.Dashboard_Config_Detail;
using Spartane.Core.Domain.Dashboard_Config_Detail;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Config_Detail;
//**@@INCLUDE_DECLARE@@**//
using Spartane.Services.Events;
using Spartane.Data.EF;
using System.Web.Http;
using System.Web;
using Autofac.Integration.WebApi;
using Spartane.Services.User.Mock;
using Spartane.Services.Security.Mock;
using Spartane.Core.Domain.Security;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.SpartanModule;
using Spartane.Web.Areas.WebApiConsumer.SpartanUserRoleModule;
using Spartane.Web.Areas.WebApiConsumer.SpartaneModuleObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleModuleObject;
using Spartane.Services.TTArchivos;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
/*Business Rules*/
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Configuration_Detail;
using Spartane.Core.Domain.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Actions_False_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_False_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Param_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Param_Type;
using Spartane.Core.Domain.Spartan_BR_Action_Result;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Result;
using Spartane.Core.Domain.Spartan_BR_Actions_True_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_True_Detail;
using Spartane.Core.Domain.Spartan_BR_Condition;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition;
using Spartane.Core.Domain.Spartan_BR_Condition_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition_Operator;
using Spartane.Core.Domain.Spartan_BR_Conditions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Conditions_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation;
using Spartane.Core.Domain.Spartan_BR_Operation_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Detail;
using Spartane.Core.Domain.Spartan_BR_Operator_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operator_Type;
using Spartane.Core.Domain.Spartan_BR_Presentation_Control_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Presentation_Control_Type;
using Spartane.Core.Domain.Spartan_BR_Process_Event;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event;
using Spartane.Core.Domain.Spartan_BR_Process_Event_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;
using Spartane.Core.Domain.Spartan_BR_Scope;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope;
using Spartane.Core.Domain.Spartan_BR_Scope_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope_Detail;
using Spartane.Core.Domain.Spartan_BR_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Status;
using Spartane.Core.Domain.Spartan_BR_Modifications_Log;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Modifications_Log;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Attribute_Control_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Attribute_Type;
using Spartane.Services.Spartan_Attribute_Control_Type;
using Spartane.Services.Spartan_Attribute_Type;
using Spartane.Services.Spartan_Business_Rule;
using Spartane.Services.Spartan_BR_Action;
using Spartane.Services.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Action_Classification;
using Spartane.Services.Spartan_BR_Action_Configuration_Detail;
using Spartane.Services.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Actions_False_Detail;
using Spartane.Services.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Services.Spartan_BR_Action_Param_Type;
using Spartane.Services.Spartan_BR_Action_Result;
using Spartane.Services.Spartan_BR_Actions_True_Detail;
using Spartane.Services.Spartan_BR_Condition;
using Spartane.Services.Spartan_BR_Condition_Operator;
using Spartane.Services.Spartan_BR_Conditions_Detail;
using Spartane.Services.Spartan_BR_Operation;
using Spartane.Services.Spartan_BR_Operation_Detail;
using Spartane.Services.Spartan_BR_Operator_Type;
using Spartane.Services.Spartan_BR_Presentation_Control_Type;
using Spartane.Services.Spartan_BR_Process_Event;
using Spartane.Services.Spartan_BR_Process_Event_Detail;
using Spartane.Services.Spartan_BR_Scope;
using Spartane.Services.Spartan_BR_Scope_Detail;
using Spartane.Services.Spartan_BR_Status;
using Spartane.Services.Spartan_BR_Modifications_Log;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Bitacora_SQL;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Services.Business_Rule_Creation;
using Spartane.Web.Areas.WebApiConsumer.Business_Rule_Creation;
using Spartane.Services.Spartan_BR_Complexity;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Complexity;
using Spartane.Services.Spartan_BR_Peer_Review;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Peer_Review;
using Spartane.Services.Spartan_BR_Testing;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Testing;
using Spartane.Services.Spartan_BR_Rejection_Reason;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Rejection_Reason;
using Spartane.Services.Spartan_BR_History;
using Spartane.Services.Spartan_BR_Type_History;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_History;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Type_History;
using Spartane.Services.Spartan_Bitacora_SQL;


namespace Spartane.Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //HTTP context and other related stuff
            builder.Register(c =>
                new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            
            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            builder.RegisterControllers();
           
            //data layer
            var dataSettigs = new DataSettings();
            dataSettigs.DataConnectionString = "name=spartaneEntities";//"data source=VM-SQL2012-01;initial catalog=spartane;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            dataSettigs.DataProvider = "sqlserver";
            builder.Register(x => new EFDataProviderManager(dataSettigs)).As<BaseDataProviderManager>().InstancePerLifetimeScope();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerLifetimeScope();
            builder.Register<IDbContext>(c => new TTObjectContext(dataSettigs.DataConnectionString)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerLifetimeScope();
            builder.RegisterType<ModulesData>().As<BaseEntity>().InstancePerLifetimeScope();

            builder.RegisterType<Spartane.Core.Domain.User.GlobalData>();
            builder.RegisterType<DataLayerFieldsBitacora>();

            builder.RegisterType<Spartan_Module>();
            
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<MockSpartanUserService>().As<ISpartanUserService>().InstancePerLifetimeScope();
            

            //New Addons
            builder.RegisterType<AuthenticationApiConsumer>().As<IAuthenticationApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<TokenManager>().As<ITokenManager>().InstancePerLifetimeScope();
            builder.RegisterType<SpartaneFileApiConsumer>().As<ISpartaneFileApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartane_FileApiConsumer>().As<ISpartane_FileApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_FormatService>().As<ISpartan_FormatService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_FormatApiConsumer>().As<ISpartan_FormatApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_TypeService>().As<ISpartan_Format_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_TypeApiConsumer>().As<ISpartan_Format_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_MetadataService>().As<ISpartan_MetadataService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_MetadataApiConsumer>().As<ISpartan_MetadataApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_ConfigurationService>().As<ISpartan_Format_ConfigurationService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_ConfigurationApiConsumer>().As<ISpartan_Format_ConfigurationApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_FieldService>().As<ISpartan_Format_FieldService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_FieldApiConsumer>().As<ISpartan_Format_FieldApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_Permission_TypeService>().As<ISpartan_Format_Permission_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_Permission_TypeApiConsumer>().As<ISpartan_Format_Permission_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_PermissionsService>().As<ISpartan_Format_PermissionsService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Format_PermissionsApiConsumer>().As<ISpartan_Format_PermissionsApiConsumer>().InstancePerLifetimeScope();

builder.RegisterType<Spartan_ReportService>().As<ISpartan_ReportService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_ReportApiConsumer>().As<ISpartan_ReportApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Field_TypeService>().As<ISpartan_Report_Field_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Field_TypeApiConsumer>().As<ISpartan_Report_Field_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Fields_DetailService>().As<ISpartan_Report_Fields_DetailService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Fields_DetailApiConsumer>().As<ISpartan_Report_Fields_DetailApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FormatService>().As<ISpartan_Report_FormatService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FormatApiConsumer>().As<ISpartan_Report_FormatApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FunctionService>().As<ISpartan_Report_FunctionService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FunctionApiConsumer>().As<ISpartan_Report_FunctionApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Order_TypeService>().As<ISpartan_Report_Order_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Order_TypeApiConsumer>().As<ISpartan_Report_Order_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Permission_TypeService>().As<ISpartan_Report_Permission_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Permission_TypeApiConsumer>().As<ISpartan_Report_Permission_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_PermissionsService>().As<ISpartan_Report_PermissionsService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_PermissionsApiConsumer>().As<ISpartan_Report_PermissionsApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_TypeService>().As<ISpartan_Report_Presentation_TypeService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_TypeApiConsumer>().As<ISpartan_Report_Presentation_TypeApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_ViewService>().As<ISpartan_Report_Presentation_ViewService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Presentation_ViewApiConsumer>().As<ISpartan_Report_Presentation_ViewApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_StatusService>().As<ISpartan_Report_StatusService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_StatusApiConsumer>().As<ISpartan_Report_StatusApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_FilterApiConsumer>().As<ISpartan_Report_FilterApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Report_Advance_FilterApiConsumer>().As<ISpartan_Report_Advance_FilterApiConsumer>().InstancePerLifetimeScope();


builder.RegisterType<SpartanChangePasswordAutorizationEstatusService>().As<ISpartanChangePasswordAutorizationEstatusService>().InstancePerLifetimeScope();
builder.RegisterType<SpartanChangePasswordAutorizationEstatusApiConsumer>().As<ISpartanChangePasswordAutorizationEstatusApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_ChangePasswordAutorizationService>().As<ISpartan_ChangePasswordAutorizationService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_ChangePasswordAutorizationApiConsumer>().As<ISpartan_ChangePasswordAutorizationApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_User_Historical_PasswordService>().As<ISpartan_User_Historical_PasswordService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_User_Historical_PasswordApiConsumer>().As<ISpartan_User_Historical_PasswordApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_SettingsService>().As<ISpartan_SettingsService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_SettingsApiConsumer>().As<ISpartan_SettingsApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Business_Rule_CreationService>().As<IBusiness_Rule_CreationService>().InstancePerLifetimeScope();
builder.RegisterType<Business_Rule_CreationApiConsumer>().As<IBusiness_Rule_CreationApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_ComplexityService>().As<ISpartan_BR_ComplexityService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_ComplexityApiConsumer>().As<ISpartan_BR_ComplexityApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Peer_ReviewService>().As<ISpartan_BR_Peer_ReviewService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Peer_ReviewApiConsumer>().As<ISpartan_BR_Peer_ReviewApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Rejection_ReasonService>().As<ISpartan_BR_Rejection_ReasonService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Rejection_ReasonApiConsumer>().As<ISpartan_BR_Rejection_ReasonApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_TestingService>().As<ISpartan_BR_TestingService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_TestingApiConsumer>().As<ISpartan_BR_TestingApiConsumer>().InstancePerLifetimeScope();

builder.RegisterType<Spartan_BR_HistoryService>().As<ISpartan_BR_HistoryService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Type_HistoryService>().As<ISpartan_BR_Type_HistoryService>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_HistoryApiConsumer>().As<ISpartan_BR_HistoryApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_BR_Type_HistoryApiConsumer>().As<ISpartan_BR_Type_HistoryApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Spartan_Bitacora_SQLService>().As<ISpartan_Bitacora_SQLService>().InstancePerLifetimeScope();
builder.RegisterType<EstatusService>().As<IEstatusService>().InstancePerLifetimeScope();
builder.RegisterType<EstatusApiConsumer>().As<IEstatusApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<ClienteService>().As<IClienteService>().InstancePerLifetimeScope();
builder.RegisterType<ClienteApiConsumer>().As<IClienteApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Valor_de_VariableService>().As<IDetalle_Valor_de_VariableService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Valor_de_VariableApiConsumer>().As<IDetalle_Valor_de_VariableApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Variables_de_VentaService>().As<IDetalle_Variables_de_VentaService>().InstancePerLifetimeScope();
builder.RegisterType<Detalle_Variables_de_VentaApiConsumer>().As<IDetalle_Variables_de_VentaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Registro_de_Orden_de_VentaService>().As<IRegistro_de_Orden_de_VentaService>().InstancePerLifetimeScope();
builder.RegisterType<Registro_de_Orden_de_VentaApiConsumer>().As<IRegistro_de_Orden_de_VentaApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<VariableService>().As<IVariableService>().InstancePerLifetimeScope();
builder.RegisterType<VariableApiConsumer>().As<IVariableApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Template_Dashboard_EditorService>().As<ITemplate_Dashboard_EditorService>().InstancePerLifetimeScope();
builder.RegisterType<Template_Dashboard_EditorApiConsumer>().As<ITemplate_Dashboard_EditorApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Dashboard_StatusService>().As<IDashboard_StatusService>().InstancePerLifetimeScope();
builder.RegisterType<Dashboard_StatusApiConsumer>().As<IDashboard_StatusApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Dashboard_EditorService>().As<IDashboard_EditorService>().InstancePerLifetimeScope();
builder.RegisterType<Dashboard_EditorApiConsumer>().As<IDashboard_EditorApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Template_Dashboard_DetailService>().As<ITemplate_Dashboard_DetailService>().InstancePerLifetimeScope();
builder.RegisterType<Template_Dashboard_DetailApiConsumer>().As<ITemplate_Dashboard_DetailApiConsumer>().InstancePerLifetimeScope();
builder.RegisterType<Dashboard_Config_DetailService>().As<IDashboard_Config_DetailService>().InstancePerLifetimeScope();
builder.RegisterType<Dashboard_Config_DetailApiConsumer>().As<IDashboard_Config_DetailApiConsumer>().InstancePerLifetimeScope();
//**@@INCLUDE_EXPOSE@@**//            

            builder.RegisterType<SpartanModuleApiConsumer>().As<ISpartanModuleApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartanUserRoleModuleApiConsumer>().As<ISpartanUserRoleModuleApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneModuleObjectApiConsumer>().As<ISpartaneModuleObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneUserRoleModuleObjectApiConsumer>().As<ISpartaneUserRoleModuleObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneObjectApiConsumer>().As<ISpartaneObjectApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneUserRoleObjectFunctionApiConsumer>().As<ISpartaneUserRoleObjectFunctionApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<LanguageApiConsumer>().As<ILanguageApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartanSecurityApiConsumer>().As<ISpartanSecurityApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<SpartanSessionApiConsumer>().As<ISpartanSessionApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneUserRoleObjectFunctionApiConsumer>().As<ISpartaneUserRoleObjectFunctionApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<SpartaneFunctionApiConsumer>().As<ISpartaneFunctionApiConsumer>().InstancePerLifetimeScope();
            //Till Here
            builder.RegisterType<TTArchivosService>().As<ITTArchivosService>().InstancePerLifetimeScope();

            //builder.RegisterType<MockSpartanDepartamentoService>().As<ISpartanDepartamentoService>().InstancePerLifetimeScope();

            builder.RegisterType<MockSpartanModuleService>().As<ISpartanModuleService>().InstancePerLifetimeScope().PreserveExistingDefaults();

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<SpartaneQueryApiConsumer>().As<ISpartaneQueryApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_Control_TypeService>().As<ISpartan_Attribute_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_Control_TypeApiConsumer>().As<ISpartan_Attribute_Control_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_TypeService>().As<ISpartan_Attribute_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Attribute_TypeApiConsumer>().As<ISpartan_Attribute_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Business_RuleService>().As<ISpartan_Business_RuleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Business_RuleApiConsumer>().As<ISpartan_Business_RuleApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ActionService>().As<ISpartan_BR_ActionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ActionApiConsumer>().As<ISpartan_BR_ActionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Attribute_Restrictions_DetailService>().As<ISpartan_BR_Attribute_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Attribute_Restrictions_DetailApiConsumer>().As<ISpartan_BR_Attribute_Restrictions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ClassificationService>().As<ISpartan_BR_Action_ClassificationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ClassificationApiConsumer>().As<ISpartan_BR_Action_ClassificationApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Configuration_DetailService>().As<ISpartan_BR_Action_Configuration_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Configuration_DetailApiConsumer>().As<ISpartan_BR_Action_Configuration_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Event_Restrictions_DetailService>().As<ISpartan_BR_Event_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Event_Restrictions_DetailApiConsumer>().As<ISpartan_BR_Event_Restrictions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_False_DetailService>().As<ISpartan_BR_Actions_False_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_False_DetailApiConsumer>().As<ISpartan_BR_Actions_False_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_Restrictions_DetailService>().As<ISpartan_BR_Operation_Restrictions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_Restrictions_DetailApiConsumer>().As<ISpartan_BR_Operation_Restrictions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Param_TypeService>().As<ISpartan_BR_Action_Param_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_Param_TypeApiConsumer>().As<ISpartan_BR_Action_Param_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ResultService>().As<ISpartan_BR_Action_ResultService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Action_ResultApiConsumer>().As<ISpartan_BR_Action_ResultApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_True_DetailService>().As<ISpartan_BR_Actions_True_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Actions_True_DetailApiConsumer>().As<ISpartan_BR_Actions_True_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ConditionService>().As<ISpartan_BR_ConditionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ConditionApiConsumer>().As<ISpartan_BR_ConditionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Condition_OperatorService>().As<ISpartan_BR_Condition_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Condition_OperatorApiConsumer>().As<ISpartan_BR_Condition_OperatorApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Conditions_DetailService>().As<ISpartan_BR_Conditions_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Conditions_DetailApiConsumer>().As<ISpartan_BR_Conditions_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_OperationService>().As<ISpartan_BR_OperationService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_OperationApiConsumer>().As<ISpartan_BR_OperationApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_DetailService>().As<ISpartan_BR_Operation_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operation_DetailApiConsumer>().As<ISpartan_BR_Operation_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operator_TypeService>().As<ISpartan_BR_Operator_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Operator_TypeApiConsumer>().As<ISpartan_BR_Operator_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Presentation_Control_TypeService>().As<ISpartan_BR_Presentation_Control_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Presentation_Control_TypeApiConsumer>().As<ISpartan_BR_Presentation_Control_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_EventService>().As<ISpartan_BR_Process_EventService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_EventApiConsumer>().As<ISpartan_BR_Process_EventApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_Event_DetailService>().As<ISpartan_BR_Process_Event_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Process_Event_DetailApiConsumer>().As<ISpartan_BR_Process_Event_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ScopeService>().As<ISpartan_BR_ScopeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_ScopeApiConsumer>().As<ISpartan_BR_ScopeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Scope_DetailService>().As<ISpartan_BR_Scope_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Scope_DetailApiConsumer>().As<ISpartan_BR_Scope_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_StatusService>().As<ISpartan_BR_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_StatusApiConsumer>().As<ISpartan_BR_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Modifications_LogService>().As<ISpartan_BR_Modifications_LogService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_BR_Modifications_LogApiConsumer>().As<ISpartan_BR_Modifications_LogApiConsumer>().InstancePerLifetimeScope();


            
			
			
			builder.RegisterType<Spartan_UserService>().As<ISpartan_UserService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_UserApiConsumer>().As<ISpartan_UserApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_RoleService>().As<ISpartan_User_RoleService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_RoleApiConsumer>().As<ISpartan_User_RoleApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Role_StatusService>().As<ISpartan_User_Role_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_Role_StatusApiConsumer>().As<ISpartan_User_Role_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_StatusService>().As<ISpartan_User_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_User_StatusApiConsumer>().As<ISpartan_User_StatusApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Traduction_Concept_TypeService>().As<ISpartan_Traduction_Concept_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Concept_TypeApiConsumer>().As<ISpartan_Traduction_Concept_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_DetailService>().As<ISpartan_Traduction_DetailService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_DetailApiConsumer>().As<ISpartan_Traduction_DetailApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_LanguageService>().As<ISpartan_Traduction_LanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_LanguageApiConsumer>().As<ISpartan_Traduction_LanguageApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ObjectService>().As<ISpartan_Traduction_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ObjectApiConsumer>().As<ISpartan_Traduction_ObjectApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Object_TypeService>().As<ISpartan_Traduction_Object_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Object_TypeApiConsumer>().As<ISpartan_Traduction_Object_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ProcessService>().As<ISpartan_Traduction_ProcessService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_ProcessApiConsumer>().As<ISpartan_Traduction_ProcessApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Traduction_Process_WorkflowService>().As<ISpartan_Traduction_Process_WorkflowService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_WorkflowApiConsumer>().As<ISpartan_Traduction_Process_WorkflowApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_DataService>().As<ISpartan_Traduction_Process_DataService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Traduction_Process_DataApiConsumer>().As<ISpartan_Traduction_Process_DataApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_WorkFlowService>().As<ISpartan_WorkFlowService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlowApiConsumer>().As<ISpartan_WorkFlowApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_ConditionService>().As<ISpartan_WorkFlow_ConditionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_ConditionApiConsumer>().As<ISpartan_WorkFlow_ConditionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Condition_OperatorService>().As<ISpartan_WorkFlow_Condition_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Condition_OperatorApiConsumer>().As<ISpartan_WorkFlow_Condition_OperatorApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Conditions_by_StateService>().As<ISpartan_WorkFlow_Conditions_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Conditions_by_StateApiConsumer>().As<ISpartan_WorkFlow_Conditions_by_StateApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Information_by_StateService>().As<ISpartan_WorkFlow_Information_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Information_by_StateApiConsumer>().As<ISpartan_WorkFlow_Information_by_StateApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Matrix_of_StatesService>().As<ISpartan_WorkFlow_Matrix_of_StatesService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Matrix_of_StatesApiConsumer>().As<ISpartan_WorkFlow_Matrix_of_StatesApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_OperatorService>().As<ISpartan_WorkFlow_OperatorService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_OperatorApiConsumer>().As<ISpartan_WorkFlow_OperatorApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_StatusService>().As<ISpartan_WorkFlow_Phase_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_StatusApiConsumer>().As<ISpartan_WorkFlow_Phase_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_TypeService>().As<ISpartan_WorkFlow_Phase_TypeService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Phase_TypeApiConsumer>().As<ISpartan_WorkFlow_Phase_TypeApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_PhasesService>().As<ISpartan_WorkFlow_PhasesService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_PhasesApiConsumer>().As<ISpartan_WorkFlow_PhasesApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Roles_by_StateService>().As<ISpartan_WorkFlow_Roles_by_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Roles_by_StateApiConsumer>().As<ISpartan_WorkFlow_Roles_by_StateApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StateService>().As<ISpartan_WorkFlow_StateService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StateApiConsumer>().As<ISpartan_WorkFlow_StateApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StatusService>().As<ISpartan_WorkFlow_StatusService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_StatusApiConsumer>().As<ISpartan_WorkFlow_StatusApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Flow_ControlService>().As<ISpartan_WorkFlow_Type_Flow_ControlService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Flow_ControlApiConsumer>().As<ISpartan_WorkFlow_Type_Flow_ControlApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Work_DistributionService>().As<ISpartan_WorkFlow_Type_Work_DistributionService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_WorkFlow_Type_Work_DistributionApiConsumer>().As<ISpartan_WorkFlow_Type_Work_DistributionApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ObjectService>().As<ISpartan_ObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_ObjectApiConsumer>().As<ISpartan_ObjectApiConsumer>().InstancePerLifetimeScope();
            
			

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<GeneratePDFApiConsumer>().As<IGeneratePDFApiConsumer>().InstancePerLifetimeScope();

            builder.RegisterType<Spartan_Bitacora_SQLApiConsumer>().As<ISpartan_Bitacora_SQLApiConsumer>().InstancePerLifetimeScope();
            builder.RegisterType<Spartan_Format_RelatedApiConsumer>().As<ISpartan_Format_RelatedApiConsumer>().InstancePerLifetimeScope();


            builder.RegisterType<HomeController>().As<Controller>();
            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //var resolver = new AutofacWebApiDependencyResolver(container);
            //config.DependencyResolver = resolver; 
        }

    }
}



































































































































