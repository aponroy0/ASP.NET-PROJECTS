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
    public class CandidateService
    {

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Candidate, CandidateDTO>().ReverseMap();

                // For vote count
                cfg.CreateMap<Candidate, CandidateVoteDTO>().ReverseMap();
                cfg.CreateMap<Voter, CandidateVoteDTO>().ReverseMap();
            });
            return new Mapper(config);
        }



        // Admin adds candidate to a specific election by id 
        public static bool AddCandidiate(int id, CandidateDTO c)
        {
            var single_election = DataAccessFactory.ElectionData().Get(id);

            var newcandidate = new Candidate()
            {
                CandidateName = c.CandidateName,
                Party = c.Party,
                Bio = c.Bio,
                ElectionId = single_election.ElectionId,

            };

            return DataAccessFactory.CandidateData().Create(newcandidate);


        }

        // List candidate using a electionid to speciifically find out how many candidates an election hold
        public static List<CandidateDTO> ListCandidateForAnElection(int id)
        {
            var single_election = DataAccessFactory.ElectionData().Get(id);
            var listOfcandidates = single_election.Candidates.ToList();

            return GetMapper().Map<List<CandidateDTO>>(listOfcandidates);
        }

        public static bool DeleteCandidate(int id_e, int id_c)
        {
            var data = DataAccessFactory.DeleteCandidateData().DeleteCandidate(id_e, id_c);
            return data;
        }


        // This service for showing the vote count
        public static List<CandidateVoteDTO> CandidateVoteCounter (int id)
        {
            var candidateList = DataAccessFactory.CandidateData().Get();
            var candidates = (from c in candidateList where c.ElectionId == id select c).ToList();

            var voterList = DataAccessFactory.VoterData().Get();
            var voters = (from v in voterList where v.ElectionId == id select v).ToList();

            var results = (from candidate in candidates
                           join voter in voters on candidate.CandidateId 
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



            return results;

        }
            


    }
}
