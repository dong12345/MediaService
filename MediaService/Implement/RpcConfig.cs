using System;
using Grpc.Core;
using GrpcMediaService;

namespace MediaService.Implement
{
    public class RpcConfig
    {
        private static Server _server;
        public static void Start()
        {
            _server = new Server
            {
                Services = { MediaServiceToGrpc.BindService(new MsgServiceImpl()) },
                Ports = { new ServerPort("0.0.0.0", 40001, ServerCredentials.Insecure) }
            };
            _server.Start();

            Console.WriteLine("grpc ServerListening On Port 40001");
            //Console.WriteLine("任意键退出...");
            //Console.ReadKey();

            //_server?.ShutdownAsync().Wait();
        }
    }
}
