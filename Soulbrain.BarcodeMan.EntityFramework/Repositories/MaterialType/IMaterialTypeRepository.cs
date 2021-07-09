using Soulbrain.BarcodeMan.Dtos.MaterialType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Repositories
{
    public interface IMaterialTypeRepository
    {
        IEnumerable<MaterialTypeSelectItem> GetMaterialTypeSelectItems();
    }
}
