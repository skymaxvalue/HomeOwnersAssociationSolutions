using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contract;
using DAL.Helper;
using ParkingModel;

namespace DAL.Implementation
{
    public class ParkingDAL:IParkingDAL
    {

        #region ParkingRequest
        public ParkingRequestModel ParkingRequestWorkFlowUpdate(ParkingRequestModel parkingRequest)
        {
            try
            {
           
                    string errors = string.Empty;

                     var param = new Dictionary<string, object>
                           {
                            { "@Status", parkingRequest.Status },
                            {"@ParkingDetailsID",parkingRequest.ParkingDetailsID  },
                            { "@VehicleID", parkingRequest.VehicleInfo.VehicleID },
                            { "@Make", parkingRequest.VehicleInfo.Make },
                            { "@Model", parkingRequest.VehicleInfo.Model },
                            { "@Year", parkingRequest.VehicleInfo.Year },
                            { "@Color", parkingRequest.VehicleInfo.Color },
                            { "@TagNumber", parkingRequest.VehicleInfo.TagNumber },
                            { "@VehiclePicture", CommonHelper.FromBase64StringToByteArray(parkingRequest.VehicleInfo.VehiclePicture ?? string.Empty) },
                            { "@UserName", parkingRequest.UserName },
                            { "@LocationId", parkingRequest.ParkingLocation.LocationId },
                            { "@Area", parkingRequest.ParkingLocation.Area },
                            { "@ParkingPicture",CommonHelper.FromBase64StringToByteArray( parkingRequest.ParkingLocation.ParkingPicture ?? string.Empty) } ,
                            { "@ParkingTimeId", parkingRequest.DurationOfParking.ParkingTimeId },
                            { "@StartDateTime", parkingRequest.DurationOfParking.StartDateTime },
                            { "@EndDateTime", parkingRequest.DurationOfParking.EndDateTime }
                        };

                    var parkingData = SQLHelper.ExecuteDataset("SP_ParkingRequestWorkFlowUpdate", param);

                if (parkingData != null && parkingData.Tables.Count > 0 && parkingData.Tables[0].Rows.Count > 0)
                {
                    if (parkingData.Tables[0].Rows[0][0].ToString()!="error" && Convert.ToUInt16(parkingData.Tables[0].Rows[0][0])>0)
                    {
                        parkingRequest= GetParkingRequest(Convert.ToUInt16(parkingData.Tables[0].Rows[0][0]));
                    }
                }

                return parkingRequest;
            

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
                List<ParkingRequestGetAllModel> parkingrequest = new List<ParkingRequestGetAllModel>();
                var param = new Dictionary<string, object> { { "@Username", username } };
                var parkingData = SQLHelper.ExecuteDataset("SP_GetAllParkingRequest", param);

                if (parkingData != null && parkingData.Tables.Count > 0 && parkingData.Tables[0].Rows.Count > 0)
                {
                    var dataTable = parkingData.Tables[0];
                    var row = dataTable.Rows[0];


                    // Map the results to a list of VehicleDetailsModel
                    parkingrequest = parkingData.Tables[0].AsEnumerable()
                        .Select(row => new ParkingRequestGetAllModel
                        {
                            ParkingDetailsID = row.Field<int>("ParkingDetailsID"),
                            DocNo = row.Field<string>("DocNo"),
                            Status = row.Field<string>("Status"),
                            Area = row.Field<string>("Area"),
                            ParkingPictureFromDB = row.Field<byte[]?>("ParkingPicture"),
                            StartDateTime = row.Field<string>("StartDateTime"),
                            EndDateTime = row.Field<string>("EndDateTime"),
                            TagNumber = row.Field<string>("TagNumber"),
                            VehiclePictureFromDB = row.Field<byte[]?>("VehiclePicture")
                        }).ToList();
                }


                return parkingrequest;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ParkingRequestModel GetParkingRequest(int ParkingRequestId)
        {
            try
            {
            ParkingRequestModel parkingrequest = new ParkingRequestModel();
            var param = new Dictionary<string, object>{{"@ParkingDetailsID",ParkingRequestId }};

            var parkingData = SQLHelper.ExecuteDataset("SP_GetParkingRequest", param);

                if (parkingData != null && parkingData.Tables.Count > 0 && parkingData.Tables[0].Rows.Count > 0)
                {
                    var dataTable = parkingData.Tables[0];
                    var row = dataTable.Rows[0];


                    var vehicleInfo = new VechileDetailsModel
                    {
                        VehicleID = row.Field<int>("VehicleID"),
                        Make = row.Field<string>("Make"),
                        Model = row.Field<string>("Model"),
                        Year = row.Field<int>("Year"),
                        Color = row.Field<string>("Color"),
                        TagNumber = row.Field<string>("TagNumber"),
                        VehiclePictureFromDB = row.Field<byte[]?>("VehiclePicture"),
                        UserName=""                        
                    };


                    var parkingLocation = new ParkingLocation
                    {
                        LocationId = row.Field<int>("LocationId"),
                        Area = row.Field<string>("Area"),
                        ParkingPictureFromDB = row.Field<byte[]?>("ParkingPicture")
                    };


                    var durationOfParking = new DurationOfParking
                    {
                        ParkingTimeId = row.Field<int>("ParkingTimeId"),
                        StartDateTime = row.Field<DateTime>("StartDateTime"),
                        EndDateTime = row.Field<DateTime>("EndDateTime")
                    };

                    // Create and return ParkingRequestModel
                    parkingrequest= new ParkingRequestModel
                    {
                        ParkingDetailsID = row.Field<int>("ParkingDetailsID"),
                        Status = row.Field<string>("Status"),
                        VehicleInfo = vehicleInfo,
                        ParkingLocation = parkingLocation,
                        DurationOfParking = durationOfParking
                    };
                }

               
                return parkingrequest;



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion


        #region HOA
        public List<ParkingRequestGetAllHOAAssignmentsModel> GetAllHOAAssignments(string username)
        {



            try
            {
                List<ParkingRequestGetAllHOAAssignmentsModel> parkingrequest = new List<ParkingRequestGetAllHOAAssignmentsModel>();
                var param = new Dictionary<string, object> { { "@Username", username } };
                var parkingData = SQLHelper.ExecuteDataset("SP_GetAllHOAAssignments", param);

                if (parkingData != null && parkingData.Tables.Count > 0 && parkingData.Tables[0].Rows.Count > 0)
                {
                    var dataTable = parkingData.Tables[0];
                    var row = dataTable.Rows[0];


                    // Map the results to a list of VehicleDetailsModel
                    parkingrequest = parkingData.Tables[0].AsEnumerable()
                        .Select(row => new ParkingRequestGetAllHOAAssignmentsModel
                        {
                            ParkingDetailsID = row.Field<int>("ParkingDetailsID"),
                            DocNo = row.Field<string>("DocNo"),
                            Status = row.Field<string>("Status"),
                            Area = row.Field<string>("Area"),
                            ParkingPictureFromDB = row.Field<byte[]?>("ParkingPicture"),
                            StartDateTime = row.Field<string>("StartDateTime"),
                            EndDateTime = row.Field<string>("EndDateTime"),
                            TagNumber = row.Field<string>("TagNumber"),
                            VehiclePictureFromDB = row.Field<byte[]?>("VehiclePicture")
                        }).ToList();
                }


                return parkingrequest;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion



        #region Towing Company
        public List<ParkingRequestGetAllTowingCompanyAssignmentsModel> GetAllTowingCompanyAssignments(string username)
        {



            try
            {
                List<ParkingRequestGetAllTowingCompanyAssignmentsModel> parkingrequest = new List<ParkingRequestGetAllTowingCompanyAssignmentsModel>();
                var param = new Dictionary<string, object> { { "@Username", username } };
                var parkingData = SQLHelper.ExecuteDataset("SP_GetAllTowingCompanyAssignments", param);

                if (parkingData != null && parkingData.Tables.Count > 0 && parkingData.Tables[0].Rows.Count > 0)
                {
                    var dataTable = parkingData.Tables[0];
                    var row = dataTable.Rows[0];


                    // Map the results to a list of VehicleDetailsModel
                    parkingrequest = parkingData.Tables[0].AsEnumerable()
                        .Select(row => new ParkingRequestGetAllTowingCompanyAssignmentsModel
                        {
                            ParkingDetailsID = row.Field<int>("ParkingDetailsID"),
                            DocNo = row.Field<string>("DocNo"),
                            Status = row.Field<string>("Status"),
                            Area = row.Field<string>("Area"),
                            ParkingPictureFromDB = row.Field<byte[]?>("ParkingPicture"),
                            StartDateTime = row.Field<string>("StartDateTime"),
                            EndDateTime = row.Field<string>("EndDateTime"),
                            TagNumber = row.Field<string>("TagNumber"),
                            VehiclePictureFromDB = row.Field<byte[]?>("VehiclePicture")
                        }).ToList();
                }


                return parkingrequest;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion





    }
}
