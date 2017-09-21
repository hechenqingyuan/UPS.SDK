/*******************************************************************************
 * Copyright (C) Git Corporation. All rights reserved.
 *
 * Author: 情缘
 * Create Date: 2016-03-07 9:13:22
 *
 * Description: Git.Framework
 * http://www.cnblogs.com/qingyuan/
 * Revision History:
 * Date         Author               Description
 * 2016-03-07 9:13:22       情缘
*********************************************************************************/

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UPS.SDK
{
    public partial interface ITopClient
    {
        /// <summary>
        /// 根据API名称以及传入的参数执行
        /// </summary>
        /// <param name="ApiName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        string Execute(string ApiName,IDictionary<string, string> parameters);

        /// <summary>
        /// 根据请求对象执行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        string Execute<T>(ITopRequest<T> request) where T : class;

        /// <summary>
        ///  根据请求对象执行
        /// </summary>
        /// <param name="ApiName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        string Execute(string ApiName, JObject parameters);
    }
}
