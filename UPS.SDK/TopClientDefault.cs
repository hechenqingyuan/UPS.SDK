/*******************************************************************************
 * Copyright (C) Git Corporation. All rights reserved.
 *
 * Author: 情缘
 * Create Date: 2016-03-07 9:18:33
 *
 * Description: Git.Framework
 * http://www.cnblogs.com/qingyuan/
 * Revision History:
 * Date         Author               Description
 * 2016-03-07 9:18:33       情缘
*********************************************************************************/


using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace UPS.SDK
{
    public partial class TopClientDefault:ITopClient
    {
        public string Execute(string ApiName, IDictionary<string, string> parameters)
        {
            string result = string.Empty;
            try
            {
                string UPS_URL_RATE = ConfigurationManager.AppSettings["UPS_URL_RATE"];
                SDKUtils sdk = new SDKUtils();
                string ApiUrl = string.Format("{0}{1}", UPS_URL_RATE, ApiName);
                result = sdk.DoPost(ApiUrl, parameters);
            }
            catch (Exception e)
            {
                DataResult dataResult = new DataResult() { Code=(int)EResponseCode.Exception,Message=e.Message };
                result = JsonHelper.SerializeObject(dataResult);
            }
            return result;
        }

        public string ExecuteUrl(string ApiUrl, IDictionary<string, string> parameters)
        {
            string result = string.Empty;
            try
            {
                SDKUtils sdk = new SDKUtils();
                result = sdk.DoPost(ApiUrl, parameters);
            }
            catch (Exception e)
            {
                DataResult dataResult = new DataResult() { Code = (int)EResponseCode.Exception, Message = e.Message };
                result = JsonHelper.SerializeObject(dataResult);
            }
            return result;
        }

        public string Execute<T>(ITopRequest<T> request) where T:class
        {
            throw new NotImplementedException();
        }

        public string Execute(string ApiName, JObject parameters)
        {
            string result = string.Empty;
            try
            {
                string UPS_URL_RATE = ConfigurationManager.AppSettings["UPS_URL_RATE"];
                string ApiUrl = string.Format("{0}{1}", UPS_URL_RATE, ApiName);
                HttpContent httpContent = new StringContent(parameters.ToString(), Encoding.UTF8, "text/json");
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient httpClient = new HttpClient();

                string responseJson = httpClient.PostAsync(ApiUrl, httpContent)
                .Result.Content.ReadAsStringAsync().Result;

                return responseJson;

                //SDKUtils sdk = new SDKUtils();
                //result = sdk.DoPost(ApiUrl, parameters.ToString());
                //return result;
            }
            catch (Exception e)
            {
                DataResult dataResult = new DataResult() { Code = (int)EResponseCode.Exception, Message = e.Message };
                result = JsonHelper.SerializeObject(dataResult);
            }
            return result;
        }
    }
}
