using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Contract
{
    public interface IParkingBAL
    {
        public List<ParkingRequestGetAllModel> GetAllParkingRequest(string username);
        public ParkingRequestModel GetParkingRequest(int ParkingRequestId);
        public ParkingRequestModel ParkingRequestWorkFlowUpdate(ParkingRequestModel parkingRequest);
        public List<ParkingRequestGetAllTowingCompanyAssignmentsModel> GetAllTowingCompanyAssignments(string username);
        public List<ParkingRequestGetAllHOAAssignmentsModel> GetAllHOAAssignments(string username);
    }
}
