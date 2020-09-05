using System.Threading.Tasks;
using what_am_i_eating.Models;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http;
using IBM.Cloud.SDK.Core.Model;
using IBM.Cloud.SDK.Core.Util;
using System.Collections.Generic;
using System;
using System.IO;
using IBM.Watson.VisualRecognition.v3;
using IBM.Watson.VisualRecognition.v3.Model;
using Microsoft.Extensions.Configuration;

namespace what_am_i_eating.Services
{
    public class ImageClassifierService :IImageClassifierService
    {
        private readonly IConfiguration _config;
        public ImageClassifierService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ServiceResponse<DetailedResponse<ClassifiedImages>>> ClassifyImage()
        {
            IamAuthenticator authenticator = new IamAuthenticator(
            apikey: _config["ApiKey"]);
            VisualRecognitionService service = new VisualRecognitionService("2020-08-26", authenticator);
            var serviceResponse = new ServiceResponse<DetailedResponse<ClassifiedImages>>();
            
            service.SetServiceUrl("https://api.eu-de.visual-recognition.watson.cloud.ibm.com/instances/4feee059-6c25-487d-b58b-d7836479bb83");
      
             using (FileStream fs = File.OpenRead("./pizza_image.jpg"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    serviceResponse.Data = service.Classify(
                        imagesFile: ms,
                        imagesFilename: "item.jpg", 
                        classifierIds: new List<string>()
                        {
                            "food"
                        }
                    );
                }
            }

            return serviceResponse;
        }
    }
}
