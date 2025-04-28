using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using System.Windows.Forms;

namespace ProductPropertyKliensApp.API
{
    internal class CategoryAPI
    {

        public ApiResponse<List<CategorySnapshotDTO>> getCategories(Api proxy) {
            try
            {
                ApiResponse<List<CategorySnapshotDTO>> response = proxy.CategoriesFindAll();
                if (response.Errors.Any())
                {
                    return response;
                }
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                                       ex.Message,
                                                          "Hiba történt",
                                                                             MessageBoxButtons.OK,
                                                                                                MessageBoxIcon.Error
                                                                                                               );
                return null;
            }
        }
    }
}
