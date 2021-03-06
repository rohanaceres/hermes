﻿using Hermes.Model.Request;
using Hermes.Core.Serialization;
using System;
using System.Linq;
using Hermes.Model.Response;
using System.Threading.Tasks;

namespace Hermes.Server.Command
{
    internal sealed class CommandFactory
    {
        Type[] RequestTypes = { typeof(LoginRequest), typeof(ReceiveRequest),
            typeof(SendRequest) };

        public static BaseResponse Build (BaseRequest request)
        {
            if (request is ReceiveRequest)
            {
                return ReceiveCommand.GetPendingMessages(request as ReceiveRequest);
            }
            if (request is LoginRequest)
            {
                return LoginCommand.LogUserIn(request as LoginRequest);
            }
            if (request is LogoffRequest)
            {
                return LogoffCommand.LogUserOff(request as LogoffRequest);
            }
            if (request is SendRequest)
            {
                return SendCommand.Send(request as SendRequest);
            }

            return null;
        }
    }
}
