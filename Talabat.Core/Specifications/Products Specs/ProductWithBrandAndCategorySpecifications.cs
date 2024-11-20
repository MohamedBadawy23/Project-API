using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.Products_Specs
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {

        // This Constructor Will Be Used For Creating Object for Get All Products
        public ProductWithBrandAndCategorySpecifications(ProductSpecParams productSpec) // null 1
            : base(P =>
                  (string.IsNullOrEmpty(productSpec.Search) ||  P.Name.ToLower().Contains(productSpec.Search))&&
                  (!productSpec.BrandId.HasValue || P.ProductBrandId == productSpec.BrandId) &&
                  (!productSpec.TypeId.HasValue || P.ProductTypeId == productSpec.TypeId)
                  )
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);

            if (!string.IsNullOrEmpty(productSpec.Sort))
            {
                switch (productSpec.Sort)
                {
                    case "priceAsc":
                        //OrderBy = P => P.Price;
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        //OrderByDesc = P => P.Price;
                        AddOrderByDesc(P => P.Price);
                        break;
                    default:
                        //OrderBy = P => P.Name;
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
            else
            {
                //OrderBy = P => P.Name;
                AddOrderBy(P => P.Name);
            }

            // 1000
            // PageIndex = 9
            // PageSize = 50

            ApplyPagination(productSpec.PageSize * (productSpec.PageIndex - 1),productSpec.PageSize);

        }

        public ProductWithBrandAndCategorySpecifications(int id) : base(P => P.Id == id)
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
        }

    }
}
