using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class ElectionService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Election, ElectionDTO>().ReverseMap();
                cfg.CreateMap<Election, ElectionUpdateDTO>().ReverseMap();
             
            });
            return new Mapper(config);
        }

        public static bool Create(ElectionDTO e)
        {
            var election = GetMapper().Map<Election>(e);
            var data = DataAccessFactory.ElectionData().Create(election);
            return data;
        }

        public static List<ElectionDTO> Get()
        {
            var data = DataAccessFactory.ElectionData().Get();
            return GetMapper().Map<List<ElectionDTO>>(data);
        }
        public static ElectionDTO GetById(int id)
        {
            var data = DataAccessFactory.ElectionData().Get(id);
            return GetMapper().Map<ElectionDTO>(data);
        }

        public static bool Update(ElectionUpdateDTO e)
        {
            var election = GetMapper().Map<Election>(e);
            return DataAccessFactory.ElectionData().Update(election);
        }
        public static bool Delete(int id)
        {
            var data = DataAccessFactory.ElectionData().DeleteCandidateData(id);
            return data;
        }


        
    }
}
