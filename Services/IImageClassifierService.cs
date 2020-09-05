using System.Threading.Tasks;
using IBM.Cloud.SDK.Core.Http;
using IBM.Watson.VisualRecognition.v3.Model;
using what_am_i_eating.Models;

namespace what_am_i_eating.Services
{
    public interface IImageClassifierService
    {
        Task<ServiceResponse<DetailedResponse<ClassifiedImages>>> ClassifyImage();
    }
}