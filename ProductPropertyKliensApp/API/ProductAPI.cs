using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using System.Windows.Forms;

namespace ProductPropertyKliensApp
{
    internal class ProductAPI
    {

        public List<ProductDTO> getAllProduct(Api proxy) {
            try {
                ApiResponse<List<ProductDTO>> response = proxy.ProductsFindAll();
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(
                        msg,
                        "API hiba a termékek lekérésekor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return null;
                }
                return response.Content;
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
