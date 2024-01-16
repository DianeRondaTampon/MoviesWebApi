using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;

namespace MoviesWebApi.Application
{
    public class GetActorById
    {
       
        #region Request
        public class GetActorByIdRequest
        {
            public int Id { get; set; }
        }

        #endregion

        
        #region Response
        public class GetActorByIdResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }

            //constructor
            public GetActorByIdResponse (Actor actor)
            {
                if (actor != null)
                {
                    Id= actor.Id;
                    Name = actor.Name;
                }
            }
        }

        #endregion

        
        #region Handler
        public class GetActorByIdHandler
        {
            private readonly ActorRepository _actorRepository;

            public GetActorByIdHandler(ActorRepository actorRepository)
            {
                _actorRepository = actorRepository;
            }

            public GetActorByIdResponse? GetActorByIdCommandHandler(GetActorByIdRequest request)
            {
                Actor? actor = _actorRepository.GetActorById(request.Id);
                //the mapping will be done in the constructor of the response
                if(actor != null)
                {
                    return new GetActorByIdResponse(actor);
                }
                else
                {
                    return null;
                }
                
            }
        }

        #endregion
    }

}
