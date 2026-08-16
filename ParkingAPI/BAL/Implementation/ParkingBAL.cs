using BAL.Contract;
using DAL.Contract;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Implementation
{
    public class ParkingBAL:IParkingBAL
    {
        IParkingDAL _IParkingDAL;
        public ParkingBAL(IParkingDAL iParkingDAL)
        {
            _IParkingDAL = iParkingDAL;
        }

        public ParkingRequestModel GetParkingRequest(int ParkingRequestId)
        {
            try
            {
                return _IParkingDAL.GetParkingRequest(ParkingRequestId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ParkingRequestGetAllModel> GetAllParkingRequest(string username)
        {
            try
            {
                return _IParkingDAL.GetAllParkingRequest(username);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ParkingRequestGetAllHOAAssignmentsModel> GetAllHOAAssignments(string username)
        {
            try
            {
                return _IParkingDAL.GetAllHOAAssignments(username);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<ParkingRequestGetAllTowingCompanyAssignmentsModel> GetAllTowingCompanyAssignments(string username)
        {
            try
            {
                return _IParkingDAL.GetAllTowingCompanyAssignments(username);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ParkingRequestModel ParkingRequestWorkFlowUpdate(ParkingRequestModel parkingRequest)
        {
            try
            {
                return _IParkingDAL.ParkingRequestWorkFlowUpdate(parkingRequest);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
