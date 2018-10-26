using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Hello2
{
    public class Function
    {
        
        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            string myReturn="Hello ";
            try
            {
               
                var bodyString = input?.Body;
                if (input.PathParameters != null && input.PathParameters.ContainsKey("name"))
                {
                   string name = input.PathParameters["name"];
                   Console.WriteLine("Call included name : " + name);
                   myReturn=myReturn+name;

                }
                else
                {
                    myReturn=myReturn+"World";
                }                
                
                return new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = myReturn
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR:" + e.Message);
                return new APIGatewayProxyResponse
                {
                    StatusCode = 500,
                    Body = e.Message
                };
            }
        }
    }
}
