﻿using Zenoph.Notify.Enums;
using Zenoph.Notify.Request;

namespace DEPTAT.Infrastructure
{
    public static class SMSGateway
    {
        public static void Send(string message, string destinationPhoneNumber, string title = "")
        {
            try
            {

                // set host
                SMSRequest.setHost("api.smsonlinegh.com");

                // Initialise SMS request with the authentication profile
                SMSRequest sr = new SMSRequest();

                // set API key for authentication
                sr.setAuthModel(AuthModel.API_KEY);
                sr.setAuthApiKey("");

                NotifyRequest.useSecureConnection(true);


                // set message properties and submit
                sr.setMessage(message);
                sr.setSender(title);
                sr.addDestination(destinationPhoneNumber);
                sr.submit();

                // submit message for response
                //  MessageResponse mr = sr.submit() as MessageResponse;

            }

            catch (Exception ex)
            {
                if (ex is RequestException)
                {
                    RequestHandshake rh = ((RequestException) ex).getRequestHandshake();
                    Console.WriteLine(rh);
                }

                // Exception catch code continues
            }
        }
    }
}