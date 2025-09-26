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
    public class UserService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<User, LoginDTO>().ReverseMap();
                cfg.CreateMap<Voter, VoteDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        // I have received a user obj from the application layer. Then I convert it into user from UserDTO. Finally saved it to
        // user table.
        // This service will work for registering a new user.
        public static bool Create(UserDTO u)
        {
            var user = GetMapper().Map<User>(u);
            var data = DataAccessFactory.UserData().Create(user);
            return data;
        }


        // This service is responsible for checking the login
        public static LoginDTO Login(LoginDTO Log)
        {
            var user = GetMapper().Map<User>(Log);
            var from_db = DataAccessFactory.UserData().Get();

            var logged = (from u in from_db
                          where
                          u.Email.Equals(user.Email) &&
                          u.Password.Equals(user.Password)
                          select u).SingleOrDefault();
            if (logged == null)
                return null;

            // Map User to LoginDTO before returning
            return GetMapper().Map<LoginDTO>(logged);
            
        }


        // For casting a vote from user side.

        public static bool CastVote(int id_u, int id_e, VoteDTO v)
        {
            // Here, we will first check whether the election exists or not.
            // Cause, if the election itself does not exist, then there is no need to go further.
            // After that, we will check whether the election has any userid in the voters list for that specific electionid.
            // That checking will ensure whether that user casted any vote before or not.

            var election = DataAccessFactory.ElectionData().Get(id_e);

            if(election != null)
            {
                var listOfvoters = DataAccessFactory.VoterData().Get();
                var has_casted_vote = (from voter in listOfvoters 
                                       where voter.ElectionId == election.ElectionId 
                                       && voter.UserId == id_u 
                                       select v).SingleOrDefault();
                
                if(has_casted_vote == null)
                {
                    var newVoter = new Voter()
                    {
                        UserId = id_u,
                        CandidateId = v.CandidateId,
                        ElectionId = election.ElectionId,

                    };
                    var cast_newVote = DataAccessFactory.VoterData().Create(newVoter);
                    return cast_newVote;

                }
                else
                {
                    return false;
                }

            }
            return false;


        }

    }
}
