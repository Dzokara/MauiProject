using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIspitniProjekat.Business.DTO
{
    public class JobDto
    {
        public int Id { get; set; }
        public PositionDto Position { get; set; }
        public CompanyDto Company { get; set; }
        public List<TechnologyDto> Technologies { get; set; }
        public RegionDto Region { get; set; }
        public TypeDto Type { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public List<BenefitDto> Benefits { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public DateTime Deadline { get; set; }
        public RemoteDto Remote { get; set; }
    }

    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class TechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RegionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BenefitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RemoteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
