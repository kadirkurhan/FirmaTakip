using FirmaTakip.Contexts;
using FirmaTakip.Entities;
using FirmaTakip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Repositories
{
    public class CompanyRepository: GenericRepository<Company>,ICompanyRepository
    {
        public List<Category> GetCategories(int companyId)
        {
            using var context = new FirmaTakipContext();
            return context.Companies.Join
                (context.CompanyCategories, company
                 => company.CompanyId, companyCategory
                   => companyCategory.CompanyId, (c, cc) => new
                   {
                       company = c,
                       companyCategory = cc
                   }).Join(context.Categories, iki => iki.companyCategory.CategoryId,
                category => category.Id, (cc, c) => new
                {

                    company = cc.company,
                    category = c,
                    companyCategory = cc.companyCategory
                }).Where(I => I.company.CompanyId == companyId)
                .Select(I => new Category{
                
                Name = I.category.Name,
                Id = I.category.Id
                
                }).ToList();


                

        }
    }
}