using FirmaTakip.Entities;
using FirmaTakip.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.TagHelpers
{
    [HtmlTargetElement("getCategoryName")]
    public class CategoryName:TagHelper
    {
        private readonly ICompanyRepository _companyRepository;

        public CategoryName(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public int CompanyId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
            var comingCategories = _companyRepository.GetCategories(CompanyId).Select(I => I.Name);
            foreach (var item in comingCategories)
            {
                data += item + " ";
            }
            output.Content.SetContent(data);
            base.Process(context, output);  
        }
    }
}
