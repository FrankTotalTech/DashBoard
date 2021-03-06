﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.SpartaneFile;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;


namespace Spartane.Web.Areas.WebApiConsumer.SpartaneFile
{
    public class SpartaneFileApiConsumer : BaseApiConsumer, ISpartaneFileApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartaneFileApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/Spartan_File";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }



        public ApiResponse<long> Insert(Core.Domain.SpartaneFile.Spartane_File entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<long>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<long>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<long>(false, -1);
            }
        }

        public ApiResponse<bool> Delete(long? Key)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<bool>(false, false);
            }
        }

        public ApiResponse<long> Update(Spartane.Core.Domain.SpartaneFile.Spartane_File entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.File_Id,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<long>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<long>(false, -1);
            }
        }

        public ApiResponse<Spartane.Core.Domain.SpartaneFile.Spartane_File> GetByKey(long? Key)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartaneFile.Spartane_File>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartaneFile.Spartane_File>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartaneFile.Spartane_File>(false, null);
            }
        }
    }
}
