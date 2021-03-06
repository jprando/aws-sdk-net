/*
 * Copyright 2010-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

/*
 * Do not modify this file. This file is generated from the iot-2015-05-28.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.IoT.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.IoT.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// CreateThingGroup Request Marshaller
    /// </summary>       
    public class CreateThingGroupRequestMarshaller : IMarshaller<IRequest, CreateThingGroupRequest> , IMarshaller<IRequest,AmazonWebServiceRequest>
    {
        /// <summary>
        /// Marshaller the request object to the HTTP request.
        /// </summary>  
        /// <param name="input"></param>
        /// <returns></returns>
        public IRequest Marshall(AmazonWebServiceRequest input)
        {
            return this.Marshall((CreateThingGroupRequest)input);
        }

        /// <summary>
        /// Marshaller the request object to the HTTP request.
        /// </summary>  
        /// <param name="publicRequest"></param>
        /// <returns></returns>
        public IRequest Marshall(CreateThingGroupRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.IoT");
            request.Headers["Content-Type"] = "application/x-amz-json-";
            request.HttpMethod = "POST";

            string uriResourcePath = "/thing-groups/{thingGroupName}";
            if (!publicRequest.IsSetThingGroupName())
                throw new AmazonIoTException("Request object does not have required field ThingGroupName set");
            uriResourcePath = uriResourcePath.Replace("{thingGroupName}", StringUtils.FromString(publicRequest.ThingGroupName));
            request.ResourcePath = uriResourcePath;
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                JsonWriter writer = new JsonWriter(stringWriter);
                writer.WriteObjectStart();
                var context = new JsonMarshallerContext(request, writer);
                if(publicRequest.IsSetParentGroupName())
                {
                    context.Writer.WritePropertyName("parentGroupName");
                    context.Writer.Write(publicRequest.ParentGroupName);
                }

                if(publicRequest.IsSetThingGroupProperties())
                {
                    context.Writer.WritePropertyName("thingGroupProperties");
                    context.Writer.WriteObjectStart();

                    var marshaller = ThingGroupPropertiesMarshaller.Instance;
                    marshaller.Marshall(publicRequest.ThingGroupProperties, context);

                    context.Writer.WriteObjectEnd();
                }

        
                writer.WriteObjectEnd();
                string snippet = stringWriter.ToString();
                request.Content = System.Text.Encoding.UTF8.GetBytes(snippet);
            }


            return request;
        }
        private static CreateThingGroupRequestMarshaller _instance = new CreateThingGroupRequestMarshaller();        

        internal static CreateThingGroupRequestMarshaller GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// Gets the singleton.
        /// </summary>  
        public static CreateThingGroupRequestMarshaller Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}