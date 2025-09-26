using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ElectionSearchService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Election, ElectionDTO>().ReverseMap();

            });
            return new Mapper(config);
        }

        public static List<ElectionDTO> Search(string search)
        {
            var electionList = DataAccessFactory.ElectionData().Get();
            string keyword = search.ToLower();
            var query = (from e in electionList where e.Title.ToLower().Contains(keyword) 
                         || e.Description.ToLower().Contains(keyword) select e).ToList();

            return GetMapper().Map<List<ElectionDTO>>(query); ;
        }
    }
}
