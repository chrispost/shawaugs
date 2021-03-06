﻿using System.Web;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        readonly IProcessWebRequests front_controller;
        readonly ICreateRequestsTheFrontControllerCanProcess request_mapper;

        public RawHandler():this(new FrontController(),Stub.of<StubRequestMapper>())
        {
        }

        public RawHandler(IProcessWebRequests front_controller, ICreateRequestsTheFrontControllerCanProcess request_mapper)
        {
            this.front_controller = front_controller;
            this.request_mapper = request_mapper;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_mapper.map_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}