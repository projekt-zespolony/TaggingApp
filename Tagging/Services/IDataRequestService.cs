using System.Collections.Generic;
using Tagging.Model;

namespace Tagging.Services
{
    public interface IDataRequestService
    {
        List<Sensors> GetSensors(int hours);
    }
}