using Avantik.Web.Service.Contracts;
using Avantik.Web.Service.Entity.Route;
using Avantik.Web.Service.Message;
using Avantik.Web.Service.Model.Contract;
using Avantik.Web.Service.Model.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avantik.Web.Service.Extension;
using Avantik.Web.Service.Helpers;
using Avantik.Web.Service.Model;
using Avantik.Web.Service.Message.Client;
namespace Avantik.Web.Service
{
    public class ClientService : Contracts.IClientService
    {
        public CreateClientProfileResponse CreateClientProfile(CreateClientProfileRequest request)
        {
            Model.Contract.IClientService objClientService = ClientServiceFactory.CreateInstance();
            CreateClientProfileResponse response = new CreateClientProfileResponse();
            Entity.Client.ClientProfile clientProfile = new Entity.Client.ClientProfile();
            Guid clientProfileId = new Guid("D7432F91-A356-4421-8F9E-CE390A1D1CC0");//Guid.NewGuid();
            bool result = false;

            // map request to entity
            clientProfile.Client = request.ClientProfile.Client.ToEntityClient(clientProfileId);
            clientProfile.BookingRemarks = null;
            clientProfile.PassengerProfiles = request.ClientProfile.PassengerProfiles.ToListEntityClient(clientProfileId);

            try
            {
                result = objClientService.ClientSave(clientProfile);

                if (result)
                {
                    // read
                    Entity.Client.ClientProfile clientProfileResult = objClientService.ClientRead(clientProfile.Client.ClientProfileId.ToString());
                    
                    if (clientProfileResult.Client != null)
                    {
                        response.ClientProfileId = clientProfileId;
                        response.ClientNumber = clientProfileResult.Client.ClientNumber;
                        response.Success = true;
                        response.Message = "SUCCESS";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "FAIL";
                }

            }
            catch
            {
                response.Success = false;
                response.Message = "FAIL";
            }
           
            return response;
        }

        public EditClientProfileResponse EditClientProfile(EditClientProfileRequest request)
        {
            Model.Contract.IClientService objClientService = ClientServiceFactory.CreateInstance();
            EditClientProfileResponse response = new EditClientProfileResponse();
            Entity.Client.ClientProfile clientProfile = new Entity.Client.ClientProfile();
            Guid clientProfileId = request.ClientProfile.Client.ClientProfileId;
            bool result = false;

            // map request to entity
            clientProfile.Client = request.ClientProfile.Client.ToEntityClient(clientProfileId);
            clientProfile.BookingRemarks = null;
            clientProfile.PassengerProfiles = request.ClientProfile.PassengerProfiles.ToListEntityClient(clientProfileId);

            try
            {
                result = objClientService.EditClientProfile(clientProfile);

                if (result)
                {
                    response.Success = true;
                    response.Message = "SUCCESS";
                }
                else
                {
                    response.Success = false;
                    response.Message = "FAIL";
                }

            }
            catch
            {
                response.Success = false;
                response.Message = "FAIL";
            }

            return response;
        }

        public CreateClientProfileResponse AddPassengerProfile(CreateClientProfileRequest request)
        {
            Model.Contract.IClientService objClientService = ClientServiceFactory.CreateInstance();
            CreateClientProfileResponse response = new CreateClientProfileResponse();
            Entity.Client.ClientProfile clientProfile = new Entity.Client.ClientProfile();
            Guid clientProfileId = request.ClientProfile.Client.ClientProfileId;
            bool result = false;

            // map request to entity
            clientProfile.Client = request.ClientProfile.Client.ToEntityClient(clientProfileId);
            clientProfile.BookingRemarks = null;
            clientProfile.PassengerProfiles = request.ClientProfile.PassengerProfiles.ToListEntityClient(clientProfileId);
            
            try
            {
                result = objClientService.ClientSave(clientProfile);

                if (result)
                {
                    response.ClientProfileId = clientProfileId;
                    response.Success = true;
                    response.Message = "SUCCESS";
                }
                else
                {
                    response.Success = false;
                    response.Message = "FAIL";
                }

            }
            catch
            {
                response.Success = false;
                response.Message = "FAIL";
            }

            return response;
        }

        public EditClientProfileResponse EditPassengerProfile(EditClientProfileRequest request)
        {
            Model.Contract.IClientService objClientService = ClientServiceFactory.CreateInstance();
            EditClientProfileResponse response = new EditClientProfileResponse();
            Entity.Client.ClientProfile clientProfile = new Entity.Client.ClientProfile();
            Guid clientProfileId = request.ClientProfile.Client.ClientProfileId;
            bool result = false;

            // map request to entity
            clientProfile.Client = request.ClientProfile.Client.ToEntityClient(clientProfileId);
            clientProfile.BookingRemarks = null;
            clientProfile.PassengerProfiles = request.ClientProfile.PassengerProfiles.ToListEntityClient(clientProfileId);
        
            try
            {
                result = objClientService.EditClientProfile(clientProfile);

                if (result)
                {
                    response.Success = true;
                    response.Message = "SUCCESS";
                }
                else
                {
                    response.Success = false;
                    response.Message = "FAIL";
                }

            }
            catch
            {
                response.Success = false;
                response.Message = "FAIL";
            }

            return response;
        }

    }
}
