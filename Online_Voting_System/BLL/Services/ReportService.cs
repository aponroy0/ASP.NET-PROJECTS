using AutoMapper;
using AutoMapper.Configuration.Annotations;
using BLL.DTO;
using DAL;
using DAL.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService
    {

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Candidate, ReportDTO>().ReverseMap();
                cfg.CreateMap<Voter, ReportDTO>().ReverseMap();
                cfg.CreateMap<User, ReportDTO>().ReverseMap();
                cfg.CreateMap<Election, ReportDTO>().ReverseMap();


                cfg.CreateMap<Candidate, CandidateVoteDTO>().ReverseMap();
                cfg.CreateMap<Voter, CandidateVoteDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static ReportDTO Report(int id)
        {
            var election = DataAccessFactory.ElectionData().Get(id);
            var totalVoter = DataAccessFactory.UserData().Get().Count();
            var voterList = DataAccessFactory.VoterData().Get();

            var totalVoted = (from vo in voterList where vo.ElectionId == id select vo).Count();

            var candidateList = DataAccessFactory.CandidateData().Get();
            var candidates = (from c in candidateList where c.ElectionId  == id select c).ToList();

            var totalVotePercentage = Math.Round(((double)totalVoted / totalVoter) * 100, 2)+ "  %";




            var results = (from candidate in candidates
                           join voter in voterList on candidate.CandidateId
                           equals voter.CandidateId into g
                           select new CandidateVoteDTO
                           {
                               CandidateId = candidate.CandidateId,
                               CandidateName = candidate.CandidateName,
                               Party = candidate.Party,
                               Bio = candidate.Bio,
                               ElectionId = id,
                               VoteCount = g.Count()
                           }).ToList();


            //Candidates with voter count

            var reportChart = new ReportDTO
            {
                ElectionId = id,
                Title = election.Title,
                TotalVoters = totalVoter,
                TotalVoted = totalVoted,
                TotalVotePercentage = totalVotePercentage,
                Candidates = results
            };


           return GetMapper().Map<ReportDTO>(reportChart); 
            
        }
    }
}
