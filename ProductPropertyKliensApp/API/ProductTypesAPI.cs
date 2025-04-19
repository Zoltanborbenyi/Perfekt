using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Catalog;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProductPropertyKliensApp.API
{
    internal class ProductTypesAPI
    {

        public List<ProductTypeDTO> getAllProductType(Api proxy)
        {
            try
            {
                ApiResponse<List<ProductTypeDTO>> response = proxy.ProductTypesFindAll();
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(
                        msg,
                        "API hiba",
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

        public Boolean createProductType(Api proxy, ProductTypeDTO newType)
        {
            try
            {
                ApiResponse<ProductTypeDTO> response = proxy.ProductTypesCreate(newType);
                if (response.Errors.Any())
                {
                    newType.StoreId = 1;
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(
                        msg,
                        "API hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }

        public Boolean deleteProductType(Api proxy, String typeId)
        {
            try
            {
                ApiResponse<bool> response = proxy.ProductTypesDelete(typeId);
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(
                        msg,
                        "API hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
                if (!response.Content)
                {
                    MessageBox.Show(
                        "Nem sikerült a törlés",
                        "Hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }

        public Boolean linkProductTypeToProperty(Api proxy, String typeId, long proptertyId)
        {
            try
            {
                int sortOrder = 0;
                ApiResponse<bool> response = proxy.ProductTypesAddProperty(typeId, proptertyId, sortOrder);
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(
                        msg,
                        "API hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
                if (!response.Content) {
                    MessageBox.Show(
                        "Nem létezik, ilyen típus vagy tulajdonság, esetleg már létezik a kapcsolat!",
                        "Hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }

        public Boolean deleteLinkProductTypeToProperty(Api proxy, String typeId, long proptertyId)
        {
            try
            {
                ApiResponse<bool> response = proxy.ProductTypesRemoveProperty(typeId, proptertyId);
                if (response.Errors.Any())
                {
                    var msg = string.Join(Environment.NewLine, response.Errors.Select(e => e.Description));
                    MessageBox.Show(
                        msg,
                        "API hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
                if (!response.Content)
                {
                    MessageBox.Show(
                        "Nem siikerült a kopcsolat törlése, meglehet nem voltak eddig kapcsolatba",
                        "Hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Hiba történt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }
    }
}
