using System;
using ZbW.Testing.Dms.Client.Services.Interface;

namespace ZbW.Testing.Dms.Client.Services
{
    internal class CreateGuid : ICreateGuid
    {
        public Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }
    }
}