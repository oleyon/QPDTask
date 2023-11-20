using QPDTask.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QPDTask.Service
{
    public interface IDadataService
    {
        public Task<CleanAddressModel> CleanAddressAsync(RawAddressModel rawAddressModel);
    }
}
