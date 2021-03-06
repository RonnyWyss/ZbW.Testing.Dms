﻿using System.Collections.Generic;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services.Interface
{
    internal interface ILoadFileRepository
    {
        void LoadMetadaten(List<KeyValuePair<string, List<IMetadataItem>>> yearItems);
    }
}