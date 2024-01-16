using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using static MoviesWebApi.Application.GetActorById;

namespace MoviesWebApi.Application
{
    public class GetAllActors
    {
        
        #region Request

        public class GetAllActorsRequest
        {

        }

        #endregion

        
        #region Response

        public class GetAllActorsResponse
        {
            public int Id { get; set; }

            public string Name { get; set; }

            //constructor 

            public GetAllActorsResponse(Actor actor)
            {
                Id = actor.Id;
                Name = actor.Name;
            }

        }
        #endregion

        
        #region Handler

        public class GetAllActorsHandler
        {
            private readonly ActorRepository _actorRepository;

            public GetAllActorsHandler(ActorRepository actorRepository) 
            {
                _actorRepository = actorRepository;
            }

            public List<GetAllActorsResponse> GetAllActorsCommandHandler (GetAllActorsRequest request)
            {
                
                List<Actor> actors = _actorRepository.GetAllActor();
                //the mapping will be done in the constructor of the response
                return actors.Select(actor => new GetAllActorsResponse(actor)).ToList();
            }

        }
        #endregion
    }
}
