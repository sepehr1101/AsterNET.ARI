﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 22/07/2014 19:01:01
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using RestSharp;

namespace AsterNET.ARI.Actions
{
	
	public class EventsActions : ARIBaseAction
	{

		public EventsActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// WebSocket connection for events.. 
		/// </summary>
		/// <param name="app">Applications to subscribe to.</param>
		public Message EventWebsocket(string app)
		{
			string path = "/events";
			var request = GetNewRequest(path, Method.GET);
			request.AddParameter("app", app, ParameterType.QueryString);

			var response = Client.Execute<Message>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Generate a user event.. 
		/// </summary>
		/// <param name="eventName">Event name</param>
		/// <param name="application">The name of the application that will receive this event</param>
		/// <param name="source">URI for event source (channel:{channelId}, bridge:{bridgeId}, endpoint:{tech}/{resource}, deviceState:{deviceName}</param>
		/// <param name="variables">The "variables" key in the body object holds custom key/value pairs to add to the user event. Ex. { "variables": { "key": "value" } }</param>
		public void UserEvent(string eventName, string application, string source, List<KeyValuePair<string, string>> variables)
		{
			string path = "/events/user/{eventName}";
			var request = GetNewRequest(path, Method.POST);
			request.AddUrlSegment("eventName", eventName);
			request.AddParameter("application", application, ParameterType.QueryString);
			request.AddParameter("source", source, ParameterType.QueryString);
			request.AddParameter("variables", variables, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
	}
}
