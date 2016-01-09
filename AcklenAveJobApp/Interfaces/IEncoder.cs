using AcklenAveJobApp.Models;
namespace AcklenAveJobApp.Interfaces
{
    public interface IEncoder
    {
        string Encode(ResponseModel model);
    }
}
