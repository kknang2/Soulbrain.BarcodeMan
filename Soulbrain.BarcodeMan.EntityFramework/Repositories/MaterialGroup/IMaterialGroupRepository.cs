using Soulbrain.BarcodeMan.Dtos.MaterialGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Repositories
{
    public interface IMaterialGroupRepository
    {
        IEnumerable<MaterialGroupSelectItem> GetMaterialGroupSelectItems();
    }
}
